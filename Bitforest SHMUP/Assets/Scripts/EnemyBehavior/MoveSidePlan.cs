using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSidePlan : AppResourceMonoBehaviour
{
    public AnimationCurve Plan;

    void Update()
    {
        var worldWidth = ScreenTopRight.x - ScreenBottomLeft.x;
        var worldHeight = ScreenTopRight.y - ScreenBottomLeft.y;
        var proportionDown = (ScreenTopRight.y - transform.position.y) / worldHeight;
        var newX = ScreenBottomLeft.x + worldWidth * Plan.Evaluate(proportionDown);
        transform.position += Vector3.right * (newX - transform.position.x);
    }
}
