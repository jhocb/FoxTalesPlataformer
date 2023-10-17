using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Climbing;

public class footsetpsController : MonoBehaviour
{
    public AudioClip[] footstepSounds;
    public AudioSource audioSource;

    public float runningPitch = 2.0f; // Default value for running pitch
    public float walkingPitch = 1.35f; // Default value for walking pitch

    private bool isAudioPlaying = false;

    private InputCharacterController inputController; // Reference to InputCharacterController

    void Start()
    {
        inputController = GetComponent<InputCharacterController>(); // Get the reference
    }

    public void PlayRandomFootstepSound()
{
    if (audioSource != null && audioSource.isActiveAndEnabled)
    {
        int randomIndex = Random.Range(0, footstepSounds.Length);
        audioSource.clip = footstepSounds[randomIndex];
        audioSource.pitch = inputController.run ? runningPitch : walkingPitch; // Set the pitch based on run variable
        audioSource.Play();
        isAudioPlaying = true;
    }
}

    void StopFootstepSound()
    {
        audioSource.Stop();
        isAudioPlaying = false;
    }

    void Update()
    {
        if (inputController != null)
        {
            if (inputController.movement.magnitude > 0.9f && !isAudioPlaying)
            {
                PlayRandomFootstepSound(); // No need to pass pitch here
            }
            else if (inputController.movement.magnitude <= 0.9f && isAudioPlaying)
            {
                StopFootstepSound();
            }
        }
    }
}
