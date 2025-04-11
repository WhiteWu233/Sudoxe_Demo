using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dayCheckButton : MonoBehaviour
{
    public GameObject daycheck;
    public Button button;
    private Clock clock;

    
    // Start is called before the first frame update
    void Start()
    {
        clock = FindObjectOfType<Clock>();
        button.onClick.AddListener(ButtonOnClick);
        
    }

    // Update is called once per frame
    void Update()
    {
;      
    }

    void ButtonOnClick()
    {
        daycheck.SetActive(false);
        clock.dayAdvanced();
    }
}
