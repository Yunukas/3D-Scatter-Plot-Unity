using System;
public class DataPoint
{
    float X { get; set; }
    float Y { get; set; }
    float Z { get; set; }
    float Size { get; set; }
    int Color { get; set; }
    
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
