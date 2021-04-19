using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle6 : MonoBehaviour
{
    private void Start()
    {
		StartRotateObject();
    }
    public void StartRotateObject()
	{
		Sequence seq;
		seq = DOTween.Sequence();
		seq.Append(gameObject.transform.DORotate(new Vector3(0, 90, 0), 2))
			.Append(gameObject.transform.DORotate(new Vector3(0, 0, 0), 2))
			.SetLoops(-1);
	}
}
