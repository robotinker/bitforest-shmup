using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(WaveSpawner))]
public class NextSceneOnLevelEnd : MonoBehaviour
{
    void Start()
    {
        GetComponent<WaveSpawner>().OnLevelComplete += HandleLevelEnd;
    }

    void HandleLevelEnd()
    {
        var currentIndex = SceneManager.GetActiveScene().buildIndex;
        var nextLevelIndex = currentIndex + 1;
        if (nextLevelIndex >= SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(App.Instance.Level1SceneIndex);
        }
        else
        {
            SceneManager.LoadScene(nextLevelIndex);
        }
    }
}
