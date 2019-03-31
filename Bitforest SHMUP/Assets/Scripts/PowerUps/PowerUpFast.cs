using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFast : AppResourceMonoBehaviour
{

  // TODO:
  // Make spawner from WaveSpawner
  public GameObject Projectile;
  public float CooldownDecrease = 0.8f;
  private void OnTriggerEnter2D(Collider2D collision)
  {

    var guns = collision.gameObject.transform.parent.GetComponentsInChildren<ProjectileLauncher>();
    foreach (var gun in guns)
    {
      gun.Cooldown *= CooldownDecrease;
      gun.Projectile = Projectile;
      Debug.Log(gun.Cooldown);

    }
    Destroy(gameObject);
  }

}
