using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    TheKiwiCoder.BehaviourTreeInstance behaviourTreeInstance;
    public GameObject waypointParent;
    private int randomIndex;
    void Start()
    {
        behaviourTreeInstance = GetComponent<TheKiwiCoder.BehaviourTreeInstance>();
        behaviourTreeInstance.SetBlackboardValue("selfGameObject", gameObject);
        behaviourTreeInstance.SetBlackboardValue("playerGameObject", GameObject.FindGameObjectWithTag("Player"));
        behaviourTreeInstance.SetBlackboardValue("waypointParent", waypointParent);
        behaviourTreeInstance.SetBlackboardValue("myTransform", gameObject);
    }

    void Update()
    {
        
    }
}
