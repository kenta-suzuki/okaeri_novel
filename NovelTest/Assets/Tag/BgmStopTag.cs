using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmStopTag : MonoBehaviour, ITag
{
	const string key = "val";
    Dictionary<string, string> kvps = new Dictionary<string, string>();

    public void Create(string str)
    {
        var commands = str.Split(' ');
        for (var i = 1; i < commands.Length; i++)
        {
            var kvp = commands[i].Replace("=", " ").Split(' ');
            kvps.Add(kvp[0], kvp[1]);
        }
    }

    public void Fire()
    {
		if (kvps.ContainsKey(key)) SoundManager.Instance.StopBgm(kvps[key]);
		else SoundManager.Instance.StopBgm();      
    }
}