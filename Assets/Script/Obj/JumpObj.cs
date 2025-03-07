using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpObj : MonoBehaviour
{
    Rigidbody body;
    public float jumpPower;
    public float waitTime;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            body = collision.gameObject.GetComponent<Rigidbody>();

            Invoke(nameof(OnJump), waitTime);
        }
    }

    void OnJump()
    {
        body.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
    }
}