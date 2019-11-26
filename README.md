# TextureX
An easy and effective way to manipulate textures in Unity.

## What

TextureX is a lean library for Unity, that allows you to manipulate textures very quickly and easily.

## How
1. Use a Texture

    ```var texx = TextureX.Use(texture)```

2. Apply commands to the texturex instance

    ```texx = texx.Random() // fills the texture with random pixels.```

3. Commit the commands

    ```texx = texx.Apply()```

    And that's it!
    
    
- There is a selection of commands to choose from and it is also possible to extend TextureX with your custom commands!

- The API follows a fluent architecture for which it is possible to concatenate commands. for example :

    ```TextureX.Use(texture).Random().Apply()```.

    So cool, isn't it?

## Why
The built-in texture API in Unity is already very powerful, but I wanted to improve the workflow by exposing a very lean and semantic API.  

## Who
Ken Ekeoha (xenoken)

## License
See LICENSE
