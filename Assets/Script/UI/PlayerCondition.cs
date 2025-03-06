using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCondition : MonoBehaviour
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
        Debug.Log("플레이어가 죽었다.");
    }
}
