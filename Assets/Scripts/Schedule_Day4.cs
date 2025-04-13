using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Schedule_Day4 : MonoBehaviour
{
    public Vector3 Day4classTime01;
    public Vector3 Day4classTime02;
    public Vector3 Day4classTime03;
    public TextMeshProUGUI Day4class01;
    public TextMeshProUGUI Day4class02;
    public TextMeshProUGUI Day4class03;

    public float Day4_classTimeSum01; // calculate the sum of the time of class 01 of day2
    public float Day4_classTimeSum02; // calculate the sum of the time of class 02 of day2
    public float Day4_classTimeSum03; // calculate the sum of the time of class 02 of day2
    // Start is called before the first frame update
    void Start()
    {
        Day4classTime01 = new Vector3(9, 0, 1); // first class at 9 am, in classroom01, the third vector is the 
        Day4classTime02 = new Vector3(13, 0, 2);
        Day4classTime03 = new Vector3(17, 0, 3);

        Day4class01.text = "Class01 in classroom01 at 10:00am";
        Day4class02.text = "Class02 in classroom02 at 1:00pm";
        Day4class03.text = "Class03 in classroom03 at 8:00pm";

        Day4_classTimeSum01 = Day4classTime01.x * 60 + Day4classTime01.y; // calculate class time sum of class01
        Day4_classTimeSum02 = Day4classTime02.x * 60 + Day4classTime02.y; // calculate class time sum of class02
        Day4_classTimeSum03 = Day4classTime03.x * 60 + Day4classTime03.y; // calculate class time sum of class02
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
