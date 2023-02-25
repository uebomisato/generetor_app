using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class LoadData
{
    public ItemData[] itemDatas;
}

public class EditSceneManager : MonoBehaviour
{
    // 遊び方説明画面
    [SerializeField]
    private GameObject editPreviewUI;
    private bool _isShowEditPreviewUI;

    [SerializeField]
    private GameObject blur;

    // Start is called before the first frame update
    public RectTransform contentRectTransform;
    public Button button;


    private void Start()
    {
        _isShowEditPreviewUI = false;

        editPreviewUI.SetActive(_isShowEditPreviewUI);
        blur.SetActive(_isShowEditPreviewUI);

        for (int i = 0; i < 20; i++)
        {
            var obj = Instantiate(button, contentRectTransform);
            obj.GetComponentInChildren<Text>().text = i.ToString();
        }
    }

    public void ToTopScene()
    {
        SceneManager.LoadScene("Top");
    }

    // ボタン押した時に発動
    public void StateChangeEditPreviewUI()
    {
        _isShowEditPreviewUI = !_isShowEditPreviewUI;
        // プレビューのポップアップ表示
        editPreviewUI.SetActive(_isShowEditPreviewUI);
        blur.SetActive(_isShowEditPreviewUI);
    }

    public void OnemoreButton()
    {
        StateChangeEditPreviewUI();
    }

    public void ToPreviewButton()
    {
        SceneManager.LoadSceneAsync("Preview");
    }
}
