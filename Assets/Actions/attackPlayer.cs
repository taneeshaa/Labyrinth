using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using UnityEngine.UIElements;

[System.Serializable]
public class attackPlayer : ActionNode
{
    public NodeProperty<GameObject> playerGameObject, selfGameObject;
    private Transform myTransform, playerTransform;
    private Animator anim;
    private Vector3 distance;
    
    protected override void OnStart()
    {
        anim = selfGameObject.Value.GetComponent<Animator>();
        myTransform = selfGameObject.Value.transform;
        playerTransform = playerGameObject.Value.transform;
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        calculateDistance();
        if(distance.magnitude > 0.2f)
        {
            anim.SetTrigger("attack");
        }
        return State.Success;
    }

    void calculateDistance()
    {
        distance = playerTransform.position - myTransform.position;
    }
}
