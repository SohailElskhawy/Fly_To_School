using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{

    public Text CoinTxt;
    
    public Text CoinsTxtM, coinTxtGo,coinTxtRAD;

    public static int coins;
    private int thisGameCoins;
    
    

    public GameObject firework;
    



    // Start is called before the first frame update

    void Start()
    {

        thisGameCoins = 0;
        coins = PlayerPrefs.GetInt("Coins");
        CoinsTxtM.text = coins.ToString();

    }

    private void OnTriggerEnter2D(Collider2D coins)
    {
        if(coins.tag == "Coin")
        {
            
            Destroy(coins.gameObject);
            Instantiate(firework.transform, transform.position, Quaternion.identity);


            thisGameCoins += 1;
            
            
            
        }

        
    }

     void Update()
    {
        CoinTxt.text = thisGameCoins.ToString();
        CoinsTxtM.text = coins.ToString();
        coinTxtGo.text = thisGameCoins.ToString();
        coinTxtRAD.text = coins.ToString();




        PlayerPrefs.SetInt("Coins", coins + thisGameCoins);
        PlayerPrefs.Save();
        

    }
}
