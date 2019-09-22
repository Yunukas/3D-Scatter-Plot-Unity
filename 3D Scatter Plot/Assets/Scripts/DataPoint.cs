using UnityEngine;

public class DataPoint : MonoBehaviour
{
    public int Row { get; set; }
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }
    public float Size { get; set; }
    public string Color { get; set; }
    
    public DataPoint(float x, float y, float z, float size, string color)
    {
        X = x;
        Y = y;
        Z = z;
        Size = size;
        Color = color;
    }

    public override string ToString()
    {
        return "X: " + X + ", Y: " + Y + ", Z: " + Z + ", Size: " + Size + ", Color: " + Color;
    }
}
