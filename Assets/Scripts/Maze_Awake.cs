using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze_Awake : MonoBehaviour
{
    private Clock clock;
    // Start is called before the first frame update
    void Start()
    {
        clock = FindObjectOfType<Clock>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
           clock.Load();
           Debug.Log("IsLoad!");

        }
    }
}
