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
        Rotate(player);
    }

    protected virtual void Rotate(Player player)
    {
        float camY = player.cam.transform.eulerAngles.y;

        player.transform.rotation = Quaternion.Euler(0, camY, 0);
    }

    public override void Exit(Player player)
    {
        player.animator.SetBool("Battle", false);
    }
}
