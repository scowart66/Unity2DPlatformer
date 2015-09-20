using UnityEngine;
using System.Collections;
using UnityEditor;

public class NewTileMap : EditorWindow {

    [MenuItem("GameObject/Create Other/Tile Map")]
    public static void Init()
    {
        GameObject go = new GameObject("Tile Map");
        go.AddComponent<TileMap>();
    }
}
