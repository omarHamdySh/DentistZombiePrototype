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
    FightingToWashing
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
    public WashingState tycoonState;
    [HideInInspector]
    public FightingState cutsceneState;
    [HideInInspector]
    public StateTransition missionState;
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

        ////Instantiate the first stat
        //cutsceneState = new CutsceneState()
        //{
        //    gameplayFSMManager = this
        //};
        //tycoonState = new TycoonState()
        //{
        //    gameplayFSMManager = this
        //};
        //missionState = new MissionState()
        //{
        //    gameplayFSMManager = this
        //};
        //trainingState = new TrainingState()
        //{
        //    gameplayFSMManager = this
        //};
        //tutorialState = new TutorialState()
        //{
        //    gameplayFSMManager = this
        //};
        //pauseState = new PauseState()
        //{
        //    gameplayFSMManager = this
        //};
        //PushState(tycoonState);
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


    //public void changeToTycoonState()
    //{
    //    PopState();
    //    PushState(tycoonState);
    //}
    //public void changeToCutSceneState()
    //{
    //    PopState();
    //    PushState(cutsceneState);
    //}
    //public void changeToMissionState()
    //{
    //    PopState();
    //    PushState(missionState);
    //}
    //public void changeToTrainingState()
    //{
    //    PopState();
    //    PushState(trainingState);
    //}
    //public void changeToTutorialState()
    //{
    //    PopState();
    //    PushState(tutorialState);
    //}
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
