using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] AudioSource audioSource; 

    float timeRemaining = 3599f;
    bool timerRunning = true;

    void Start()
    {
        if (audioSource != null)
        {
            audioSource.loop = true; 
            audioSource.Play();
        }
    }

    void Update()
    {
        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;

                int minutes = Mathf.FloorToInt(timeRemaining / 60);
                int seconds = Mathf.FloorToInt(timeRemaining % 60);

                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            else
            {
                timeRemaining = 0;
                timerRunning = false;
                timerText.text = "00:00";

                if (audioSource != null)
                    audioSource.Stop();

                Debug.Log("END!");
            }
        }
    }
}
