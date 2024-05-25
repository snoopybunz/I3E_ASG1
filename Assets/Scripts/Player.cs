/*
* Author: Karlyn Wee
* Date: 19 May 2024
* Description: This script manages the player's scores, lives, and interactions with the game.
*/

using UnityEngine;
using TMPro; // Required for TextMeshPro

/// <summary>
/// Manages the player's scores, lives, and interactions with the game.
/// </summary>
public class Player : MonoBehaviour
{
    // Scores for each type of collectible at the start
    private int totalScore = 0;
    private int breadScore = 0;
    private int chickenScore = 0;
    private int cheeseScore = 0;
    private int keyCardScore = 0;
    private int poisonCheeseScore = 0;
    private bool hasKeyCard = false;

    // Lives and respawn
    private int lives = 3;
    private Vector3 startPosition;
    public Transform respawnPoint;

    // UI Text to display the score, lives, timer, and total key cards
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public GameTimer gameTimer;
    public int totalKeyCards;

    // Player movement properties
    public float moveSpeed = 5f;
    public float jumpHeight = 2f;

    void Start()
    {
        // Store the initial position of the player
        startPosition = transform.position;
        UpdateUI();
    }

    /// <summary>
    /// Update the UI to display the current scores and lives
    /// </summary>
    void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Total: {totalScore}\n\nBread: {breadScore}\nChicken: {chickenScore}\nCheese: {cheeseScore}\nKey Card: {keyCardScore}";
        }

        if (livesText != null)
        {
            livesText.text = $"Lives: {lives}";
        }
    }

    /// <summary>
    /// Increase the score of the player by the given amount for the specified collectible type
    /// </summary>
    /// <param name="scoreToAdd">The amount of score to add.</param>
    /// <param name="collectibleType">The type of collectible.</param>
    public void IncreaseScore(int scoreToAdd, string collectibleType)
    {
        switch (collectibleType)
        {
            case "Bread":
                breadScore += scoreToAdd;
                totalScore += scoreToAdd;
                break;
            case "Chicken":
                chickenScore += scoreToAdd;
                totalScore += scoreToAdd;
                break;
            case "Cheese":
                cheeseScore += scoreToAdd;
                totalScore += scoreToAdd;
                break;
            case "KeyCard":
                keyCardScore += scoreToAdd;
                hasKeyCard = true;
                // Start the timer when the first keycard is collected
                if (keyCardScore == 1 && gameTimer != null)
                {
                    gameTimer.StartTimer();
                }
                // Stop the timer when all keycards are collected
                if (keyCardScore == totalKeyCards && gameTimer != null)
                {
                    gameTimer.StopTimer();
                    Debug.Log("All keycards collected. Timer stopped.");
                }
                break;
            case "PoisonCheese":
                poisonCheeseScore += scoreToAdd;  // Track the points from poison cheese
                cheeseScore += scoreToAdd;        // Also deduct from cheese score
                totalScore += scoreToAdd;         // Include in total score (even if it's negative)
                break;
            case "GolfBall":
                totalScore += scoreToAdd;
                break;
        }
        UpdateUI();
    }

    /// <summary>
    /// Increase the total score by the given amount
    /// </summary>
    /// <param name="scoreToAdd">The amount of score to add.</param>
    public void IncreaseScore(int scoreToAdd)
    {
        totalScore += scoreToAdd;
        UpdateUI();
    }

    /// <summary>
    /// Increase the player's movement speed
    /// </summary>
    /// <param name="amount">The amount to increase the speed by.</param>
    public void IncreaseSpeed(float amount)
    {
        moveSpeed += amount;
        Debug.Log($"Player speed increased by {amount}. New speed: {moveSpeed}");
    }

    /// <summary>
    /// Increase the player's jump height
    /// </summary>
    /// <param name="amount">The amount to increase the jump height by.</param>
    public void IncreaseJumpHeight(float amount)
    {
        jumpHeight += amount;
        Debug.Log($"Player jump height increased by {amount}. New jump height: {jumpHeight}");
    }

    /// <summary>
    /// Get the current key card score
    /// </summary>
    /// <returns>The current key card score.</returns>
    public int GetKeyCardScore()
    {
        return keyCardScore;
    }

    /// <summary>
    /// Handles the player dying
    /// </summary>
    public void Die()
    {
        Debug.Log("Player died.");
        if (lives > 1)
        {
            lives--;
            Debug.Log("Respawning player. Lives left: " + lives);
            Respawn();
        }
        else
        {
            Debug.Log("Restarting game. Lives left: " + lives);
            RestartGame();
        }
        UpdateUI();
    }

    /// <summary>
    /// Respawn the player at the respawn point or start position
    /// </summary>
    void Respawn()
    {
        if (respawnPoint != null)
        {
            Debug.Log("Respawning at respawn point.");
            transform.position = respawnPoint.position;
        }
        else
        {
            Debug.Log("Respawning at start position.");
            transform.position = startPosition;
        }
    }

    /// <summary>
    /// Restart the game by resetting lives, scores, and timer
    /// </summary>
    void RestartGame()
    {
        Debug.Log("Restarting game.");
        lives = 3;
        // Reset player position to the start position
        transform.position = startPosition;
        totalScore = 0;
        breadScore = 0;
        chickenScore = 0;
        cheeseScore = 0;
        keyCardScore = 0;
        poisonCheeseScore = 0;
        hasKeyCard = false;

        // Restart the timer
        if (gameTimer != null)
        {
            gameTimer.ResetTimer();
        }

        // Update the UI to reflect the reset state
        UpdateUI();
    }
}