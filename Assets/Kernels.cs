/*Kernels.cs
by Ken Ekeoha*/
public static class Kernels
{
    public static Kernel Identity(int columns, int rows)
    {
        var k = new Kernel(columns,rows);
        
        // fill with zeros
        k.Fill(0);
        
        // set the center to 1.
        k.Set(0, 0, 1);

        return k;

    }
    
    public static Kernel Sharpen(int columns, int rows)
    {
        var k = new Kernel(columns,rows);
        
        // fill with zeros
        k.Fill(0);
        
        k.Set(0, -1, -1);
        k.Set(0, 1, -1);
        k.Set(1, 0, -1);
        k.Set(-1, 0, -1);

        k.Set(0, 0, 5);

        return k;

    }
    
    public static Kernel BoxBlur(int columns, int rows)
    {
        var k = new Kernel(columns,rows);
        
        // fill with values.
        k.Fill(1.0f/9);
        
        return k;

    }
    
    public static Kernel EdgeDetection(int columns, int rows)
    {
        var k = new Kernel(columns,rows);
        
        // fill with values.
        k.Fill(-1);

        k.Set(0, 0, 8);
        
        return k;

    }
}