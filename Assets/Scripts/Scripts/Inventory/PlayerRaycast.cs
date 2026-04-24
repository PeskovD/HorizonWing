using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRaycast : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private Camera playerCamera;

    [Header("Interaction")]
    public GameObject interactText;
    public float interactionDistance = 3f;
    public LayerMask layers;

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

        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance, layers))
        {
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