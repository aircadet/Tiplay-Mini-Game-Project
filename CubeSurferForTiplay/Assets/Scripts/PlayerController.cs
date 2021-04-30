using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Vector3 _playerSpeed;
    [SerializeField] Transform _playerModel, _stackParent;
    public DynamicJoystick dynamicJoystick;
    private void Update()
    {
        CheckPlayerModelIsJumpHigh();

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

    void CheckPlayerModelIsJumpHigh() 
    {
        float regulatedY = Mathf.Clamp(_playerModel.position.y, _stackParent.position.y, _stackParent.position.y + 5);
        Vector3 regulatedPosForPlayerModel = new Vector3(_playerModel.position.x, regulatedY, _playerModel.position.z);
    }
}
