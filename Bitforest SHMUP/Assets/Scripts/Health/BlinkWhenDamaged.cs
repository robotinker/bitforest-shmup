using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkWhenDamaged : MonoBehaviour
{
    public float BlinkSpan = 0.1f;

    float BlinkTime;
    float BlinkTimer;
    float SubBlinkTimer;

    bool IsVisible = true;

    private void Awake()
    {
        var health = GetComponent<Health>();
        if (health != null)
        {
            health.OnDamage += HandleDamage;
            BlinkTime = health.ImmuneTime;
        }
    }

    private void Update()
    {
        if (BlinkTimer > 0)
        {
            BlinkTimer -= Time.deltaTime;

            if (BlinkTimer <= 0f)
            {
                IsVisible = true;
            }
            else
            {
                SubBlinkTimer -= Time.deltaTime;
                if (SubBlinkTimer <= 0)
                {
                    IsVisible = !IsVisible;
                    SubBlinkTimer = BlinkSpan / 2f;
                }
            }

            foreach (var r in GetComponentsInChildren<Renderer>())
            {
                r.enabled = IsVisible;
            }
        }
    }

    void HandleDamage()
    {
        BlinkTimer = BlinkTime;
    }
}
