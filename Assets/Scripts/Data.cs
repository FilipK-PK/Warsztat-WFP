using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data
{
    private int id;
    private string name;
    private string describe;
    private Sprite image;
    private int danger;
    private int[] box;
    private int category;
    private int[] components;

    public Data(int id, string name, string describe, Sprite image, int[] box, int danger, int[] components, int category )
    {
        this.Id = id;
        this.Name = name;
        this.Describe = describe;
        this.Image = image;
        this.Box = box;
        this.Danger = danger;
        this.Components = components;
        this.Category = category;
    }

    public int Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
    public string Describe { get => describe; set => describe = value; }
    public Sprite Image { get => image; set => image = value; }
    public int Danger { get => danger; set => danger = value; }
    public int[] Box { get => box; set => box = value; }
    public int Category { get => category; set => category = value; }
    public int[] Components { get => components; set => components = value; }
}
