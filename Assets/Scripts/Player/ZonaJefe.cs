using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaJefe : MonoBehaviour
{
    public GameObject[] paredes;
    public JefeController jefe;

    public bool activated;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (activated) return;
        if (other.CompareTag("Player"))
        {
            activated = true;
            ActivarParedes(true);
            gameObject.SetActive(false);
            jefe.enabled = true;
        }
    }

    public void ActivarParedes(bool active)
    {
        foreach (var wall in paredes)
            wall.SetActive(active);
    }
}
