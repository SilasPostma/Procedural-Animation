using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndEffector
{
    public Vector2 position { get; set; }
    public float length { get; }

    public EndEffector(float x, float y, float Length)
    {
        position = new Vector2(x, y);
        length = Length;
    }
}
