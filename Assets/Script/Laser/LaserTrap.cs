using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrap : MonoBehaviour
{
    RaycastHit hit;
    public GameObject Capsule;
    public LayerMask playerLayer;
    public GameObject spawnMonster;
    private bool isSpwan = false;
    public Transform enemySpawnPoint;

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, CapslueDirection());
        if (Physics.Raycast(transform.position, CapslueDirection(), out hit, 20f , playerLayer) && !isSpwan)
        {
            StartCoroutine(SpwanMonster());
        }
    }

    Vector3 CapslueDirection()
    {
        return Capsule.transform.position - transform.position;
    }

    IEnumerator SpwanMonster()
    {
        isSpwan = true;
        Instantiate(spawnMonster, enemySpawnPoint);
        yield return new WaitForSeconds(10f);
        isSpwan = false;
    }
}
