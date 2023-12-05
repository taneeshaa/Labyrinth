using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateManager : MonoBehaviour
//public class MovementStateManager : NetworkBehaviour
{
    #region Movement
    [SerializeField] public float currentMoveSpeed = 3f;
    public float walkSpeed, walkBackSpeed;
    public float runSpeed, runBackSpeed;
    public float crouchSpeed, crouchBackSpeed;
    public float airSpeed = 1.5f;

    [HideInInspector] public Vector3 dir;
    [HideInInspector] public float hzInput, vInput;
     public CharacterController controller;
    #endregion

    #region Gravity
    [SerializeField] float groundYOffset;

    [SerializeField] float gravity = -9.81f;
    Vector3 velocity;
    [SerializeField] float jumpForce = 10;
    [HideInInspector] public bool jumped;
    #endregion

    public MovementBaseState previousState;
    MovementBaseState currentState;

    public IdleState Idle = new IdleState();
    public WalkState Walk = new WalkState();
    public RunState Run = new RunState();
    public CrouchState Crouch = new CrouchState();
    public JumpState Jump = new JumpState();


    [HideInInspector] public Animator anim;
    public float playerHeight;
    void Awake()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        SwitchState(Idle);
        //Cursor.lockState = CursorLockMode.Locked;
        playerHeight = controller.height;
    }

    //public override void FixedUpdateNetwork()
    private void Update()
    {
        
        GetDirectionAndMove();
        Gravity();
        Falling();
        
        anim.SetFloat("hzInput", hzInput);
        anim.SetFloat("vInput", vInput);

        if (Input.GetKey(KeyCode.Mouse0))
        {
            anim.SetTrigger("attack");
        }

        currentState.UpdateState(this);

    }

    public void SwitchState(MovementBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
    void GetDirectionAndMove()
    {
        hzInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        Vector3 airDir = Vector3.zero;
        if (!controller.isGrounded) airDir = transform.forward * vInput + transform.right * hzInput;
        else dir = transform.forward * vInput + transform.right * hzInput;

        dir = transform.forward * vInput + transform.right * hzInput;

        //controller.Move((dir.normalized * currentMoveSpeed + airDir.normalized * airSpeed) * Runner.DeltaTime);
        controller.Move((dir.normalized * currentMoveSpeed + airDir.normalized * airSpeed) * Time.deltaTime);
    }

    void Gravity()
    {
        if (!controller.isGrounded)
        {
            //velocity.y += gravity * Runner.DeltaTime;
            velocity.y += gravity * Time.deltaTime;
        }
        else if (velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //controller.Move(velocity * Runner.DeltaTime);
        controller.Move(velocity * Time.deltaTime);
    }

    void Falling() => anim.SetBool("Falling", !controller.isGrounded);

    public void JumpForce() => velocity.y += jumpForce;

    public void Jumped() => jumped = true;
}
