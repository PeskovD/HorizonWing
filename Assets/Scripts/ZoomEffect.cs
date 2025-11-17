using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ZoomEffect : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    public float zoomSpeed = 60f;
    private bool zoomingOut = false;

    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            zoomingOut = false;

            if (vcam.m_Lens.FieldOfView > 45)
            {
                vcam.m_Lens.FieldOfView -= zoomSpeed * Time.deltaTime;
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            zoomingOut = true;
        }

        if (zoomingOut)
        {
            if (vcam.m_Lens.FieldOfView < 70)
            {
                vcam.m_Lens.FieldOfView += zoomSpeed * Time.deltaTime;
            }
        }
    }
}
