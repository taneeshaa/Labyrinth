using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage;

    BoxCollider triggerBox;

    void Start()
    {
        triggerBox = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.gameObject.GetComponent<Enemy>();
        var anim = other.gameObject.GetComponent<Animator>();
        if (enemy != null)
        {
            enemy.health -= damage;
            anim.SetTrigger("pain");
            
            if (enemy.health <= 0)
            {
                anim.SetTrigger("death");
                Destroy(enemy.gameObject);
            }

        }
    }

    public void EnableTrigger()
    {
        triggerBox.enabled = true;
    }

    public void DisableTrigger()
    {
        triggerBox.enabled = false;
    }
}
