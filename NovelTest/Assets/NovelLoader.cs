using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NovelLoader 
{
	public static List<ITag> Load(int novelId)
	{
		var path = string.Format("Novel/{0}", novelId);
		var novelText = Resources.Load<TextAsset>(path);
		var lines = novelText.text.Split('\n');
		var tagList = new List<ITag>();

		foreach(var line in lines)
		{
			if (line.Trim() == "") continue;
			tagList.Add(TagCreater.Create(line));
		}
		return tagList;
	}
}
