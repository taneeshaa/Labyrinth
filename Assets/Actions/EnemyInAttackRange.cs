using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class EnemyInAttackRange : ActionNode
{
    //player transform
    //own transform
    //range to check
    public NodeProperty<GameObject> selfGameObject, playerGameObject;
    public NodeProperty<float> upperrange, lowerrange;
    private Transform myTransform, playerTransform;

    private float upperRange;
    private float lowerRange;

    protected override void OnStart()
    {
        myTransform = selfGameObject.Value.transform;
        upperRange = upperrange.Value;
        lowerRange = lowerrange.Value;
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {

        playerTransform = playerGameObject.Value.transform;
        return IsInRange() ? State.Success : State.Failure;
    }

    bool IsInRange()
    {
        return Vector3.Distance(myTransform.position, playerTransform.position) <= upperRange;
    }
}
