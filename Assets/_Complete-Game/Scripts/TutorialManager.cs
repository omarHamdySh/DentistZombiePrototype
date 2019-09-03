using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{

    public static TutorialManager _Instance;

    //[HideInInspector]
    public List<TutorialEntity> tutorialEntities = new List<TutorialEntity>();
    private Queue<TutorialEntity> EntitiesQueue = new Queue<TutorialEntity>();
    public AnimationFSM avatarAnimationFSM;
    public TextTypingAnimation textTypingAnimator;

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
        foreach (var item in tutorialEntities)
        {
            EntitiesQueue.Enqueue(item.gameObject.GetComponent<TutorialEntity>());
        }
    }

    public void PlayNextSequence() {
        EntitiesQueue.Dequeue().playSequence();
    }


}
