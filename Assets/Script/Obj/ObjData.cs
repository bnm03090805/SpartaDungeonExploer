using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjType
{
    Damageable,
    Jump,
    Box,
    Lever,
    Wall
}

[CreateAssetMenu(fileName = "Obj", menuName = "New Obj")]
public class ObjData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public ObjType type;
    public ItemData[] dropItems;
}
