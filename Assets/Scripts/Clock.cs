using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Clock : MonoBehaviour
{
    static float timeSpend = 0;
    public int day = 4;
    public int month = 1;
    public int year = 2024;
    public int hour = 8; // initial hour set to 8
    public int minutes = 0;
    public int daystring = 1;
    public int testString = 1;
    public int daycount;
    public bool check = false;
    public TextMeshProUGUI time;
    public float timeSpeed;
    private InteractionManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<InteractionManager>();
        StartCoroutine(Timer());
        
    }

    // Update is called once per frame
    void Update()
    {
 
        time.text = $"{year:D2}/{month:D2}/{day:D2} {hour:D2}:{minutes:D2}";

        if (manager.isLoading)
        {
            StopCoroutine(Timer());
        }

    }

    IEnumerator Timer()
    {
        while (!check)
        {
            timeSpend += Time.deltaTime * timeSpeed;
            hourCheck();
            //dayCheck();
            monthCheck();
            yearCheck();
            dayString();
            minutes = (int)timeSpend;

            yield return new WaitForSeconds(0f);

           
        }
    }

    void hourCheck()
    {
        if ((int)timeSpend >= 60)
        {
            hour++;
            timeSpend = 0;
        }
    }

    /*void dayCheck()
    {
       
       
        hour = 8;
        
    }*/

    void monthCheck()
    {
        if (day == 31)
        {
            month++;
            hour = 8;
        }
    }

    void yearCheck()
    {
        if (month == 12)
        {
            year++;
            month = 1;
        }
    }

    public void dayAdvanced() // once finish class, jump to next day
    {
        day++;
        daycount++;
        daystring++;
        testString++;
        hour = 8;
    }


    public void hourAdvanced()
    {
        hour++;
    }


    public void dayString() // check for monday, tuesday..
    {
        if (daystring > 7)
        {
            daystring = 1;
        }

    }

    public void weeklyString()
    {
        daycount++;
    }




}
