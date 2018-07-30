using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameTag : MonoBehaviour, ITag
{
	const string key = "val";
	const string parentName = "Name";
	Text nameText;
	Dictionary<string, string> kvps = new Dictionary<string, string>();

    public void Create(string str)
    {
		var commands = str.Split(' ');
        for (var i = 1; i < commands.Length; i++)
        {
            var kvp = commands[i].Replace("=", " ").Split(' ');
            kvps.Add(kvp[0], kvp[1]);
        }

		nameText = GameObject.Find(parentName).GetComponent<Text>();
    }

    public void Fire()
    {
		nameText.text = kvps[key];
    }
}