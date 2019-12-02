using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int mapWidth;
    public int mapHeight;
    public float mapScale;

    public int octaves;
    [Range(0f,1f)]
    public float persistance;
    public float lacunarity;

    public int seed;
    public Vector2 offset;

    public bool autoUpdate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generateMap()
    {
        float[,] map =Noise.generateNoiseMap(mapWidth, mapHeight,seed, mapScale,octaves,persistance,lacunarity,offset);

        MapDisplay display = FindObjectOfType<MapDisplay>();
        display.drawNoiseMap(map);
    }

    public void OnValidate()
    {
        if (lacunarity < 1f)
        {
            lacunarity = 1f;
        }

        if (octaves < 2)
        {
            octaves = 2;
        }
    }
}
