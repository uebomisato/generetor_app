using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PreviewSceneManager : MonoBehaviour
{
    [SerializeField] private RawImage _paintImage;
    private ExportTexture exportTexture;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ボタン押した時に発動
    public void DownloadButton()
    {
        exportTexture.OnPressExport(_paintImage);
    }

    public void ToTopButton()
    {
        SceneManager.LoadSceneAsync("Top");
    }
}
