using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IDamageable
{ 
    void TakePhysicalDamage(int damageAmount);
}

public class PlayerCondition : MonoBehaviour, IDamageable
{
    public UIConditions uiCondition;

    Conditions health { get { return uiCondition.health; } }
    Conditions stamina { get { return uiCondition.stamina; } }

    public event Action onTakeDamage;

    private void Update()
    {
        stamina.Add(stamina.passiveValue * Time.deltaTime);


        if (health.curValue < 0f)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void Die()
    {
        Debug.Log("»ç¸Á");
    }

    public void ConsumeStamina(float amount)
    {
        stamina.Subtract(amount);
    }

    public bool IsStaminaZero()
    {
        if (stamina.curValue <= 0f)
            return true;
        else return false;
    }

    public bool CanAction(float amount)
    {
        if(stamina.curValue < amount)
        {
            return false;
        }
        else
            return true;
    }

    public void TakePhysicalDamage(int damageAmount)
    {
        health.Subtract(damageAmount);
        onTakeDamage?.Invoke();
    }
}
