using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyChase : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;
    public float stopDistance = 0.5f;

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void Update()
    {
        if (player != null)
        {
            ChasePlayer();
        }
    }

    private void ChasePlayer()
    {
        float direction = Mathf.Sign(player.position.x - transform.position.x);
        float distance = Mathf.Abs(player.position.x - transform.position.x);

        if (distance > stopDistance)
        {
            transform.position += new Vector3(direction * speed * Time.deltaTime, 0, 0);
        }

        Vector3 lookDirection = new Vector3(player.position.x, transform.position.y, player.position.z) - transform.position;
        if (lookDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
