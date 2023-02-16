using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class button : MonoBehaviour
{
	//　非同期動作で使用するAsyncOperation
	private AsyncOperation async;
	//　シーンロード中に表示するUI画面
	[SerializeField]
	private GameObject loadUI;
	//　読み込み率を表示するスライダー
	[SerializeField]
	private Slider slider;
	[SerializeField]
	private GameObject loadingImage;

	void Start()
	{
		loadingImage.SetActive(false);
	}

	public void NextScene()
	{
		//　ロード画面UIをアクティブにする
		loadUI.SetActive(true);
		loadingImage.SetActive(true);

		//　コルーチンを開始
		StartCoroutine("LoadData");
	}

	IEnumerator LoadData()
	{
		// シーンの読み込みをする
		async = SceneManager.LoadSceneAsync("SampleScene");

		/*
		//　読み込みが終わるまで進捗状況をスライダーの値に反映させる
		while (!async.isDone)
		{
			var progressVal = Mathf.Clamp01(async.progress / 0.9f);
			slider.value = progressVal;
			yield return null;
		}

		loadUI.GetComponent<Text>().text = "読み込み完了！";
		yield return 3.0f;
		loadingImage.SetActive(false);
		*/

		
		async.allowSceneActivation = false;
		while (true)
		{
			yield return null;
			// 読み込み完了したら
			if (async.progress >= 0.9f)
			{
				// ロードバーが100%になっても1秒だけ表示維持
				loadUI.GetComponent<Text>().text = "読み込み完了！";
				loadingImage.SetActive(false);
				yield return new WaitForSeconds(2.0f);

				// シーン読み込み
				async.allowSceneActivation = true;

				break;
			}
		}
		
	}
}
