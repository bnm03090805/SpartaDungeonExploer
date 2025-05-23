using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObj : MonoBehaviour
{
    public Transform Destination;
    public Transform Depart;
    public bool isArrive = false;
    Vector3 des;
    Vector3 dep;

    private void Start()
    {
        des = Destination.position;
        dep = Depart.position;
    }

    private void FixedUpdate()
    {
        if (isArrive)
        {
            transform.position = Vector3.MoveTowards(gameObject.transform.position, des, 0.05f);
        }
        else
        {
            transform.position = Vector3.MoveTowards(gameObject.transform.position, dep, 0.05f);
        }
    }

    public void ToggleArrive()
    {
        if (!isArrive)
        {
            isArrive = true;
        }
        else
        {
            isArrive = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.parent = this.transform;
    }

    private void OnCollisionExit(Collision collision)
    {
        collision.transform.parent = null;
    }
}
