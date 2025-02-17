using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableLight : MonoBehaviour
{
    public Light lightSource; 
    public Text interactText; 
    private bool isPlayerNear = false;

    void Start()
    {
        if (interactText != null)
        {
            interactText.enabled = false; 
        }
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            ToggleLight();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            if (interactText != null)
            {
                interactText.text = "Press E";
                interactText.enabled = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            if (interactText != null)
            {
                interactText.enabled = false;
            }
        }
    }

    void ToggleLight()
    {
        if (lightSource != null)
        {
            lightSource.enabled = !lightSource.enabled; 
        }
    }
}