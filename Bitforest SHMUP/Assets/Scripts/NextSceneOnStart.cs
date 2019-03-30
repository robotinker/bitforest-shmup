using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneOnStart : MonoBehaviour
{
    void Start()
    {
        var currentIndex = SceneManager.GetActiveScene().buildIndex;
        var nextLevelIndex = currentIndex + 1;
        SceneManager.LoadScene(nextLevelIndex);
    }
}
