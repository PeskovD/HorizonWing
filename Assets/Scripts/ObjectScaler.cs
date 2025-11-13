using UnityEngine;

public class ObjectScaler : MonoBehaviour
{
    public Transform player;               
    public float triggerDistance = 10f;     
    public float maxScaleMultiplier = 2f;   
    public float scaleSpeed = 2f;           

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (player == null) return;
        float distance = Vector3.Distance(player.position, transform.position);
        float t = Mathf.InverseLerp(triggerDistance, 0f, distance);
        float targetScale = Mathf.Lerp(1f, maxScaleMultiplier, t);
        transform.localScale = Vector3.Lerp(transform.localScale, originalScale * targetScale, Time.deltaTime * scaleSpeed);
    }
}
