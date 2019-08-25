using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _Instance;
    public GameplayFSMManager gameplayFSMManager;

    public List<GameObject> enemyObjects = new List<GameObject>();

    public List<GameObject> DirtyTeeth = new List<GameObject>();

    /// <summary>
    /// Define States Varaible
    /// </summary>
    public GameObject enemySpawingPointManager;
    //public GameObject changeToGun;
    //public GameObject chnageToController;
        
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
    }

}
