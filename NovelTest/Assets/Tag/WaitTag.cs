using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitTag : MonoBehaviour, ITag
{
	const string key = "val";
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
    }

    public void Fire()
    {
		controller.isWait = true;
		controller.Fired = WaitForValueSecond();
    }

	IEnumerator WaitForValueSecond()
	{
		yield return new WaitForSeconds(float.Parse(kvps[key]) / 1000f);
		controller.isWait = false;
	}
}