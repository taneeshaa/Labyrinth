using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    TheKiwiCoder.BehaviourTreeInstance behaviourTreeInstance;
    public GameObject waypointParent;
    public int health = 30;
    void Awake()
    {
        behaviourTreeInstance = GetComponent<TheKiwiCoder.BehaviourTreeInstance>();
        behaviourTreeInstance.SetBlackboardValue("selfGameObject", gameObject);
        behaviourTreeInstance.SetBlackboardValue("waypointParent", waypointParent);
        behaviourTreeInstance.SetBlackboardValue("myTransform", gameObject);
        behaviourTreeInstance.SetBlackboardValue("playerGameObject", GameObject.FindGameObjectWithTag("Player"));
        behaviourTreeInstance.SetBlackboardValue("healthbar", GameObject.FindGameObjectWithTag("Healthbar"));
    }


}
