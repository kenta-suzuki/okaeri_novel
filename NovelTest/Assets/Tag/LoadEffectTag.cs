using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadEffectTag : MonoBehaviour, ITag
{
	const string parentName = "Effect";
	const string key = "val";
	const string path = "Effect/{0}";
	Dictionary<string, string> kvps = new Dictionary<string, string>();

	GameObject effect;

	Transform parent;

    public void Create(string str)
    {
		var commands = str.Split(' ');
		for (var i = 1; i < commands.Length; i++)
		{
			var kvp = commands[i].Replace("=", " ").Split(' ');
			kvps.Add(kvp[0], kvp[1]);
		}

		effect = Resources.Load<GameObject>(string.Format(path, kvps[key]));
		parent = GameObject.Find(parentName).transform;
    }

    public void Fire()
    {
		var obj = Instantiate(effect, parent, false);
		obj.SetActive(false);
		obj.name = kvps[key];
    }
}