using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Schedule_Manager : MonoBehaviour
{
    public Vector3 classTime01;
    public Vector3 classTime02;
    public Vector3 classTime03;
    public TextMeshProUGUI class01;
    public TextMeshProUGUI class02;
    public TextMeshProUGUI class03;
    // Start is called before the first frame update
    void Start()
    {
        classTime01 = new Vector3(9,0,1); // first class at 9 am, in classroom01, the third vector is the 
        classTime02 = new Vector3(13,0,2);
        classTime03 = new Vector3(17,0,3);

        class01.text = "Class01 in classroom01 at 9:00am";
        class02.text = "Class02 in classroom02 at 1:00pm";
        class03.text = "Class03 in classroom03 at 5:00pm";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
