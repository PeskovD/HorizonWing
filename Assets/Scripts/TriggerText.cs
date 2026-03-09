using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TriggerText : MonoBehaviour
{
    public GameObject canvasObject;   // Drag your Canvas or Text object here
    public float displayTime = 3f;

    private bool triggered = false;

    void Start()
    {
        canvasObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;
            StartCoroutine(ShowCanvas());
        }
    }

    IEnumerator ShowCanvas()
    {
        canvasObject.SetActive(true);

        yield return new WaitForSeconds(displayTime);

        canvasObject.SetActive(false);

        // disable trigger permanently
        GetComponent<Collider>().enabled = false;
    }
}
