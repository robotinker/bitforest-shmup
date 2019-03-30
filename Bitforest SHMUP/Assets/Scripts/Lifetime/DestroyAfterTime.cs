using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float DeathTimer = 1f;

    void Start()
    {
        StartCoroutine(DestroySelfAfterTime());
    }

    IEnumerator DestroySelfAfterTime()
    {
        yield return new WaitForSeconds(DeathTimer);
        Destroy(gameObject);
    }
}
