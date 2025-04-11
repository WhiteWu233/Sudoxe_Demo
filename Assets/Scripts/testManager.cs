using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testManager : MonoBehaviour
{
    private Clock clock;
    public bool testTest;
    // Start is called before the first frame update
    void Start()
    {
        clock = FindObjectOfType<Clock>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void testCount()
    {
        if (clock.daycount % 7 == 0)
        {
            testTest = true;
        }

          

    }

}
