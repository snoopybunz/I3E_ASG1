/*
* Author: Karlyn Wee
* Date: 19 May 2024
* Description: This script manages the collection of items by the player.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the collection of items by the player.
/// </summary>
public class Collectible : MonoBehaviour
{
    // Scores for different collectibles
    public int breadScore = 2;
    public int chickenScore = 5;
    public int cheeseScore = 3;
    public int keyCardScore = 1;
    public int poisonCheeseScore = -2;

    // Reference to the Player script to update the score
    private Player player;

    void Start()
    {
        // Find the Player object and get the Player script component
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.GetComponent<Player>();
            if (player == null)
            {
                Debug.LogError("Player script not found on the Player GameObject.");
            }
        }
        else
        {
            Debug.LogError("Player GameObject with tag 'Player' not found.");
        }
    }

    /// <summary>
    /// Handles the collection of the item by the player.
    /// </summary>
    /// <param name="score">The score value of the collectible.</param>
    /// <param name="collectibleType">The type of collectible.</param>
    void Collected(int score, string collectibleType)
    {
        player.IncreaseScore(score, collectibleType);

        if (collectibleType == "KeyCard")
        {
            Debug.Log("You have collected a Key Card.");
        }
        else
        {
            Debug.Log($"Collected item worth: {score} points!");
        }

        Destroy(gameObject);
    }

    /// <summary>
    /// Triggered when another collider enters the trigger collider attached to this object.
    /// </summary>
    /// <param name="other">The collider that entered the trigger.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            if (gameObject.CompareTag("Bread"))
            {
                Collected(breadScore, "Bread");
            }
            else if (gameObject.CompareTag("Chicken"))
            {
                Collected(chickenScore, "Chicken");
            }
            else if (gameObject.CompareTag("Cheese"))
            {
                Collected(cheeseScore, "Cheese");
            }
            else if (gameObject.CompareTag("KeyCard"))
            {
                Collected(keyCardScore, "KeyCard");
            }
            else if (gameObject.CompareTag("PoisonCheese"))
            {
                Collected(poisonCheeseScore, "PoisonCheese");
            }
        }
    }
}
