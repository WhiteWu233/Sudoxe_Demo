using UnityEngine;
using TMPro;

public class InteractionManager : MonoBehaviour
{
    public TextMeshProUGUI hintText;  // 提示文本
    private GameClock gameClock;
    private bool canInteract = false; // 是否可以进行交互
    private float hintDuration = 60f;  // 提示文本持续时间（单位：分钟）
    private float hintStartTime = -1f; // 记录提示文本开始显示的时间

    private void Start()
    {
        gameClock = FindObjectOfType<GameClock>();
        hintText.gameObject.SetActive(false); // 初始隐藏提示文本
    }

    void Update()
    {
        if (hintStartTime >= 0f)  // 如果提示文本正在显示
        {
            if ((gameClock.GetCurrentHour() * 60 + gameClock.GetCurrentMinute()) - hintStartTime >= hintDuration)
            {
                hintText.gameObject.SetActive(false);  // 隐藏提示文本
                hintStartTime = -1f; // 重置时间
                canInteract = false; // 交互无效
            }
        }
        else
        {
            // 检测当前时间是否应该显示提示文本
            CheckForClassroomInteraction();
        }

        // 按 F 键进行时间跳转
        if (canInteract && Input.GetKeyDown(KeyCode.F))
        {
            gameClock.AdvanceTime(1.5f);  // 跳转 1.5 小时
            hintText.gameObject.SetActive(false);  // 按下 F 键后隐藏提示文本
            hintStartTime = -1f;  // 交互完成，清除提示时间
            canInteract = false;  // 交互无效，直到下次触发
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
        canInteract = true; // 允许交互
    }
}
