using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using TMPro;
using UnityEngine.UI;
using UnityEngine.AI;
using CompleteProject;

public enum GameLevel
{
    level0,
    Level1,
    Level2,
    Level3
}
public class GameManager : MonoBehaviour
{

    GameLevel currentLevel;
    private static GameManager _Instance;                               //reference for this script to access it from another place to manage/control his variables and function
    public VRTK_ControllerEvents controllerEvent;                       //reference for controller events script on controller gameobject           
    public GameplayFSMManager gameplayFSMManager;                       //reference for the state machine controller to access his state
    public List<GameObject> enemyObjects = new List<GameObject>();      //variable to store the enemy gameobjects to control it while pausing the scene and other functionality 
    public List<GameObject> DirtyTeeth = new List<GameObject>();        //variable for the hited teeth by bacteria
    public List<GameObject> fightingTools;                              //refernce for the fighting tools as gun,.....
    public List<GameObject> washingTools;                               //reference for the washing tool as toothpaste,toothbrush,...
    public GameObject enemySpawingPointManager;                         //refernce for the spawing point controller which generating enemy in the scene
    [HideInInspector]
    public int maximumEnemyHits = 0;                                         //the score which use for translte the state from the fighting to washing
    public PlayerScoreManager playerScoreManager;                       //reference for the text of the player score to update the ui
    [HideInInspector]
    public int enemykilledScore = 0;                                    //the score which increase when the player hit the enemies

    public TextMeshProUGUI currentLevelInfoLabel;
    public TextMeshProUGUI speedEnemyInfoLabel;

    public ParticleSystem toothEffect;
    public GameObject toothPasteGameObjct;

    public GameEvent OnWashingFinish;
    public GameEvent OnSheildActivation;
    public GameEvent OnSheildDeactivation;

    private void Update()
    {
        // If the current health is less than or equal to zero...
        if (maximumEnemyHits >= 10)
        {
            maximumEnemyHits = 0;
            gameplayFSMManager.ChangeToWashing();
        }
    }
    public static GameManager Instance
    {
        get { return _Instance; }
    }
    private void Awake()
    {
        /** Order of methods calling is critical**/
        if (_Instance == null)
        {
            _Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

        controllerEvent.TriggerPressed += new ControllerInteractionEventHandler(doTriggerPressed);
    }
    private void Start()
    {
        currentLevel = GameLevel.level0;
    }

    /// <summary>
    /// functions for controlling the player tools in the gameplay
    /// </summary>
    public void enableFightingTools()
    {
        foreach (var item in fightingTools)
        {
            item.gameObject.SetActive(true);
        }

    }
    public void disableFightingTools()
    {
        foreach (var item in fightingTools)
        {
            item.gameObject.SetActive(false);
        }
    }
    public void enableWashingTools()
    {
        foreach (var item in washingTools)
        {
            item.gameObject.SetActive(true);
        }
    }
    public void disableWashingTools()
    {
        foreach (var item in washingTools)
        {
            item.gameObject.SetActive(false);
        }
    }

    ///<summary>
    ///function that define the controller event by the trigger button for toothpaste
    /// </summary>
    private void doTriggerPressed(object sender, ControllerInteractionEventArgs e)
    {
        ////generate the toothpaste
        //toothPasteParticle.Play();
    }

    /// <summary>
    /// function to pause the scene and all the live scripts in the scene
    /// </summary>
    public void PauseGame()
    {
        MonoBehaviour[] list = enemySpawingPointManager.GetComponents<MonoBehaviour>();
        foreach (var item in list)
        {
            item.enabled = false;
        }
        foreach (var item in enemyObjects)
        {
            if (item != null)
            {
                item.GetComponent<Animator>().enabled = false;
                item.GetComponent<NavMeshAgent>().enabled = false;
            }
        }
        #region --deperacted Code
        ///
        /// this code make all scene the scene stop and also the controller functionality
        /// Time.timeScale = 0;
        ///
        #endregion
    }
    /// <summary>
    /// /// <summary>
    /// function to resume the scene and all the live scripts in the scene
    /// </summary>
    /// </summary>
    public void ResumeGame()
    {
        MonoBehaviour[] list = enemySpawingPointManager.GetComponents<MonoBehaviour>();
        foreach (var item in list)
        {
            item.enabled = true;
        }
        foreach (var item in enemyObjects)
        {
            if (item != null)
            {
                item.GetComponent<Animator>().enabled = true;
                item.GetComponent<NavMeshAgent>().enabled = true;
            }
        }
        #region --deperacted Code
        ///
        /// this code make all scene the scene stop and also the controller functionality
        /// Time.timeScale = 1;
        ///
        #endregion
    }

    public void declareWashingProcessEnd()
    {
        print("Washing process has ended");
        ToothDecayManager.isSheildActivated = true;
        OnWashingFinish.Raise();
        OnSheildActivation.Raise();
    }
    /// <summary>
    /// this methods returns the index of specific level in the enum
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    public int GetLevelIndex(GameLevel level)
    {
        var states = Enum.GetValues(typeof(GameLevel));
        foreach (var item in states)
        {
            if ((GameLevel)item == level)
            {
                return (int)item;
            }
        }
        return -1;
    }
    public void MoveToTheNextLevel()
    {
        currentLevel = (GameLevel)GetLevelIndex(currentLevel) + 1;
        LevelManager.Instance.incrementEnemySpwanTime();

        if (currentLevelInfoLabel)
            currentLevelInfoLabel.text = currentLevel.ToString();

        switch (currentLevel)
        {
            case GameLevel.Level1:
                LevelManager.Instance.enemySpeed = LevelManager.Instance.level1EnemySpeed;

                break;
            case GameLevel.Level2:
                LevelManager.Instance.enemySpeed = LevelManager.Instance.level2EnemySpeed;
                break;
            case GameLevel.Level3:
                LevelManager.Instance.enemySpeed = LevelManager.Instance.level3EnemySpeed;
                break;
            default:
                break;
        }
        if (speedEnemyInfoLabel)
            speedEnemyInfoLabel.text = LevelManager.Instance.enemySpeed.ToString();
    }
}
