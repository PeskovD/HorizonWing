using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour
{
    public CharacterController controller;

    public float walkBobSpeed = 5f;
    public float sprintBobSpeed = 9f;

    public float walkBobAmount = 0.015f;
    public float sprintBobAmount = 0.03f;

    public float horizontalAmount = 0.01f;
    public float smooth = 8f;

    private Vector3 startPos;
    private float timer;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void LateUpdate()
    {
        float speed = controller.velocity.magnitude;

        if (speed > 0.1f && controller.isGrounded)
        {
            bool sprinting = Input.GetKey(KeyCode.LeftShift);

            float bobSpeed = sprinting ? sprintBobSpeed : walkBobSpeed;
            float bobAmount = sprinting ? sprintBobAmount : walkBobAmount;

            timer += Time.deltaTime * bobSpeed;

            float bobY = Mathf.Sin(timer) * bobAmount;
            float bobX = Mathf.Cos(timer * 0.5f) * horizontalAmount;

            Vector3 target = startPos + new Vector3(bobX, bobY, 0);

            transform.localPosition = Vector3.Lerp(
                transform.localPosition,
                target,
                Time.deltaTime * smooth
            );
        }
        else
        {
            timer = 0;

            transform.localPosition = Vector3.Lerp(
                transform.localPosition,
                startPos,
                Time.deltaTime * smooth
            );
        }
    }
}
