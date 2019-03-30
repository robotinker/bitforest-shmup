using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AutoTile : AppResourceMonoBehaviour
{
    public float Margin = 0.05f;

    public bool HasSpawnedTop;
    public bool HasSpawnedBottom;
    public bool HasSpawnedLeft;
    public bool HasSpawnedRight;

    SpriteRenderer Sprite;

    float Top { get { return Sprite.bounds.center.y + Sprite.bounds.extents.y; } }
    float Bottom { get { return Sprite.bounds.center.y - Sprite.bounds.extents.y; } }
    float Left { get { return Sprite.bounds.center.x - Sprite.bounds.extents.x; } }
    float Right { get { return Sprite.bounds.center.x + Sprite.bounds.extents.x; } }

    private void Awake()
    {
        Sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        FillGaps();
    }

    void FillGaps()
    {
        if (ScreenTopRight.x - Right > 0)
        {
            if (!HasSpawnedRight)
            {
                var newTile = Instantiate(gameObject, transform.position + Vector3.right * (Sprite.bounds.extents.x * 2 - Margin), Quaternion.identity);
                HasSpawnedRight = true;
                newTile.GetComponent<AutoTile>().HasSpawnedLeft = true;
            }
        }
        if (Left - ScreenBottomLeft.x > 0)
        {
            if (!HasSpawnedLeft)
            {
                var newTile = Instantiate(gameObject, transform.position + Vector3.left * (Sprite.bounds.extents.x * 2 - Margin), Quaternion.identity);
                HasSpawnedLeft = true;
                newTile.GetComponent<AutoTile>().HasSpawnedRight = true;
            }
        }
        if (ScreenTopRight.y - Top > 0)
        {
            if (!HasSpawnedTop)
            {
                var newTile = Instantiate(gameObject, transform.position + Vector3.up * (Sprite.bounds.extents.y * 2 - Margin), Quaternion.identity);
                HasSpawnedTop = true;
                newTile.GetComponent<AutoTile>().HasSpawnedBottom = true;
            }
        }
        if (Bottom - ScreenBottomLeft.y > 0)
        {
            if (!HasSpawnedBottom)
            {
                var newTile = Instantiate(gameObject, transform.position + Vector3.down * (Sprite.bounds.extents.y * 2 - Margin), Quaternion.identity);
                HasSpawnedBottom = true;
                newTile.GetComponent<AutoTile>().HasSpawnedTop = true;
            }
        }
    }
}
