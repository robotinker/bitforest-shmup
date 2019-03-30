using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnAwake : SoundBase
{
    protected override void Start()
    {
        base.Start();
        PlaySound();
    }
}
