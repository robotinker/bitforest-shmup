using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnDeath : AppResourceMonoBehaviour
{
    public float Delay;

    private void Awake()
    {
        var health = GetComponentInChildren<Health>();
        if (health != null)
        {
            health.OnDeath += HandleDeath;
        }
    }

    void HandleDeath()
    {
        StartCoroutine(HandleDeathRoutine());
    }

    IEnumerator HandleDeathRoutine()
    {
        InputState = InputState.Pause;
        var sprite = GetComponentInChildren<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.enabled = false;

            var blinker = GetComponentInChildren<BlinkWhenDamaged>();
            if (blinker != null)
            {
                blinker.enabled = false;
            }
        }

        yield return new WaitForSeconds(Delay);

        InputState = InputState.World;
        var currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.UnloadSceneAsync(currentIndex);
        SceneManager.LoadSceneAsync(currentIndex);
    }
}
