using UnityEngine;

[System.Serializable]
public class DataPoint : MonoBehaviour
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }
    public float Size { get; set; }
    public int Color { get; set; }
    
    public DataPoint(float x, float y, float z, float size, int color)
    {
        X = x;
        Y = y;
        Z = z;
        Size = size;
        Color = color;
    }

    public string toString()
    {
        return "X: " + X + ", Y: " + Y + ", Z: " + Z + ", Size: " + Size + ", Color: " + Color;
    }
}
