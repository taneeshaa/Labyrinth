using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySenses : MonoBehaviour
{
    public float viewRadius;
    public float viewAngle;

    public float hearRadius;

    public LayerMask targetPlayer;
    public LayerMask obstacleMask;

    public GameObject player;

    void Update()
    {
        Vector3 playerTarget = (player.transform.position - transform.position).normalized;

        float distanceToTarget = Vector3.Distance(transform.forward, player.transform.position);

        if (Vector3.Angle(transform.forward, playerTarget) < viewAngle / 2)
        {
            
            if (distanceToTarget <= viewRadius)
            {
                if(Physics.Raycast(transform.position, playerTarget, distanceToTarget, obstacleMask) == false)
                {
                    //Debug.Log("I have seen you :)");
                }
            }
        }
        bool playerNotMakingNoise = player.GetComponent<MovementStateManager>().currentState == player.GetComponent<MovementStateManager>().Idle ||
            player.GetComponent<MovementStateManager>().currentState == player.GetComponent<MovementStateManager>().Crouch;
        if ( !playerNotMakingNoise && distanceToTarget < hearRadius)
        {
            //Debug.Log("I can hear you :)");
        }
    }
}
