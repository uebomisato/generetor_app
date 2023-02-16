using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    string GetItemName()
    {
        string name = this.gameObject.name;
        return name;
       
    }

    public void OnTap()
    {
        this.GetComponent<Button>().interactable = false;
        string itemName = GetItemName();
        Debug.Log(itemName);

    }
}
