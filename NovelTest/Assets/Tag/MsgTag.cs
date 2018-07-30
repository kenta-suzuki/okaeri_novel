using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MsgTag : MonoBehaviour, ITag
{
	const string key = "val";
    const string parentName = "Msg";
    Text message;
    Dictionary<string, string> kvps = new Dictionary<string, string>();

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
		message = GameObject.Find(parentName).GetComponent<Text>();
    }

    public void Fire()
    {
		controller.isWait = true;
		controller.Fired = ShowMessage();
    }

	IEnumerator ShowMessage()
	{
		var wait = new WaitForSeconds(0.05f);
		for (var i = 0; i < kvps[key].Length; i++)
		{
			message.text += kvps[key][i];
			yield return wait;
		}
		message.text += "\n";
		controller.isWait = false;
	}
}