using System;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public Action OnShoot;

    public GameObject Projectile;
    public float LaunchSpeed = 3;
    public float Cooldown = 0.4f;
    float CooldownTimer = 0f;

    bool CanShoot => CooldownTimer <= 0f;

    private void Update()
    {
        if (!CanShoot)
        {
            CooldownTimer -= Time.deltaTime;
        }
    }

    public void Shoot()
    {
        if (!CanShoot)
            return;

        var newBullet = Instantiate(Projectile, transform.position, transform.rotation);
        var rigidBody = newBullet.GetComponent<Rigidbody2D>();
        if (rigidBody != null)
        {
            rigidBody.velocity = transform.up * LaunchSpeed;
        }
        CooldownTimer = Cooldown;
        OnShoot?.Invoke();
    }
}
