using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{
    [SerializeField] private GameObject Tool;
    [SerializeField] private GameObject ToolBox;
    [SerializeField] private GameObject SearchBox;
    [SerializeField] private GameObject ToolUp;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ToolUp.activeSelf)
            {
                ToolUp.SetActive(false);
                return;
            }

            if (Tool.activeSelf)
            {
                Tool.SetActive(false);
                return;
            }

            if (ToolBox.activeSelf)
            {
                ToolBox.SetActive(false);
                return;
            }

            if (SearchBox.activeSelf)
            {
                SearchBox.SetActive(false);
                return;
            }

            Application.Quit();
        }
    }
}
