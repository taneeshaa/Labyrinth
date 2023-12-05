using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public List<AttackSO> combo;
    float lastClickedTime;
    float lastComboEnd;
    int comboCounter;
    float timeBetweenAttacks = 0.2f;
    float timeBetweenCombos = 0.2f;
    Animator anim;
    [SerializeField] Weapon weapon;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    //public override void FixedUpdateNetwork()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
        ExitAttack();
    }

    void Attack()
    {
        if(Time.time - lastComboEnd > timeBetweenCombos && comboCounter <= combo.Count)
        {
            CancelInvoke("EndCombo");

            if(Time.time - lastClickedTime >= timeBetweenAttacks)
            {
                anim.runtimeAnimatorController = combo[comboCounter].animatorOV;
                anim.SetLayerWeight(1, 1);
                anim.Play("Attack", 1);
                weapon.damage = combo[comboCounter].damage;
                comboCounter++;
                lastClickedTime = Time.time;

                if(comboCounter + 1 > combo.Count)
                {
                    comboCounter = 0;
                }
            }
        }
    }

    void ExitAttack()
    {
        if(anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.9 && anim.GetCurrentAnimatorStateInfo(1).IsTag("Attack"))
        {
            anim.SetLayerWeight(1, 0);
            Invoke("EndCombo", 1);
        }
    }

    void EndCombo()
    {
        comboCounter = 0;
        lastComboEnd = Time.time;
    }
}
