using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    public TextMeshProUGUI loadingBar_text;
    public Image loadingbar_image;
    private Clock clock;
    private InteractionManager manager;
    public int cd;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<InteractionManager>();
        loadingBar_text.gameObject.SetActive(false);
        clock = FindObjectOfType<Clock>();
        loadingbar_image.fillAmount = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (manager.isLoading)// if the player press F, the loading bar start loading, timer stop, the 
        {

            manager.hintText.gameObject.SetActive(false);
            loadingBar_text.gameObject.SetActive(true);
            loadingbar_image.fillAmount += 0.005f;

           
        }

        if (loadingbar_image.fillAmount == 1)
        {
            clock.hourAdvanced();
            
            manager.isLoading = false;

        }

        if (!manager.isLoading)
        {
            loadingBar_text.gameObject.SetActive(false);
            loadingbar_image.fillAmount = 0;
        }

    }
}
