using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schedule_dayControl : MonoBehaviour
{
    private Clock clock;

    
    // Start is called before the first frame update
    void Start()
    {
        clock = FindObjectOfType<Clock>();
  

    }

    // Update is called once per frame
    void Update()
    {
        if (clock.daystring == 1)
        {
            //GetComponent<Schedule_Day2>().enabled = false;
        }

        if (clock.daystring == 2)
        {
           
        }


    }

    public void Day1Control()
    {

    }

}
