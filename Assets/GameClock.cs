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

        while (timer >= 60f) // �����ۻ�ʱ�䣬ȷ��ʱ�䲻������
        {
            timer -= 60f;
            minute++;

            if (minute >= 60)
            {
                minute = 0;
                hour++;

                if (hour >= 24)
                {
                    hour = 6; // ������߼���ÿ�������6�㿪ʼ
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
                hour = 6; // ȷ��ʱ�䲻�ᳬ��24Сʱ
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

        timer = 0f; // **�ؼ��޸ģ����� `Update()` ����������ת���ʱ��**
        UpdateClockText();
    }
}
