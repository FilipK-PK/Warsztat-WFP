using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxTools : MonoBehaviour
{
    OneTool ToolWiu;
    GameObject Tool;

    public BoxTools() => ToolWiu = new OneTool ();

    public void IncludeDataItemsBoxCarts(Data[] data, Data[][] components, GameObject BoxTool, GameObject Tool, GameObject ToolUp)
    {
        Transform Grid = BoxTool.transform.GetChild(0).GetChild(0).GetChild(0);
        this.Tool = ToolUp; // ------

        BoxTool.SetActive(true);

        ClearBlocks(Grid);
        CloneBlocks(Grid, data, components, Tool);
    }

    void CloneBlocks(Transform Grid, Data[] data, Data[][] components, GameObject Tool)
    {
        GameObject cart = Grid.GetChild(0).gameObject;
        GameObject block;
        int N = data.Length;

        for (int i = 0; i < N; i++)
        {
            block = Instantiate(cart, Grid);

            block.transform.GetChild(0).GetComponent<Image>().sprite = data[i].Image;
            block.transform.GetChild(1).GetComponent<Text>().text = data[i].Name;

            block.GetComponent<Button>().AddEventListener(data[i], components[i], Tool, ItemClicked);
        }

        Destroy(cart);
    }

    void ClearBlocks(Transform Grid)
    {
        int lenChild = Grid.childCount;

        for (int i = lenChild - 1; i >= 1; i--)
        {
            Destroy(Grid.GetChild(i).gameObject);
        }

        Grid.GetChild(0).gameObject.name = "item";
    }

    void ItemClicked(Data item, Data[] components, GameObject cart)
    {
        ToolWiu.IncludeDataItemsCart(item, components, cart, Tool);
    }
}
