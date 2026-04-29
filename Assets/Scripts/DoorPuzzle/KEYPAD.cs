using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class KEYPAD : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI Ans;
    [SerializeField] private Animator Door;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip correctSound;
    [SerializeField] private AudioClip wrongSound;

    public string Answer = "A7B4C2D6";

    public void Input(string value)
    {
        if (Ans.text.Length < 8)
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
        if (Ans.text == Answer)
        {
            Ans.text = "Correct";

            if (audioSource != null && correctSound != null)
                audioSource.PlayOneShot(correctSound);

            if (Door != null)
                Door.SetBool("Open", true);
        }
        else
        {
            Ans.text = "WRONG";

            if (audioSource != null && wrongSound != null)
                audioSource.PlayOneShot(wrongSound);
        }
    }
}