using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MazeTrigger : MonoBehaviour
{
    public string mazeSceneName = "maze"; // Name of the Maze Scene
    public Text pressEText; // Reference to the existing "Press E" Text object
    private bool playerInRange = false;

    void Start()
    {
        if (pressEText != null)
        {
            pressEText.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Press E Text is not assigned in the Inspector!");
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Load the Maze Scene
            SceneManager.LoadScene(mazeSceneName);
        }
    }

    // Detect when the player enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            // Show "Press E" text
            if (pressEText != null)
            {
                pressEText.gameObject.SetActive(true);
            }
        }
    }

    // Detect when the player exits the trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            // Hide "Press E" text
            if (pressEText != null)
            {
                pressEText.gameObject.SetActive(false);
            }
        }
    }
}
