using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed;
    public float moveTime;

    public Vector3 newPosition;

    void Start()
    {
        newPosition = transform.position;

        moveSpeed = 0.25f;
        moveTime = 10f;
    }

    void Update()
    {
        HandleMovementInput();
    }

    void HandleMovementInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            newPosition += (transform.forward * moveSpeed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            newPosition += (transform.forward * -moveSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            newPosition += (transform.right * moveSpeed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition += (transform.right * -moveSpeed);
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * moveTime);
    }
}
