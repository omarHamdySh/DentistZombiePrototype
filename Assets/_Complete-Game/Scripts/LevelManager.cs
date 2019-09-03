﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CompleteProject;
public class LevelManager : MonoBehaviour
{

    public List<CompleteProject.EnemyManager> enemyManagerScripts;
    [HideInInspector]
    public int enemySpeed = 5;
    public int level1EnemySpeed;
    public int level2EnemySpeed;
    public int level3EnemySpeed;
    [Range(1, 0.7f)]
    public float multiplySpwanTime;

    private static LevelManager _Instance;

    public static LevelManager Instance
    {
        get { return _Instance; }
    }
    private void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public void incrementEnemySpwanTime()
    {
        foreach (var item in enemyManagerScripts)
        {
            item.spawnTime *= multiplySpwanTime;
        }
    }
}
