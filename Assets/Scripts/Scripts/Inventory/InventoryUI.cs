using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [field: Header("References")]
    [field: SerializeField] public Inventory Inventory { get; private set; }
    [SerializeField] private RectTransform contentContainer;
    [SerializeField] private GameObject slotPrefab;
    
    private readonly List<InventorySlot> _slots = new();
    
    private void Start()
    {
        Inventory.OnInventoryUpdatedCallback += UpdateUI;

        for (int i = 0; i < Inventory.Capacity; i++)
        {
            _slots.Add(Instantiate(slotPrefab, contentContainer).GetComponent<InventorySlot>());
            _slots[i].SetInventoryUIReference(this);
        }
    }

    private void UpdateUI()
    {
        for (int i = 0; i < _slots.Count; i++)
        {
            if (i < Inventory.Items.Count)
            {
                _slots[i].SetItem(Inventory.Items[i]);
            }
            else
            {
                _slots[i].ClearSlot();
            }
        }
    }
}
