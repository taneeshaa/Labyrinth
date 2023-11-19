using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class GetNextDestination : ActionNode
{
    public NodeProperty<GameObject> waypointParent;
    public NodeProperty<GameObject> myTransform;
    private Transform waypointParentTransform, transform;
    private int currentWayPointIndex = -1;
    private Enemy enemy;
    private List<Transform> wayPoints;
    protected override void OnStart() {
        wayPoints = new List<Transform>();
        waypointParentTransform = waypointParent.Value.transform;
        for(int i = 0; i < waypointParentTransform.childCount; i++)
        {
            wayPoints.Add(waypointParentTransform.GetChild(i));
        }
        transform = myTransform.Value.transform;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        SetNextWavepoint();
        setTargetWavepoint();
        return State.Success;
    }

    void SetNextWavepoint()
    {
        if (currentWayPointIndex == -1)
        {
            currentWayPointIndex = Random.Range(0, wayPoints.Count);
        }
        if(Vector3.Distance(transform.position, wayPoints[currentWayPointIndex].position) < 5f)
        {
            currentWayPointIndex = Random.Range(0, wayPoints.Count);
        }
    }

    void setTargetWavepoint()
    {
        transform.GetComponent<BehaviourTreeInstance>().SetBlackboardValue("targetObject", wayPoints[currentWayPointIndex].gameObject);
    }
}
