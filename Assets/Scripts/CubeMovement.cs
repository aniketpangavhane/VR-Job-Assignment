using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float speed = 5f;
    public bool canMove = false;

    void Update()
    {
        if (!canMove)
            return;

        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            move += Vector3.forward;
        if (Input.GetKey(KeyCode.S))
            move += Vector3.back;
        if (Input.GetKey(KeyCode.A))
            move += Vector3.left;
        if (Input.GetKey(KeyCode.D))
            move += Vector3.right;
        if (Input.GetKey(KeyCode.Space))
            move += Vector3.up;
        if (Input.GetKey(KeyCode.LeftShift))
            move += Vector3.down;

        transform.Translate(move * speed * Time.deltaTime, Space.World);
    }
}