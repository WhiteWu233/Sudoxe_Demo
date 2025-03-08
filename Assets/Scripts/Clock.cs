using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Clock : MonoBehaviour
{
    private float timeSpend = 0;
    public int day = 4;
    public int month = 1;
    public int year = 2024;
    public int hour = 8; // initial hour set to 8
    public int minutes = 0;
    private bool check = false;
    public TextMeshProUGUI time;
    public float timeSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Timer());

     
        time.text = $"{year:D2}/{month:D2}/{day:D2} {hour:D2}:{minutes:D2}";
    }

    IEnumerator Timer()
    {
        while (!check)
        {
            timeSpend += Time.deltaTime * timeSpeed;
            hourCheck();
            minutes = (int)timeSpend;

            yield return new WaitForSeconds(1.2f);

           
        }
    }

    void hourCheck()
    {
        if ((int)timeSpend == 60)
        {
            hour++;
            timeSpend = 0;
        }
    }

    void dayCheck()
    {
        if (hour == 24)
        {
            day++;
            hour = 8;
        }
    }

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

    public void hourAdvanced() // for the class system
    {
        timeSpend = Mathf.Lerp(timeSpend, 60, 0.5f);
    }
}
