using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using UnityEngine.UIElements;

[System.Serializable]
public class SeeingPlayer : ActionNode
{
    public NodeProperty<GameObject> selfGameObject, playerGameObject;
    private Transform myTransform, playerTransform;

    private EnemySenses sense;
    private float viewRadius = 30f;
    private float viewAngle = 90f;

    protected override void OnStart()
    {
        myTransform = selfGameObject.Value.transform;
        playerTransform = playerGameObject.Value.transform;
        sense = playerGameObject.Value.GetComponent<EnemySenses>();
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {

        Vector3 playerTarget = (playerTransform.position - myTransform.position).normalized;

        float distanceToTarget = Vector3.Distance(myTransform.forward, playerTransform.position);

        if (Vector3.Angle(myTransform.forward, playerTarget) < viewAngle / 2)
        {

            if (distanceToTarget <= viewRadius)
            {
                if (Physics.Raycast(myTransform.position, playerTarget, distanceToTarget, 3) == false)
                {
                    return State.Success;
                }
            }
        }

        return State.Failure;
        
    }
}
