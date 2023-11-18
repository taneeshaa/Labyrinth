using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    TheKiwiCoder.BehaviourTreeInstance behaviourTreeInstance;
    void Start()
    {
        behaviourTreeInstance = GetComponent<TheKiwiCoder.BehaviourTreeInstance>();
        behaviourTreeInstance.SetBlackboardValue("selfGameObject", gameObject);
        behaviourTreeInstance.SetBlackboardValue("playerGameObject", GameObject.FindGameObjectWithTag("Player"));
    }

    void Update()
    {
        
    }
}
