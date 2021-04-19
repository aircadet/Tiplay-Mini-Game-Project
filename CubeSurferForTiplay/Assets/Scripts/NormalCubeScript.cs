using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCubeScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Collected Cube"))
        {
            // KÜPÜ TOPLA

            FindObjectOfType<CubeControlScript>().CollectCube(gameObject);
        }
    }
}
