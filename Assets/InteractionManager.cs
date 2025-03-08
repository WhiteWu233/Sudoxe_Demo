using UnityEngine;
using TMPro;

public class InteractionManager : MonoBehaviour
{
    public TextMeshProUGUI hintText;  // 提示文本
    private Clock clock;
    private bool canInteract = false; // 是否可以进行交互
    private Schedule_Manager schedule_manager;
    private ClassroomTrigger trigger;
    private int timeSum;
    private float classTimeSum01; // calculate the sum of the time of class 01


    private void Start()
    {
        trigger = FindObjectOfType<ClassroomTrigger>();
        schedule_manager = FindObjectOfType<Schedule_Manager>();
        clock = FindObjectOfType<Clock>();
        hintText.gameObject.SetActive(false); // 初始隐藏提示文本
        classTimeSum01 = schedule_manager.classTime01.x * 60 + schedule_manager.classTime01.y; // calculate class time sum
    }

    void Update()
    {
        timeSum = clock.hour * 60 + clock.minutes;
 
        classroom_access();

        if (canInteract)
        {
            hintText.gameObject.SetActive(true);  // 显示提示文本

            if (trigger.isEntered && Input.GetKeyDown(KeyCode.F))
            {
                clock.hourAdvanced();
                clock.isLoading = false;
            }
        }

        else
        {
            hintText.gameObject.SetActive(false);
        }
       
    }

  
    private void ShowHint()
    {
        hintText.text = "Press F to attend class";
        
        canInteract = true; // 允许交互
    }

    private void classroom_access()
    {
        if (Mathf.Abs(timeSum - classTimeSum01) <= 15)
        {
            canInteract = true;

        }

        else
        {
            canInteract = false;
        }
    }
}
