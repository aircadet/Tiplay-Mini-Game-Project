using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleCubeScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Collected Cube")) 
        {
            // KÜPÜ SİL //

            FindObjectOfType<CubeControlScript>().RemoveCube(other.gameObject);
            FindObjectOfType<CubeControlScript>().CheckStackCount();

            // ENGELİ KAPAT //

            Destroy(gameObject.GetComponent<ObstacleCubeScript>());

            ////PLAYER'I İT //
            Vector3 pos = GameObject.Find("Player").transform.position;
            GameObject.Find("Player").transform.DOMove(pos + new Vector3(0, 0, 1), .1f);
        }

    }
}
