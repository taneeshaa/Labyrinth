using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class EnemyInRange : ActionNode
{
    //player transform
    //own transform
    //range to check
    public NodeProperty<GameObject> selfGameObject, playerGameObject;
    public NodeProperty<float> range;
    private Transform myTransform, playerTransform;
    private float Range;
    protected override void OnStart() {
        myTransform = selfGameObject.Value.transform;
        playerTransform = playerGameObject.Value.transform;
        Range = range.Value;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        return IsInRange() ? State.Success : State.Failure;
    }

    bool IsInRange()
    {
        return Vector3.Distance(myTransform.position, playerTransform.position) <= Range;
    }
}
