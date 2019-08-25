using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameplayState
{
    Transition,
    Washing,
    Fighting,
    Pause

}

public enum StateTransitionDirection
{
    WashingToFighting,
    WashingToPause,
    PauseToWashing,
    FightingToWashing,
    FightingToPause,
    PauseToFighting

}
public class GameplayFSMManager : MonoBehaviour
{
    
    /// <summary>
    /// Declaration of dynamic variables for surving the logic goes here.
    /// Eg.
    ///     public int chasingRange;
    ///     public int shootingRange;
    ///     public int alertRange;
    /// </summary>


    Stack<IGameplayState> stateStack = new Stack<IGameplayState>();

    /// <summary>
    /// Declaration of states Instances goes here.
    /// </summary>
    [HideInInspector]
    public WashingState washingState;
    [HideInInspector]
    public FightingState fightingState;
    [HideInInspector]
    public StateTransition stateTransition;
    //public TrainingState trainingState;
    //[HideInInspector]
    //public TutorialState tutorialState;
    [HideInInspector]
    public PauseState pauseState;
    [HideInInspector]
    public IGameplayState tempFromPause;

    [HideInInspector]
    public StateTransitionDirection transitionDirection;

    /// <summary>
    /// Declaration of references will be used for the states logic goes here
    /// Eg. 
    ///     public ISteer steeringScript;
    ///     public GameObject pathRoute;
    ///     public Queue<GameObject> enemyQueue = new Queue<GameObject>();
    /// 
    /// </summary>
    private void Start()
    {
        /// <summary>
        /// Instantiation of states Instances goes here.
        /// Eg.
        /// chaseEnemy = new ChaseState()
        ///        {
        ///     chasingRange = this.chasingRange,
        ///     shootingRange = this.shootingRange,
        ///     alertRange = this.alertRange,
        ///     movementController = this
        ///         };
        /// </summary>

        ////Instantiate the first state
        fightingState = new FightingState()
        {
            gameplayFSMManager = this
        };
        stateTransition = new StateTransition()
        {
            gameplayFSMManager = this
        };
        washingState = new WashingState()
        {
            gameplayFSMManager = this
        };
        PushState(fightingState);
    }

    // Update is called once per frame
    void Update()
    {
        stateStack.Peek().OnStateUpdate();
    }

    public void PopState()
    {
        stateStack.Pop().OnStateExit();
    }
    public void PushState(IGameplayState newState)
    {
        newState.OnStateEnter();
        stateStack.Push(newState);
    }

    /// <summary>
    /// States relative logic goes here.
    /// This logic will be used from inside each state itself.
    /// </summary>    
    public void DetermineStateTransationDirection(IGameplayState nextState)
    {
        switch (stateStack.Peek().GetStateName())
        {
            case GameplayState.Washing:
                switch (nextState.GetStateName())
                {
                    case GameplayState.Fighting:
                        transitionDirection = StateTransitionDirection.WashingToFighting;
                        break;
                    case GameplayState.Pause:
                        transitionDirection = StateTransitionDirection.WashingToPause;
                        break;
                    default:
                        break;
                }
                break;
            case GameplayState.Fighting:
                switch (nextState.GetStateName())
                {
                    case GameplayState.Washing:
                        transitionDirection = StateTransitionDirection.FightingToWashing;
                        break;
                    case GameplayState.Pause:
                        transitionDirection = StateTransitionDirection.FightingToPause;
                        break;
                    default:
                        break;
                }
                break;
            case GameplayState.Pause:
                switch (nextState.GetStateName())
                {
                    case GameplayState.Washing:
                        transitionDirection = StateTransitionDirection.PauseToWashing;
                        break;
                    case GameplayState.Fighting:
                        transitionDirection = StateTransitionDirection.PauseToFighting;
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
    }
    public void ChangeToWashing()
    {
        DetermineStateTransationDirection(washingState);
        PopState();
        PushState(stateTransition);
    }
    public void ChangeToFighting()
    {
        DetermineStateTransationDirection(fightingState);
        PopState();
        PushState(stateTransition);

    }
    public void ChangeToPause()
    {
        DetermineStateTransationDirection(pauseState);
        PopState();
        PushState(stateTransition);

    }
    public void pauseGame()
    {
        if (tempFromPause == null)
        {
            tempFromPause = stateStack.Peek();
            PopState();
            PushState(pauseState);
        }

    }
    public void resumeGame()
    {
        if (tempFromPause != null)
        {
            PopState();
            PushState(tempFromPause);
            tempFromPause = null;
        }
    }

    public GameplayState getCurrentState()
    {
        return stateStack.Peek().GetStateName();
    }

}
