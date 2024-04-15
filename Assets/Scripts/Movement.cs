using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement
{
    private Movement() { }
    private static Movement instance = null;

    public static Movement Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Movement();
            }

            return instance;
        }
    }

    private bool IsPausa = false;

    public bool GetPause()
    {
        return IsPausa;
    }

    public void SetPause()
    {
        IsPausa = true;
    }

    public void SetOffPause()
    {
        IsPausa = false;
    }
}
