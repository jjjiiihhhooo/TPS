using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{
    #region state

    [HideInInspector] public PlayerNIdleState normalIdle;
    [HideInInspector] public PlayerNWalkState normalWalk;
    [HideInInspector] public PlayerNDashState normalDash;

    [HideInInspector] public PlayerBIdleState battleIdle;
    [HideInInspector] public PlayerBWalkState battleWalk;
    [HideInInspector] public PlayerBDashState battleDash;

    #endregion

    [SerializeField] private float curHp;
    [SerializeField] private float maxHp;
    [SerializeField] private float speed = 5;
    [SerializeField] private float rotSpeed = 2f;
    [SerializeField] private float yVelocity;


    [SerializeField] private Vector2 inputVec;

    public bool isBattle;
    public Animator animator;
    public CharacterController controller;
    public Transform cam;
    
    [HideInInspector] public PlayerState state;

    public float Speed { get => speed; }
    public float RotSpeed { get => rotSpeed; }
    public float YVelocity { get => yVelocity; set => value = yVelocity; }
    public Vector2 InputVec { get => inputVec; }

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        #region newState

        normalIdle = new PlayerNIdleState();
        normalWalk = new PlayerNWalkState();
        normalDash = new PlayerNDashState();

        battleIdle = new PlayerBIdleState();
        battleWalk = new PlayerBWalkState();
        battleDash = new PlayerBDashState();
        #endregion

        curHp = maxHp;
        state = normalIdle;
        state.Enter(this);
    }

    private void Update()
    {
        state.Update(this);
    }

    private void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
        Setdir();
    }

    private void Setdir()
    {
        animator.SetFloat("xDir", inputVec.x);
        animator.SetFloat("yDir", inputVec.y);
    }

    public void SetState(PlayerState state)
    {
        state.Change(this);
    }
}
