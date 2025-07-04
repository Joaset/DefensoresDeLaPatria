using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    void Start()
    {
        AudioManager.Instance.PlayAudio(AudioManager.Instance.menuMusic);
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            AudioManager.Instance.StopAudio(AudioManager.Instance.menuMusic);
            SceneManager.LoadScene(0);
        }
    }
}
