using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenSpawner : MonoBehaviour
{
    public GameObject[] tokens;

    public float timeBetweenSpawn;
    int randomInt;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;



    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(enemyAttack());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        randomInt = Random.Range(0, tokens.Length);

        Instantiate(tokens[randomInt], transform.position + new Vector3(randomX, randomY, 0), transform.rotation);



    }


    IEnumerator enemyAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenSpawn);
            Spawn();
        }
    }
}
