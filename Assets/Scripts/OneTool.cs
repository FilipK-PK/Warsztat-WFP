using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OneTool : MonoBehaviour
{
    GameObject Wiu;
    GameObject WiuUp;
    Data Item;
    Data[] Components;
    float arm;

    protected string[] ListsBox =
    {
        "Warsztat", //1
        "Stolarnia", //2
        "Lakiernia", //3
        "Sala prac manualnych", //4
        "Stary kantorek", //5
        "Sala 014?", // 6
        "Œwietlica", //7
        "Szafa szklana warsztat",
        "Szafa czerwona warsztat",
        "Sejf Stolarnia",
        "Sejf lakiernia",
    };

    protected string[] Alert =
    {
        "Pod kontrol¹ prowadzacego !",
        "Tylko prowadzacy"
    };

    protected string[] User =
    {
        "Narzêdzie s³u¿y do:",
        "Chetnie pomo¿e w:",
        "Pomieszczenie do:"
    };

    void SetWidth()
    {
        GameObject block = Wiu.transform.GetChild(1).gameObject;

        float width = Screen.width - 110.0f;
        float height = Screen.height - 110.0f;

        if (height > width)
        {
            arm = width;
            width = height;
            height = arm;
        }

        if (width >= 2 * height)
        {
            arm = height;
        }
        else
        {
            arm = width / 2.0f;
        }

        Vector2 newSize = new Vector2(arm - 70.0f, arm - 10.0f);
        block.transform.GetComponent<GridLayoutGroup>().cellSize = newSize;
    }

    public void IncludeDataItemsCart(Data Item, Data[] Component, GameObject Tool, GameObject ToolUp)
    {
        this.Wiu = Tool;
        this.WiuUp = ToolUp;
        this.Item = Item;
        this.Components = Component;

        Wiu.SetActive(true);

        this.SetWidth();
        this.SetImagePanel();
        this.SetInfoPanel();
    }

    void SetImagePanel()
    {
        GameObject img = Wiu.transform.GetChild(1).GetChild(0).gameObject;

        img.transform.GetChild(0).GetComponent<Image>().sprite = Item.Image;
        img.transform.GetChild(1).GetComponent<Text>().text = Item.Name;
    }

    void SetInfoPanel()
    {
        GameObject info = Wiu.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(0).gameObject;

        SetDengerUpPanel(info);
        SetDescribeUpPanel(info);
        SetBoxUpPanel(info);
        SetComponentUpPanel(info);
    }

    void SetDengerUpPanel(GameObject component)
    {
        if (Item.Danger == 0)
        {
            component.transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            component.transform.GetChild(0).gameObject.SetActive(true);

            component.transform.
                GetChild(0).
                GetComponent<Text>().text = Alert[Item.Danger - 1];
        }
    }

    void SetDescribeUpPanel(GameObject componemt)
    {
        componemt.transform.GetChild(1).
            GetComponent<Text>().text = User[Item.Category];

        componemt.transform.
            GetChild(2).GetChild(0).GetChild(0)
            .GetComponent<Text>().text = Item.Describe;
    }

    void SetBoxUpPanel(GameObject component)
    {
        if (Item.Category == 0 && Item.Box.Length > 0)
        {
            component.transform.
                GetChild(3).gameObject.SetActive(true);

            component.transform.
                GetChild(4).GetChild(0).GetChild(0).
                gameObject.SetActive(true);

            String nameBox = "";

            foreach (int i in Item.Box)
            {
                if (i != -1)
                {
                    nameBox += "- " + ListsBox[i - 1] + '\n';
                }
                else
                {
                    nameBox += "---\n";
                }
            }

            nameBox = nameBox.Remove(nameBox.Length - 1);

            component.transform.
                GetChild(4).GetChild(0).GetChild(0).
                GetComponent<Text>().text = nameBox;
        }
        else
        {
            component.transform.
                GetChild(3).gameObject.SetActive(false);

            component.transform.
                GetChild(4).GetChild(0).GetChild(0).
                gameObject.SetActive(false);
        }
    }

    void SetComponentUpPanel(GameObject component)
    {   
        if (Item.Components.Length == 0)
        {
            component.transform.GetChild(5).gameObject.SetActive(false);
            component.transform.GetChild(6).gameObject.SetActive(false);
        }
        else
        {
            component.transform.GetChild(5).gameObject.SetActive(true);
            component.transform.GetChild(6).gameObject.SetActive(true);

            int lenBlock = component.transform.GetChild(6).childCount;

            GameObject block;
            GameObject cart = component.transform.GetChild(6).GetChild(0).gameObject;

            for (int i=lenBlock-1; i>=1; i--)
            {
                Destroy(component.transform.GetChild(6).GetChild(i).gameObject);
            }

            int N = Item.Components.Length;

            for(int i=0; i<N; i++)
            {
                block = Instantiate(cart, component.transform.GetChild(6));

                block.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = Components[i].Name;
                block.GetComponent<Button>().AddEventListener(Components[i], new Data[0], WiuUp, ItemClicked);
            }

            Destroy(cart);
        }

        void ItemClicked(Data item, Data[] components, GameObject cart)
        {
            OneTool ToolWiuUp = new OneTool();
            ToolWiuUp.IncludeDataItemsCart(item, components, cart, null);
        }
    }
}
