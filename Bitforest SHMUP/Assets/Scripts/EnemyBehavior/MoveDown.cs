using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float Speed = 0.7f;

    void Update()
    {
        transform.position += Vector3.down * Speed * Time.deltaTime;
    }
}
