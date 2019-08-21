using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTransition : IGameplayState
{
    GameplayState stateName = GameplayState.Transition;

    /// <summary>
    /// Declaration of dynamic variables for surving the logic goes here.
    /// will be populated here by the GameplayFSMManager itself that will declare this place at the first place.
    /// Eg.
    ///     GameplayFSMManager
    /// </summary>
    public GameplayFSMManager gameplayFSMManager;

    public void OnStateEnter()
    {
        //Change controller to be tooth paste and the brush.
        //Stop all Instatiations script and wait for the last enemy to be killed.
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
       
    }

    public void OnStateUpdate()
    {
        //Follow patroling path route.
        switch (gameplayFSMManager.transitionDirection)
        {
            case StateTransitionDirection.WashingToFighting:
                //if there are any clues for the washing process like some paste on the teeth or some effect is still working don't do anything.
                //else if there is nothing and everything is clean -> change to the intended state.
                break;
            case StateTransitionDirection.FightingToWashing:
                //if there is any enemy alive wait unil he dies.
                //else if there is no enemy alive and everything is clean -> change to the intended state.
                break;
        }
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
