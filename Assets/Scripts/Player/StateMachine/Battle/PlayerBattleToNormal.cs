using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleToNormal : PlayerBattleState
{
    public override void Enter(Player player)
    {
        player.animator.SetTrigger("BattleToNormal");
    }

    public override void Update(Player player)
    {
        if (player.isBattle)
        {
            if (player.animator.GetCurrentAnimatorStateInfo(0).IsName("Battle_To_Normal"))
            {
                if (player.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
                {
                    player.isBattle = false;
                    player.SetState(player.normalIdle);
                }
            }
        }
    }

    public override void Exit(Player player)
    {
        
    }
}
