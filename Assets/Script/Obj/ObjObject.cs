using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjObject : MonoBehaviour, IInteractable
{
    public ObjData data;

    public string GetInteractPrompt()
    {
        string str = $"{data.displayName}\n{data.description}";
        return str;
    }

    public void OnInteract()
    {
        return;
    }

}
