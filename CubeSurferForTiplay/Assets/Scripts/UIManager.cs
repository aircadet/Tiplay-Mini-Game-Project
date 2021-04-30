using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Container Objects")]
    public GameObject onPlaying;
    public GameObject dragToPlay;
    public GameObject finishScreen;
    public GameObject deathScreen;

    [Header("On Playing Objects")]
    public Image currentlevelImg;
    public Image nextLevelImg;
    public Text currentLevelText;
    public Text nextLevelText;
    public Slider slider;
    public Text totalDiamondCount;
    public Text extraCubePrice;

    [Header("Finish Screen Objects")]

    public Text finishXTxt;
    public Text gemCountTxt;

    [Header("Death Screen Objects")]
    public Text gemCountTextDeath;

    GameObject[] grounds;
    float totalMapDistance;
    Vector3 currentPlayerPos;

    public static UIManager instance;
    private void Awake()
    {
        if (instance == null) { instance = this; }

        // SLİDER İÇİN VERİLERİ TOPLAMA //
        grounds = GameObject.FindGameObjectsWithTag("Ground");
        foreach (GameObject go in grounds) 
        {
            totalMapDistance += go.transform.localScale.z;
        }
    }

    private void Start()
    {
        PrepareLevelUI();
    }

    private void Update()
    {
        // slider işlemleri //

        UpdateSlider();
        PrepareLevelUI();

        // DRAG TO PLAY AÇILMASI İŞLEMLERİ //

        if (GameManager.instance.playerState == GameManager.PlayerState.Preparing) {dragToPlay.SetActive(true);} else {dragToPlay.SetActive(false);}

        // FİNİSH SCREEN AÇILMASI İŞLEMLERİ //

        if (GameManager.instance.playerState == GameManager.PlayerState.Finish) { finishScreen.SetActive(true); PrepareFinishScreen(); } else { finishScreen.SetActive(false); }

        // DEATH SCREEN AÇILMASI İŞLEMLERİ //

        if (GameManager.instance.playerState == GameManager.PlayerState.Death) { deathScreen.SetActive(true); PrepareDeathScreen(); } else { deathScreen.SetActive(false); }
    }

    public void PrepareLevelUI() 
    {
        currentLevelText.text = PlayerPrefs.GetInt("Level").ToString();
        nextLevelText.text = (PlayerPrefs.GetInt("Level") + 1).ToString();
        totalDiamondCount.text = PlayerPrefs.GetInt("Diamond").ToString();

        try
        {
            extraCubePrice.text = PlayerPrefs.GetInt("ExtraCubePrice").ToString();
        }
        catch 
        {

        }

        //currentlevelImg.GetComponent<Image>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        //nextLevelImg.GetComponent<Image>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    void UpdateSlider() 
    {
        currentPlayerPos = GameObject.Find("Player").transform.position;
        slider.value = currentPlayerPos.z / totalMapDistance;
    }

    void PrepareFinishScreen() 
    {
        gemCountTxt.text = (GameManager.instance.diamond * GameManager.instance.xFinish).ToString();
        finishXTxt.text = GameManager.instance.xFinish.ToString() + " X";
    }

    void PrepareDeathScreen() 
    {
        gemCountTextDeath.text = GameManager.instance.diamond.ToString();
    }
}
