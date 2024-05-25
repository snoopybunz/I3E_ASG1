/*
* Author: Karlyn Wee
* Date: 19 May 2024
* Description: This script manages the game timer display and functionality.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // If using TextMeshPro
using UnityEngine.UI; // If using default Text component

/// <summary>
/// Manages the game timer, including starting, stopping, and updating a countdown timer.
/// </summary>
public class GameTimer : MonoBehaviour
{
    /// <summary> Reference to the TextMeshPro text element displaying the timer. </summary>
    public TextMeshProUGUI timerText;
    // public Text timerText; // Use this if using default Text component

    /// <summary> The starting time for the countdown timer in seconds. </summary>
    public float startTimeInSeconds = 20 * 60f; // 20 minutes in seconds

    /// <summary> The remaining time for the countdown timer in seconds. </summary>
    private float remainingTime;

    /// <summary> Indicates whether the timer is currently running. </summary>
    private bool timerRunning = false;

    void Start()
    {
        // Initialize the remaining time with the starting time
        ResetTimer();
    }

    void Update()
    {
        if (timerRunning)
        {
            // Decrease the remaining time
            remainingTime -= Time.deltaTime;

            // If time runs out, stop the timer and handle the event
            if (remainingTime <= 0)
            {
                remainingTime = 0;
                timerRunning = false;
                TimerEnded();
            }

            // Update the timer text
            UpdateTimerText();
        }
    }

    /// <summary>
    /// Starts the countdown timer.
    /// </summary>
    public void StartTimer()
    {
        timerRunning = true;
    }

    /// <summary>
    /// Stops the countdown timer.
    /// </summary>
    public void StopTimer()
    {
        timerRunning = false;
    }

    /// <summary>
    /// Resets the countdown timer to the starting time.
    /// </summary>
    public void ResetTimer()
    {
        remainingTime = startTimeInSeconds;
        UpdateTimerText();
    }

    /// <summary>
    /// Updates the timer text to display the remaining time.
    /// </summary>
    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60F);
        int seconds = Mathf.FloorToInt(remainingTime % 60F);
        int milliseconds = Mathf.FloorToInt((remainingTime * 100F) % 100F);
        timerText.text = string.Format("Time: {0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    /// <summary>
    /// Handles the event when the timer ends.
    /// </summary>
    private void TimerEnded()
    {
        Debug.Log("Timer ended!");
        // Add any additional logic you want to happen when the timer ends
    }
}
