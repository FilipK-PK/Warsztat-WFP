using UnityEngine;
using UnityEngine.UI;

public class SearchBox : MonoBehaviour
{
    OneTool ToolWiu;
    GameObject Tool;
    Data[] data;
    Transform Grid;

    public SearchBox() => ToolWiu = new OneTool();

    public void IncludeDataSearchAllCarts(Data[] data, Data[][] components, GameObject BoxTool, GameObject Tool, GameObject ToolUp)
    {
        Grid = BoxTool.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(1);
        this.Tool = ToolUp; // ???
        this.data = data;

        BoxTool.SetActive(true);

        ClearBlocks();
        CloneBlocks(components, Tool);
        
    }

    void ClearSerch(GameObject BoxTool)
    {
        BoxTool.transform.
            GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0).
            GetComponent<InputField>().text = "c";
    }

    public void SearchItems(string s)
    {
        int N = data.Length;

        if (s == "")
        {
            for (int i = 0; i < N; i++)
            {
                Grid.GetChild(i).gameObject.SetActive(true);
            }

            return;
        }

        for (int i = 0; i < N; i++)
        {
            if (data[i].Name.ToLower().Contains(s.ToLower()))
            {
                Grid.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                Grid.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    void CloneBlocks(Data[][] components, GameObject Tool)
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

    void ClearBlocks()
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
