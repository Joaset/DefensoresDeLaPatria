using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    void Start()
    {
        GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>().Follow = transform;
    }

}
