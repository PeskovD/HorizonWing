using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image icon;
    
    private Item _item;
    private InventoryUI _inventoryUI;

    private void Start()
    {
        icon.preserveAspect = true;
    }

    public void SetItem(Item item)
    {
        _item = item;
        
        icon.sprite = item.Icon;
        icon.enabled = true;
    }
    
    public void ClearSlot()
    {
        _item = null;
        
        icon.sprite = null;
        icon.enabled = false;
    }
    
    public void UseItem()
    {
        if (_item != null && _item is ReadableItem item)
        {
            _inventoryUI.Inventory.ReadItem(item);
        }
    }
    
    public void SetInventoryUIReference(InventoryUI inventoryUI)
    {
        _inventoryUI = inventoryUI;
    }
}
