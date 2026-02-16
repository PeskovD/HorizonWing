using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringSpotLight : MonoBehaviour
{
    [Header("Flicker Settings")]
    public float minIntensity = 0.2f;
    public float maxIntensity = 1.5f;
    public float flickerSpeed = 0.05f; // lower = faster flicker
    public bool randomFlicker = true;

    private Light spotLight;
    private float targetIntensity;
    private float timer;

    void Start()
    {
        spotLight = GetComponent<Light>();
        targetIntensity = spotLight.intensity;
        timer = flickerSpeed;
    }

    void Update()
    {
        if (randomFlicker)
        {
            RandomFlicker();
        }
        else
        {
            SmoothFlicker();
        }
    }

    void RandomFlicker()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            spotLight.intensity = Random.Range(minIntensity, maxIntensity);
            timer = flickerSpeed;
        }
    }

    void SmoothFlicker()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            targetIntensity = Random.Range(minIntensity, maxIntensity);
            timer = flickerSpeed;
        }

        spotLight.intensity = Mathf.Lerp(
            spotLight.intensity,
            targetIntensity,
            Time.deltaTime * 10f
        );
    }
}