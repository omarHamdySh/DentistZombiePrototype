using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingState : IGameplayState
{
    GameplayState stateName = GameplayState.Fighting;
    /// <summary>
    /// Declaration of dynamic variables for surving the logic goes here.
    /// will be populated here by the GameplayFSMManager itself that will declare this place at the first place.
    /// Eg.
    ///     GameplayFSMManager
    /// </summary>
    public GameplayFSMManager gameplayFSMManager;

    public void OnStateEnter()
    {
        //Enable the spawning scripts of the enemies;
        //Turn off the other states' controllers and turn on this state's controller
        GameManager.Instance.enemySpawingPointManager.SetActive(true);
        GameManager.Instance.enableFightingTools();
        Debug.Log(this.ToString());
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

        //Disable the spawning scripts of the enemies;
        GameManager.Instance.enemySpawingPointManager.SetActive(false);
        GameManager.Instance.disableFightingTools();
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
