using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    public Light flashlight;

    public AudioSource audioSource;   
    public AudioClip toggleSound;     

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight.enabled = !flashlight.enabled;

            // Play sound
            if (audioSource != null && toggleSound != null)
            {
                audioSource.PlayOneShot(toggleSound);
            }
        }
    }
}
