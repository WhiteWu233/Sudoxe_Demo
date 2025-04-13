using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schedule_dayControl : MonoBehaviour
{
    private Clock clock;
    public GameObject Day1;
    public GameObject Day2;
    public GameObject Day3;
    public GameObject Day4;
    public GameObject Day5;
    // Start is called before the first frame update
    void Start()
    {
        clock = FindObjectOfType<Clock>();
        

    }

    // Update is called once per frame
    // daystring control the daily schedule and weekly quiz system, add a 2week/month string to control the exam system
    void Update()
    {
        if (clock.daystring == 1)
        {
            GetComponent<Schedule_Day2>().enabled = false;
            GetComponent<Schedule_Day3>().enabled = false;
            Day2.SetActive(false);
            Day3.SetActive(false);
            Day4.SetActive(false);
            Day5.SetActive(false);
        }

        if (clock.daystring == 2)
        {
            Day1.SetActive(false);
            Day3.SetActive(false);
            Day4.SetActive(false);
            Day5.SetActive(false);
            Day2.SetActive(true);
            GetComponent<Schedule_Manager>().enabled = false;
            GetComponent<Schedule_Day2>().enabled = true;
            GetComponent<Schedule_Day3>().enabled = false;

        }

        if (clock.daystring == 3)
        {
            Day1.SetActive(false);
            Day2.SetActive(false);
            Day3.SetActive(true);
            Day4.SetActive(false);
            Day5.SetActive(false);
            GetComponent<Schedule_Manager>().enabled = false;
            GetComponent<Schedule_Day2>().enabled = false;
            GetComponent<Schedule_Day3>().enabled = true;

        }


    }

    public void Day1Control()
    {

    }

}
