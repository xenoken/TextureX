using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureXComponent : MonoBehaviour
{
    public Texture2D tex;

    void Start()
    {
        TextureX
            // initialize a new texturex instance with the specified texture. all the following commands will apply to this texture.
            .Use(tex)
            // run a convolution kernel on the texture.
            .Kernel(Kernels.EdgeDetection(3, 3))
            // apply the state of the texture.
            .Apply()
            // save the texture to disk.
            .Save("texturex.png", out bool saved)
            // and you can also keep working on the texture, cool! :D
            .Random()
            
            .Apply()
            
            .Save("random.png", out saved)
            ;
    }
}