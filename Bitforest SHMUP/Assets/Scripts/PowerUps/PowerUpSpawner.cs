using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : AppResourceMonoBehaviour
{

  public float Min = 3;
  public float Max = 6;
  public float SpawnYMargin = 1;
  public List<GameObject> PowerUps;
  void Start()
  {
    StartCoroutine(SpawnRoutine());
  }

  IEnumerator SpawnRoutine()
  {
    yield return new WaitForSeconds(Random.Range(Min, Max));
    yield return new WaitUntil(() => InputState == InputState.World);
    var randomPowerUp = PowerUps[Random.Range(0, PowerUps.Count)];
    var worldWidth = ScreenTopRight.x - ScreenBottomLeft.x;
    var x = ScreenBottomLeft.x + worldWidth * Random.Range(0.1f, 0.9f);
    var y = ScreenTopRight.y + SpawnYMargin;
    var newPowerUp = Instantiate(randomPowerUp, new Vector3(x, y, 0), Quaternion.identity);

    StartCoroutine(SpawnRoutine());
  }

}
