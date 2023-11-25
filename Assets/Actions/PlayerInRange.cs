using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class PlayerInRange : ActionNode
{
    public NodeProperty<GameObject> npcGameObject, playerGameObject;
    public NodeProperty<float> range;
    private Transform npcTransform, playerTransform;
    private float Range;

    protected override void OnStart() {
        Range = range.Value;
        npcTransform = npcGameObject.Value.transform;
        playerTransform = playerGameObject.Value.transform;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        return IsInRange() ? State.Success : State.Failure;
    }

    bool IsInRange()
    {
        return Vector3.Distance(playerTransform.position, npcTransform.position) <=Range;
    }
}
