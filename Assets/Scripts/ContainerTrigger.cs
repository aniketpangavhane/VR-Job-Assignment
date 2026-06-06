using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ContainerTrigger : MonoBehaviour
{
    public Transform snapPoint;

    bool completed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (completed)
            return;

        if (other.CompareTag("Cube"))
        {
            completed = true;

            XRGrabInteractable grab =
                other.GetComponent<XRGrabInteractable>();

            if(grab != null)
                grab.enabled = false;

            Rigidbody rb =
                other.GetComponent<Rigidbody>();

            if(rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true;
            }

            other.transform.position =
                snapPoint.position;

            GameManager.Instance.ShowSuccess(
                other.gameObject);
        }
    }
}