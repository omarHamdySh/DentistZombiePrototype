using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class SwitchEvent : MonoBehaviour
{

    bool switchFlag = true;         //a flag to switch from pause to resume and the inverse also
    public Text pauseButtonText;    //reference for text field of the button of pause to switch the mode from pause to resume and the opposite also   
    public VideoPlayer video;
    public bool isIntro;
    /// <summary>
    /// a functiond to switch the mode from pause mode to resume mode and the opposite 
    /// also passed in the inspectore in interactable gameobject events scipt
    /// </summary>
    public void SwitchMode()
    {
        //reverse the mode
        switchFlag = !switchFlag;
        if (switchFlag)
        {
            //change the text of button
            pauseButtonText.text = "Pause";
            //move to the pause state
            GameManager.Instance.gameplayFSMManager.resumeGame();
        }
        else
        {
            //change the text of button
            pauseButtonText.text = "Resume";
            //move to the pause state
            GameManager.Instance.gameplayFSMManager.pauseGame();
        }
    }

    public void StartGame()
    {
        //GameManager.Instance.gameplayFSMManager.ChangeToWashing();
        if (!isIntro)
        {
            video.Play();
            TutorialManager.Instance.PlayNextSequence();
            isIntro = true;
        }

    }
}
