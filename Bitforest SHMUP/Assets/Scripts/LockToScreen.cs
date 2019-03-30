using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockToScreen : AppResourceMonoBehaviour
{
    public Vector2 Margin = Vector2.one;

    void Update()
    {
        Vector2 margin = Margin;
        var sprite = GetComponentInChildren<SpriteRenderer>();
        if (sprite != null)
        {
            margin *= sprite.gameObject.transform.localScale;
        }

        transform.position = new Vector3(
            Mathf.Clamp(
                transform.position.x,
                ScreenBottomLeft.x + margin.x,
                ScreenTopRight.x - margin.x),
            Mathf.Clamp(
                transform.position.y,
                ScreenBottomLeft.y + margin.y,
                ScreenTopRight.y - margin.y),
            transform.position.z);
    }
}
