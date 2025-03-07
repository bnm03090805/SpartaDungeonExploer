using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingObjContorller : MonoBehaviour
{
    MovingJumpObj obj;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("¡¢√À«‘");
        if (other.CompareTag("Obj"))
        {
            Debug.Log(other.name);
            obj = other.GetComponent<MovingJumpObj>();
            obj.ToggleArrive();
        }
    }

    
}
