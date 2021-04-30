using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Collected Cube"))
        {
            //YETERINCE KUP OLDUGUNU SORGULUYORUM //

            if (FindObjectOfType<CubeControlScript>().CheckStackCountForFinish())
            {
                // KÜPÜ BIRAKTIK
                FindObjectOfType<CubeControlScript>().RemoveCube(other.gameObject);

                // FINISH X SAYISINI ARTIRDIK

                GameManager.instance.xFinish++;
                Debug.Log("X ----> " + GameManager.instance.xFinish);

                // AYNI YERDE TEKRAR ÇALIŞMAMASI İÇİN SCRİPTİ SILDIM //

                Destroy(gameObject.GetComponent<FinishScript>());
            }
            else
            {
                Debug.Log("Finished");
                GameManager.instance.Finish();
            }

        }
        
    }
}
