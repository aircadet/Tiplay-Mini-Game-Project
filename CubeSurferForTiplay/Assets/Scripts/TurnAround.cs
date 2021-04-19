using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TurnAround : MonoBehaviour
{
	void Start()
	{
		StartRotateObject();
	}
	public void StartRotateObject()
	{
		gameObject.transform.DORotate(new Vector3(0, 180, 0), 1).SetLoops(-1).SetEase(Ease.Linear);
	}
}
