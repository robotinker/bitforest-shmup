using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : AppResourceMonoBehaviour
{
    public AudioClip Music;

    AudioSource Source;

    void Start()
    {
        Source = GetComponent<AudioSource>();
        Source.clip = Music;
        Source.Play();
        Source.loop = true;

        WaveSpawner.OnLevelComplete += HandleLevelEnd;
        PlayerHealth.OnDeath += HandleLevelEnd;
    }

    void HandleLevelEnd()
    {
        Source.Stop();
    }
}
