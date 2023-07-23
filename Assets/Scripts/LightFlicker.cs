using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Adapted by Greg Scobie (Gangascoob) from Steve Streeting 2017 under CCO Public Domain licence

public class LightFlicker : MonoBehaviour
{
    public Light light;

    public float minIntensity = 0f;
    public float maxIntensity = 1f;
    [Range(1, 100)] public int smoothing = 5;

    Queue<float> smoothQueue;
    float lastSum = 0;

    // Start is called before the first frame update
    void Start()
    {
        smoothQueue = new Queue<float>(smoothing);
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if(light == null)
        {
            return;
        }

        while(smoothQueue.Count >= smoothing)
        {
            lastSum -= smoothQueue.Dequeue();
        }

        float newVal = Random.Range(minIntensity, maxIntensity);
        smoothQueue.Enqueue(newVal);
        lastSum += newVal;

        light.intensity = lastSum / (float)smoothQueue.Count;
    }
}
