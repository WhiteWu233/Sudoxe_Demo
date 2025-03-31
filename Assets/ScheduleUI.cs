using UnityEngine;
using UnityEngine.UI;

public class ScheduleUI : MonoBehaviour
{
    public GameObject schedulePanel;      
    public GameObject scheduleTablePanel; 
    public Button logoButton;             

    void Start()
    {
        logoButton.onClick.AddListener(ButtonOnClick);
        schedulePanel.SetActive(true);
        scheduleTablePanel.SetActive(false);
    }

    void update()
    {
       
    }

    void ButtonOnClick()
    {
        if (scheduleTablePanel.activeInHierarchy)
        {
            scheduleTablePanel.SetActive(false);
            schedulePanel.SetActive(false);
        }

        else
        {
            scheduleTablePanel.SetActive(true);
            schedulePanel.SetActive(true);
        }

    }
}
