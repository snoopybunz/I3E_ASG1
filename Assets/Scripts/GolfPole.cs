/*
* Author: Karlyn Wee
* Date: 19 May 2024
* Description: This script manages interactions between golf balls and the golf pole.
*/

using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages interactions between golf balls and the golf pole.
/// </summary>
public class GolfPole : MonoBehaviour
{
    // Reference to the Player script to update the score
    private Player player;

    // Initializes the golf pole by finding the Player object and getting the Player script component.
    void Start()
    {
        // Find the Player object and get the Player script component
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (player == null)
        {
            Debug.LogError("Player script not found on the Player GameObject.");
        }
    }

    /// <summary>
    /// Triggered when another collider enters the trigger collider attached to this object.
    /// </summary>
    /// <param name="other">The collider that entered the trigger.</param>
    void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is a golf ball
        if (other.CompareTag("GolfBall"))
        {
            GolfBall golfBall = other.GetComponent<GolfBall>();
            if (golfBall != null)
            {
                // Add the ball's score to the player's total score
                player.IncreaseScore(golfBall.ballScore, "GolfBall");

                // Log the points scored
                Debug.Log($"Golf ball entered the pole's area and scored {golfBall.ballScore} points");

                // Destroy the golf ball after scoring
                Destroy(other.gameObject);
            }
        }
    }
}
