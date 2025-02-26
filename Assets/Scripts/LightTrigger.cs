using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightTrigger : MonoBehaviour
{
    public LightManager lightManager;
    private bool isPlayerInRange = false;  // detect PLAYER IN RANGE
    public GameObject pressEText;          // press E UI

    private void Start()
    {
        // hide press e
        if (pressEText != null)
        {
            pressEText.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;

            if (pressEText != null)
            {
                pressEText.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;

            if (pressEText != null)
            {
                pressEText.SetActive(false);
            }
        }
    }

    private void Update()
    {
        // E entererd 
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            lightManager.StartLightingUp();

            if (pressEText != null)
            {
                pressEText.SetActive(false);
            }
        }
    }
}
