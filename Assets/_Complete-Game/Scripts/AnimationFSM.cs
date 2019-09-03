using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AnimationState
{
    Idle,
    Waving,
    Attention,
    Talking,
    Talking01,
    Talking02,
    clipping,
}
public class AnimationFSM : MonoBehaviour
{
    public AnimationState currentAnimationState;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentAnimationState = AnimationState.Idle;
        animator = GetComponent<Animator>();
    }

    public void updateCurrentState(AnimationState newAnimationState)
    {
        this.currentAnimationState = newAnimationState;
    }

    // Update is called once per frame


    public void activateThisAnimationStateState(AnimationState animationState)
    {
        updateCurrentState(animationState);
        var states = Enum.GetValues(typeof(AnimationState));
        foreach (int stateNumber in states)
        {

            if ((AnimationState)stateNumber == animationState)
            {
                animator.SetBool(animationState.ToString(), true);
                this.currentAnimationState = animationState;
            }
            else
            {
                animator.SetBool(((AnimationState)stateNumber).ToString(), false);
            }
        }
    }


}
