using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float dashSpeed;
    public float resultSpeed;
    public float plusSpeed;
    private Vector2 curMovementInput;
    public float jumpPower;
    public LayerMask groundLayerMask;
    public LayerMask objLayerMask;
    public int jumpStamina;
    public float dashStamina;

    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook;
    public float maxXLook;
    private float camCurXRot;
    public float lookSensitivity;

    private Vector2 mouseDelta;

    [HideInInspector]
    public bool canLook = true;
    public bool isDash = false;
    public bool onLauched = false;
    public bool isCliming = false;

    private Rigidbody rigidbody;

    RaycastHit hit;

    public Action inventory;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        resultSpeed = moveSpeed;
    }

    private void Update()
    {
        if (isDash)
        {
            CharacterManager.Instance.Player.conditions.ConsumeStamina(dashStamina);
        }
        if(CharacterManager.Instance.Player.conditions.IsStaminaZero())
            DashOnOff();
    }

    private void FixedUpdate()
    {
        if (!onLauched)
            Move();
    }

    private void LateUpdate()
    {
        if (canLook)
        {
            CameraLook();
        }
    }

    public void OnLookInput(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGrounded())
        {
            rigidbody.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
            CharacterManager.Instance.Player.conditions.ConsumeStamina(jumpStamina);
        }
    }

    public void OnDashInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            DashOnOff();
        }
    }

    public void DashOnOff()
    {
        if (!isDash)
        {
            resultSpeed = (dashSpeed + plusSpeed) * moveSpeed;
            isDash = true;
        }
        else
        {
            resultSpeed = moveSpeed + plusSpeed;
            isDash = false;
        }
    }

    private void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= resultSpeed;
        dir.y = rigidbody.velocity.y;

        rigidbody.velocity = dir;
    }

    void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) +(transform.up * 0.01f), Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.1f, groundLayerMask))
            {
                onLauched = false;
                return true;
            }
        }

        return false;
    }


    public void OnInventoryButton(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.phase == InputActionPhase.Started)
        {
            inventory?.Invoke();
            ToggleCursor();
        }
    }

    void ToggleCursor()
    {
        bool toggle = Cursor.lockState == CursorLockMode.Locked;
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
        canLook = !toggle;
    }

    public void ItemSpeedUP(ItemData item, float amount)
    {
        if (item == null)
            return;
        StartCoroutine(SpeedUP(item.duration, amount));
    }

    private IEnumerator SpeedUP(float duration, float amount)
    {
        plusSpeed += amount;
        resultSpeed += plusSpeed;
        yield return new WaitForSeconds(duration);
        plusSpeed = 0;
        if (isDash)
            resultSpeed = moveSpeed * dashSpeed;
        else
            resultSpeed = moveSpeed;
    }

    
}
