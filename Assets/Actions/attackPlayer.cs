using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using UnityEngine.UIElements;

[System.Serializable]
public class AttackPlayer : ActionNode
{
    public NodeProperty<GameObject> playerGameObject, selfGameObject;
    private Animator anim;
    
    protected override void OnStart()
    {
        anim = selfGameObject.Value.GetComponent<Animator>();
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        anim.SetBool("attack", true);
        return State.Success;
    }

}
