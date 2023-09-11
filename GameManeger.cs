using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GameManeger : MonoBehaviour
{
    private bool isPaused;
    
    public GameObject inGameUI;
    public GameObject mainMenu;
    public GameObject gameOverPanel;
    public GameObject shopPanel;
    private GameObject player;

    private int countdownTime = 3;
    public Text countdownTxt;
    public GameObject PauseMenu;
    public CameraShake cameraShake;

    public GameObject[] gameElements;

    int playerIndex;

    public GameObject radPanel;

    

    
    
    
    
    
   // Start is called before the first frame update
    void Start()
    {

        Advertisement.Initialize("4731317");
        isPaused = true;
        inGameUI.SetActive(false);
        mainMenu.SetActive(true);
        gameOverPanel.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        countdownTxt.gameObject.SetActive(false);
        PauseMenu.SetActive(false);
        shopPanel.SetActive(false);
        playerIndex = PlayerPrefs.GetInt("SelectedPlayer");
        radPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused == true)
        {
            Time.timeScale = 0;

        }
        else if(isPaused == false)
        {
            Time.timeScale = 1;
            
            inGameUI.SetActive(true); // turn this to true
            mainMenu.SetActive(false);

        }

        if (player == null)
        {
            gameOverPanel.SetActive(true);
            inGameUI.SetActive(false);

        }
        


        for (int i = 0; i < gameElements.Length; i++)
        {
            if(player == null)
            {
                gameElements[i].SetActive(false);
            }
        }

        
        
    }

    public void Play()
    {

        
        mainMenu.SetActive(false);
        
        StartCoroutine(CountdownToStart());
    }

    public void Home()
    {
        
            SceneManager.LoadScene("EndlessRunner");

        PlayAd();

        playerIndex = PlayerPrefs.GetInt("SelectedPlayer");

    }

    public void Pause()
    {
        isPaused = true;
        PauseMenu.SetActive(true);
    }

    public void Resume()
    {
        isPaused = false;
        PauseMenu.SetActive(false);
    }

    public void PlayAd()
    {
        if (Advertisement.IsReady("Interstitial_Android"))
        {
            Advertisement.Show("Interstitial_Android");
        }
    }

    public void PlayRewardedAD()
    {
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");
            CoinCollector.coins += 100;
        }
    }

    


    IEnumerator CountdownToStart()
    {
        countdownTxt.gameObject.SetActive(true);
        
        while(countdownTime > 0 && isPaused == true)
        {
            countdownTxt.text = countdownTime.ToString();
            

            yield return new WaitForSecondsRealtime(1f);

            countdownTime--;
        }

        countdownTxt.text = "GO! ";

        isPaused = false;
        inGameUI.SetActive(true);

        yield return new WaitForSecondsRealtime(1f);

        countdownTxt.gameObject.SetActive(false);


        



    }

    
}

