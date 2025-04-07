using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount = 20;
    public GameObject pressEUI;
    private bool isPlayerInRange = false;
    public PlayerHealth player;

    void Start()
    {
        pressEUI.SetActive(false);
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (player != null)
            {
                player.Heal(healAmount);
                pressEUI.SetActive(false);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            isPlayerInRange = true;
            pressEUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerHealth>() != null)
        {
            isPlayerInRange = false;
            pressEUI.SetActive(false);
        }
    }
}
