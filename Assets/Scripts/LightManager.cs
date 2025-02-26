using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public List<Light> lights;
    public float lightUpInterval = 1f;

    private void Start()
    {
        foreach (Light light in lights)
        {
            light.enabled = false;
        }
    }

    public void StartLightingUp()
    {
        StartCoroutine(LightUpSequence());
    }

    private IEnumerator LightUpSequence()
    {
        int halfCount = lights.Count / 2;

        for (int i = 0; i < halfCount; i++)
        {
            lights[i].enabled = true;

            lights[lights.Count - 1 - i].enabled = true;

            yield return new WaitForSeconds(lightUpInterval);
        }

        // if odd
        if (lights.Count % 2 != 0)
        {
            lights[halfCount].enabled = true;
        }
    }
}
