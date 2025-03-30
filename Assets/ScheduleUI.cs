using UnityEngine;
using UnityEngine.UI;

public class ScheduleUI : MonoBehaviour
{
    public GameObject schedulePanel;      
    public GameObject scheduleTablePanel; 
    public Button logoButton;             

    void Start()
    {
        logoButton.onClick.AddListener(ToggleSchedule);
        schedulePanel.SetActive(false);
        scheduleTablePanel.SetActive(false);
    }

    void ToggleSchedule()
    {
        bool isActive = !schedulePanel.activeSelf; 
        schedulePanel.SetActive(isActive);
        scheduleTablePanel.SetActive(isActive);
    }
}
