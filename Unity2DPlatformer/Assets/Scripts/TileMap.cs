using UnityEngine;
using System.Collections;

public class TileMap : MonoBehaviour {
    public Vector2 mapSize = new Vector2(20, 10);
    public Texture2D texture2D;
    public Vector2 tileSize = new Vector2();
    public Vector2 gridSize;
    public Sprite currentTileBrush;
    public GameObject tiles;
    public bool boxCollider;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDrawGizmosSelected()
    {
        var pos = this.transform.position;
        if (texture2D)
        {
            Gizmos.color = Color.gray;
            var row = 0;
            var maxColumns = mapSize.x;
            var total = mapSize.x * mapSize.y;
            var tile = new Vector3(tileSize.x / 100, tileSize.y / 100);
            var offset = new Vector2(tile.x / 2, tile.y / 2);

            for (var i=0;i< total; i++)
            {
                var column = i % maxColumns;
                var newX = (i % maxColumns * tile.x) + offset.x + transform.position.x;
                var newY = -(row * tile.y) - offset.y + transform.position.y;
                Gizmos.DrawWireCube(new Vector2(newX, newY), tile);
                if (column == (maxColumns - 1)){
                    row++;
                }
            }

            Gizmos.color = Color.white;
            Gizmos.DrawWireCube(new Vector2(pos.x + (gridSize.x / 2), pos.y - (gridSize.y / 2)), gridSize);
        }
    }
}
