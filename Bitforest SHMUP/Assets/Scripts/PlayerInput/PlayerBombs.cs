using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBombs : AppResourceMonoBehaviour
{
    private BombsLeft bombsLeft;

    private void Start()
    {
        bombsLeft = FindObjectOfType<BombsLeft>();
    }
    void Update()
    {
        if (InputState == InputState.World && Input.GetAxis("Fire2") > 0)
        {
            bombsLeft.UseBomb();
        }
    }
}
