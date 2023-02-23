using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sample : MonoBehaviour
{
	//　非同期動作で使用するAsyncOperation
	private AsyncOperation async;

	private Animator animator;

	void Start()
	{
		animator = GetComponent<Animator>();
	}

	public void NextScene()
	{
		//　コルーチンを開始
		StartCoroutine("LoadData");
	}

	IEnumerator LoadData()
	{
		// シーンの読み込みをする
		async = SceneManager.LoadSceneAsync("SampleScene");

		//　読み込みが終わるまで進捗状況をスライダーの値に反映させる
		while (!async.isDone)
		{
			animator.SetBool("Sprite Clip", true);
			yield return null;
		}
		animator.SetBool("New State", true);
	}
}
