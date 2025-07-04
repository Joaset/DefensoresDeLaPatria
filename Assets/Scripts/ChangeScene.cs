using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
        {
            AudioManager.Instance.PlayAudio(AudioManager.Instance.backgroundMusic);
            SceneManager.LoadScene(3);
        }
    }
}
