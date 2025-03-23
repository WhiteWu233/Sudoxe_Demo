using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.position = new Vector3(100, 100, 100);
            Debug.Log("isWorking");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       
    }
}
