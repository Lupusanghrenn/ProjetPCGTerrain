using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapGenerator))]
public class MapGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MapGenerator mapGenerator = (MapGenerator)target;

        if (DrawDefaultInspector())
        {
            if (mapGenerator.autoUpdate)
            {
                mapGenerator.generateMap2D();
            }
        }

        if (GUILayout.Button("Generate"))
        {
            mapGenerator.generateMap2D();
        }

        if (GUILayout.Button("Generate3D"))
        {
            mapGenerator.generateMap3D();
        }

        if (GUILayout.Button("Marching cube"))
        {
            mapGenerator.updateMarchingCube();
        }
    }
}
