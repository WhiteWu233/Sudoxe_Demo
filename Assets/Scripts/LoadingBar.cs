using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    public TextMeshProUGUI loadingBar_text; 
    private Image loadingbar;
    private Clock clock;
    public int cd;
    // Start is called before the first frame update
    void Start()
    {
        loadingBar_text.gameObject.SetActive(false);
        clock = FindObjectOfType<Clock>();
        loadingbar.fillAmount = 0;
        cd = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (clock.isLoading)
        {
            loadingBar_text.gameObject.SetActive(true);
            loadingbar.fillAmount += Time.deltaTime / cd;
        }

        else
        {
            loadingBar_text.gameObject.SetActive(false);
            loadingbar.fillAmount = 0;
        }
    }
}
