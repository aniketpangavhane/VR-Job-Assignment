using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
public class CubeFallSound : MonoBehaviour
{
    public AudioClip fallSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 1f)
        {
            if (fallSound != null)
            {
                audioSource.PlayOneShot(fallSound);
            }
        }
    }
}