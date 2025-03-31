using UnityEngine;
using TMPro;

public class InteractionManager : MonoBehaviour
{
    public TextMeshProUGUI hintText;  // ????????
    private Clock clock;
    public Transform player;
    public bool canInteract = false; // ????????????????
    public bool isLoading;
    private Schedule_Manager schedule_manager; // this is schedule day01
    private Schedule_Day2 schedule_day2;
    private ClassroomTrigger trigger;
    private ClassroomTrigger02 trigger02;
    private int timeSum;
   


    private void Start()
    {
        isLoading = false;
        trigger = FindObjectOfType<ClassroomTrigger>();
        schedule_manager = FindObjectOfType<Schedule_Manager>();
        trigger02 = FindObjectOfType<ClassroomTrigger02>();
        clock = FindObjectOfType<Clock>();
        schedule_day2 = FindObjectOfType<Schedule_Day2>();
        hintText.gameObject.SetActive(false); // ????????????????
        


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

            hintText.gameObject.SetActive(true);  // ????????????

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
        if (clock.daystring == 1) // check for day
        {
            if (Mathf.Abs(timeSum - schedule_manager.classTimeSum01) <= 15) // check for classroom01 time, if the time is in the 15 mintues range, enable classroom enter

            {
                if (trigger.isEntered_classroom01)// check is player entered classroom01 collider box
                {

                    canInteract = true; // can take class01

                }

            }

            if (Mathf.Abs(timeSum - schedule_manager.classTimeSum02) <= 15) // check for classroom02 time, if the time is in the 15 mintues range, enable classroom enter
            {

                if (trigger02.isEntered_classroom02)// check is player entered classroom02 collider box
                {
                    canInteract = true; // can take class02

                }

            }
        }

        if (clock.daystring == 2)
        {
            if (Mathf.Abs(timeSum - schedule_day2.Day2_classTimeSum01) <= 15) // check for classroom01 time, if the time is in the 15 mintues range, enable classroom enter

            {
                if (trigger.isEntered_classroom01)// check is player entered classroom01 collider box
                {

                    canInteract = true; // can take class01

                }

            }

            if (Mathf.Abs(timeSum - schedule_day2.Day2_classTimeSum02) <= 15) // check for classroom02 time, if the time is in the 15 mintues range, enable classroom enter
            {

                if (trigger02.isEntered_classroom02)// check is player entered classroom02 collider box
                {
                    canInteract = true; // can take class02

                }

            }
        }

      

      

    }

    private void schedule_minues() // after 15 minutes of class, classroom interaction disable
    {
        if (clock.daystring == 1)
        {
            if (timeSum - schedule_manager.classTimeSum01 >= 15)
            {
                schedule_manager.class01.gameObject.SetActive(false);

            }

            if (timeSum - schedule_manager.classTimeSum02 >= 15)
            {
                schedule_manager.class02.gameObject.SetActive(false);

            }

            if (timeSum - schedule_manager.classTimeSum03 >= 15)
            {
                schedule_manager.class03.gameObject.SetActive(false);

            }
        }

       /* if (clock.daystring == 2)
        {
            if (timeSum - schedule_day2.Day2_classTimeSum01 >= 15)
            {
                schedule_day2.Day2class01.gameObject.SetActive(false);

            }
        }*/

       
    }
}
