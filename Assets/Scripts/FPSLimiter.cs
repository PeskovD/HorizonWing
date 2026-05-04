using UnityEngine;

public class FPSLimited : MonoBehaviour
{
    void Start()
    {
        QualitySettings.vSyncCount = 0; 
        Application.targetFrameRate = 60; 
    }
}
