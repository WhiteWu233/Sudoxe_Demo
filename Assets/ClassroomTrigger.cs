using UnityEngine;

public class ClassroomTrigger : MonoBehaviour
{
    private InteractionManager interactionManager;
    private Clock clock;
    private bool isEntered;

    private void Start()
    {
        interactionManager = FindObjectOfType<InteractionManager>();  // 获取提示管理器
        clock = FindObjectOfType<Clock>();
        isEntered = false;
    }

    void Update()
    {
        if (isEntered && Input.GetKeyDown(KeyCode.F))
        {
            clock.hourAdvanced();
            Debug.Log("isWorking");
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // 检查是否是玩家进入
        {
            //interactionManager.hintText.gameObject.SetActive(true);  // 显示提示文本
            Debug.Log("isEntered");

            isEntered = true;
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))  // 检查是否是玩家离开
        {
            //interactionManager.hintText.gameObject.SetActive(false);  // 隐藏提示文本
        }
    }
}
