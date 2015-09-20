using UnityEngine;
using System.Collections;

public class TileBrush : MonoBehaviour {

    public Vector2 brushSize = new Vector2();
    public int tileId;
    public SpriteRenderer renderer2D;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, brushSize);
    }

    public static TileBrush CreateBrush(TileMap map)
    {
        var sprite = map.currentTileBrush;
        TileBrush brush = null;

        if (sprite)
        {
            GameObject go = new GameObject("Brush");
            go.transform.parent = map.transform;

            brush = go.AddComponent<TileBrush>();
            brush.renderer2D = go.AddComponent<SpriteRenderer>();

            brush.brushSize = new Vector2(sprite.textureRect.width / 100, sprite.textureRect.height / 100);

            brush.UpdateBrush(sprite);
        }
        return brush;
    }

    public void UpdateBrush(Sprite sprite)
    {
        if (renderer2D.name != sprite.name)
        {
            renderer2D.sprite = sprite;
        }
    }

    public void Destroy()
    {
        DestroyImmediate(gameObject);
    }
}
