using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.PostProcessing;

public class NovelController : MonoBehaviour
{
	[SerializeField]
	Button BtnDisplay;
	[SerializeField]
	PostProcessingBehaviour processingBehaviour;

	public PostProcessingBehaviour PostProcessingBehaviour{ get { return processingBehaviour; } }

	List<ITag> tagList;

	public static int novelId = 1;

	public bool isWait { get; set; }
	int currentStep;

	public IEnumerator Fired { get; set; }

    void Start()
    {
		tagList = NovelLoader.Load(novelId);
		BtnDisplay.onClick.AddListener(OnClickNext);
		isWait = false;
		currentStep = 0;
		Fired = null;
      
		foreach(var novelTag in tagList)
		{
			if (typeof(StartTag) == novelTag.GetType())
				break;
			OnClickNext();
		}
    }

    void OnClickNext()
	{
		if (isWait || currentStep > tagList.Count) return;
		Debug.LogError(tagList[currentStep].GetType());
		Fired = null;
		tagList[currentStep].Fire();

		StartCoroutine(WaitForAction(() =>
		{
			currentStep++;

            if (currentStep < tagList.Count && tagList[currentStep].GetType() != typeof(PTag))
            {
                OnClickNext();
            }
		}));
	}

	IEnumerator WaitForAction(Action action)
	{
		if(Fired != null)
		{
			yield return StartCoroutine(Fired);
		}

		action();
	}

    /// <summary>
    /// リアクティブプロパティーで呼びたい
    /// </summary>
	public void Finish()
	{
		BtnDisplay.onClick.RemoveAllListeners();
		Debug.LogError("終わり");
		SceneManager.LoadScene("NovelMenu");
	}
}
