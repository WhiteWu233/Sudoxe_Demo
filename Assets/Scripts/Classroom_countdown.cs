using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Classroom_countdown : MonoBehaviour
{
    public float countdownTime;
    public TextMeshProUGUI time;
    public Image score_canvas;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        button.gameObject.SetActive(false);
        score_canvas.gameObject.SetActive(false);
        countdownTime = 30;
        
    }

    // Update is called once per frame
    void Update()
    {
        countdownTime -= Time.deltaTime;
        time.SetText(" " + countdownTime);

        if (countdownTime <= 0)
        {
            score_canvas.gameObject.SetActive(true);
            button.gameObject.SetActive(true);
        }
    }
}
