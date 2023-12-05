using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class GoToTarget : ActionNode
{
    public NodeProperty<GameObject> selfGameObject, targetObject;
    private Transform myTransform, nextWavepointTransform;
    private Vector3 direction;
    private float speed = 1f;
    protected override void OnStart() {
        myTransform = selfGameObject.Value.transform;
        nextWavepointTransform = targetObject.Value.transform;
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
        direction = nextWavepointTransform.position - myTransform.position; 
        myTransform.Translate(direction * speed * Time.deltaTime);
    }
}
