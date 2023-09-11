using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullit : MonoBehaviour
{
    public float speed;

    public GameObject explotion;







    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = -transform.up * speed;




    }




    void Update()
    {
        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            Destroy(this.gameObject);
            Instantiate(explotion.transform, transform.position, Quaternion.identity);





        }
        if (collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }

    }
}
