using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpObj : MonoBehaviour
{
    Rigidbody body;
    public float jumpPower;
    private void OnCollisionEnter(Collision collision)
    {
        body = collision.gameObject.GetComponent<Rigidbody>();

        Invoke(nameof(OnJump), 0.5f);
    }

    void OnJump()
    {
        body.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
    }
}