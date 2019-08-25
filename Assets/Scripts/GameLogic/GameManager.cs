using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class GameManager : MonoBehaviour
{
    public VRTK_ControllerEvents controllerEvent;
    public ParticleSystem toothPasteParticle;

    private static GameManager _Instance;

    /// <summary>
    /// Define States Varaible
    /// </summary>
    public GameplayFSMManager gameplayFSMManager;

    public List<GameObject> enemyObjects = new List<GameObject>();

    public List<GameObject> DirtyTeeth = new List<GameObject>();

    public List<GameObject> fightingTools;

    public List<GameObject> washingTools;

    public GameObject enemySpawingPointManager;
    [HideInInspector]
    public int ScoreToWash = 0;
    private void Update()
    {
        // If the current health is less than or equal to zero...

        if (ScoreToWash == 10)
        {
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

    private void doTriggerPressed(object sender, ControllerInteractionEventArgs e)
    {
        Debug.Log("TriggerPressed : " + e.buttonPressure);
        toothPasteParticle.Play();
    }
}
