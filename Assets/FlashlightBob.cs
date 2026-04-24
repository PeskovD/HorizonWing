using UnityEngine;

public class FlashlightBob : MonoBehaviour
{
    public Transform cameraTransform;

    [Range(0f, 1f)] public float bobReduction = 0.7f;

    private Vector3 initialLocalPos;

    void Start()
    {
        initialLocalPos = transform.localPosition;
    }

    void LateUpdate()
    {
        // Get camera bob movement
        Vector3 bobOffset = cameraTransform.localPosition;

        // Reduce its influence instead of adding more
        transform.localPosition = initialLocalPos + bobOffset * (1f - bobReduction);
    }
}