using UnityEngine;
using System.Collections;

public class Lever : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip leverSound;
    [SerializeField] private Collider leverCollider;
    [SerializeField] private Outline outline;

    public int leverID;
    public LeverPuzzleManager puzzle;

    private bool isPulled = false;
    private Coroutine disableRoutine;

    public void Interact(GameObject interactor)
    {
        if (isPulled) return;

        isPulled = true;
        outline.enabled = false;

        animator.ResetTrigger("ReverseLever");
        animator.SetTrigger("PullLever");

        if (audioSource && leverSound)
            audioSource.PlayOneShot(leverSound);

        if (puzzle != null)
            puzzle.LeverPulled(leverID);

        disableRoutine = StartCoroutine(DisableColliderAfterPull());
    }

    private IEnumerator DisableColliderAfterPull()
    {
        yield return new WaitForSeconds(1.2f);

        if (leverCollider != null)
            leverCollider.enabled = false;

        disableRoutine = null;
    }

    public void ReverseLever()
    {
        if (disableRoutine != null)
        {
            StopCoroutine(disableRoutine);
            disableRoutine = null;
        }

        animator.ResetTrigger("PullLever");
        animator.SetTrigger("ReverseLever");

        isPulled = false;

        outline.enabled = true;

        if (leverCollider != null)
            leverCollider.enabled = true;

        StartCoroutine(ResetToIdleAfterReverse());
    }

    private IEnumerator ResetToIdleAfterReverse()
    {
        yield return new WaitForSeconds(1.0f);

        animator.Play("Idle", 0, 0f);
    }
}
