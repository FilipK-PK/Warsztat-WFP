using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ButtonExtension
{
    public static void AddEventListener<T, A, C>(this Button bt, T param, A datas, C cart, Action<T, A, C> OnClick)
    {
        bt.onClick.AddListener(delegate ()
        {
            OnClick(param, datas, cart);
        });
    }
}
