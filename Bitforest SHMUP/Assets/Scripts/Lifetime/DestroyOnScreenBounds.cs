using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnScreenBounds : AppResourceMonoBehaviour
{
    bool WasOnScreen;
    public float Margin;

    bool IsOffScreen
    {
        get
        {
            return transform.position.x < ScreenBottomLeft.x - Margin
            || transform.position.x > ScreenTopRight.x + Margin
            || transform.position.y < ScreenBottomLeft.y - Margin
            || transform.position.y > ScreenTopRight.y + Margin;
        }
    }

    void Update()
    {
        if (!WasOnScreen)
        {
            WasOnScreen = !IsOffScreen;
        }
        else if (IsOffScreen) 
        {
            Destroy(gameObject);
        }
    }
}
