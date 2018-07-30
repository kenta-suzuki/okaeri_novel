using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{
	static SoundManager instance;
	public static SoundManager Instance
	{
		get
		{
			if(instance == null)
			{
				instance = new SoundManager();
			}
			return instance;
		}
	}

    public void PlayBgm(string name)
	{
		
	}

    public void StopBgm(string name)
	{
		
	}

    public void StopBgm()
	{
		
	}

	public void PlaySe(string name, bool isLoop = false)
	{
		
	}

    public void StopSe()
	{
		
	}
}
