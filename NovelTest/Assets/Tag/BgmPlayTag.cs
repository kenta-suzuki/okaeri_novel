using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmPlayTag : MonoBehaviour, ITag 
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
		SoundManager.Instance.PlayBgm(kvps[key]);
    }
}
