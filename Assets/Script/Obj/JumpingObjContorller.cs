using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingObjContorller : MonoBehaviour
{
    MovingObj obj;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obj"))
        {
            obj = other.GetComponent<MovingObj>();
            obj.ToggleArrive();
        }
    }

    
}
