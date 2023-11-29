using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Fusion;

public class AimStateManager : NetworkBehaviour
{
    AimBaseState currentState;
    public HipFireState Hip = new HipFireState();
    public AimState Aim = new AimState();

    [SerializeField] float mouseSense = 1f;
    [SerializeField] float xAxis, yAxis;
    [SerializeField] Transform camFollowPosition;

    [HideInInspector] public Animator anim;
    [HideInInspector] public CinemachineVirtualCamera vCam;
    public float adsFOV = 40;
    [HideInInspector] public float hipFOV;
    [HideInInspector] public float currentFOV;
    public float fovSmoothSpeed = 10;

    public Transform aimPos;
    [HideInInspector] public Vector3 actualAimPos;
    [SerializeField] float aimSmoothSpeed = 20f;
    [SerializeField] LayerMask aimMask;


    void Start()
    {
        vCam = GetComponentInChildren<CinemachineVirtualCamera>();
        hipFOV = vCam.m_Lens.FieldOfView;
        anim = GetComponent<Animator>();
        SwitchState(Hip);
    }
    private void Update()
    {
        if (HasStateAuthority == false)
        {
            return;
        }
        xAxis += Input.GetAxisRaw("Mouse X") * mouseSense;
        yAxis -= Input.GetAxisRaw("Mouse Y") * mouseSense;
        yAxis = Mathf.Clamp(yAxis, -80, 80);

        vCam.m_Lens.FieldOfView = Mathf.Lerp(vCam.m_Lens.FieldOfView, currentFOV, fovSmoothSpeed *Runner.DeltaTime);

        currentState.UpdateState(this);
        
        Vector2 screenCenter = new Vector2(Screen.width/2, Screen.height/2);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, aimMask))
        {
            aimPos.position = Vector3.Lerp(aimPos.position, hit.point, aimSmoothSpeed * Runner.DeltaTime);
            actualAimPos = hit.point;
        }
    }

    private void LateUpdate()
    {
        camFollowPosition.localEulerAngles = new Vector3(yAxis, camFollowPosition.localEulerAngles.y, camFollowPosition.localEulerAngles.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis, transform.eulerAngles.z);
    }

    public void SwitchState(AimBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
