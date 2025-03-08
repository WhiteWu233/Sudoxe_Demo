using UnityEngine;

public class ClassroomTrigger : MonoBehaviour
{
    private Clock clock;
    public bool isEntered;

    private void Start()
    {
        clock = FindObjectOfType<Clock>();
        isEntered = false;
    }

    void Update()
    {
      

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // 检查是否是玩家进入
        {
                  
            isEntered = true;
           
        }

    }

   
}
