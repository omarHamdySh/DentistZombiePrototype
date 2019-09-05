using CompleteProject;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToothDecayManager : MonoBehaviour
{
    
    public static ToothDecayManager instance;
    Renderer thisToothRenderer;
    PlayerHealth playerHealth;
    static int TeethHited = 0;

    public bool toothIsBeingWashed;
    public List<Material> toothMaterials;
    int indexOfMaterial;

    //ToothWashinTimer
    float washingSecondsTimer;
    public int washingSpeed;

    //When the sheild is activated don't consider the enemy attacks.
    public static bool isSheildActivated;

    //Variables for test and must be removed later on.
    public bool testingBrushes;
    public TextMeshProUGUI testText;
    bool isHittedFlag = true;
    private void Start()
    {
        instance = GetComponent<ToothDecayManager>();
        thisToothRenderer = GetComponent<Renderer>();
        playerHealth = GetComponent<PlayerHealth>();


        if (testingBrushes)
        {
            thisToothRenderer.material = toothMaterials[Random.Range(1, 5)];
            GameManager.Instance.DirtyTeeth.Add(this.gameObject);
            if (testText)
            {
                testText.text = "Is not Washing";
            }

        }
        else
        {
            indexOfMaterial = 1;
            thisToothRenderer.material = toothMaterials[indexOfMaterial];
            GameManager.Instance.DirtyTeeth.Add(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "Enemy")
        //{
        //    int nextMatIndex = toothMaterials.IndexOf(thisToothRenderer.material) < (toothMaterials.Count - 1) ? toothMaterials.IndexOf(thisToothRenderer.material) + 1 : (toothMaterials.Count - 1);

        //    thisToothRenderer.material = toothMaterials[nextMatIndex];
        //}
        if (isSheildActivated)
        {
            return;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            //int nextMatIndex = toothMaterials.IndexOf(thisToothRenderer.material) < (toothMaterials.Count - 1) ? toothMaterials.IndexOf(thisToothRenderer.material) + 1 : (toothMaterials.Count - 1);

            int nextMatIndex = ++indexOfMaterial;
            if (nextMatIndex > (toothMaterials.Count - 1))
                nextMatIndex = (toothMaterials.Count - 1);

            thisToothRenderer.material = toothMaterials[nextMatIndex];
            if (isHittedFlag)
            {
                GameManager.Instance.DirtyTeeth.Add(this.gameObject);
                isHittedFlag = false;
            }

            collision.gameObject.GetComponent<CompleteProject.EnemyHealth>()
                .killTheEnemy();                       //Destroy the enemy game object that has collided with the tooth.
            TeethHited++;
            GameManager.Instance.maximumEnemyHits++;

        }

    }
    private void OnCollisionStay(Collision collision)
    {

    }

    private void OnCollisionExit(Collision collision)
    {
        if (testText)
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
            GameManager.Instance.toothPasteGameObjct.GetComponent<MeshRenderer>().enabled = false;
            GameManager.Instance.toothEffect.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "ToothPaste")
        {
            if (testText)
                testText.text = "Is Washing";
            toothIsBeingWashed = true;
            if (washingSecondsTimer >= (washingSpeed))
            {
                //int nextMatIndex = --indexOfMaterial;
                //if (nextMatIndex <= 0)
                //{
                //nextMatIndex = 0;
                //GameManager.Instance.DirtyTeeth.Remove(this.gameObject);
                //}
                CleaningTooth();

            }
        }
    }

    private void CleaningTooth()
    {
        //foreach (var item in GameManager.Instance.DirtyTeeth)
        //{
        //    if (item != this.gameObject)
        //    {
        //        var rend = item.GetComponent<Renderer>();
        //        rend.material = toothMaterials[0];
        //        GameManager.Instance.DirtyTeeth.Remove(item);
        //    }
        //}
        thisToothRenderer.material = toothMaterials[0];
        isHittedFlag = true;
        GameManager.Instance.DirtyTeeth.Remove(this.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ToothPaste")
        {
            if (testText)
                testText.text = "Is not Washing";
            toothIsBeingWashed = false;
            washingSecondsTimer = 0;
        }
    }

    public void OnSheildActivation()
    {
        //print("sheild is activated");
        //isSheildActivated = true;
    }
    public void OnSheildDeactivation()
    {
        //print("sheild is disactivated");
        //isSheildActivated = false;
    }
}
