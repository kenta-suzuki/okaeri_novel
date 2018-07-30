using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectShowTag : MonoBehaviour, ITag
{
	const string key = "val";
	const string parentName = "Effect";
	Dictionary<string, string> kvps = new Dictionary<string, string>();
	GameObject effect;
	Transform parent;
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
		controller.isWait = true;
		parent.Find(kvps[key]).gameObject.SetActive(true);
    }
}