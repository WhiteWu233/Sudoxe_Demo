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
    private InteractionManager interactionManager;
    public Image gun;
    
    // Start is called before the first frame update
    void Start()
    {
        gun.gameObject.SetActive(false);
        interactionManager = FindObjectOfType<InteractionManager>();
        clock = FindObjectOfType<Clock>();
        button.onClick.AddListener(ButtonOnClick);
        
    }

    // Update is called once per frame
    void Update()
    {
;      if (interactionManager.classCredit == 3)
        {
            gun.gameObject.SetActive(true);
        }
    }

    void ButtonOnClick()
    {
        daycheck.SetActive(false);
        clock.dayAdvanced();
    }
}
