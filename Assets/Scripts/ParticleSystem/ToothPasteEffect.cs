using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothPasteEffect : MonoBehaviour
{
    public GameObject toothPaste;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ToothPaste")
            toothPaste.SetActive(true);
    }
}
