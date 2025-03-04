using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    private float timeSpend = 0;
    private int hour = 8;
    private int minutes = 0;
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

     
        time.text = $"{hour:D2}:{minutes:D2}";
    }

    IEnumerator Timer()
    {
        while (!check)
        {
            timeSpend += Time.deltaTime * timeSpeed;
            hourCheck();
            minutes = (int)timeSpend;
            yield return new WaitForSeconds(hour);
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

    public void hourAdvanced()
    {
        hour++;
    }
}
