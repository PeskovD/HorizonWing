using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    public Transform target;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;


        if (audioSource != null)
            audioSource.Play();


        CharacterController cc = other.GetComponent<CharacterController>();

        if (cc != null)
        {
            Vector3 move = target.position - other.transform.position;
            cc.Move(move);
        }
    }
}