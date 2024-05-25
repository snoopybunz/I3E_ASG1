/*
* Author: Karlyn Wee
* Date: 19 May 2024
* Description: This script manages interactions between the player and lava.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages interactions between the player and lava.
/// </summary>
public class Lava : MonoBehaviour
{
    /// <summary>
    /// Triggered when another collider enters the trigger collider attached to this object.
    /// </summary>
    /// <param name="other">The collider that entered the trigger.</param>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"OnTriggerEnter called with {other.gameObject.name}");
        if (other.CompareTag("Player"))
        {
            Debug.Log($"Player entered the lava: {other.gameObject.name}");
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                Debug.Log("Player script found. Calling Die method.");
                player.Die();
                Debug.Log("Player fell into lava and died.");
            }
            else
            {
                Debug.Log("Player script not found.");
            }
        }
        else
        {
            Debug.Log($"Entered by non-player object: {other.gameObject.tag}");
        }
    }
}
