using UnityEngine;

public class ClassroomTrigger : MonoBehaviour
{
    private InteractionManager interactionManager;

    private void Start()
    {
        interactionManager = FindObjectOfType<InteractionManager>();  // 获取提示管理器
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // 检查是否是玩家进入
        {
            interactionManager.hintText.gameObject.SetActive(true);  // 显示提示文本
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))  // 检查是否是玩家离开
        {
            interactionManager.hintText.gameObject.SetActive(false);  // 隐藏提示文本
        }
    }
}
