using UnityEngine;

public class SunMovement : MonoBehaviour
{
    public float rotationSpeed = 5f;

    void Start()
    {
        Debug.Log("Sun has started spinning");
    }

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
