using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using UnityEngine;

public class NPC : MonoBehaviour
{
    TheKiwiCoder.BehaviourTreeInstance behaviourTreeInstance;
    [SerializeField] float Range;
    // Start is called before the first frame update
    void Start()
    {
        behaviourTreeInstance = GetComponent<TheKiwiCoder.BehaviourTreeInstance>();
        behaviourTreeInstance.SetBlackboardValue("npcGameObject", gameObject);
        behaviourTreeInstance.SetBlackboardValue("playerGameObject", GameObject.FindGameObjectWithTag("Player"));
        behaviourTreeInstance.SetBlackboardValue("Range", Range);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
