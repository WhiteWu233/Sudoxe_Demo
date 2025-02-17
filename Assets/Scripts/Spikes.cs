using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Splines.Interpolators;

public class Spikes : MonoBehaviour
{
    [SerializeField] float yMin = -2.8f;
    [SerializeField] float yMax = -1f;
    [SerializeField] float currentPosition;
    [SerializeField] float startDelay;
    [SerializeField] RoomManager roomManager;
    private float speed;
    [SerializeField] bool movingUp = true;
    [SerializeField] bool go = false;
    public bool touchedByWall = false;

    void Start()
    {
        currentPosition = yMin;
        StartCoroutine("delayStart");
    }

    void Update()
    {
        speed = roomManager.spikeSpeed;
        currentPosition = transform.position.y;
        if (go)
        {
            if (currentPosition >= yMax * 1.05f)
            {
                movingUp = false;
            }
            if (currentPosition <= yMin * .95f)
            {
                movingUp = true;
            }
            if (movingUp && touchedByWall == false)
            {
                transform.position = new Vector3(transform.position.x,
                    Mathf.Lerp(currentPosition, yMax, speed * 4 * Time.deltaTime),
                    transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x,
                    Mathf.Lerp(currentPosition, yMin, speed * .5f * Time.deltaTime),
                    transform.position.z);
            }
        }
    }

    IEnumerator delayStart()
    {
        yield return new WaitForSeconds(startDelay);
        go = true;
    }
}
