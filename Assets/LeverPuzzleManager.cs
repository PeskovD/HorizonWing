using UnityEngine;
using System.Collections;

public class LeverPuzzleManager : MonoBehaviour
{
    public int[] correctOrder = { 0, 1, 2, 3 };
    private int[] playerOrder = new int[4];
    private int inputCount = 0;

    public Animator doorAnimator;
    public AudioSource audioSource;
    public AudioClip correctSound;
    public AudioClip wrongSound;

    public Lever[] levers;

    public void LeverPulled(int leverID)
    {
        playerOrder[inputCount] = leverID;
        inputCount++;

        if (inputCount < 4)
            return;

        bool sequenceCorrect = true;

        for (int i = 0; i < 4; i++)
        {
            if (playerOrder[i] != correctOrder[i])
            {
                sequenceCorrect = false;
                break;
            }
        }

        if (sequenceCorrect)
        {
            if (audioSource && correctSound)
                audioSource.PlayOneShot(correctSound);

            if (doorAnimator)
                doorAnimator.SetTrigger("Open");

            Debug.Log("Puzzle solved correctly!");
        }
        else
        {
            if (audioSource && wrongSound)
                audioSource.PlayOneShot(wrongSound);

            Debug.Log("Puzzle solved incorrectly!");
            StartCoroutine(ReverseAllLevers());
        }

        inputCount = 0;
    }

    private IEnumerator ReverseAllLevers()
    {
        yield return new WaitForSeconds(0.2f);

        foreach (Lever lever in levers)
        {
            if (lever != null)
                lever.ReverseLever();
        }
    }
}
