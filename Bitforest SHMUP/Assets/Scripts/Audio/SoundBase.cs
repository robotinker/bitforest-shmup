using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundBase : MonoBehaviour
{
    public List<AudioClip> Sounds;

    AudioSource Source;

    protected virtual void Start()
    {
        Source = GetComponent<AudioSource>();
    }

    protected void PlaySound()
    {
        Source.clip = Sounds[Random.Range(0, Sounds.Count)];
        Source.Play();
    }
}
