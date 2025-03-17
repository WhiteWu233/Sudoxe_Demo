using UnityEngine;
using TMPro;

public class GameClock : MonoBehaviour
{
    public TextMeshProUGUI clockText; 
    private int year = 2025;
    private int month = 1;
    private int day = 4;
    private int hour = 6;
    private int minute = 0;

    private float gameTimeSpeed = 200f;
    private float timer = 0f;

    private bool isNewDay = false;

    void Start()
    {
        UpdateClockText();
    }

    void Update()
    {
        timer += Time.deltaTime * gameTimeSpeed;

        while (timer >= 60f) 
        {
            timer -= 60f;
            minute++;

            if (minute >= 60)
            {
                minute = 0;
                hour++;

                if (hour >= 24)
                {
                    hour = 6; 
                    day++;

                    if (day > 30)
                    {
                        day = 1;
                        month++;

                        if (month > 12)
                        {
                            month = 1;
                            year++;
                        }
                    }

                    
                    if (hour == 8)
                    {
                        isNewDay = true;
                    }
                }
            }
        }

        UpdateClockText();

       
        if (isNewDay)
        {
            isNewDay = false; 
            OnNewDay(); 
        }
    }

    void UpdateClockText()
    {
        clockText.text = $"{year}.{month:D2}.{day:D2} {hour:D2}:{minute:D2}";
    }

    public int GetCurrentHour()
    {
        return hour;
    }

    public int GetCurrentMinute()
    {
        return minute;
    }

    public void AdvanceTime(float hours)
    {
        int totalMinutes = Mathf.FloorToInt(hours * 60);
        minute += totalMinutes;

        while (minute >= 60)
        {
            minute -= 60;
            hour++;

            if (hour >= 24)
            {
                hour = 6; 
                day++;

                if (day > 30)
                {
                    day = 1;
                    month++;

                    if (month > 12)
                    {
                        month = 1;
                        year++;
                    }
                }
            }
        }

        timer = 0f; 
        UpdateClockText();
    }

    
    private void OnNewDay()
    {
        
        DailyTaskManager.Instance.UpdateDailyTasks();
    }
}
