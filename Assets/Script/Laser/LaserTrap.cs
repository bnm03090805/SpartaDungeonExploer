using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrap : MonoBehaviour
{
    RaycastHit hit;
    public GameObject Capsule;
    public LayerMask playerLayer;

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, CapslueDirection());
        if (Physics.Raycast(transform.position, CapslueDirection(), out hit, 20f , playerLayer))
        {
            Debug.Log(hit.transform.name);
        }
    }

    Vector3 CapslueDirection()
    {
        return Capsule.transform.position - transform.position;
    }
}
