using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region state

    private PlayerNIdleState normalIdle;
    private PlayerNWalkState normalWalk;
    private PlayerNDashState normalDash;

    private PlayerBIdleState battleIdle;
    private PlayerBWalkState battleWalk;
    private PlayerBDashState battleDash;

    #endregion



    [SerializeField] private float curHp;
    [SerializeField] private float maxHp;
    [SerializeField] private float speed;

    [HideInInspector] public PlayerState state;

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

}
