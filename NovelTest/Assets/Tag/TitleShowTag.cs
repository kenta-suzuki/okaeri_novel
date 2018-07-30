using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleShowTag : MonoBehaviour, ITag
{
	const string key = "val";
	const string parentName = "Title";
	Dictionary<string, string> kvps = new Dictionary<string, string>();

	Text title;
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
		kvps[key] = kvps[key].Replace("¥n", "\n");
		title = GameObject.Find(parentName).GetComponent<Text>();
    }

    public void Fire()
    {
		controller.isWait = true;
		controller.Fired = ShowTitle();
    }

	IEnumerator ShowTitle()
	{
		var wait = new WaitForSeconds(0.1f);
		for (var i = 0; i < kvps[key].Length; i++)
		{
			title.text += kvps[key][i];
			yield return wait;
		}
		controller.isWait = false;
	}
}