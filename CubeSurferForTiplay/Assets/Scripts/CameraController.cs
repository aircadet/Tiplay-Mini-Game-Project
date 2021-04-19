using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] bool lookAt;
    public Vector3 offSet;
    public float yPos;

  
    void Update()
    {
        if (lookAt) { transform.LookAt(target.transform); }

        float xPos = target.transform.position.x - offSet.x;
        float zPos = target.transform.position.z - offSet.z;
        Vector3 newPos = new Vector3(xPos, yPos, zPos);

        transform.DOMove(newPos,0);

        if (GameManager.instance.playerState == GameManager.PlayerState.Collecting) { yPos = GameManager.instance.xFinish - 2; }

        
    }
}
