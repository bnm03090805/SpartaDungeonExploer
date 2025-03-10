using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverObj : MonoBehaviour, IInteractable
{

    public ObjData data;
    public GameObject brigde;

    public string GetInteractPrompt()
    {
        string str = $"{data.displayName}\n{data.description}";
        return str;
    }

    public void OnInteract()
    {
        ActiveToggleBrigde();
    }

    void ActiveToggleBrigde()
    {
        if (brigde.activeSelf)
        {
            brigde.SetActive(false);
            transform.localRotation = Quaternion.Euler(180f, 0f, 40f);
        }
        else
        {
            brigde.SetActive(true);
            transform.localRotation = Quaternion.Euler(180f, 0f, -40f);
        }
            
    }
}
