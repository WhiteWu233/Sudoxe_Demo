using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Schedule_Day3 : MonoBehaviour
{
    public Vector3 Day3classTime01;
    public Vector3 Day3classTime02;
    public Vector3 Day3classTime03;
    public TextMeshProUGUI Day3class01;
    public TextMeshProUGUI Day3class02;
    public TextMeshProUGUI Day3class03;
    public float Day3_classTimeSum01; // calculate the sum of the time of class 01
    public float Day3_classTimeSum02; // calculate the sum of the time of class 02
    public float Day3_classTimeSum03; // calculate the sum of the time of class 02

    // Start is called before the first frame update
    void Start()
    {
        Day3classTime01 = new Vector3(10, 0, 1); // first class at 9 am, in classroom01, the third vector is the 
        Day3classTime02 = new Vector3(15, 0, 2);
        Day3classTime03 = new Vector3(19, 0, 3);

        Day3class01.text = "Class01 in classroom01 at 10:00am";
        Day3class02.text = "Class02 in classroom02 at 1:00pm";
        Day3class03.text = "Class03 in classroom03 at 8:00pm";

        Day3_classTimeSum01 = Day3classTime01.x * 60 + Day3classTime01.y; // calculate class time sum of class01
        Day3_classTimeSum02 = Day3classTime02.x * 60 + Day3classTime02.y; // calculate class time sum of class02
        Day3_classTimeSum03 = Day3classTime03.x * 60 + Day3classTime03.y; // calculate class time sum of class02
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
