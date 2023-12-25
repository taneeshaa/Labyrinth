using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class HearingPlayer : ActionNode
{
    public NodeProperty<GameObject> selfGameObject, playerGameObject;
    private Transform myTransform, playerTransform;

    private float hearRadius = 25f;
    protected override void OnStart() {

        myTransform = selfGameObject.Value.transform;
        playerTransform = playerGameObject.Value.transform;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        Vector3 playerTarget = (playerTransform.position - myTransform.position).normalized;

        float distanceToTarget = Vector3.Distance(myTransform.forward, playerTransform.position);

        bool playerNotMakingNoise = playerTransform.gameObject.GetComponent<MovementStateManager>().currentState == 
            playerTransform.gameObject.GetComponent<MovementStateManager>().Idle ||
            playerTransform.gameObject.GetComponent<MovementStateManager>().currentState == playerTransform.gameObject.GetComponent<MovementStateManager>().Crouch;
        if (!playerNotMakingNoise && distanceToTarget < hearRadius)
        {
            return State.Success;
        }
        else
        {
            return State.Failure;
        }
    }
}
