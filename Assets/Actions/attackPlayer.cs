using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using UnityEngine.UIElements;

[System.Serializable]
public class AttackPlayer : ActionNode
{
    public NodeProperty<GameObject> playerGameObject, selfGameObject, Healthbar;
    private Animator anim;
    private float countDownTime = 3f;
    private float timer = 3f;
    private PlayerHealth health;
    private Healthbar healthbarComponent;
    protected override void OnStart()
    {
        anim = selfGameObject.Value.GetComponent<Animator>();
        health = playerGameObject.Value.GetComponent<PlayerHealth>();
        healthbarComponent = Healthbar.Value.GetComponent<Healthbar>();
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        anim.SetBool("attack", true);
        timer = timer - Time.deltaTime;
        if(timer < 0)
        {
            timer = countDownTime;
            health.currentHealth -= 10;
            //health.healthbar.SetHealth(health.currentHealth/100);
            healthbarComponent.SetHealth(health.currentHealth/100);
        }
        return State.Success;
    }

}
