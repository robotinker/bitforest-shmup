using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    public int Damage;
    public LayerMask TargetLayer;
    public bool KillSelfOnCollision = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & TargetLayer) == 0)
            return;

        var targetHealth = collision.gameObject.GetComponentInParent<Health>();
        if (targetHealth != null)
        {
            targetHealth.Damage(Damage);
        }

        if (KillSelfOnCollision)
        {
            var health = GetComponent<Health>();
            if (health == null)
            {
                Destroy(gameObject);
            }
            else
            {
                health.Damage(health.MaxHP);
            }
        }
    }
}
