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
    public float classTimeSum01; // calculate the sum of the time of class 01
    public float classTimeSum02; // calculate the sum of the time of class 02
    public float classTimeSum03; // calculate the sum of the time of class 02
    private Clock clock;
    // Start is called before the first frame update
    void Start()
    {
        clock = FindObjectOfType<Clock>();
        classTime01 = new Vector3(9, 0, 1); // first class at 9 am, in classroom01, the third vector is the 
        classTime02 = new Vector3(12, 0, 2);
        classTime03 = new Vector3(17, 0, 3);

        class01.text = "Class01 in classroom01 at 9:00am";
        class02.text = "Class02 in classroom02 at 12:00pm";
        class03.text = "Class03 in classroom03 at 5:00pm";

        classTimeSum01 = classTime01.x * 60 + classTime01.y; // calculate class time sum of class01
        classTimeSum02 = classTime02.x * 60 + classTime02.y; // calculate class time sum of class02
        classTimeSum03 = classTime03.x * 60 + classTime03.y; // calculate class time sum of class02

    }

    // Update is called once per frame
    void Update()
    {

    }

     
   
}
