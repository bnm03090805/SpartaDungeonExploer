using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingObjContorller : MonoBehaviour
{
    MovingObj obj;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("¡¢√À«‘");
        if (other.CompareTag("Obj"))
        {
            Debug.Log(other.name);
            obj = other.GetComponent<MovingObj>();
            obj.ToggleArrive();
        }
    }

    
}
