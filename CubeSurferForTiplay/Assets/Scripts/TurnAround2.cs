using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAround2 : MonoBehaviour
{

    Vector3 rot;
    [SerializeField] Vector3 speed;
    void Update()
    {
        rot += speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(rot);

    }
}
