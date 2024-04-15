using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LoadData
{
    ListItems listItems = new ListItems();
    Data[] data;
    
    public void LoadElements(string json)
    {
        listItems = JsonUtility.FromJson<ListItems>(json);

        int N = listItems.listItems.Length;
        data = new Data[N];
        int i = 0;

        foreach (Item item in listItems.listItems)
        {
            data[i++] = new Data(
                item.id, item.name, item.describe,
                Resources.Load<Sprite>(item.patch_img),
                item.box, item.danger, item.components,
                item.category
                );
        }
    }

    public Data[] GetData()
    {
        return data;
    }

    public Data GetItemById(int id)
    {
        foreach (Data item in data)
        {
            if (item.Id == id)
            {
                
                return item;
            }
        }

        throw new ArgumentOutOfRangeException("Not find id Items");
    }

    public Data[] GetComponentById(int[] components)
    {
        Data[] dataComponent = new Data[components.Length];
        int i = 0;

        foreach(Data item in data)
        {
            if (components.Contains(item.Id))
            {
                dataComponent[i++] = item;
            }
        }

        return dataComponent;
    }

    public Data[] GetItemsBoxById(int box)
    {
        int N = data.Length;
        int len = 0;

        foreach(Data item in data)
        {
            if (item.Box.Contains(box))
            {
                len++;
            }
        }

        Data[] items = new Data[len];
        int i = 0;

        foreach(Data item in data)
        {
            if (item.Box.Contains(box))
            {
                items[i++] = item;
            }
        }

        return items;
    }
}
