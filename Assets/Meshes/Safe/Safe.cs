using UnityEngine;
using System.Collections;

public class Safe : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip openSound;
    [SerializeField] private Collider safeCollider;
    [SerializeField] private Outline outline;
    private bool isOpen = false;

    public void Interact(GameObject interactor)
    {
        if (isOpen) return;

        isOpen = true;

        outline.enabled = false;

        animator.SetTrigger("OpenSafe");

        if (audioSource != null && openSound != null)
        {
            audioSource.PlayOneShot(openSound);
        }


        StartCoroutine(DisableColliderAfterOpen());
    }

    private IEnumerator DisableColliderAfterOpen()
    {
        yield return new WaitForSeconds(1.2f); 

        if (safeCollider != null)
            safeCollider.enabled = false;


        this.enabled = false;
    }
}
