using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ItemTile : Tile {
    
    public override bool StartUp(Vector3Int position, ITilemap tilemap, GameObject go)
    {
        
        sprite = Resources.Load <Sprite>("items/item" + Random.Range(1,3));
        Debug.Log(Resources.Load("items/item" + Random.Range(1, 3)));
        return true;
    }

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        base.GetTileData(position, tilemap, ref tileData);
        
    }

}
