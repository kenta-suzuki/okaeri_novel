using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTag : MonoBehaviour, ITag
{
	const string effectParent = "Effect";
	const string imageParent = "Image";
	const string nameParent = "Name";
	const string msgParen = "Msg";

	List<Transform> parents = new List<Transform>();

	NovelController controller;

    public void Create(string str)
    {
		controller = FindObjectOfType<NovelController>();
		parents.Add(GameObject.Find(effectParent).transform);
		parents.Add(GameObject.Find(imageParent).transform);
		parents.Add(GameObject.Find(nameParent).transform);
		parents.Add(GameObject.Find(msgParen).transform);
    }

    public void Fire()
    {
		parents.ForEach(p => Clear(p));
		parents[2].GetComponent<Text>().text = "";
		parents[3].GetComponent<Text>().text = "";

		SoundManager.Instance.StopBgm();
		SoundManager.Instance.StopSe();
		controller.Finish();
    }

    void Clear(Transform parent)
	{
		List<GameObject> children = new List<GameObject>();
		for (var i = 0; i < parent.childCount; i++)
		{
			children.Add(parent.transform.GetChild(i).gameObject);
		}

		children.ForEach(c => Destroy(c));
	}
}