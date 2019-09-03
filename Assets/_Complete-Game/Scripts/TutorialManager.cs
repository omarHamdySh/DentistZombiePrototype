﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{

    public static TutorialManager _Instance;

    public List<TutorialEntity> tutorialEntities;

    public static TutorialManager Instance
    {
        get { return _Instance; }
    }

    private void Awake()
    {
        if (_Instance == null)
            _Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        foreach (Transform item in transform)
        {
            tutorialEntities.Add(item.gameObject.GetComponent<TutorialEntity>());
        }
    }
}
