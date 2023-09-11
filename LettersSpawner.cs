using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LettersSpawner : MonoBehaviour
{
    public GameObject[] letters;

    public float timeBetweenSpawn;
    int randomInt;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;



    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        randomInt = Random.Range(0, letters.Length);

        Instantiate(letters[randomInt], transform.position + new Vector3(randomX, randomY, 0), transform.rotation);



    }


    public IEnumerator SpawnLetters()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenSpawn);
            Spawn();
        }
    }
}
