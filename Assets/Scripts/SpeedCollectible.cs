using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCollectible : Collectible
{
    public override void Collected()
    {
        base.Collected();
        if (player != null)
        {
            player.IncreaseSpeed(2); // Increase movement speed
            Debug.Log("Speed increased!");
        }
    }
}
