using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 10f, 0);
    public Quaternion fixedRotation = Quaternion.Euler(80f, 0f, 0f);

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
            transform.rotation = fixedRotation;
        }
    }
}
