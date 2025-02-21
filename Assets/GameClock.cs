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
        if (clockText == null)
        {
            Debug.LogError("clockText 未绑定，请在 Inspector 里拖入 UI 组件！");
        }
        UpdateClockText();
    }

    void Update()
    {
        timer += Time.deltaTime * gameTimeSpeed;

        while (timer >= 60f)
        {
            timer -= 60f;
            AdvanceTime(1f / 60f);
        }
    }

    void UpdateClockText()
    {
        if (clockText != null)
        {
            clockText.text = $"{year}.{month:D2}.{day:D2}.{hour:D2}:{minute:D2}";
            Debug.Log($"当前时间：{clockText.text}");
        }
    }

    public int GetCurrentHour()
    {
        return hour;
    }

    public void AdvanceTime(float hours)
    {
        int totalMinutes = Mathf.FloorToInt(hours * 60);
        minute += totalMinutes;

        while (minute >= 60)
        {
            minute -= 60;
            hour++;
        }

        while (hour >= 24)
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

        UpdateClockText();
    }
}