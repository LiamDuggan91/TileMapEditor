using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TileMap))]
public class TileMapEditor : Editor {

    public TileMap map;
    public override void OnInspectorGUI()
    {
        EditorGUILayout.BeginVertical();

        map.mapSize = EditorGUILayout.Vector2Field("Map Size : ", map.mapSize);
        map.texture = (Texture2D) EditorGUILayout.ObjectField("Texture 2d : ", map.texture, typeof(Texture2D), false);

        if (map.texture == null)
        {
            EditorGUILayout.HelpBox("The Texture2d field is not populated on this object", MessageType.Warning);
        }
        else {
            EditorGUILayout.LabelField("Tile Size : ", map.tileSize.x + "x" + map.tileSize.y );
        }

        EditorGUILayout.EndVertical();
    }

    void OnEnable()
    {
        map = target as TileMap;
        Tools.current = Tool.View;

        if(map.texture != null)
        {
            var path = AssetDatabase.GetAssetPath(map.texture);
            map.objectRefs = AssetDatabase.LoadAllAssetsAtPath(path);
            //We're getting the second element because when we laod a texture 2d object this way, the first element in the array is the texture2d object itself
            var sprite = (Sprite)map.objectRefs[1];
            var height = sprite.textureRect.height;
            var width = sprite.textureRect.width;
            var testVar = new Object();
            map.tileSize = new Vector2(width, height);

            map.gridSize = new Vector2();
        }
    }
}
