using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip soundClip;

    public bool playOnce = true;
    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (playOnce && hasPlayed) return;

            if (audioSource != null && soundClip != null)
            {
                audioSource.PlayOneShot(soundClip);
                hasPlayed = true;
            }
        }
    }
}