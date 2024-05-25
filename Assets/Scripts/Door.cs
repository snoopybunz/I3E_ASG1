/*
* Author: Karlyn Wee
* Date: 19 May 2024
* Description: This script manages interactions between the player and the door, including checking for keycards and opening the door.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Required for TextMeshPro

/// <summary>
/// Manages door interactions, requiring keycards to open and displaying a message if the player lacks a key.
/// </summary>
public class Door : MonoBehaviour
{
    /// <summary> Tracks if the door has been opened. </summary>
    bool opened = false;

    /// <summary> Number of keycards required to open the door. </summary>
    public int requiredKeyCardCount = 1;

    /// <summary> Reference to the UI text element to display messages. </summary>
    public TextMeshProUGUI messageText;

    /// <summary> Reference to the UI panel element to serve as a backdrop. </summary>
    public GameObject messagePanel;

    /// <summary> The message to display when the player lacks a key. </summary>
    public string noKeyMessage = "You need a keycard to open this door.";

    /// <summary> The duration to display the message in seconds. </summary>
    public float messageDuration = 2.0f;

    /// <summary>
    /// Callback function for when an object enters the Trigger area.
    /// </summary>
    /// <param name="other">The collider that entered the area.</param>
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that enters the trigger has the "Player" tag and if the door is not opened
        if (other.gameObject.tag == "Player" && !opened)
        {
            Player player = other.GetComponent<Player>();
            if (player != null && player.GetKeyCardScore() >= requiredKeyCardCount)
            {
                OpenDoor();
                Debug.Log("You have successfully entered.");
            }
            else
            {
                Debug.Log("You need a keycard to open this door. Find the keycard to pass through.");
                ShowMessage(noKeyMessage);
            }
        }
    }

    /// <summary>
    /// Rotates the door open.
    /// </summary>
    void OpenDoor()
    {
        // Store the object's rotation
        Vector3 newRotation = transform.eulerAngles;

        // Modify the new variable
        newRotation.y += -90f;

        // Re-assign the value to the object's rotation
        transform.eulerAngles = newRotation;

        // Track that the door has been opened.
        opened = true;
    }

    /// <summary>
    /// Shows a message on the screen for a set duration.
    /// </summary>
    /// <param name="message">The message to display.</param>
    void ShowMessage(string message)
    {
        if (messagePanel != null && messageText != null)
        {
            messagePanel.SetActive(true); // Show the panel
            messageText.text = message;   // Set the message text
            StartCoroutine(HideMessageAfterDelay(messageDuration));
        }
        else
        {
            Debug.LogError("Message panel or text is not assigned.");
        }
    }

    /// <summary>
    /// Hides the message after a delay.
    /// </summary>
    /// <param name="delay">The duration to wait before hiding the message.</param>
    /// <returns>An IEnumerator for the coroutine.</returns>
    IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (messagePanel != null && messageText != null)
        {
            messagePanel.SetActive(false); // Hide the panel
            messageText.text = "";        // Clear the message text
        }
    }
}
