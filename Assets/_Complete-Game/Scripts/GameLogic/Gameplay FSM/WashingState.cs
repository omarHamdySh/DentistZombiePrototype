using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashingState : IGameplayState
{
    GameplayState stateName = GameplayState.Washing;
    /// <summary>
    /// Declaration of dynamic variables for surving the logic goes here.
    /// will be populated here by the GameplayFSMManager itself that will declare this place at the first place.
    /// Eg.
    ///     GameplayFSMManager
    /// </summary>
    public GameplayFSMManager gameplayFSMManager;

    public void OnStateEnter()
    {
        //Turn off the other states' controllers and turn on this state's controller 
        GameManager.Instance.enemySpawingPointManager.SetActive(false);
        GameManager.Instance.enableWashingTools();
        Debug.Log(this.ToString());
    }
    /// <summary>
    /// Logic of exiting the state goes here.
    ///  Eg.
    ///     pop the currentstate
    ///     push the next state
    /// </summary>
    public void OnStateExit()
    {
        /// <summary>
        /// Logic of exiting the state goes here.
        /// Eg.    
        ///     pop the currentstate
        ///     push the next state
        /// other logic related to exiting the this state also goes here
        /// </summary>
        GameManager.Instance.disableWashingTools();

    }

    public void OnStateUpdate()
    {
        //Follow patroling path route.

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
