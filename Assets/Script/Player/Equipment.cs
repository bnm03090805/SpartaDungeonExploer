using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Equipment : MonoBehaviour
{
    public Equip curEquip;
    public Transform equipParent;

    private PlayerController controller;
    private PlayerCondition condition;

    void Start()
    {
        controller = CharacterManager.Instance.Player.controller;
        condition = CharacterManager.Instance.Player.conditions;
    }

    public void EquipNew(ItemData data)
    {
        UnEquip();
        if(data.type == ItemType.EquipBoostable)
            controller.ItemJumpPowerUPOn(data.boostAmount);
        else
            curEquip = Instantiate(data.equipPrefab, equipParent).GetComponent<Equip>();
        
    }

    public void UnEquip()
    {
        if (curEquip != null)
        {
            Destroy(curEquip.gameObject);
            curEquip = null;
        }
    }

    public void UnEquipBoost()
    {
        controller.ItemJumpPowerUPOff();
    }

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && curEquip != null && controller.canLook)
        {
            curEquip.OnAttackInput();
        }
    }
}
