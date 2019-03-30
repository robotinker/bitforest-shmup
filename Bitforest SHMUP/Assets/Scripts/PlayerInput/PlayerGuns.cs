using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGuns : AppResourceMonoBehaviour
{
    void Update()
    {
        if (InputState == InputState.World && Input.GetAxis("Fire1") > 0)
        {
            var guns = GetComponentsInChildren<ProjectileLauncher>();
            foreach (var gun in guns)
            {
                gun.Shoot();
            }
        }
    }
}
