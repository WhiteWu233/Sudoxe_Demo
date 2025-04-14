using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Maze_trigger01 : MonoBehaviour
{
    private int ran;

    // Start is called before the first frame update
    void Start()
    {
        ran = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.DeleteKey("Count");
            Debug.Log("Delete!");
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            ran = Random.Range(0, 7);
           

            if(ran >= 3) // random number
            {

                onCount();
                loadMaze01();
                
            }
            
        }
    }

    public void loadMaze01()
    {
        int mazeCount = PlayerPrefs.GetInt("Count",2);
        SceneManager.LoadScene(mazeCount);
        Debug.Log(mazeCount);
    }

   

    public void onCount()
    {
        int mazeCount = PlayerPrefs.GetInt("Count", 2);
        PlayerPrefs.SetInt("Count", mazeCount + 1);

    }
}
