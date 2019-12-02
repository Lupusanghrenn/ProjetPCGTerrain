using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{

    public Renderer textureRenderer;

    public void drawNoiseMap(float[,] map)
    {
        int width = map.GetLength(0);
        int height = map.GetLength(1);

        Texture2D texture = new Texture2D(width, height);

        for(int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                //texture.SetPixel(x, y, new Color(map[x, y], map[x, y], map[x, y]));
                texture.SetPixel(x, y, Color.Lerp(Color.black,Color.white,map[x,y]));
            }
        }

        texture.Apply();
        textureRenderer.sharedMaterial.mainTexture = texture;
        textureRenderer.transform.localScale = new Vector3(width, 1, height);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
