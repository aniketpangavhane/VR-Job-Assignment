using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
[RequireComponent(typeof(AudioSource))]
public class GrabSound : MonoBehaviour
{
    public AudioClip grabClip;

    private XRGrabInteractable grabInteractable;
    private AudioSource audioSource;

    private void Awake()
    {
        grabInteractable =
            GetComponent<XRGrabInteractable>();

        audioSource =
            GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        grabInteractable.selectEntered
            .AddListener(OnGrab);
    }

    private void OnDisable()
    {
        grabInteractable.selectEntered
            .RemoveListener(OnGrab);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        if (grabClip != null)
        {
            audioSource.PlayOneShot(grabClip);
        }
    }
}