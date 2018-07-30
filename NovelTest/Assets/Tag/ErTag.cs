using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErTag : MonoBehaviour, ITag
{
	const string parentName = "Msg";
	Text message;

	public void Create(string str)
	{
		message = GameObject.Find(parentName).GetComponent<Text>();
	}

    public void Fire()
	{
		message.text = "";
	}
}
