using UnityEngine;
using TMPro;  
public class GameClock : MonoBehaviour
{
    public TextMeshProUGUI timeText; 
    private float gameTime; 
    private float timeMultiplier = 4.8f;

    void Start()
    {
        gameTime = 6 * 60; 
        Debug.Log("Game Start Time: " + gameTime);
    }

    void Update()
    {
        gameTime += Time.deltaTime * timeMultiplier; 
        Debug.Log("Game Time: " + gameTime); 
        UpdateClockUI();
    }

    void UpdateClockUI()
    {
        int hours = (int)(gameTime / 60) % 24;
        int minutes = (int)(gameTime % 60); 
        string timeFormat = string.Format("{0:D2}:{1:D2}", hours, minutes);
        timeText.text = timeFormat; 
    }
}
