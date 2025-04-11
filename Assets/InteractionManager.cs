using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InteractionManager : MonoBehaviour
{
    public TextMeshProUGUI hintText;  // ????????
    public GameObject dayCheck;
    private Clock clock;
    public Transform player;
    public bool canInteract = false; // ????????????????
    public bool canTest = false;
    public bool isLoading;
    private Schedule_Manager schedule_manager; // this is schedule day01
    private Schedule_Day2 schedule_day2;
    private ClassroomTrigger trigger;
    private ClassroomTrigger02 trigger02;
    private ClassroomTrigger03 trigger03;
    private int timeSum;
    private testManager test;
    public int classCredit;
    public TextMeshProUGUI classTaken;

    private void Start()
    {
        test = FindObjectOfType<testManager>();
        isLoading = false;
        trigger = FindObjectOfType<ClassroomTrigger>();
        schedule_manager = FindObjectOfType<Schedule_Manager>();
        trigger02 = FindObjectOfType<ClassroomTrigger02>();
        trigger03 = FindObjectOfType<ClassroomTrigger03>();
        clock = FindObjectOfType<Clock>();
        schedule_day2 = FindObjectOfType<Schedule_Day2>();
        hintText.gameObject.SetActive(false); // ????????????????

        classCredit = 0;
        dayCheck.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        classTaken.SetText(" " + classCredit);
        timeSum = clock.hour * 60 + clock.minutes;
        classroom_access(); // check for class time
        schedule_minues();

       
       
        if (canInteract)
        {
            hintText.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                //add a if (daystring == 7) here, if true, not is loading but is taking test, teleport to the classroom scene and start taking quiz/exam
                isLoading = true;
                classCredit += 1;

            }

            hintText.gameObject.SetActive(true);  // ????????????

        }

        if (canTest)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {

                SceneManager.LoadScene(3);

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

            if (Mathf.Abs(timeSum - schedule_manager.classTimeSum03) <= 15) // check for classroom02 time, if the time is in the 15 mintues range, enable classroom enter
            {

                if (trigger03.isEntered_classroom03)// check is player entered classroom02 collider box
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

        if (clock.daystring == 3)
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

        if (clock.daystring == 4)
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

        if (clock.daystring == 5)
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

        if (clock.daystring == 6)
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

        if (clock.daystring == 7)
        {
            if (trigger.isEntered_classroom01)// check is player entered classroom01 collider box
            {

                canTest = true; // taking the exam

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
                dayCheck.SetActive(true);


            }
        }

       if (clock.daystring == 2)
        {
            if (timeSum - schedule_day2.Day2_classTimeSum01 >= 15)
            {
                schedule_day2.Day2class01.gameObject.SetActive(false);

            }


        }

       
    }
}
