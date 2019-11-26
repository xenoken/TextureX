/*Kernel.cs
by Ken Ekeoha*/
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using UnityEngine.UIElements;

/// <summary>
/// Small matrix. Columns go from left to right. Rows go from top to bottom. the position 0,0 is in the center of the Kernel.
/// </summary>
public class Kernel
{
    public int Columns;
    
    public int Rows;
    
    public float[] Values;
    
    public Kernel(int columns, int rows)
    {
        Columns = columns;
        
        Rows = rows;

        Values = new float[columns * rows];
    }

    private int CalcPosition(int x, int y)
    {
        // to make x:0,y:0 map to the center of the kernel.
        var offset = (Rows / 2) * Columns + (Columns / 2);

        var position = x + y * Columns;

        return position + offset;
    }

    public float Get(int x, int y)
    {
        return Values[CalcPosition(x,y)];
    }
    
    public float Set(int x, int y, float v)
    {
       return Values[CalcPosition(x,y)] = v;
    }

    public void Fill(float v)
    {
        for (int i = - Rows /2; i <= Rows / 2; i++)
        {
            for (int j = - Columns /2; j <= Columns / 2; j++)
            {
                Set(j, i, v);
            }
        }
    }

  
}