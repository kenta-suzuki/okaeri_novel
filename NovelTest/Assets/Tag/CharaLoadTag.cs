using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaLoadTag : MonoBehaviour, ITag
{
	const string key = "val";
    const string layer = "layer";
	const string scale = "scale";

    const string parentName = "Image";
    const string path = "Images/Chara/{0}";
    const string prefabPath = "Prefabs/Chara";

    Dictionary<string, string> kvps = new Dictionary<string, string>();

    GameObject chara;
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

		image = Resources.Load<Sprite>(string.Format(path, kvps[key]));
        chara = Resources.Load<GameObject>(prefabPath);
        parent = GameObject.Find(parentName).transform;
    }

    public void Fire()
    {
        var obj = Instantiate(chara, parent, false);
		var img = obj.GetComponent<Image>();
        img.sprite = image;
		img.SetNativeSize();
		if(kvps.ContainsKey(scale))
		{
			var localScale = float.Parse(kvps[scale]);
			img.rectTransform.localScale = new Vector3(localScale, localScale, 1);
		}
        obj.GetComponent<Canvas>().sortingOrder = int.Parse(kvps[layer]);
        obj.name = kvps[key];
        obj.transform.localPosition = new Vector3(1000, 1000, 0);
    }
}
