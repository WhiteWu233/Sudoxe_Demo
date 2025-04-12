using UnityEngine;
using UnityEngine.UI;

public class Therapy : MonoBehaviour
{
    public GameObject therapy_UI;             
    public Button therapy_button;             
    public Button notNowButton;               
    public Button takeTherapyButton;          

    void Start()
    {
        therapy_button.onClick.AddListener(OnTherapyButtonClick);
        notNowButton.onClick.AddListener(OnNotNowClick);
        takeTherapyButton.onClick.AddListener(OnTakeTherapyClick);

        therapy_UI.SetActive(false); 
    }

    public void OnTherapyButtonClick()
    {
        
        therapy_UI.SetActive(!therapy_UI.activeInHierarchy);
    }

    public void OnNotNowClick()
    {
       
        therapy_UI.SetActive(false);
    }

    public void OnTakeTherapyClick()
    {
       
        Debug.Log("Take Therapy clicked.");
    }
}
