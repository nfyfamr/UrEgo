using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GroundTile1 : Tile {
    
    [SerializeField]
    private Sprite[] sprites;

    public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
    {
        int randomVal = Random.Range(0, 5);
		tileData.sprite = sprites [randomVal];
    }


#if UNITY_EDITOR
    [MenuItem("Assets/Create/Tiles/GroundTile1")]
    public static void CreateCaveWaterPoolTile1()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save GroundTile1", "New Groundtile1", "asset", "Save ground_tile1", "Assets");
        if (path == "")
        {
            return;
        }
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<GroundTile1>(), path);
    }
#endif
}
