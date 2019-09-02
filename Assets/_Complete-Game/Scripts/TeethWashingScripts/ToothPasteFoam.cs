using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothPasteFoam : MonoBehaviour
{
    ParticleSystem myParticleSystem;
    ToothDecayManager myToothDecayScript;
    // Start is called before the first frame update
    void Start()
    {
        myParticleSystem = GetComponent<ParticleSystem>();
        myToothDecayScript = GetComponent<ToothDecayManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ToothPaste" && myToothDecayScript.toothIsBeingWashed)
        {
            myParticleSystem.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "ToothPaste" && myToothDecayScript.toothIsBeingWashed)
        {
            myParticleSystem.Play();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ToothPaste" && myToothDecayScript.toothIsBeingWashed)
        {
            myParticleSystem.Pause();
            StartCoroutine("removeParticlesAfterAWhile");
        }
    }

    IEnumerator removeParticlesAfterAWhile() {
        yield return new WaitForSeconds(5);
        myParticleSystem.Stop();
    }
}
