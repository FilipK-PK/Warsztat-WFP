using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMap : MonoBehaviour
{
    [SerializeField] private GameObject Tool;
    [SerializeField] private GameObject Tools;
    [SerializeField] private GameObject SearchTools;
    public Movement pauza = Movement.Instance;

    
    void Update()
    {
        if (Tool.activeSelf || Tools.activeSelf || SearchTools.activeSelf)
        {
            pauza.SetPause();
        }
        else
        {
            pauza.SetOffPause();
        }
    }
}
