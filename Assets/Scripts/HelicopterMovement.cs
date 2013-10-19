using UnityEngine;
using System.Collections;

public class HelicopterMovement : MonoBehaviour {

    public float speed = 5f;
    public float screenOffset = 0.1f;
    public float rotateSpeed = 10f;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            MoveForward();
        if (Input.GetKey(KeyCode.A))
            MoveLeft();
        if (Input.GetKey(KeyCode.S))
            MoveBack();
        if (Input.GetKey(KeyCode.D))
            MoveRight();
        float mouseX = Input.mousePosition.x;
        float screenMouseRange = Screen.width * screenOffset;
        if (mouseX <= screenMouseRange)
            RotateLeft();
        if (mouseX >= Screen.width - screenMouseRange)
            RotateRight();
    }

    private void MoveRight()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);
    }

    private void MoveLeft()
    {
        transform.Translate(Vector3.right * -speed * Time.deltaTime, Space.Self);
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }

    private void MoveBack()
    {
        transform.Translate(Vector3.forward* -speed * Time.deltaTime, Space.Self);
    }

    private void RotateRight()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }

    private void RotateLeft()
    {
        transform.Rotate(Vector3.up, -rotateSpeed * Time.deltaTime);
    }
}
