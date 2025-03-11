using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpObj : MonoBehaviour
{
    Rigidbody body;
    PlayerController controller;
    public float jumpPower;
    public float waitTime;

    Vector3 vector;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            body = collision.gameObject.GetComponent<Rigidbody>();
            controller = collision.gameObject.GetComponent<PlayerController>();
            vector = collision.contacts[0].normal * -1;
            Debug.Log(vector);

            Invoke(nameof(OnJump), waitTime);
        }
    }

    void OnJump()
    {
        if(vector !=  Vector3.up)
            controller.onLauched = true;

        body.AddForce(vector * jumpPower, ForceMode.Impulse);
        //body = null;
        //vector = Vector3.zero;
    }
}