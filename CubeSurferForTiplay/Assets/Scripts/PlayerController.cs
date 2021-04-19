using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Vector3 _playerSpeed;
    [SerializeField] float _regulationRate;
    public DynamicJoystick dynamicJoystick;
    Swipe swiper;

    private void Start()
    {
        swiper = GetComponent<Swipe>();
    }
    private void Update()
    {
        if (FindObjectOfType<GameManager>().playerState == GameManager.PlayerState.Preparing ) 
        {
            if (Input.GetMouseButtonDown(0)) { FindObjectOfType<GameManager>().playerState = GameManager.PlayerState.Playing; }
        }

        if (FindObjectOfType<GameManager>().playerState == GameManager.PlayerState.Playing || FindObjectOfType<GameManager>().playerState == GameManager.PlayerState.Collecting)
        {
            MovePlayer();
        }
    }

    void MovePlayer() 
    {
        // KARAKTERİN X ve Z EKSENİNDEKİ KONTROLLERİ //

        Vector3 posPlus = new Vector3(_playerSpeed.x * dynamicJoystick.Horizontal * Time.deltaTime, 0, _playerSpeed.z * Time.deltaTime);
        Vector3 RegulatedPos = transform.position += posPlus;
        if (RegulatedPos.x > 6.88f) { RegulatedPos.x = 6.88f; }
        if (RegulatedPos.x < .87f) { RegulatedPos.x = .87f; }

        transform.position = RegulatedPos;
    }
}
