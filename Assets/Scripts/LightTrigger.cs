using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LightTrigger : MonoBehaviour
{
    public LightManager lightManager;
    public GameObject pressEText;
    public Transform cameraTransform;
    public Transform playerTransform;
    public float rotationDuration = 2f;  // 摄像机旋转持续时间
    private bool isPlayerInRange = false;
    private bool isTriggered = false;          // press E UI
    public float returnDelay = 10f; // return sample scene delay

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
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E) && !isTriggered)
        {
            isTriggered = true;
            if (pressEText != null)
            {
                pressEText.SetActive(false);
            }

            StartCoroutine(RotateCameraAroundPlayer());
        }
    }

    private IEnumerator RotateCameraAroundPlayer()
    {
        float elapsedTime = 0f;
        while (elapsedTime < rotationDuration)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / rotationDuration;

            // -90
            cameraTransform.RotateAround(playerTransform.position, Vector3.up, -90f * (Time.deltaTime / rotationDuration));

            // look at player
            cameraTransform.LookAt(playerTransform);

            yield return null;
        }

        lightManager.StartLightingUp();
        StartCoroutine(ReturnToSampleScene());
    }

    // coroutine: back to sample scene 
    private IEnumerator ReturnToSampleScene()
    {
        yield return new WaitForSeconds(returnDelay);
        SceneManager.LoadScene("SampleScene");
    }
}
