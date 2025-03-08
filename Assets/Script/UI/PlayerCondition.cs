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
    private bool IsInvincible;

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
    public void PlusStamina(float amount)
    {
        stamina.Add(amount);
    }

    public bool ConsumeStamina(float amount)
    {
        if(stamina.curValue < amount)
        {
            return false;
        }
        stamina.Subtract(amount);
        return true;
    }

    public bool IsStaminaZero()
    {
        if (stamina.curValue <= 0f)
            return true;
        else return false;
    }
    public void UseInvincibleItem(ItemData data)
    {
        StartCoroutine(OnInvincible(data.duration));
    }
    
    void ToggleInvincibleItem()
    {
        if (IsInvincible)
            IsInvincible = false;
        else
            IsInvincible = true;
    }

    IEnumerator OnInvincible(float duration)
    {
        ToggleInvincibleItem();

        yield return new WaitForSeconds(duration);
        ToggleInvincibleItem();
    }

 
    public void TakePhysicalDamage(int damageAmount)
    {
        if (IsInvincible)
            return;
        health.Subtract(damageAmount);
        onTakeDamage?.Invoke();
    }
}
