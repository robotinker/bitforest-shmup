using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Wave
{
    public GameObject Formation;
    public float Delay;
    [Range(0f,1f)]
    public float SpawnLocation;
}
