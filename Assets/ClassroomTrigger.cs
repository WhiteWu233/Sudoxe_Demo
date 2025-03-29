using UnityEngine;

public class ClassroomTrigger : MonoBehaviour
{
    private Clock clock;
    public bool isEntered_classroom01; // enter collider box
    private Schedule_Manager manager;

    private void Start()
    {
        manager = FindObjectOfType<Schedule_Manager>();
        clock = FindObjectOfType<Clock>();
        isEntered_classroom01 = false;
    }

    void Update()
    {

    }
    private void OnTriggerEnter(Collider other) // 现在的思路，根据vector3的z值，在固定时间开启相对应的collider box可以解决问题
    {
        if (other.CompareTag("Player"))  // 检查是否是玩家进入collider box
        {
            isEntered_classroom01 = true;
           
        }

    }

   
}
