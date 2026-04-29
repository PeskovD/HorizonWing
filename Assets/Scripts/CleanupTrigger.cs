using UnityEngine;

public class CleanupTrigger : MonoBehaviour
{
    [SerializeField] private Transform[] parentObjects;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetChildrenActive(false);
        }
    }

    void SetChildrenActive(bool state)
    {
        foreach (Transform parent in parentObjects)
        {
            if (parent == null) continue;

            foreach (Transform child in parent.GetComponentsInChildren<Transform>(true))
            {
                if (child != parent)
                {
                    child.gameObject.SetActive(state);
                }
            }
        }
    }
}