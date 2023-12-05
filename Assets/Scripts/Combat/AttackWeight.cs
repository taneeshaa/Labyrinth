using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWeight : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void resetAttackLayerWeight()
    {
        anim.SetLayerWeight(1, 0);
    }
}
