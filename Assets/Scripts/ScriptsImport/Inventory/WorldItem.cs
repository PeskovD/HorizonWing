using UnityEngine;

public class WorldItem : MonoBehaviour, IInteractable
{
    [field: SerializeField] public Item Item { get; private set; }

    [Header("Outline")]
    [SerializeField] private Behaviour outline;
    // Use Behaviour so it works with ANY outline script (QuickOutline, etc.)

    private void Start()
    {
        name = Item.ItemName;

        // Ensure outline is OFF at start
        if (outline != null)
            outline.enabled = false;
    }

    public void Interact(GameObject caller)
    {
        if (caller.TryGetComponent(out Inventory inventory))
        {
            inventory.AddItem(Item);
            Destroy(gameObject);
        }
    }

    public void EnableOutline(bool enable)
    {
        if (outline != null)
            outline.enabled = enable;
    }
}
