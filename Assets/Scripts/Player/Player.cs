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
    [HideInInspector] public PlayerNormalToBattle normalToBattle;

    [HideInInspector] public PlayerBIdleState battleIdle;
    [HideInInspector] public PlayerBWalkState battleWalk;
    [HideInInspector] public PlayerBattleToNormal battleToNormal;

    #endregion

    public static Player Instance;

    [SerializeField] private float curHp;
    [SerializeField] private float maxHp;
    [SerializeField] private float normalSpeed = 3;
    [SerializeField] private float battleSpeed = 5;
    [SerializeField] private float dashSpeed = 60;
    [SerializeField] private float rotSpeed = 2f;
    [SerializeField] private float dashToNormalSpeed;
    [SerializeField] private float yVelocity;
    [SerializeField] private MeshTrail trail;

    private float curSpeed;

    public float speed = 5;
    public bool isBattle;
    public Vector2 inputVec;
    public Animator animator;
    public CharacterController controller;
    public Transform cam;
    
    [HideInInspector] public PlayerState state;

    public float NormalSpeed { get => normalSpeed; }
    public float BattleSpeed { get => battleSpeed; }
    public float Speed { get => curSpeed; }
    public float RotSpeed { get => rotSpeed; }
    public float YVelocity { get => yVelocity; set => value = yVelocity; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            Init();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Init()
    {
        #region newState

        normalIdle = new PlayerNIdleState();
        normalWalk = new PlayerNWalkState();
        normalToBattle = new PlayerNormalToBattle();

        battleIdle = new PlayerBIdleState();
        battleWalk = new PlayerBWalkState();
        battleToNormal = new PlayerBattleToNormal();
        #endregion

        curHp = maxHp;
        curSpeed = speed;
        state = normalIdle;
        state.Enter(this);
    }

    private void Update()
    {
        state.Update(this);
        Setdir();
        DashToNormalSpeed();
    }

    private void DashToNormalSpeed()
    {
        if(curSpeed > speed)
        {
            curSpeed -= dashToNormalSpeed;
        }
        else
        {
            curSpeed = speed;
        }
    }

    private void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    private void Setdir()
    {
        animator.SetFloat("xDir", inputVec.x, 0.1f, Time.deltaTime);
        animator.SetFloat("yDir", inputVec.y, 0.1f, Time.deltaTime);
    }

    public void SetState(PlayerState state)
    {
        state.Change(this);
    }

    public void ToggleWeapon()
    {
        if (state is PlayerBattleToNormal || state is PlayerNormalToBattle) return;

        if (isBattle) SetState(battleToNormal);
        else SetState(normalToBattle);
    }

    public void DashInput()
    {
        SoundManager.Play("Dash", false, 0.2f);
        trail.DashTrail();
        curSpeed = dashSpeed;
    }
}
