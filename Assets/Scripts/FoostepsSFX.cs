using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;


[RequireComponent(typeof(AudioSource))]
public class FootstepsSFX : MonoBehaviour
{
    public AudioSource audioSource;

    [Header("Audio Clips")]
    public AudioClip[] walkClips;
    public AudioClip[] sprintClips;

    [Header("Step Timing")]
    public float walkStepDelay = 0.6f;
    public float sprintStepDelay = 0.35f;

    private FirstPersonController controller;
    private CharacterController characterController;
    private StarterAssetsInputs input;

    private float stepTimer;

    void Start()
    {
        controller = GetComponent<FirstPersonController>();
        characterController = GetComponent<CharacterController>();
        input = GetComponent<StarterAssetsInputs>();
    }

    void Update()
    {
        float speed = new Vector3(characterController.velocity.x, 0, characterController.velocity.z).magnitude;

        bool isMoving = speed > 0.1f;
        bool isGrounded = controller.Grounded;
        bool isSprinting = input.sprint && isMoving;

        if (isMoving && isGrounded)
        {
            float delay = isSprinting ? sprintStepDelay : walkStepDelay;

            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0f)
            {
                PlayFootstep(isSprinting);
                stepTimer = delay;
            }
        }
        else
        {
            stepTimer = 0f;
        }
    }

    void PlayFootstep(bool sprinting)
    {
        AudioClip[] clips = sprinting ? sprintClips : walkClips;

        if (clips.Length == 0) return;

        AudioClip clip = clips[Random.Range(0, clips.Length)];
        audioSource.PlayOneShot(clip);
    }
}