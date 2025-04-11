using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClassroomTrigger03 : MonoBehaviour
{
    public bool isEntered_classroom03; // enter classroom 01
    // Start is called before the first frame update
    void Start()
    {
       
        isEntered_classroom03 = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // ??????????????????
        {

            isEntered_classroom03 = true;

        }

    }
}
