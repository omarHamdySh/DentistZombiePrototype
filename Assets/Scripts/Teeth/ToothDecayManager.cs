using CompleteProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothDecayManager : MonoBehaviour
{
    Renderer thisToothRenderer;
    PlayerHealth playerHealth;

    public List<Material> toothMaterials;
    int indexOfMaterial;
    private void Start()
    {
        thisToothRenderer = GetComponent<Renderer>();
        playerHealth = GetComponent<PlayerHealth>();
     
    }
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "Enemy")
        //{
        //    int nextMatIndex = toothMaterials.IndexOf(thisToothRenderer.material) < (toothMaterials.Count - 1) ? toothMaterials.IndexOf(thisToothRenderer.material) + 1 : (toothMaterials.Count - 1);

        //    thisToothRenderer.material = toothMaterials[nextMatIndex];
        //}
        if (collision.gameObject.tag == "Enemy")
        {
            //int nextMatIndex = toothMaterials.IndexOf(thisToothRenderer.material) < (toothMaterials.Count - 1) ? toothMaterials.IndexOf(thisToothRenderer.material) + 1 : (toothMaterials.Count - 1);

            int nextMatIndex = ++indexOfMaterial;
            if (nextMatIndex > (toothMaterials.Count - 1))
                nextMatIndex = (toothMaterials.Count - 1);

            thisToothRenderer.material = toothMaterials[nextMatIndex];
            Destroy(collision.gameObject);
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Enemy")
    //    {
    //        //int nextMatIndex = toothMaterials.IndexOf(thisToothRenderer.material) < (toothMaterials.Count - 1) ? toothMaterials.IndexOf(thisToothRenderer.material) + 1 : (toothMaterials.Count - 1);

    //        int nextMatIndex = toothMaterials.IndexOf(thisToothRenderer.material);
    //        if (nextMatIndex > (toothMaterials.Count - 1))
    //            nextMatIndex = (toothMaterials.Count - 1);

    //        thisToothRenderer.material = toothMaterials[nextMatIndex];
    //        Destroy(other.gameObject);
    //    }
    //}
    private void Update()
    {
        if (playerHealth.currentHealth < 100)
        {
            thisToothRenderer.material = toothMaterials[0];
        }
        else if (playerHealth.currentHealth < 85)
        {
            thisToothRenderer.material = toothMaterials[1];
        }
        else if (playerHealth.currentHealth < 65)
        {
            thisToothRenderer.material = toothMaterials[2];
        }
        else if (playerHealth.currentHealth < 55)
        {
            thisToothRenderer.material = toothMaterials[3];
        }
        else if (playerHealth.currentHealth < 40)
        {
            thisToothRenderer.material = toothMaterials[4];
        }
        else if (playerHealth.currentHealth < 20)
        {
            thisToothRenderer.material = toothMaterials[5];
        }
        else if (playerHealth.currentHealth < 10)
        {
            thisToothRenderer.material = toothMaterials[6];
        }
    }

}
