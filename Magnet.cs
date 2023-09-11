using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    private Transform player;
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPowerUps.isMagnet == true)
        {
            if(Vector3.Distance(transform.position,player.position) < 4)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, 0.4f);
            }
        }
    }
}
