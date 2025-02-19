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

        if(move != Vector3.zero)
            Rotate(player);
    }

    private void Rotate(Player player)
    {
        Vector3 lookDir = player.cam.forward;
        lookDir.y = 0;

        Quaternion targetRot = Quaternion.LookRotation(lookDir);

        player.transform.rotation = Quaternion.Slerp(player.transform.rotation, targetRot, Time.deltaTime * player.RotSpeed);
    }

    public override void Exit(Player player)
    {
        base.Exit(player);
        player.animator.SetBool("Walk", false);
    }
}
