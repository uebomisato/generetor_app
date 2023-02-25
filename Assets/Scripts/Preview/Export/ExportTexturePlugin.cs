using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class ExportTexturePlugin
{
#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void ExportTextureJS(string base64);
#endif

    public static void ExportTexture(string base64)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        ExportTextureJS("data:image/png;base64," + base64);
#endif
    }

}
