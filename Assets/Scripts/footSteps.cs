using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public AudioSource footstepsSound, sprintSound;
    private MovementStateManager movement;

    void Awake()
    {
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementStateManager>();
    }

    void Update()
    {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    footstepsSound.enabled = false;
                    sprintSound.enabled = true;
                }
                else
                {
                    if (movement.currentState != movement.Crouch)
                    {
                        footstepsSound.enabled = true;
                        sprintSound.enabled = false;
                    }
                }
            }
            else
            {
                footstepsSound.enabled = false;
                sprintSound.enabled = false;
            }
        }
    
        
}
