using UnityEngine;

public class WrongContainerTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Cube"))
        {
            GameManager.Instance.ShowFailure(
                other.gameObject);
        }
    }
}