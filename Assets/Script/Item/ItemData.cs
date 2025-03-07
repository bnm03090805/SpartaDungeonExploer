using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Resource,
    Equipable,
    Consumable,
    Boost
}

public enum ConsumableType
{
    Health,
    Stamina
}

public enum BoostType
{
    SpeedUP
}

[System.Serializable]
public class ItemDataConsumable
{
    public ConsumableType type;
    public float value;
}

[System.Serializable]
public class ItemDataBoost
{
    public BoostType type;
    public float value;
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public ItemType type;
    public Sprite icon;
    public GameObject dropPrefab;

    [Header("Stacking")]
    public bool canStack;
    public int maxStackAmount;

    [Header("Consumable")]
    public ItemDataConsumable[] consumables;

    [Header("Boost")]
    public ItemDataBoost[] boosts;

    [Header("Equip")]
    public GameObject equipPrefab;

    [Header("Duration")]
    public float duration;
}
