using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerPowerUps : MonoBehaviour
{

    public static int health = 3;
    public GameObject[] hearts;
    public CameraShake cameraShake;

    public bool isSheilded;
    public bool isShooting;
    public static bool isMagnet;
    public bool isBoosting;
    public bool isSword;



    public GameObject sheild;
    public Transform firePoint;
    public GameObject Bullit;
    public float abilityTime;
    public GameObject fireTrail;
    public ScoreManeger scoreManeger;
    public AudioSource pickUpSound;
    public SpriteRenderer sword;


    private GameObject sheildToken, gunToken, magnetToken, boostToken,swordToken;

    public GameObject playersHolder;



    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        isSheilded = false;
        isShooting = false;
        isMagnet = false;
        isBoosting = false;

        
        sheildToken = GameObject.FindGameObjectWithTag("Sheild"); 
        gunToken = GameObject.FindGameObjectWithTag("Gun");
        magnetToken = GameObject.FindGameObjectWithTag("Magnet");
        boostToken = GameObject.FindGameObjectWithTag("Boost");
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }
        }

        if(health == 0)
        {
            Destroy(gameObject);
            Destroy(playersHolder);
            Debug.Log("Player Dead!");
        }
        else
        {
            gameObject.SetActive(true);
        }


        if (isSheilded)
        {
            sheild.SetActive(true);
        }
        else
        {
            sheild.SetActive(false);
        }


        if (!isBoosting)
        {
            fireTrail.SetActive(false);
            scoreManeger.scoreSpeed = 10f;
            LoopingBG.backgroundSpeed = 1f;
            CameraMovement.cameraSpeed = 5f;
            DragFingerMove.moveSpeed = 10;


        }

        if (sword != null)
        {
            sword.enabled = !sword.enabled;
        }



    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {

            if (isSheilded)
            {
                isSheilded = false;
            }
            else if (isSword && isSheilded)
            {
                isSheilded = true;
                isSword = true;

            }
            else if (isSword)
            {
                isSword = true;
            }
            else
            {
                health -= 1;
                Debug.Log("health decreased");
            }
            
            
            
            
           
            
            
        }

        if (collision.tag == "Bullit")
        {
            if (isSheilded)
            {
                isSheilded = false;
            }
            else if (isSword && isSheilded)
            {
                isSheilded = true;
                isSword = true;

            }
            else if (isSword)
            {
                isSword = true;
            }
            else
            {
                health -= 1;
                Debug.Log("health decreased");
            }
        }


        if(collision.tag == "Sheild")
        {
            sheildToken = GameObject.FindGameObjectWithTag("Sheild");
            isSheilded = true;
            Debug.Log("Player Shielded");
            Destroy(collision.gameObject);
            pickUpSound.Play();
            
        }

        if(collision.tag == "Gun")
        {
            gunToken = GameObject.FindGameObjectWithTag("Gun");
            isShooting = true;
            Debug.Log("Player Shooting");
            Destroy(gunToken);
            StartCoroutine(Shoot());
            pickUpSound.Play();
            Destroy(collision.gameObject);

        }

        if(collision.tag == "Magnet")                                                      // detect coins -- if its on coins come to player
        {
            magnetToken = GameObject.FindGameObjectWithTag("Magnet");                         
            isMagnet = true;
            Debug.Log("Magnet On");
            Destroy(magnetToken);
            StartCoroutine(MagnetOn());
            pickUpSound.Play();
            Destroy(collision.gameObject);
        }

        if(collision.tag == "Boost")
        {
            boostToken = GameObject.FindGameObjectWithTag("Boost");
            isBoosting = true;
            Debug.Log("Player Boosting");                                     
            Destroy(boostToken);
            StartCoroutine(BoostCut());
            pickUpSound.Play();
            Destroy(collision.gameObject);


        }


        if (collision.tag == "Health")
        {
            Destroy(collision.gameObject);
            pickUpSound.Play();
            if (health < 3)
            {
                health += 1;
                Debug.Log("health increased");

            }


        }

        if(collision.tag == "Sword")
        {
            swordToken = GameObject.FindGameObjectWithTag("Sword");
            isSword = true;
            Debug.Log("Player Has Sword");
            Destroy(swordToken);
            pickUpSound.Play();
            Destroy(collision.gameObject);
            StartCoroutine(SwordOn());
            sword.gameObject.SetActive(true);
        }

        

    }

    void ShootBullit()
    {
        Instantiate(Bullit.transform, firePoint.position, firePoint.rotation);
    }
    
   

    public IEnumerator Shoot()
    {
        while(isShooting == true)
        {
            yield return new WaitForSeconds(0.5f);
            ShootBullit();
            yield return new WaitForSeconds(0.5f);
            ShootBullit();
            yield return new WaitForSeconds(0.5f);
            ShootBullit();
            yield return new WaitForSeconds(0.5f);
            ShootBullit();
            yield return new WaitForSeconds(0.5f);
            ShootBullit();
            yield return new WaitForSeconds(0.5f);
            ShootBullit();
            yield return new WaitForSeconds(0.5f);
            ShootBullit();
            yield return new WaitForSeconds(0.5f);
            ShootBullit();
            yield return new WaitForSeconds(0.5f);
            ShootBullit();
            yield return new WaitForSeconds(0.5f);
            ShootBullit();
            yield return new WaitForSeconds(3f);
            isShooting = false;
        }

       

    }


    public IEnumerator BoostCut()
    {
        if (isBoosting)
        {
            fireTrail.SetActive(true);
            scoreManeger.scoreSpeed += 3;
            LoopingBG.backgroundSpeed += 1f;
            CameraMovement.cameraSpeed += 1f;
            DragFingerMove.moveSpeed += 0.5f;
            yield return new WaitForSeconds(abilityTime);
            isBoosting = false;
        }

        
    }



    public IEnumerator MagnetOn()
    {
        if(isMagnet == true)
        {
            yield return new WaitForSeconds(abilityTime);
            isMagnet = false;
        }
    }

    public IEnumerator SwordOn()
    {
        if(isSword == true)
        {
            
            yield return new WaitForSeconds(abilityTime);
            sword.gameObject.SetActive(false);
            isSword = false;
            
            
            


            










        }
    }
}
