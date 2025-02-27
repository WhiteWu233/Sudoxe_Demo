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

    void Start()
    {
        UpdateClockText();
    }

    void Update()
    {
        timer += Time.deltaTime * gameTimeSpeed;

        while (timer >= 60f) // 允许累积时间，确保时间不会跳回
        {
            timer -= 60f;
            minute++;

            if (minute >= 60)
            {
                minute = 0;
                hour++;

                if (hour >= 24)
                {
                    hour = 6; // 按你的逻辑，每天从早上6点开始
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
        }

        UpdateClockText();
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
                hour = 6; // 确保时间不会超出24小时
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

        timer = 0f; // **关键修改：避免 `Update()` 立即覆盖跳转后的时间**
        UpdateClockText();
    }
}
