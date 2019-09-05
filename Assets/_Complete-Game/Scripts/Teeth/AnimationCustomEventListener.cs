using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AnimationCustomEventListener : StateMachineBehaviour
{
    public bool DestroyObjOnExit;
    public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateMove(animator, stateInfo, layerIndex);
        DestoryTheEnemy(animator.gameObject);
    }


    private void DestoryTheEnemy(GameObject obj)
    {
        if (DestroyObjOnExit)
            Destroy(obj,0.6f);
    }
}

