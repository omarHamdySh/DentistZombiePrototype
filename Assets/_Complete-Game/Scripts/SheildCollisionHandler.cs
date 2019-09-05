using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheildCollisionHandler : MonoBehaviour
{
    public static int sheildPowerCounts = 5;
    public static int sheildHitsCounter;
    public List<SheildCollisionHandler> sheilds;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            ++sheildHitsCounter;

            if (sheildHitsCounter >= sheildPowerCounts)
            {
                GameManager.Instance.OnSheildDeactivation.Raise();
                foreach (var item in sheilds)
                {
                    if (item != this)
                    {
                        item.gameObject.SetActive(false);
                    }
                }
                sheildHitsCounter = 0;
                ToothDecayManager.isSheildActivated = false;
                this.gameObject.SetActive(false);
                TutorialManager.Instance.playThisSequence(TutorialEvent.SheildDestraction);
            }
        }
    }
}
