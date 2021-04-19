using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectorForFinish : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.transform.tag == "Collecting" && collision.transform.CompareTag("Collected Cube")) 
        {
            GameManager.instance.playerState = GameManager.PlayerState.Collecting;
        }

        if (gameObject.transform.tag == "Finish" && collision.transform.CompareTag("Collected Cube"))
        {
            GameManager.instance.playerState = GameManager.PlayerState.Finish;
        }
    }
}
