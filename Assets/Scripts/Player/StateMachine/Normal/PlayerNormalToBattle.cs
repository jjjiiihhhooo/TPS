using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalToBattle : PlayerNormalState
{
    public override void Enter(Player player)
    {
        player.animator.SetTrigger("NormalToBattle");
    }

    public override void Update(Player player)
    {
        if (!player.isBattle)
        {
            if (player.animator.GetCurrentAnimatorStateInfo(0).IsName("Normal_To_Battle"))
            {
                if (player.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
                {
                    player.isBattle = true;
                    player.SetState(player.battleIdle);
                }
                
            }
        }
    }

    public override void Exit(Player player)
    {
        
    }
}
