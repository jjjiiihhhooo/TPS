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
}
