using UnityEngine;

public interface IInteractable
{
	public void Interact(GameObject caller);
	void EnableOutline(bool enable);
}
