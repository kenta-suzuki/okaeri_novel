using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAnimationController : MonoBehaviour
{
	NovelController controller;
	private void Start()
	{
		controller = FindObjectOfType<NovelController>();
	}

	public void FinishAnimation()
	{
		controller.isWait = false;
		gameObject.SetActive(false);
	}
}
