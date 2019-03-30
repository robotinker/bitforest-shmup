using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{
    public static App Instance;

    public GameObject PlayerPrefab;
    public GameObject Player;

    public InputState CurrentInputState = InputState.World;

    public int Level1SceneIndex = 1;

    public Vector3 ScreenBottomLeft { get { return Camera.main.ScreenToWorldPoint(Vector3.zero); } }
    public Vector3 ScreenTopRight { get { return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)); } }

    public WaveSpawner WaveSpawner;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void MakeNewPlayer()
    {
        var playerX = ScreenBottomLeft.x + (ScreenTopRight.x - ScreenBottomLeft.x) / 2f;
        var playerY = ScreenBottomLeft.y + (ScreenTopRight.y - ScreenBottomLeft.y) / 5f;
        Player = Instantiate(PlayerPrefab, new Vector3(playerX, playerY, 0f), Quaternion.identity);
    }
}

public enum InputState
{
    World,
    Pause
}
