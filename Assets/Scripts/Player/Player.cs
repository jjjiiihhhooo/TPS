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
    [HideInInspector] public PlayerNormalToBattle normalToBattle;

    [HideInInspector] public PlayerBIdleState battleIdle;
    [HideInInspector] public PlayerBWalkState battleWalk;
    [HideInInspector] public PlayerBDashState battleDash;
    [HideInInspector] public PlayerBattleToNormal battleToNormal;

    #endregion

    public static Player Instance;

    [SerializeField] private float curHp;
    [SerializeField] private float maxHp;
    [SerializeField] private float speed = 5;
    [SerializeField] private float rotSpeed = 2f;
    [SerializeField] private float yVelocity;

    public bool isBattle;
    public Vector2 inputVec;
    public Animator animator;
    public CharacterController controller;
    public Transform cam;
    
    [HideInInspector] public PlayerState state;

    public float Speed { get => speed; }
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
        normalDash = new PlayerNDashState();
        normalToBattle = new PlayerNormalToBattle();

        battleIdle = new PlayerBIdleState();
        battleWalk = new PlayerBWalkState();
        battleDash = new PlayerBDashState();
        battleToNormal = new PlayerBattleToNormal();
        #endregion

        curHp = maxHp;
        state = normalIdle;
        state.Enter(this);
    }

    private void Update()
    {
        state.Update(this);
        Setdir();
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
        if (isBattle) SetState(battleToNormal);
        else SetState(normalToBattle);
    }
}
