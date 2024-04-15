using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close : MonoBehaviour
{
    [SerializeField] private GameObject Layer;
    private Movement Panel = Movement.Instance;

    public void CloseLayer()
    {
        Layer.SetActive(false);
    }
}
