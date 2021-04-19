using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondCollectScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collected Cube")) 
        {
            // ELMASI TOPLADIK 
            AudioManager._instance.PlayMusic(1);
            GameManager.instance.diamond++;
            Debug.Log("Diamond ----> " + GameManager.instance.diamond);

            Destroy(gameObject);
        }
    }
}
