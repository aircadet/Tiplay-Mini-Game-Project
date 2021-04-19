using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeControlScript : MonoBehaviour
{
    [SerializeField] GameObject _player, _stackParent, _playerModel;
    [SerializeField] float camDistanceZ, camDistanceY;
    [SerializeField] Material removedCubeMat;

    Sequence seq;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void CollectCube(GameObject cube) 
    {
        // KÜP TOPLAMA MÜZİĞİ //

        AudioManager._instance.PlayMusic(0);

        // Animasyon //
        anim.SetTrigger("Jump");

        seq = DOTween.Sequence();

        seq.Append(_player.transform.DOMove(new Vector3(_player.transform.position.x, _player.transform.position.y + .9f, _player.transform.position.z),0)); 
        Vector3 lastCubePos = _stackParent.transform.GetChild(_stackParent.transform.childCount - 1).position;
        seq.Append(cube.transform.DOMove(lastCubePos - new Vector3(0, .9f, 0),0));
        cube.transform.tag = "Collected Cube";
        
        Destroy(cube.GetComponent<NormalCubeScript>());

        cube.GetComponent<BoxCollider>().isTrigger = false;
        cube.GetComponent<Rigidbody>().useGravity = true;
        cube.transform.SetParent(_stackParent.transform);

        // KAMERAYI UZAKLAŞTIR //
        FindObjectOfType<CameraController>().offSet.z += camDistanceZ;
        FindObjectOfType<CameraController>().yPos += camDistanceY;

        // KÜP SIRALAMASINI DÜZENLE //

        EditTheCubes();

    }
    public void RemoveCube(GameObject cube) 
    {
        // KÜP KAYBETME MÜZİĞİ //
        AudioManager._instance.PlayMusic(2);


        cube.GetComponent<BoxCollider>().enabled = false;
        cube.GetComponent<Rigidbody>().isKinematic = true;
        cube.transform.tag = "Removed Cube";
        cube.transform.SetParent(null);

        //BIRAKILAN KÜPÜN MATERYALİNİ DEĞİŞTİR //

        for (int i = 0; i < cube.transform.childCount; i++) 
        {
            cube.transform.GetChild(i).GetComponent<MeshRenderer>().material = removedCubeMat;
        }

        // KAMERAYI YAKLAŞTIR //

        FindObjectOfType<CameraController>().offSet.z -= camDistanceZ;
        FindObjectOfType<CameraController>().yPos -= camDistanceY;
    }

    public void CheckStackCount() 
    {
        if (_stackParent.transform.childCount <= 0)
        {
            // STACK SAYISI BİTTİ //
            // ÖLDÜR //
            Debug.Log("Stack bitti / Oyun gitti");

            GameManager.instance.Death();
            _playerModel.transform.SetParent(null);
            anim.SetTrigger("Death");
        }
        else 
        {
            // DEVAMKE // 
            Debug.Log("Üzülme! / Devamkee");
        }
    }

    public bool CheckStackCountForFinish() 
    {
        if (_stackParent.transform.childCount <= 1)
        {           
            return false;
            GameManager.instance.Finish();
        }
        else
        {
            Debug.Log("Devamkee");
            return true;
        }

    }

    void EditTheCubes() 
    {
        for (int i = 1; i < _stackParent.transform.childCount; i++)
        {
            _stackParent.transform.GetChild(i).transform.position = _stackParent.transform.GetChild(i - 1).transform.position - new Vector3(0, .9f, 0);
        }
    }
}
