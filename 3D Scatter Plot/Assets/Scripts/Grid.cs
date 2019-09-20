using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour
{

    public bool showMain = true;
    //public bool showSub = false;

    public int gridSizeX;
    public int gridSizeY;
    public int gridSizeZ;

    public float step;

    public float startX;
    public float startY;
    public float startZ;

    public Color color = new Color(0.5f, 0.5f, 0.5f, 1f);
   
    static Material lineMaterial;

    void Awake()
    {
        // must be called before trying to draw lines..
        CreateLineMaterial();
    }
    static void CreateLineMaterial()
    {
        // Unity has a built-in shader that is useful for drawing
        // simple colored things.
        Shader shader = Shader.Find("Hidden/Internal-Colored");
        lineMaterial = new Material(shader);
        lineMaterial.hideFlags = HideFlags.HideAndDontSave;
        // Turn on alpha blending
        lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        // Turn backface culling off
        lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
        // Turn off depth writes
        lineMaterial.SetInt("_ZWrite", 0);  
    }

    // Will be called after all regular rendering is done
    public void OnRenderObject()
    {
        // Apply the line material
        lineMaterial.SetPass(0);

        GL.PushMatrix();
        // Set transformation matrix for drawing to
        // match our transform
        GL.MultMatrix(transform.localToWorldMatrix);

        // Draw lines
        GL.Begin(GL.LINES);

        GL.Color(color);

        //Layers
        for (float j = 0; j <= gridSizeY; j += step)
        {
            //X axis lines for XY plane
            GL.Vertex3(startX, startY + j, startZ);
            GL.Vertex3(startX + gridSizeX, startY + j, startZ);

            //Z axis lines for YZ plane
            GL.Vertex3(startX, startY + j, startZ);
            GL.Vertex3(startX, startY + j, startZ + gridSizeZ);


        }

        for (float j = 0; j <= gridSizeX; j += step)
        {
            //Y axis lines for XY plane
            GL.Vertex3(startX + j, startY, startZ);
            GL.Vertex3(startX + j, startY + gridSizeY, startZ);

            //Z axis lines for XZ plane
            GL.Vertex3(startX + j, startY, startZ);
            GL.Vertex3(startX + j, startY, startZ + gridSizeZ);

        }

        for (float j = 0; j <= gridSizeZ; j += step)
        {
            //X axis lines for XZ plane
            GL.Vertex3(startX, startY, startZ + j);
            GL.Vertex3(startX + gridSizeX, startY, startZ + j);

            //Y axis lines for YZ plane
            GL.Vertex3(startX, startY, startZ + j);
            GL.Vertex3(startX, startY + gridSizeY, startZ + j);

        }
        GL.End();
        GL.PopMatrix();
    }
}