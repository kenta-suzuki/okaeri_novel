using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgShowTag : MonoBehaviour, ITag
{
	const string key = "val";
    const string parentName = "Image";

    Dictionary<string, string> kvps = new Dictionary<string, string>();
    Transform parent;
    Image chara;
	NovelController controller;
    
    public void Create(string str)
    {
		controller = FindObjectOfType<NovelController>();
        var commands = str.Split(' ');
        for (var i = 1; i < commands.Length; i++)
        {
            var kvp = commands[i].Replace("=", " ").Split(' ');
            kvps.Add(kvp[0], kvp[1]);
        }
        parent = GameObject.Find(parentName).transform;
    }

    public void Fire()
    {
        chara = parent.Find(kvps[key]).GetComponent<Image>();
		chara.transform.localPosition = Vector3.zero;
        chara.color = new Color(255, 255, 255, 255);
        chara.gameObject.SetActive(true);
    }
}
