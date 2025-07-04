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

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(6);
            }
        }
    }

    public void Play()
    {
        AudioManager.Instance.PlayAudio(AudioManager.Instance.button);
        SceneManager.LoadScene(1);
        AudioManager.Instance.StopAudio(AudioManager.Instance.menuMusic);
    }

    public void Restart()
    {
        AudioManager.Instance.StopAudio(AudioManager.Instance.lose);
        AudioManager.Instance.PlayAudio(AudioManager.Instance.button);
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        AudioManager.Instance.PlayAudio(AudioManager.Instance.button);
        Application.Quit();
    }

    public void Choose()
    {
        AudioManager.Instance.PlayAudio(AudioManager.Instance.button);
        SceneManager.LoadScene(3);
        AudioManager.Instance.PlayAudio(AudioManager.Instance.backgroundMusic);
    }
}
