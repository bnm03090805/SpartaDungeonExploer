using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallObj : MonoBehaviour, IInteractable
{
    public ObjData data;

    public string GetInteractPrompt()
    {
        string str = $"{data.displayName}\n{data.description}";
        return str;
    }

    public void OnInteract()
    {
        //Debug.Log($"인터렉트{CharacterManager.Instance.Player.controller.isCliming}");
        CharacterManager.Instance.Player.controller.ToggleIsCliming();
    }

}
