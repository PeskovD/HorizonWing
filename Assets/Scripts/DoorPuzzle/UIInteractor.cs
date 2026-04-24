using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIInteractor : MonoBehaviour
{
    public float distance = 3f;

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            int uiLayerMask = 1 << LayerMask.NameToLayer("UI");

            if (Physics.Raycast(ray, out hit, distance, uiLayerMask))
            {
                Button button = hit.collider.GetComponent<Button>();

                if (button != null)
                {
                    button.onClick.Invoke();
                }
            }
        }
    }
}
