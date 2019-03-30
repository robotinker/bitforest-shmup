using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveSchedule", menuName = "Bitforest Invaders/Level", order = 1)]
public class WaveSchedule : ScriptableObject
{
    public List<Wave> Waves;
}
