using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppResourceMonoBehaviour : MonoBehaviour
{
    protected InputState InputState
    {
        get
        {
            return App.Instance.CurrentInputState;
        }
        set
        {
            App.Instance.CurrentInputState = value;
        }
    }

    protected Health PlayerHealth { get { return App.Instance.Player?.GetComponentInChildren<Health>(); } }
    protected WaveSpawner WaveSpawner { get { return App.Instance.WaveSpawner; } }

    protected Vector3 ScreenBottomLeft { get { return App.Instance.ScreenBottomLeft; } }
    protected Vector3 ScreenTopRight { get { return App.Instance.ScreenTopRight; } }

    protected string LayerNameEnemy { get { return "Enemy"; } }
}
