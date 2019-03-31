using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveSpawner : AppResourceMonoBehaviour
{
  public float SpawnYMargin = 1;
  public WaveSchedule Schedule;

  public Action OnLevelComplete;

  List<GameObject> EnemiesSpawned = new List<GameObject>();

  public void Start()
  {
    StartCoroutine(SpawnRoutine());
  }

  IEnumerator SpawnRoutine()
  {
    foreach (var wave in Schedule.Waves)
    {
      yield return new WaitForSeconds(wave.Delay);
      var worldWidth = ScreenTopRight.x - ScreenBottomLeft.x;
      var x = ScreenBottomLeft.x + worldWidth * wave.SpawnLocation;
      var y = ScreenTopRight.y + SpawnYMargin;
      var newFormation = Instantiate(wave.Formation, new Vector3(x, y, 0f), Quaternion.identity);
      foreach (var t in newFormation.GetComponentsInChildren<Transform>())
      {
        if (t.gameObject.layer == LayerMask.NameToLayer(LayerNameEnemy))
        {
          EnemiesSpawned.Add(t.gameObject);
        }
      }
    }
    yield return new WaitUntil(() => !EnemiesSpawned.Any(x => x != null));
    OnLevelComplete?.Invoke();
  }
}
