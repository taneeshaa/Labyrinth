using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using TMPro;

[System.Serializable]
public class chasePlayer : ActionNode
{
    public NodeProperty<GameObject> selfGameObject, playerGameObject;
    private Transform myTransform, playerTransform;
    private float speed = 0.6f;
    private Rigidbody rb;

    private Vector3 playerGroundedTransform;

    private Vector3 direction;

    private float rotationSpeed = 5f;
    protected override void OnStart()
    {
        myTransform = selfGameObject.Value.transform;
        playerTransform = playerGameObject.Value.transform;
        direction = playerTransform.position - myTransform.position;
        rb = selfGameObject.Value.GetComponent<Rigidbody>();
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        playerGroundedTransform = new Vector3(myTransform.position.x, myTransform.position.y, myTransform.position.z);
        direction = playerTransform.position - myTransform.position;

        if (direction.magnitude > 0.7f && direction.magnitude < 4f)
        {
            ChasePlayer();
            return State.Success;
        }
        else
        {
            return State.Failure;
        }
        
    }

    void ChasePlayer()
    {
        rb.MovePosition(Vector3.Lerp(rb.position, playerTransform.position, Time.deltaTime * speed));

        Vector3 directionToTarget = playerTransform.position - myTransform.position;
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

        // Smoothly interpolate between the current rotation and the target rotation
        Quaternion newRotation = Quaternion.RotateTowards(myTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Apply the new rotation to the Rigidbody using MoveRotation
        rb.MoveRotation(newRotation);


    }
}
