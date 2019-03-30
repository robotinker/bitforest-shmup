using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetup : MonoBehaviour
{
    void Awake()
    {
        App.Instance.MakeNewPlayer();
        App.Instance.WaveSpawner = GetComponentInChildren<WaveSpawner>();
    }
}
