/*
* Author: Karlyn Wee
* Date: 19 May 2024
* Description: This script manages the goal platform interactions and congratulatory message.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // If using TextMeshPro

/// <summary>
/// Manages the goal platform interactions and congratulatory message.
/// </summary>
public class GoalPlatform : MonoBehaviour
{
    /// <summary> Reference to the congratulatory panel. </summary>
    public GameObject congratsPanel;
    /// <summary> Reference to the close button. </summary>
    public Button closeButton;

    /// <summary> Initializes the goal platform by setting up the panel and button. </summary>
    void Start()
    {
        if (congratsPanel != null)
        {
            congratsPanel.SetActive(false); // Ensure the panel is inactive at the start
        }

        if (closeButton != null)
        {
            closeButton.onClick.AddListener(CloseCongratsPanel);
        }
        else
        {
            Debug.LogError("Close button is not assigned.");
        }
    }

    /// <summary>
    /// Triggered when another collider enters the trigger collider attached to this object.
    /// </summary>
    /// <param name="other">The collider that entered the trigger.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShowCongratsPanel();
        }
    }

    /// <summary> Shows the congratulatory panel. </summary>
    public void ShowCongratsPanel()
    {
        if (congratsPanel != null)
        {
            congratsPanel.SetActive(true);
            Debug.Log("Congrats panel shown.");
        }
    }

    /// <summary> Closes the congratulatory panel. </summary>
    public void CloseCongratsPanel()
    {
        Debug.Log("CloseCongratsPanel method called.");
        if (congratsPanel != null)
        {
            congratsPanel.SetActive(false);
            Debug.Log("Congrats panel closed.");
        }
    }
}
