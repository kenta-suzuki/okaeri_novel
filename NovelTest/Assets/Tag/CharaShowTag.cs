using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaShowTag : MonoBehaviour, ITag
{
	const string key = "val";
	const string xKey = "x";
	const string yKey = "y";
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
		var posX = kvps.ContainsKey(xKey) ? int.Parse(kvps[xKey]) : 0;
		var posY = kvps.ContainsKey(yKey) ? int.Parse(kvps[yKey]) : 0;

		chara = parent.Find(kvps[key]).GetComponent<Image>();
		chara.transform.localPosition = new Vector3(posX, posY, 0);
		chara.color = new Color(255, 255, 255, 255);
		chara.gameObject.SetActive(true);
    }
}