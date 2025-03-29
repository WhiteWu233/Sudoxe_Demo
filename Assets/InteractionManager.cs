using UnityEngine;
using TMPro;

public class InteractionManager : MonoBehaviour
{
    public TextMeshProUGUI hintText;  // 提示文本
    private Clock clock;
    public Transform player;
    public bool canInteract = false; // 是否可以进行交互
    public bool isLoading;
    private Schedule_Manager schedule_manager;
    private ClassroomTrigger trigger;
    private ClassroomTrigger02 trigger02;
    private int timeSum;
    private float classTimeSum01; // calculate the sum of the time of class 01
    private float classTimeSum02; // calculate the sum of the time of class 02
    private float classTimeSum03; // calculate the sum of the time of class 02


    private void Start()
    {
        isLoading = false;
        trigger = FindObjectOfType<ClassroomTrigger>();
        schedule_manager = FindObjectOfType<Schedule_Manager>();
        trigger02 = FindObjectOfType<ClassroomTrigger02>();
        clock = FindObjectOfType<Clock>();
        hintText.gameObject.SetActive(false); // 初始隐藏提示文本
        classTimeSum01 = schedule_manager.classTime01.x * 60 + schedule_manager.classTime01.y; // calculate class time sum of class01
        classTimeSum02 = schedule_manager.classTime02.x * 60 + schedule_manager.classTime02.y; // calculate class time sum of class02
        classTimeSum03 = schedule_manager.classTime03.x * 60 + schedule_manager.classTime03.y; // calculate class time sum of class02


        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        timeSum = clock.hour * 60 + clock.minutes;
        classroom_access(); // check for class time
        schedule_minues();

       
       
        if (canInteract)
        {
           

            if (Input.GetKeyDown(KeyCode.F))
            {
                isLoading = true;
                

            }

            hintText.gameObject.SetActive(true);  // 显示提示文本

        }

        else
        {
            hintText.gameObject.SetActive(false);//disabled the text
        }
       
    }

  
    private void ShowHint()
    {
        hintText.text = "Press F to attend class";
        
    }

    private void classroom_access()
    {
        if (Mathf.Abs(timeSum - classTimeSum01) <= 15) // check for classroom01 time, if the time is in the 15 mintues range, enable classroom enter
            
        {
            if (trigger.isEntered_classroom01)// check is player entered classroom01 collider box
            {
               
               canInteract = true; // can take class01

            }   

        }

        if (Mathf.Abs(timeSum - classTimeSum02) <= 15) // check for classroom02 time, if the time is in the 15 mintues range, enable classroom enter
        {
            
            if (trigger02.isEntered_classroom02)// check is player entered classroom02 collider box
            {
                Debug.Log(canInteract);
                canInteract = true; // can take class02

            }

        }

      

    }

    private void schedule_minues() // after 15 minutes of class, classroom interaction disable
    {
        if (timeSum - classTimeSum01 >= 15)
        {
            schedule_manager.class01.gameObject.SetActive(false);
            
        }

        if (timeSum - classTimeSum02 >= 15)
        {
            schedule_manager.class02.gameObject.SetActive(false);
            
        }

        if (timeSum - classTimeSum03 >= 15)
        {
            schedule_manager.class03.gameObject.SetActive(false);
            
        }

    }
}
