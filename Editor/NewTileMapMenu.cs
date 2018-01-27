using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class NewTileMapMenu {

    [MenuItem("GameObject/Tile Map")]
    public static void createTileMap() {
        GameObject tileMapGameObject = new GameObject("Tile Map");
        tileMapGameObject.AddComponent <TileMap> ();
    }
}
