using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //定義したクラスをJSONデータに変換できるようにする
public class ItemData
{
    public string itemName;
    public string itemImagePath;

    public ItemData(string itemName, string itemImagePath)
    {
        this.itemImagePath = itemImagePath;
        this.itemName = itemName;
    }
}
