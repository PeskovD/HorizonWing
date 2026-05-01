using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerRaycast : MonoBehaviour
{

    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private Camera playerCamera;

    public GameObject interactText;
    public float interactionDistance = 3f;
    public LayerMask layers;


    [SerializeField] private Image crosshair;
    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color interactColor = Color.green;

    private InputAction _interactAction;

    private void Awake()
    {
        _interactAction = playerInput.actions["Interact"];

        if (playerCamera == null)
            playerCamera = Camera.main;
    }

    private void Update()
    {
        interactText.SetActive(false);
        crosshair.color = normalColor; 

        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance, layers))
        {

            crosshair.color = interactColor;

            if (hit.collider.TryGetComponent(out IInteractable interactable))
            {
                interactText.SetActive(true);

                if (_interactAction.WasPressedThisFrame())
                {
                    interactable.Interact(playerObject);
                }
            }
        }
    }
}