using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : IGameplayState
{
    GameplayState stateName = GameplayState.Pause;
    /// <summary>
    /// Declaration of dynamic variables for surving the logic goes here.
    /// will be populated here by the GameplayFSMManager itself that will declare this place at the first place.
    /// Eg.
    ///     GameplayFSMManager
    /// </summary>
    public GameplayFSMManager gameplayFSMManager;

    public void OnStateEnter()
    {
        //pause the game        
        GameManager.Instance.PauseGame();
    }
    public void OnStateExit()
    {
        /// <summary>
        /// Logic of exiting the state goes here.
        /// Eg.    
        ///     pop the currentstate
        ///     push the next state
        /// other logic related to exiting the this state also goes here
        /// </summary>
        /// 
        //resume the game  
        GameManager.Instance.ResumeGame();
    }

    public void OnStateUpdate()
    {
    }
    string ToString()
    {
        return stateName.ToString();
    }

    public GameplayState GetStateName()
    {
        return stateName;
    }
}
