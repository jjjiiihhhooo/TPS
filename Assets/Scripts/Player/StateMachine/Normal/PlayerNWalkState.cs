using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerNWalkState : PlayerNormalState
{
    public override void Enter(Player player)
    {
        base.Enter(player);
        player.YVelocity = 0f;
        player.animator.SetBool("Walk", true);
    }

    public override void Update(Player player)
    {
        if (player.inputVec == Vector2.zero)
            player.SetState(player.normalIdle);
        else
            Move(player);

    }

    private void Move(Player player)
    {
        Vector3 move = new Vector3(player.inputVec.x, 0f, player.inputVec.y);

        move = player.transform.TransformDirection(move);

        move *= player.Speed;

        player.controller.Move(move * Time.deltaTime);

        if(move != Vector3.zero)
            Rotate(player);
    }

    public override void Exit(Player player)
    {
        base.Exit(player);
        player.animator.SetBool("Walk", false);
    }
}
