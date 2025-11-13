using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaSpawn : MonoBehaviour
{
    public EnemySpawn spawner;
    public GameObject[] wallsToActivate;
    public GameObject goText;

    public bool activated;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (activated) return;
        if (other.CompareTag("Player"))
        {
            activated = true;
            ActivateWalls(true);
            spawner.StartWaveSequence(OnWavesComplete);
            gameObject.SetActive(false);
        }
    }

    public void ActivateWalls(bool active)
    {
        foreach (var wall in wallsToActivate)
            wall.SetActive(active);
    }

    void OnWavesComplete()
    {
        ActivateWalls(false);
        goText.SetActive(true);
        Invoke(nameof(HideGoText), 2f);
    }

    void HideGoText()
    {
        goText.SetActive(false);
    }
}
