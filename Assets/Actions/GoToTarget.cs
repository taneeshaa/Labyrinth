using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using UnityEngine.AI;

[System.Serializable]
public class GoToTarget : ActionNode
{
    public NodeProperty<GameObject> selfGameObject, targetObject;
    private Transform myTransform, nextWavepointTransform;
    private Vector3 direction;
    private NavMeshAgent agent;
    private float speed = 0.5f;
    protected override void OnStart() {
        myTransform = selfGameObject.Value.transform;
        nextWavepointTransform = targetObject.Value.transform;
        agent = selfGameObject.Value.GetComponent<NavMeshAgent>();
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        if(nextWavepointTransform != null)
        {
            moveToTarget();
        }
        
        return State.Success;
    }

    void moveToTarget()
    {
        agent.SetDestination(nextWavepointTransform.position);
    }
}
