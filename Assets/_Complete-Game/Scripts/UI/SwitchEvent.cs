using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchEvent : MonoBehaviour
{
   
    bool switchFlag = true;         //a flag to switch from pause to resume and the inverse also
    
    /// <summary>
    /// a functiond to switch the mode from pause mode to resume mode and the opposite 
    /// also passed in the inspectore in interactable gameobject events scipt
    /// </summary>
    public void SwitchMode()
    {
        //reverse the mode
        switchFlag =! switchFlag;
        if (switchFlag)
        {
            //change the text of button
            GameManager.Instance.pauseButtonText.text = "Pause";
            //move to the pause state
            GameManager.Instance.gameplayFSMManager.resumeGame();
        }
        else
        {
            //change the text of button
            GameManager.Instance.pauseButtonText.text = "Resume";
            //move to the pause state
            GameManager.Instance.gameplayFSMManager.pauseGame();
        }
    }
}
