using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class chasePlayer : ActionNode
{
    public NodeProperty<GameObject> selfGameObject, playerGameObject;
    private Transform myTransform, playerTransform;
    private float speed = 0.6f;

    private Vector3 direction;
    protected override void OnStart()
    {
        myTransform = selfGameObject.Value.transform;
        playerTransform = playerGameObject.Value.transform;
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        if (direction.magnitude > 0.7f)
        {
            ChasePlayer();

        }

        return State.Success;
    }

    void ChasePlayer()
    {
        direction = playerTransform.position - myTransform.position;
        myTransform.Translate(direction * speed * Time.deltaTime);
        myTransform.LookAt(playerTransform.position);
    }
}
