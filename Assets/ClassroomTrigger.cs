using UnityEngine;

public class ClassroomTrigger : MonoBehaviour
{
    private InteractionManager interactionManager;

    private void Start()
    {
        interactionManager = FindObjectOfType<InteractionManager>();  // ��ȡ��ʾ������
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // ����Ƿ�����ҽ���
        {
            interactionManager.hintText.gameObject.SetActive(true);  // ��ʾ��ʾ�ı�
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))  // ����Ƿ�������뿪
        {
            interactionManager.hintText.gameObject.SetActive(false);  // ������ʾ�ı�
        }
    }
}
