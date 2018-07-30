using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class NovelMenuController : MonoBehaviour
{
	[SerializeField]
	GameObject BlockObj;
	[SerializeField]
	Transform Parent;
	[SerializeField]
	GameObject content;

	private void Start()
	{
		var novelList = Resources.LoadAll<TextAsset>("Novel");
		StartCoroutine(WiatForOneFrame(novelList));
	}

	IEnumerator WiatForOneFrame(TextAsset[] novelList)
	{
		yield return null;
		BlockObj.SetActive(false);

		for (var i = 0; i < novelList.Length; i++)
        {
            var obj = Instantiate(content, Parent, false);
            obj.SetActive(true);
            var text = obj.GetComponentInChildren<Text>();
            text.text = novelList[i].name;
            var button = obj.GetComponentInChildren<Button>();
            var index = i;
            button.onClick.AddListener(() => OnClick(novelList[index].name));
        }
	}

    void OnClick(string novelId)
	{
		var id = int.Parse(novelId);
		NovelController.novelId = id;
		SceneManager.LoadScene("Novel");
	}
}
