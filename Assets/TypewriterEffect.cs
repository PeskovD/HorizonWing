using System.Collections;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    [System.Serializable]
    public class Line
    {
        public TextMeshProUGUI textUI;
        [TextArea] public string fullText;
    }

    [Header("Lines")]
    public Line[] lines;

    [Header("Timing")]
    public float startDelay = 0.5f;
    public float typingSpeed = 0.05f;
    public float delayBetweenLines = 0.8f;

    [Header("Audio (Optional)")]
    public AudioSource audioSource;
    public AudioClip typingSound;
    public int soundFrequency = 2;

    private void Awake()
    {

        foreach (Line line in lines)
        {
            if (line.textUI != null)
                line.textUI.text = "";
        }
    }

    private void OnEnable()
    {
        StartCoroutine(StartTyping());
    }

    IEnumerator StartTyping()
    {

        yield return new WaitForSecondsRealtime(startDelay);

        yield return StartCoroutine(PlaySequence());
    }

    IEnumerator PlaySequence()
    {
        for (int i = 0; i < lines.Length; i++)
        {
            yield return StartCoroutine(TypeLine(lines[i]));


            yield return new WaitForSecondsRealtime(delayBetweenLines);
        }

  
        yield return new WaitForSecondsRealtime(2f);
    }

    IEnumerator TypeLine(Line line)
    {
        if (line.textUI == null) yield break;

        line.textUI.text = "";

        int charIndex = 0;

        foreach (char c in line.fullText)
        {
            line.textUI.text += c;

            if (audioSource != null && typingSound != null &&
                charIndex % soundFrequency == 0 && c != ' ')
            {
                audioSource.pitch = Random.Range(0.95f, 1.05f);
                audioSource.PlayOneShot(typingSound);
            }

            charIndex++;

            yield return new WaitForSecondsRealtime(typingSpeed);
        }
    }
}
