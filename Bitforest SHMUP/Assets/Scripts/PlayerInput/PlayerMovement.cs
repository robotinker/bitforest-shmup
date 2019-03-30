using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : AppResourceMonoBehaviour
{
    public float Speed = 3f;

    void Start()
    {
        
    }

    void Update()
    {
        if (InputState == InputState.World)
        {
            HandleInput();
        }
    }

    void HandleInput()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        transform.position += new Vector3(horizontalInput, verticalInput, 0f) * Speed * Time.deltaTime;
    }
}
