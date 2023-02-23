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
    [SerializeField]
    Text TextPath;

    string path;
    ItemData itemData;

    // Start is called before the first frame update
    public RectTransform contentRectTransform;
    public Button button;


    private void Start()
    {

        for (int i = 0; i < 20; i++)
        {
            var obj = Instantiate(button, contentRectTransform);
            obj.GetComponentInChildren<Text>().text = i.ToString();
        }

        /*
        path = Application.persistentDataPath + "/itemData.json";
        string json = File.ReadAllText(path);
        TextPath.text = json;

        var parents1 = JsonUtility.FromJson<LoadData>(json);
                */

        //TextPath.text = parents1.itemDatas[0].itemName;
    }

    public void ToTopScene()
    {
        SceneManager.LoadScene("Top");
    }
}
