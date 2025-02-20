using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : State<Player>
{
    public override void Change(Player player)
    {
        //Debug.LogError(this.GetType());
        player.state.Exit(player);
        player.state = this;
        Enter(player);
    }

    protected virtual void Rotate(Player player)
    {
        Quaternion targetRot = Quaternion.Euler(0, player.cam.eulerAngles.y, 0);

        player.transform.rotation = Quaternion.Slerp(player.transform.rotation, targetRot, Time.deltaTime * player.RotSpeed);
    }
}
