using UnityEngine;

public class ClassroomTrigger02 : MonoBehaviour
{
    private Clock clock;
    public bool isEntered_classroom02; // enter classroom 01
    private Schedule_Manager manager;

    private void Start()
    {
        manager = FindObjectOfType<Schedule_Manager>();
        clock = FindObjectOfType<Clock>();
        isEntered_classroom02 = false;
    }

    void Update()
    {
      

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // 检查是否是玩家进入
        {

            isEntered_classroom02 = true;

        }

    }

   
}
