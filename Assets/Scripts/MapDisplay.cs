using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{

    public Renderer textureRenderer;
    public Transform cubeTransform;
    public GameObject spheres;
    public GameObject prefab;
    public Material matPrefab;

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

    public void drawNoiseMap3D(float[,,] map)
    {
        int width = map.GetLength(0);
        int height = map.GetLength(1);
        int deep = map.GetLength(2);

        cubeTransform.localScale = new Vector3(width, height, deep);
        spheres.transform.position = cubeTransform.position;
        //remove des anciennes sphere
        int childs = spheres.transform.childCount;
        for (var i = 0; i < childs; i++)
        {
            DestroyImmediate(spheres.transform.GetChild(0).gameObject);
        }
        Vector3 initPos = (cubeTransform.position - cubeTransform.forward * deep / 2) - cubeTransform.right * width / 2 - cubeTransform.up * height / 2;
        initPos += cubeTransform.right / 2;
        initPos += cubeTransform.forward / 2;
        initPos += cubeTransform.up / 2;
        Vector3 currentPos = initPos;
        Debug.Log("sphere");


        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                currentPos = initPos;
                currentPos += cubeTransform.right * x;
                currentPos += cubeTransform.up * y;
                for (int z = 0; z < deep; z++)
                {
                    //texture.SetPixel(x, y, new Color(map[x, y], map[x, y], map[x, y]));
                    GameObject go = Instantiate(prefab, currentPos, Quaternion.identity, spheres.transform);
                    Debug.Log(map[x, y, z]);
                    Material mat = new Material(matPrefab);
                    mat.color= Color.Lerp(Color.black, Color.white, map[x, y, z]);
                    go.GetComponent<MeshRenderer>().sharedMaterial = mat;
                    currentPos += cubeTransform.forward;
                }
            }
        }

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
