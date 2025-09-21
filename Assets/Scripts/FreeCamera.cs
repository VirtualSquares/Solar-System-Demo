using UnityEngine;
using UnityEngine.InputSystem;

public class FreeCamera : MonoBehaviour
{
    public float moveSpeed = 200f;  
    public float lookSpeed = 30f;
    public Vector3 startPosition = new Vector3(0, 50, -100);

    float yaw = 0f;
    float pitch = 0f;

    void Start()
    {
        transform.position = startPosition;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();
        yaw += mouseDelta.x * lookSpeed * Time.deltaTime;
        pitch -= mouseDelta.y * lookSpeed * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, -89f, 89f);
        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);

        Vector3 move = Vector3.zero;
        if (Keyboard.current.wKey.isPressed) move += transform.forward;
        if (Keyboard.current.sKey.isPressed) move -= transform.forward;
        if (Keyboard.current.aKey.isPressed) move -= transform.right;
        if (Keyboard.current.dKey.isPressed) move += transform.right;

        transform.position += move.normalized * moveSpeed * Time.deltaTime;
    }
}
