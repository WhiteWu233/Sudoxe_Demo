using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Schedule_Day5 : MonoBehaviour
{
    public Vector3 Day5classTime01;
    public Vector3 Day5classTime02;
    public Vector3 Day5classTime03;
    public TextMeshProUGUI Day5class01;
    public TextMeshProUGUI Day5class02;
    public TextMeshProUGUI Day5class03;

    public float Day5_classTimeSum01; // calculate the sum of the time of class 01 of day2
    public float Day5_classTimeSum02; // calculate the sum of the time of class 02 of day2
    public float Day5_classTimeSum03; // calculate the sum of the time of class 02 of day2
    // Start is called before the first frame update
    void Start()
    {
        Day5classTime01 = new Vector3(9, 0, 1); // first class at 9 am, in classroom01, the third vector is the 
        Day5classTime02 = new Vector3(13, 0, 2);
        Day5classTime03 = new Vector3(17, 0, 3);

        Day5class01.text = "Class01 in classroom01 at 10:00am";
        Day5class02.text = "Class02 in classroom02 at 1:00pm";
        Day5class03.text = "Class03 in classroom03 at 8:00pm";

        Day5_classTimeSum01 = Day5classTime01.x * 60 + Day5classTime01.y; // calculate class time sum of class01
        Day5_classTimeSum02 = Day5classTime02.x * 60 + Day5classTime02.y; // calculate class time sum of class02
        Day5_classTimeSum03 = Day5classTime03.x * 60 + Day5classTime03.y; // calculate class time sum of class02
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
