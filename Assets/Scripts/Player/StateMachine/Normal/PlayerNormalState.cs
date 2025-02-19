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
        Rotate(player);
    }

    protected virtual void Rotate(Player player)
    {
        float camY = player.cam.transform.eulerAngles.y;

        player.transform.rotation = Quaternion.Euler(0, camY, 0);
    }

    public override void Exit(Player player)
    {
        player.animator.SetBool("Normal", false);
    }
}
