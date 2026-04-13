using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using StarterAssets;

public class Inventory : MonoBehaviour
{
	public delegate void OnInventoryUpdated();
	public OnInventoryUpdated OnInventoryUpdatedCallback;

	[field: SerializeField] public int Capacity { get; private set; } = 12;
	[field: SerializeField] public List<Item> Items { get; private set; } = new();

	[Header("References")]
	[SerializeField] private PlayerRaycast playerRaycast;
	[SerializeField] private GameObject inventoryContainer;
	[SerializeField] private RawImage itemPopup;

	private bool _isInventoryOpen;
	private bool _isReading;

	private FirstPersonController _controller;
	private PlayerInput _playerInput;
	private InputAction _inventoryAction;
	private InputAction _interactAction;

	private void Awake()
	{
		_controller = GetComponent<FirstPersonController>();
		_playerInput = GetComponent<PlayerInput>();

		_inventoryAction = _playerInput.actions["Inventory"];
		_interactAction = _playerInput.actions["Interact"];
	}

	private void Update()
	{
		if (_inventoryAction.WasPressedThisFrame() && !_isReading)
		{
			if (_isInventoryOpen)
				CloseInventory();
			else
				OpenInventory();
		}

		if (_interactAction.WasPressedThisFrame() && _isReading)
		{
			CloseItemPopup();
		}
	}

	private void CloseInventory()
	{
		_controller.enabled = true;

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		inventoryContainer.SetActive(false);
		_isInventoryOpen = false;
	}

	private void OpenInventory()
	{
		_controller.enabled = false;

		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;

		inventoryContainer.SetActive(true);
		_isInventoryOpen = true;
	}

	public void AddItem(Item item)
	{
		Items.Add(item);
		OnInventoryUpdatedCallback?.Invoke();

		if (item is ReadableItem readableItem)
		{
			ReadItem(readableItem);
		}
	}

	public void RemoveItem(Item item)
	{
		Items.Remove(item);
		OnInventoryUpdatedCallback?.Invoke();
	}

	public void ReadItem(ReadableItem item)
	{
		itemPopup.gameObject.SetActive(true);
		itemPopup.texture = item.Image;

		Vector2 newSize = itemPopup.rectTransform.sizeDelta;

		if (item.Image.width * item.Image.height > 2500000)
		{
			float divisor = (float)item.Image.width * item.Image.height / 2500000;

			newSize.x = item.Image.width / divisor;
			newSize.y = item.Image.height / divisor;
		}
		else
		{
			newSize.x = item.Image.width;
			newSize.y = item.Image.height;
		}

		if (_isInventoryOpen)
		{
			CloseInventory();
		}

		itemPopup.rectTransform.sizeDelta = newSize;

		_isReading = true;

		_controller.enabled = false;
	}

	private void CloseItemPopup()
	{
		itemPopup.gameObject.SetActive(false);

		OpenInventory();

		_isReading = false;

		_controller.enabled = false;
	}

	public bool HasItem(Item item)
	{
		return Items.Contains(item);
	}
}