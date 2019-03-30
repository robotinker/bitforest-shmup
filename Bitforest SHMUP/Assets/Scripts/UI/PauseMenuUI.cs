using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuUI : MonoBehaviour
{
    public Canvas PauseCanvas;

    InputState PreviousState = InputState.World;
    bool WasPausePressed;

    private void Start()
    {
        PauseCanvas.enabled = false;
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(PauseCanvas.gameObject);
    }

    void Update()
    {
        if (Input.GetAxis("Pause") > 0)
        {
            if (WasPausePressed)
                return;

            WasPausePressed = true;

            if (App.Instance.CurrentInputState == InputState.Pause)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
        }
        else
        {
            WasPausePressed = false;
        }
    }

    void Pause()
    {
        PreviousState = App.Instance.CurrentInputState;
        App.Instance.CurrentInputState = InputState.Pause;
        PauseCanvas.enabled = true;
        Time.timeScale = 0.01f;
    }

    void Unpause()
    {
        App.Instance.CurrentInputState = PreviousState;
        PauseCanvas.enabled = false;
        Time.timeScale = 1f;
    }
}
