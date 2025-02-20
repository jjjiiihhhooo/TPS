using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleState : PlayerState
{
    public override void Enter(Player player)
    {
        player.animator.SetBool("Battle", true);
    }

    public override void Update(Player player)
    {
        //Rotate(player);
    }

    public override void Exit(Player player)
    {
        player.animator.SetBool("Battle", false);
    }
}
