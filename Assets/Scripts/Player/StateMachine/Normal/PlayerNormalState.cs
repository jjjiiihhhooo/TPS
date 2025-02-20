using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalState : PlayerState
{
    public override void Enter(Player player)
    {
        player.animator.SetBool("Normal", true);
    }

    public override void Update(Player player)
    {
        //Rotate(player);
    }

    public override void Exit(Player player)
    {
        player.animator.SetBool("Normal", false);
    }
}
