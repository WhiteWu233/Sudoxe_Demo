using UnityEngine;
using UnityEngine.UI;

public class ScheduleUI : MonoBehaviour
{
    public GameObject schedulePanel;
    public Button logoButton;
    void Start()
    {
        logoButton.onClick.AddListener(ToggleSchedule);
        schedulePanel.SetActive(false);

        void ToggleSchedule()
        {
            schedulePanel.SetActive(!schedulePanel.activeSelf);
        }
    }
}
