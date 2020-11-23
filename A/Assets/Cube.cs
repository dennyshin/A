using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float moveSpeed;
    public float moveTime;

    public Vector3 newPosition;

    void Start()
    {
        newPosition = transform.position;

        moveSpeed = 0.35f;
        moveTime = 4.5f;
    }

    void Update()
    {
        HandleMovementInput();
    }

    void HandleMovementInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            newPosition += (transform.forward * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            newPosition += (transform.forward * -moveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            newPosition += (transform.right * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            newPosition += (transform.right * -moveSpeed);
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * moveTime);
    }
}
