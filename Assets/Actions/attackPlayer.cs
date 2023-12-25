using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using UnityEngine.UIElements;

[System.Serializable]
public class AttackPlayer : ActionNode
{
    public NodeProperty<GameObject> playerGameObject, selfGameObject;
    private Animator anim;
    private float countDownTime = 3f;
    private float timer = 3f;
    private PlayerHealth health;
    protected override void OnStart()
    {
        anim = selfGameObject.Value.GetComponent<Animator>();
        Debug.Log("grabbing player health component");
        health = playerGameObject.Value.GetComponent<PlayerHealth>();
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        if(health == null)
        {
            //Debug.Log("health is null");
        }
        anim.SetBool("attack", true);
        timer = timer - Time.deltaTime;
        if(timer < 0)
        {
            timer = countDownTime;
            Debug.Log("player damage taken");
            health.currentHealth -= 10;
            //Debug.Log(health.currentHealth);
        }
        return State.Success;
    }

}
