using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject rotateCamera, mainCam;
   
    public PlayerState playerState;
    public static GameManager instance;
    public int gold, diamond, xFinish;

    [Header("Player Prefs")]
    public int pLevel;
    public int pDiamond;
    public int pExtraCube;
    public int pExtraCubePrice;

    public enum PlayerState
    {
        Preparing,
        Playing,
        Collecting,
        Finish,
        Death
    }

    private void Awake()
    {
        if (instance == null) { instance = this; }

        playerState = PlayerState.Preparing;

        PlayerPrefs.GetInt("Level", 1);
        PlayerPrefs.GetInt("Diamond", 0);
        PlayerPrefs.GetInt("ExtraCube", 0);
        PlayerPrefs.GetInt("ExtraCubePrice", 100);
    }

    private void Start()
    {
        ResetGameData();

        StartCoroutine(AddExtraCubesOnStart());
    }

    private void Update()
    {
        pLevel = PlayerPrefs.GetInt("Level");
        pDiamond = PlayerPrefs.GetInt("Diamond");
        pExtraCube = PlayerPrefs.GetInt("ExtraCube");
        pExtraCubePrice = PlayerPrefs.GetInt("ExtraCubePrice");
    }

    public void Finish() 
    {
        playerState = PlayerState.Finish;

        // KARAKTER ETRAFINDA DONUS BASLADI //
        mainCam.SetActive(false);
        rotateCamera.SetActive(true);
    }

    public void Death()
    {
        playerState = PlayerState.Death;

        // KARAKTER ETRAFINDA DONUS BASLADI //
        mainCam.SetActive(false);
        rotateCamera.SetActive(true);
    }

    public void NextLevel() 
    {
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") + (diamond * xFinish));

        SceneManager.LoadScene(0);

        
    }

    public void TryAgain() 
    {
        PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") + diamond);

        SceneManager.LoadScene(0);

    }

    IEnumerator AddExtraCubesOnStart() 
    {
       
        int countOfExtras = PlayerPrefs.GetInt("ExtraCube");
        for (int i = 0; i < countOfExtras; i++) 
        {
            yield return new WaitForSeconds(.1f);
            FindObjectOfType<CubeControlScript>().AddExtraCube();
        }
    }

    public void BuyExtraCube() 
    {
        int diamondCount = PlayerPrefs.GetInt("Diamond");
        int cubePrice = PlayerPrefs.GetInt("ExtraCubePrice");

        if (diamondCount >= cubePrice) 
        {
            FindObjectOfType<CubeControlScript>().AddExtraCube();
            diamondCount -= cubePrice;
            cubePrice *= 2;

            PlayerPrefs.SetInt("Diamond", diamondCount);
            PlayerPrefs.SetInt("ExtraCubePrice", cubePrice);
            PlayerPrefs.SetInt("ExtraCube", PlayerPrefs.GetInt("ExtraCube") + 1);

            UIManager.instance.PrepareLevelUI();

        }

    }

    public void Playing() 
    {
        if (playerState == PlayerState.Preparing) 
        {
            playerState = PlayerState.Playing;
        }
    }

    void ResetGameData() 
    {
        if (PlayerPrefs.GetInt("Level") <= 1 && PlayerPrefs.GetInt("Diamond") <= 0)
        {
            PlayerPrefs.SetInt("Level", 1);
            PlayerPrefs.SetInt("Diamond", 0);
            PlayerPrefs.SetInt("ExtraCube", 0);
            PlayerPrefs.SetInt("ExtraCubePrice", 100);
        }
        
    }


}
