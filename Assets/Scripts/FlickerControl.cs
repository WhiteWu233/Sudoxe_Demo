using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class FlickerControl : MonoBehaviour
{
    public bool isFlickering = false;
    public float timeDelay;
    public float lightMin;
    public float lightMax;
    void Update()
    {
        if (isFlickering == false)
        {
            StartCoroutine(FlickeringLight());

        }

    }

    IEnumerator FlickeringLight()
    {
        isFlickering = true;
        this.gameObject.GetComponent<Light>().intensity = Random.Range(lightMin, lightMax);
        timeDelay = Random.Range(0.01f, 0.1f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().intensity = Random.Range(lightMin, lightMax);
        timeDelay = Random.Range(0.01f, 0.1f);
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
    }
}
