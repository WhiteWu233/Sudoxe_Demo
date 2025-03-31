using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schedule_dayControl : MonoBehaviour
{
    private Clock clock;
    public GameObject Day1;
    public GameObject Day2;
    
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
            GetComponent<Schedule_Day2>().enabled = false;
            Day2.SetActive(false);
        }

        if (clock.daystring == 2)
        {
            Day1.SetActive(false);
            Day2.SetActive(true);
            GetComponent<Schedule_Manager>().enabled = false;
            GetComponent<Schedule_Day2>().enabled = true;

        }


    }

    public void Day1Control()
    {

    }

}
