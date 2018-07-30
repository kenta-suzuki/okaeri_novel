using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgLoadTag : MonoBehaviour, ITag
{
	const string nameVal = "val";
    const string layer = "layer";

    const string parentName = "Image";
    const string path = "Images/BG/{0}";
    const string prefabPath = "Prefabs/BG";

    Dictionary<string, string> kvps = new Dictionary<string, string>();
    
    GameObject bg;
    Sprite image;
    Transform parent;

    public void Create(string str)
    {
        var commands = str.Split(' ');
        for (var i = 1; i < commands.Length; i++)
        {
            var kvp = commands[i].Replace("=", " ").Split(' ');
            kvps.Add(kvp[0], kvp[1]);
        }

        image = Resources.Load<Sprite>(string.Format(path, kvps[nameVal]));
		bg = Resources.Load<GameObject>(prefabPath);
        parent = GameObject.Find(parentName).transform;
    }

    public void Fire()
    {
		var obj = Instantiate(bg, parent, false);
        obj.GetComponent<Image>().sprite = image;
        obj.GetComponent<Canvas>().sortingOrder = int.Parse(kvps[layer]);
        obj.name = kvps[nameVal];
        obj.transform.localPosition = new Vector3(1000, 1000, 0);
    }
}