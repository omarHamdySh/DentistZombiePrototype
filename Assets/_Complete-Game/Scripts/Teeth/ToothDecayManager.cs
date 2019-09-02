using CompleteProject;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToothDecayManager : MonoBehaviour
{
    Renderer thisToothRenderer;
    PlayerHealth playerHealth;
    static int TeethHited = 0;

    public bool toothIsBeingWashed;
    public List<Material> toothMaterials;
    int indexOfMaterial;

    //ToothWashinTimer
    float washingSecondsTimer;
    public int washingSpeed;

    //Variables for test and must be removed later on.
    public bool testingBrushes;
    public TextMeshProUGUI testText;
    private void Start()
    {
        thisToothRenderer = GetComponent<Renderer>();
        playerHealth = GetComponent<PlayerHealth>();


        if (testingBrushes)
        {
            thisToothRenderer.material = toothMaterials[Random.Range(1, 5)];
            testText.text = "Is not Washing";

        }
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
            GameManager.Instance.DirtyTeeth.Add(this.gameObject);
            Destroy(collision.gameObject);                          //Destroy the enemy game object that has collided with the tooth.
            TeethHited++;
            GameManager.Instance.ScoreToWash++;
        }

    }
    private void OnCollisionStay(Collision collision)
    {

    }

    private void OnCollisionExit(Collision collision)
    {
        testText.text = "Is not washing";

        if (collision.gameObject.tag == "ToothPaste")
        {
            toothIsBeingWashed = false;
        }
    }
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
        if (toothIsBeingWashed)
        {
            washingSecondsTimer += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ToothPaste")
        {
            testText.text = "Is Washing";
            if (washingSecondsTimer >= (washingSpeed))
            {
                int nextMatIndex = --indexOfMaterial;
                if (nextMatIndex <= 0)
                {
                    nextMatIndex = 0;
                    GameManager.Instance.DirtyTeeth.Remove(this.gameObject);
                }
                thisToothRenderer.material = toothMaterials[nextMatIndex];

            }
            toothIsBeingWashed = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "ToothPaste")
        {
            testText.text = "Is Washing";
            toothIsBeingWashed = true;
            if (washingSecondsTimer >= ( washingSpeed))
            {
                int nextMatIndex = --indexOfMaterial;
                if (nextMatIndex <= 0)
                {
                    nextMatIndex = 0;
                    GameManager.Instance.DirtyTeeth.Remove(this.gameObject);
                }
                thisToothRenderer.material = toothMaterials[nextMatIndex];

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ToothPaste")
        {
            testText.text = "Is not Washing";
            toothIsBeingWashed = false;
            washingSecondsTimer = 0;
        }
    }

}
