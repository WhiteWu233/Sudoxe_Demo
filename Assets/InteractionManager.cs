using UnityEngine;
using TMPro;

public class InteractionManager : MonoBehaviour
{
    public TextMeshProUGUI hintText;  // ��ʾ�ı�
    private GameClock gameClock;
    private bool canInteract = false; // �Ƿ���Խ��н���
    private float hintDuration = 60f;  // ��ʾ�ı�����ʱ�䣨��λ�����ӣ�
    private float hintStartTime = -1f; // ��¼��ʾ�ı���ʼ��ʾ��ʱ��

    private void Start()
    {
        gameClock = FindObjectOfType<GameClock>();
        hintText.gameObject.SetActive(false); // ��ʼ������ʾ�ı�
    }

    void Update()
    {
        if (hintStartTime >= 0f)  // �����ʾ�ı�������ʾ
        {
            if ((gameClock.GetCurrentHour() * 60 + gameClock.GetCurrentMinute()) - hintStartTime >= hintDuration)
            {
                hintText.gameObject.SetActive(false);  // ������ʾ�ı�
                hintStartTime = -1f; // ����ʱ��
                canInteract = false; // ������Ч
            }
        }
        else
        {
            // ��⵱ǰʱ���Ƿ�Ӧ����ʾ��ʾ�ı�
            CheckForClassroomInteraction();
        }

        // �� F ������ʱ����ת
        if (canInteract && Input.GetKeyDown(KeyCode.F))
        {
            gameClock.AdvanceTime(1.5f);  // ��ת 1.5 Сʱ
            hintText.gameObject.SetActive(false);  // ���� F ����������ʾ�ı�
            hintStartTime = -1f;  // ������ɣ������ʾʱ��
            canInteract = false;  // ������Ч��ֱ���´δ���
        }
    }

    private void CheckForClassroomInteraction()
    {
        int currentHour = gameClock.GetCurrentHour();
        int currentMinute = gameClock.GetCurrentMinute();

        if ((currentHour == 9 && currentMinute == 0) ||
            (currentHour == 13 && currentMinute == 0) ||
            (currentHour == 15 && currentMinute == 0))
        {
            ShowHint();
        }
    }

    private void ShowHint()
    {
        hintText.text = "Press F to attend class";
        hintText.gameObject.SetActive(true);
        hintStartTime = gameClock.GetCurrentHour() * 60 + gameClock.GetCurrentMinute();
        canInteract = true; // ������
    }
}
