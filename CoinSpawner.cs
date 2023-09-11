using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coins;
    
    public float timeBetweenSpawn;
    private float spawnTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void Spawn()
    {
        
        Instantiate(coins.transform, transform.position, Quaternion.identity);
    }
}
