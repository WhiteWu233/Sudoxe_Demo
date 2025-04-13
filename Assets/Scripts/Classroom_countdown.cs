using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Classroom_countdown : MonoBehaviour
{
    public float countdownTime;
    public TextMeshProUGUI time;
    // Start is called before the first frame update
    void Start()
    {
        countdownTime = 10;
        
    }

    // Update is called once per frame
    void Update()
    {
        countdownTime -= Time.deltaTime;
        time.SetText(" " + countdownTime);

        if (countdownTime <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
