using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform enemyPos;
    private float repeatRate = 0.5f;

    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            InvokeRepeating("Spawn", 0.5f, repeatRate);
            Destroy(gameObject, 2);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }

    }

    void Spawn()
    {
        Instantiate(enemy, enemyPos.position, enemyPos.rotation);
    }
    
}
