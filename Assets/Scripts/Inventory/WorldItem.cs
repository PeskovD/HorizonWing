using UnityEngine;

public class WorldItem : MonoBehaviour, IInteractable
{
    [field: SerializeField] public Item Item { get; private set; }
    [SerializeField] private AudioClip pickupSound;
    private AudioSource audioSource;

    private void Start()
    {
        name = Item.ItemName;

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void Interact(GameObject caller)
    {
        if (caller.TryGetComponent(out Inventory inventory))
        {
            inventory.AddItem(Item);

            if (pickupSound != null)
            {
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            }

            Destroy(gameObject);
        }
    }
}
