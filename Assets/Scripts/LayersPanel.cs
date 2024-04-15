using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayersPanel : MonoBehaviour
{
    [SerializeField] TextAsset json;
    [SerializeField] private GameObject Tool;
    [SerializeField] private GameObject ToolBox; //del
    [SerializeField] private GameObject SearchBox;
    [SerializeField] private GameObject ToolUp;

    LoadData loadData;
    OneTool ToolWiu;
    BoxTools BoxWiu; //del
    SearchBox SBoxWiu;

    GameObject[] ListWiu;

    public LayersPanel()
    {
        loadData = new LoadData();
        ToolWiu = new OneTool();
        BoxWiu = new BoxTools();
        SBoxWiu = new SearchBox();
    }

    private void Start()
    {
        loadData.LoadElements(json.text);
        loadData.LoadElements(json.text);
    }

    public void ItemCart(int id)
    {
        Data item = loadData.GetItemById(id);
        Data[] component = loadData.GetComponentById(item.Components);

        ToolWiu.IncludeDataItemsCart(item, component, Tool, ToolUp);
    }

    public void ItemsBox(int boxId)
    {
        Data[] items = loadData.GetItemsBoxById(boxId);
        Data[][] components = new Data[items.Length][];

        int i = 0;

        foreach(Data item in items)
        {
            components[i++] = loadData.GetComponentById(item.Components);
        }

       BoxWiu.IncludeDataItemsBoxCarts(items, components, ToolBox, Tool, ToolUp);
    }

    public void SearchItems()
    {
        Data[] items = loadData.GetData();
        Data[][] components = new Data[items.Length][];

        int i = 0;

        foreach (Data item in items)
        {
            components[i++] = loadData.GetComponentById(item.Components);
        }

        SBoxWiu.IncludeDataSearchAllCarts(items, components, SearchBox, Tool, ToolUp);
    }

    public void SearchItems(string s)
    {
        SBoxWiu.SearchItems(s);
    }
}
