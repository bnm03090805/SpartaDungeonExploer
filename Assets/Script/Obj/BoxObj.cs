using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxObj : MonoBehaviour, IInteractable, IDamageable
{
    public ObjData data;
    public float health;
    public ItemData[] dropOnDeath;

    public string GetInteractPrompt()
    {
        string str = $"{data.displayName}\n{data.description}";
        return str;
    }

    public void OnInteract()
    {
        for (int i = 0; i < data.dropItems.Length; i++)
        {
            Instantiate(data.dropItems[i].dropPrefab, transform.position + Vector3.up * 2, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    public void TakePhysicalDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        for (int i = 0; i < dropOnDeath.Length; i++)
        {
            Instantiate(dropOnDeath[i].dropPrefab, transform.position + Vector3.up * 2, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
