using UnityEngine.UI;
using TMPro;
using UnityEngine;
using System.Collections;

public class KEYPAD : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI Ans;
    [SerializeField] private Animator Door;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip correctSound;
    [SerializeField] private AudioClip wrongSound;

    public string Answer = "1977";

    public void Number(int number)
    {
        if (Ans.text.Length < 4)
        {
            Ans.text += number.ToString();
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

            audioSource.PlayOneShot(correctSound);

            Door.SetBool("Open", true); // open door
        }
        else
        {
            Ans.text = "WRONG";
            audioSource.PlayOneShot(wrongSound);
        }
    }
}
