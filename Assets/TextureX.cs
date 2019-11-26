/*TextureX.cs
by Ken Ekeoha*/

using System;
using UnityEngine;

public class TextureX
{
    public Texture2D texture;

    private TextureX(Texture2D texture)
    {
        this.texture = texture;
    }

    public static TextureX Use(Texture2D texture)
    {
        return new TextureX(texture);
    }
    
    public TextureX ForEach(Func<int, int, int, int, Color> action)
    {
        var columns = texture.width;

        var rows = texture.height;

        var pixels = new Color[rows * columns];

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                pixels[c + r * columns] = action(c, r, columns, rows);

                //texture.SetPixel(c, r, action(c, r, columns, rows));
            }
        }

        texture.SetPixels(pixels);

        return this;
    }

    public TextureX White()
    {
        ForEach((c, r, w, h) => { return Color.white; });
        return this;
    }

    public TextureX Black()
    {
        ForEach((c, r, w, h) => { return Color.white; });
        return this;
    }

    public TextureX Fill(Color color)
    {
        ForEach((c, r, w, h) => { return color; });
        return this;
    }

    public TextureX Random()
    {
        ForEach((c, r, w, h) => { return UnityEngine.Random.ColorHSV(); });
        return this;
    }

    public TextureX Kernel(Kernel k)
    {
        
        Color RunKernel(int c, int r, int w, int h)
        {
            Color accum = Color.black;

            for (int i = -k.Rows / 2; i <= k.Rows / 2; i++)
            {
                for (int j = -k.Columns / 2; j <= k.Columns / 2; j++)
                {
                    var weight = k.Get(j, i);

                    try
                    {
                        var sample = texture.GetPixel(c - i, r - j);

                        accum += weight * sample;
                    }
                    catch
                    {
                        Debug.Log("There was an error.");
                    }
                }
            }

            return accum;
        }

        ForEach(RunKernel);

        return this;
    }

    public TextureX Apply()
    {
        texture.Apply();
        return this;
    }

    public TextureX Bytes(Action<byte[]> action, Formats format = Formats.Png)
    {
        switch (format)
        {
            case Formats.Png:
                action(texture.EncodeToPNG());
                break;
            case Formats.Tga:
                action(texture.EncodeToTGA());
                break;
            case Formats.Jpg:
                action(texture.EncodeToJPG());
                break;
            case Formats.Exr:
                action(texture.EncodeToEXR());
                break;
            default:
                action(texture.EncodeToPNG());
                break;
        }

        return this;
    }

    public TextureX Save(string path, out bool success, Formats format = Formats.Png)
    {
        try
        {
            Bytes((data) => { System.IO.File.WriteAllBytes(path, data); }, format);
            success = true;
        }
        catch (Exception ex)
        {
            success = false;
        }

        return this;
    }

    public enum Formats
    {
        Png,
        Tga,
        Jpg,
        Exr
    }
}