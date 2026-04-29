using UnityEngine;

public class EnableArea : MonoBehaviour
{
    [SerializeField] private GameObject[] parentObjects;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetParentsActive(true);
        }
    }

    void SetParentsActive(bool state)
    {
        foreach (GameObject parent in parentObjects)
        {
            if (parent != null)
            {
                parent.SetActive(state);
            }
        }
    }
}