using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIConditions : MonoBehaviour
{
    public Conditions health;
    public Conditions stamina;

    private void Start()
    {
        CharacterManager.Instance.Player.conditions.uiCondition = this;
    }
}
