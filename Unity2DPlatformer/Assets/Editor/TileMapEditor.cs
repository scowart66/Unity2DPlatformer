using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(TileMap))]
public class TileMapEditor : Editor {

    public TileMap map;
    private Object[] spriteReferences;

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        GUILayout.BeginVertical();
        map.mapSize = EditorGUILayout.Vector2Field("Map Size:", map.mapSize);
        GUILayout.EndVertical();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Texture2D");
        map.texture2D = (Texture2D)EditorGUILayout.ObjectField(map.texture2D, typeof(Texture2D), false);
        GUILayout.EndHorizontal();

        if(map.texture2D != null)
        {
            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Tile Size:", map.tileSize.x + "x" + map.tileSize.y);
            GUILayout.EndHorizontal();
        }

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Grid Size In Units:", map.gridSize.x + "x" + map.gridSize.y);
        GUILayout.EndHorizontal();

        if (map.texture2D)
        {
            var sprite = (Sprite)spriteReferences[1];
            var width = sprite.textureRect.width;
            var height = sprite.textureRect.height;
            map.tileSize = new Vector2(width, height);

            map.gridSize = new Vector2((width / 100) * map.mapSize.x, (height / 100) * map.mapSize.y);
        }
    }

    void OnEnable()
    {
        map = target as TileMap;
        Tools.current = Tool.View;
        if (map.texture2D)
        {
            spriteReferences = AssetDatabase.LoadAllAssetsAtPath(AssetDatabase.GetAssetPath(map.texture2D));
        }
    }
}
