using UnityEngine;
using TMPro;

public class InteractionManager : MonoBehaviour
{
    public TextMeshProUGUI hintText;  // 提示文本
    private Clock clock;
    public Transform player;
    private bool canInteract = false; // 是否可以进行交互
    private bool canInteractClass01 = false;// can interact with the classroom01
    private bool canInteractClass02 = false;// can interact with the classroom02
    private bool canInteractClass03 = false;// can interact with the classroom03
    public bool isLoading;
    private Schedule_Manager schedule_manager;
    private ClassroomTrigger trigger;
    private int timeSum;
    private float classTimeSum01; // calculate the sum of the time of class 01
    private float classTimeSum02; // calculate the sum of the time of class 02


    private void Start()
    {
        isLoading = false;
        trigger = FindObjectOfType<ClassroomTrigger>();
        schedule_manager = FindObjectOfType<Schedule_Manager>();
        clock = FindObjectOfType<Clock>();
        hintText.gameObject.SetActive(false); // 初始隐藏提示文本
        classTimeSum01 = schedule_manager.classTime01.x * 60 + schedule_manager.classTime01.y; // calculate class time sum
        classTimeSum02 = schedule_manager.classTime02.x * 60 + schedule_manager.classTime02.y; // calculate class time sum

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        timeSum = clock.hour * 60 + clock.minutes;
        classroom_access(); // check for class time
        schedule_minues();

        if (canInteractClass01)
        {
            hintText.gameObject.SetActive(true);  // 显示提示文本

            if (Input.GetKeyDown(KeyCode.F))
            {
                isLoading = true;
            }
           
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
        if (Mathf.Abs(timeSum - classTimeSum01) <= 15)
        {
            if (trigger.isEntered_classroom)
            {
                Debug.Log("isEntered");
                if (player.transform.position.x <= -320 && player.transform.position.x >= 350) // check for classroom by comparing the building position with the player position, classroom01 is between X: (2, 22)
                {
                    Debug.Log("isWorking");
                    canInteractClass01 = true;
                }
                    
            }   

        }

    }

    private void schedule_minues()
    {
        if (timeSum - classTimeSum01 >= 15)
        {
            schedule_manager.class01.gameObject.SetActive(false);
        }
    }
}
