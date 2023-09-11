using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float speed;
    
    public GameObject explotion;

   
    
   
    
    
   
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;

        


    }


   

    void Update()
    {
        Destroy(gameObject, 1.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            Instantiate(explotion.transform, transform.position, Quaternion.identity);

            
            


        }

        if (collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }

    }

}
