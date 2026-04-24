using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadButton : MonoBehaviour
{
    public void Press()
    {
        Debug.Log("Button Pressed: " + gameObject.name);
    }
}
