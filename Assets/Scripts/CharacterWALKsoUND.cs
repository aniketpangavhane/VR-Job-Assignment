using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FootstepSound : MonoBehaviour
{
    public AudioClip footstepClip;

    public float stepInterval = 0.5f;

    private AudioSource audioSource;
    private CharacterController controller;

    private float timer;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (controller != null &&
            controller.isGrounded &&
            controller.velocity.magnitude > 0.1f)
        {
            timer += Time.deltaTime;

            if (timer >= stepInterval)
            {
                audioSource.PlayOneShot(footstepClip);
                timer = 0f;
            }
        }
        else
        {
            timer = 0f;
        }
    }
}