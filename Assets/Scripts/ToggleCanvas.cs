using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCanvas : MonoBehaviour
{
    public GameObject canvasObject;
    public FirstPersonController playerController;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip openCloseSound;

    private bool isCanvasActive = false;

    void Start()
    {
        canvasObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isCanvasActive = !isCanvasActive;

 
            if (audioSource != null && openCloseSound != null)
            {
                audioSource.PlayOneShot(openCloseSound);
            }


            canvasObject.SetActive(isCanvasActive);


            if (playerController != null)
                playerController.enabled = !isCanvasActive;


            Cursor.lockState = isCanvasActive ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = isCanvasActive;
        }
    }
}