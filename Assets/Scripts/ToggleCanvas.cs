using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCanvas : MonoBehaviour
{
    public GameObject canvasObject;
    public GameObject canvasObject2;
    public FirstPersonController playerController; 

    private bool isCanvasActive = false;

    void Start()
    {
        canvasObject.SetActive(false);
        canvasObject2.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isCanvasActive = !isCanvasActive;

           
            canvasObject.SetActive(isCanvasActive);
            canvasObject2.SetActive(isCanvasActive);


            if (playerController != null)
                playerController.enabled = !isCanvasActive;

         
            Cursor.lockState = isCanvasActive ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = isCanvasActive;
        }
    }
}
