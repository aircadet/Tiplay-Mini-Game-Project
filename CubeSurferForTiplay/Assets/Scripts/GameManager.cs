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
    }

    private void Start()
    {
        playerState = PlayerState.Preparing;

        PlayerPrefs.GetInt("Level", 1);
        PlayerPrefs.GetInt("Diamond", 0);

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


}
