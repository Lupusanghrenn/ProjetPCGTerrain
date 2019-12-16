using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Header("MapSettings")]
    public int mapWidth;
    public int mapHeight;
    public int mapDeep;
    public float mapScale;
    [Range(0.0f,1.0f)]
    public float seuil;
    public int mapChunkSize;

    [Header("Perlin Noise Settings")]
    public int octaves;
    [Range(0f,1f)]
    public float persistance;
    public float lacunarity;

    public int seed;
    public Vector3 offset;

    public bool autoUpdate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generateMap2D()
    {
        float[,] map = Noise.GenerateNoiseMap2D(mapWidth, mapHeight,seed, mapScale,octaves,persistance,lacunarity,new Vector2(offset.x,offset.y));

        MapDisplay display = FindObjectOfType<MapDisplay>();
        display.drawNoiseMap(map);
    }

    public Mesh generateMap3D()
    {
        float[,,] map = Noise.GenerateNoiseMap3D(mapWidth, mapHeight, mapDeep, seed, mapScale, octaves, persistance, lacunarity, offset);

        MapDisplay display = GetComponent<MapDisplay>();
        MarchingCube mc = GetComponent<MarchingCube>();

        mc.setMap(map);
        return mc.debugCubes(seuil);

        //display.drawNoiseMap3D(display.generatePositions3D(map),map, seuil);
    }

    public void updateMarchingCube()
    {
        MarchingCube mc = GetComponent<MarchingCube>();
        mc.debugCubes(seuil);
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
