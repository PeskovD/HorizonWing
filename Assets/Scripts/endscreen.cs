using UnityEngine;
using TMPro;

public class endscreen : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] public TextMeshProUGUI Ans;
    [SerializeField] private GameObject endingCanvas;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip correctSound;
    [SerializeField] private AudioClip wrongSound;

    public string Answer = "YES";

    private bool hasEnded = false;

    public void Input(string value)
    {
        if (Ans.text.Length < 3)
        {
            Ans.text += value;
        }
    }

    public void Reset()
    {
        Ans.text = "";
    }

    public void Enter()
    {
        if (hasEnded) return;

        if (Ans.text.ToUpper() == Answer)
        {
            hasEnded = true;

            Ans.text = "ACCEPTED";

            if (audioSource != null && correctSound != null)
                audioSource.PlayOneShot(correctSound);

            StartCoroutine(EndSequence());
        }
        else
        {
            Ans.text = "DENIED";

            if (audioSource != null && wrongSound != null)
                audioSource.PlayOneShot(wrongSound);
        }
    }

    private System.Collections.IEnumerator EndSequence()
    {
        yield return new WaitForSeconds(1f);

        AudioListener.pause = true;

        Time.timeScale = 0f;

        if (endingCanvas != null)
            endingCanvas.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}