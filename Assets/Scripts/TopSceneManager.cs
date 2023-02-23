using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopSceneManager : MonoBehaviour
{
	//　非同期動作で使用するAsyncOperation
	private AsyncOperation async;
	//　シーンロード中に表示するUI画面
	[SerializeField]
	private GameObject blur;

	// 遊び方説明画面
	[SerializeField]
	private GameObject mainUI;

	// 遊び方説明画面
	[SerializeField]
	private GameObject descriptionUI;

	[SerializeField]
	private Text lodingText;

	[SerializeField]
	private GameObject loadingImage;

	private bool _isShowdescriptionUI;

	void Start()
	{
		_isShowdescriptionUI = false;

		loadingImage.SetActive(false);
		lodingText.gameObject.SetActive(false);
		descriptionUI.SetActive(_isShowdescriptionUI);
		blur.SetActive(false);
		mainUI.SetActive(true);
	}

	/// <summary>
    /// 編集画面へ遷移する
    /// </summary>
	public void ToEditScene()
	{
		loadingImage.SetActive(true);
		mainUI.SetActive(false);

		//　コルーチンを開始
		StartCoroutine("LoadData");
	}

	/// <summary>
	/// 遊び方画面の表示切り替え
	/// </summary>
	public void StateChangeDescriptionUI()
	{
		_isShowdescriptionUI = !_isShowdescriptionUI;
		descriptionUI.SetActive(_isShowdescriptionUI);
		blur.SetActive(_isShowdescriptionUI);
	}

	/// <summary>
    /// 画面遷移する際のローディングアニメーション
    /// </summary>
    /// <returns></returns>
	IEnumerator LoadData()
	{
		// シーンの読み込みをする
		async = SceneManager.LoadSceneAsync("Edit");
		lodingText.gameObject.SetActive(true);

		async.allowSceneActivation = false;
		while (true)
		{
			yield return null;
			// 読み込み完了したら
			if (async.progress >= 0.9f)
			{
				// ロードバーが100%になっても1秒だけ表示維持
				yield return new WaitForSeconds(1.0f);
				lodingText.GetComponent<Text>().text = "読み込み完了！";

                yield return new WaitForSeconds(2.0f);
				loadingImage.SetActive(false);

				// シーン読み込み
				async.allowSceneActivation = true;

				break;
			}
		}

	}
}


