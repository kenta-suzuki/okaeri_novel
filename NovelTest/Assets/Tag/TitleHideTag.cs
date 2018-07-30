using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleHideTag : MonoBehaviour, ITag
{
    const string parentName = "Title";

	Text title;

    public void Create(string str)
    {
        title = GameObject.Find(parentName).GetComponent<Text>();
    }

    public void Fire()
    {
		title.text = "";
    }
}