using UnityEngine;
using TMPro;

public class DailyTaskManager : MonoBehaviour
{
    public static DailyTaskManager Instance; 
    public TMP_Text task1Text;
    public TMP_Text task2Text;
    public TMP_Text task3Text;

    private string[] classrooms = { "classroom 1", "classroom 2" };

    private void Awake()
    {
       
        if (Instance == null)
        {
            Instance = this;
        }
    }

   
    public void UpdateDailyTasks()
    {
       
        string task1Classroom = classrooms[Random.Range(0, classrooms.Length)];
        string task2Classroom = classrooms[Random.Range(0, classrooms.Length)];
        string task3Classroom = classrooms[Random.Range(0, classrooms.Length)];

       
        task1Text.text = $"Class in {task1Classroom} at 9 AM";
        task2Text.text = $"Class in {task2Classroom} at 1 PM";
        task3Text.text = $"Class in {task3Classroom} at 3 PM";

     
    }
}
