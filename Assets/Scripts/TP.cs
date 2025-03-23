using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Target;
    private bool canTeleport = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canTeleport && Input.GetKeyDown(KeyCode.F))
        {
            if (Target != null)
            {
                transform.position = Target.position;
            }
            else
            {
                Debug.LogWarning("no Target");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canTeleport = true;
            Debug.Log("F tp");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canTeleport = false;
            Debug.Log("out range");
        }
    }
}
