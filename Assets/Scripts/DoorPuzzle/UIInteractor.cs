using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIInteractor : MonoBehaviour
{
    public float distance = 3f;

    [SerializeField] private Image crosshair;
    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color uiColor = Color.cyan;

    void Update()
    {
        crosshair.color = normalColor;
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        int uiLayerMask = 1 << LayerMask.NameToLayer("UI");

        if (Physics.Raycast(ray, out hit, distance, uiLayerMask))
        {
            crosshair.color = uiColor;
  
            if (Keyboard.current.eKey.wasPressedThisFrame)
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
