using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SpriteCombiner : MonoBehaviour
{

    [SerializeField] private RawImage _paintImage;
    //public RectTransform iconRect; // アイコン画像を含むRectTransform
    //public string savePath = "Images/icon.png"; // 保存先のファイルパス

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
    public void hoge()
    {
        //string saveImagePath = GetSavePath("Images");
        //ConvertToPngAndSave(saveImagePath);
        exportTexture.OnPressExport(_paintImage);
    }

}
