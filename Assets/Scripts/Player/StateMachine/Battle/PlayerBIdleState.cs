using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBIdleState : PlayerBattleState
{
    public override void Enter(Player player)
    {
        player.animator.SetBool("Idle", true);
    }

    public override void Update(Player player)
    {
        base.Update(player);

        if (player.inputVec != Vector2.zero)
        {
            if (player.isBattle) player.SetState(player.battleWalk);
            else player.SetState(player.normalWalk);
        }
    }



    public override void Exit(Player player)
    {
        player.animator.SetBool("Idle", false);
    }
}
