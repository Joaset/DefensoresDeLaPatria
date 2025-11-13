using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IJefeState 
{
    void Enter(JefeController jefe);
    void Update();
    void Exit();
}
