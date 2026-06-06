using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CubeHoverEffect : MonoBehaviour
{
    XRGrabInteractable grabInteractable;

    Vector3 originalScale;

    private void Awake()
    {
        grabInteractable =
            GetComponent<XRGrabInteractable>();

        originalScale =
            transform.localScale;
    }

    private void OnEnable()
    {
        grabInteractable.hoverEntered.AddListener(OnHoverEnter);
        grabInteractable.hoverExited.AddListener(OnHoverExit);
    }

    private void OnDisable()
    {
        grabInteractable.hoverEntered.RemoveListener(OnHoverEnter);
        grabInteractable.hoverExited.RemoveListener(OnHoverExit);
    }

    private void OnHoverEnter(HoverEnterEventArgs args)
    {
        Debug.Log("HOVER ENTER");

        transform.localScale =
            originalScale * 1.3f;
    }

    private void OnHoverExit(HoverExitEventArgs args)
    {
        Debug.Log("HOVER EXIT");

        transform.localScale =
            originalScale;
    }
}