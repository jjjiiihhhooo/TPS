using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBWalkState : PlayerBattleState
{
    public override void Enter(Player player)
    {
        base.Enter(player);
        player.animator.SetBool("Walk", true);
    }

    public override void Update(Player player)
    {
        base.Update(player);

        if (player.InputVec == Vector2.zero)
            player.SetState(player.normalIdle);
        else
            Move(player);

    }

    private void Move(Player player)
    {
        Vector3 move = new Vector3(player.InputVec.x, 0f, player.InputVec.y);

        move = player.transform.TransformDirection(move);

        move *= player.Speed;

        player.controller.Move(move * Time.deltaTime);
    }

    public override void Exit(Player player)
    {
        base.Exit(player);
        player.animator.SetBool("Walk", false);
    }
}
