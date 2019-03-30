using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class SpawnOnDeath : MonoBehaviour
{
    public GameObject ObjectToSpawn;

    private void Awake()
    {
        var health = GetComponentInChildren<Health>();
        if (health != null)
        {
            health.OnDeath += HandleDeath;
        }
    }

    void HandleDeath()
    {
        Instantiate(ObjectToSpawn, transform.position, transform.rotation);
    }
}
