using UnityEngine;
using System.Collections;
using UnityEditor;

public class TilePickerWindow : EditorWindow {

    public Vector2 scrollPosition = Vector2.zero;
    private Vector2 currentSelection = new Vector2(0, 0);
    private Object[] spriteReferences;

    [MenuItem("Window/Tile Picker")]
    static void Init()
    {
        TilePickerWindow window = (TilePickerWindow)EditorWindow.GetWindow(typeof(TilePickerWindow));
        window.title = "Tile Picker";
    }

    void OnGUI()
    {
        if (Selection.activeGameObject == null) return;
        if (Selection.activeGameObject.GetComponent<TileMap>() != null)
        {
            var selectedGameObject = Selection.activeGameObject.GetComponent<TileMap>();

            if(selectedGameObject != null)
            {
                var texture2D = selectedGameObject.texture2D;
                if (texture2D != null)
                {
                    spriteReferences = AssetDatabase.LoadAllAssetsAtPath(AssetDatabase.GetAssetPath(texture2D));

                    scrollPosition = GUI.BeginScrollView(new Rect(0, 0, position.width - 5, position.height - 5), scrollPosition, new Rect(0, 0, texture2D.width, texture2D.height));
                    GUI.DrawTexture(new Rect(0, 0, texture2D.width, texture2D.height), texture2D);

                    var tileWidth = selectedGameObject.tileSize.x;
                    var tileHeight = selectedGameObject.tileSize.y;
                    var tileGrid = new Vector2(texture2D.width / tileWidth, texture2D.height / tileHeight);

                    var boxTex = new Texture2D(1, 1);
                    boxTex.SetPixel(0, 0, new Color(0, 0.5f, 1f, 0.4f));
                    boxTex.Apply();

                    GUIStyle style = new GUIStyle(GUI.skin.customStyles[0]);
                    style.normal.background = boxTex;

                    GUI.Box(new Rect(tileWidth * currentSelection.x, tileHeight * currentSelection.y, tileWidth, tileHeight), "", style);

                    GUI.EndScrollView();

                    Event cE = Event.current;
                    Vector2 tS = new Vector2(cE.mousePosition.x - 5, cE.mousePosition.y);
                    if (Event.current.type == EventType.mouseDown && Event.current.button == 0)
                    {
                        currentSelection.x = (float)System.Math.Floor((int)(tS.x + scrollPosition.x) / tileHeight);
                        currentSelection.y = (float)System.Math.Floor((int)(tS.y + scrollPosition.y) / tileHeight);

                        if (currentSelection.x > tileGrid.x - 1) currentSelection.x = tileGrid.x - 1;
                        if (currentSelection.y > tileGrid.y - 1) currentSelection.y = tileGrid.y - 1;

                        var spriteId = (int)(currentSelection.x + (currentSelection.y * tileGrid.x) + 1);
                        var sprite = (Sprite)spriteReferences[spriteId];
                        selectedGameObject.currentTileBrush = sprite;

                        Repaint();
                    }
                }
            }
        }
    }
}
