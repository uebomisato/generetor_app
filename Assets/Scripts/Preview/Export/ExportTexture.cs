using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using System;

public class ExportTexture : MonoBehaviour
{
#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void ExportTextureJS(string base64);
#endif

    //[SerializeField]
    //private RawImage _image;

    public void OnPressExport(RawImage _image)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        var texture = (Texture2D)_image.texture;
        var png = texture.EncodeToPNG();
        var base64 = Convert.ToBase64String(png);

        ExportTextureJS("data:image/png;base64," + base64);
#endif
    }
}
