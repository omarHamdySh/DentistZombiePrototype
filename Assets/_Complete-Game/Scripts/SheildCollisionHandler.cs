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

            if (sheildHitsCounter == 3)
            {
                TutorialManager.Instance.playThisSequence(TutorialEvent.WhenInjured);
            }
            else
            {
                TutorialManager.Instance.playThisSequence(TutorialEvent.Attention);
            }

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
            
            //Kill the enemy here 
            collision.gameObject.GetComponent<CompleteProject.EnemyHealth>().killTheEnemy();
        }
    }
}
