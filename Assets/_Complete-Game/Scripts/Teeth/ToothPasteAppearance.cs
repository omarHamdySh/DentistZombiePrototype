using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothPasteAppearance : MonoBehaviour
{
    public GameObject toothpasteModel;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "tube")
        {
            toothpasteModel.SetActive(true);
        }
    }
}
