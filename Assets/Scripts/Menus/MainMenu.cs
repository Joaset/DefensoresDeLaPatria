using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            AudioManager.Instance.PlayAudio(AudioManager.Instance.menuMusic);
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
        AudioManager.Instance.StopAudio(AudioManager.Instance.menuMusic);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Choose()
    {
        SceneManager.LoadScene(3);
    }
}
