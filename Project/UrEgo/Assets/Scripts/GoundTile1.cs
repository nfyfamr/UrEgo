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
        int randomVal = Random.Range(0, 100);

        if (randomVal < 10)
        {
            tileData.sprite = sprites[0];
        }
        else if (randomVal >= 10 && randomVal < 20)
        {
            tileData.sprite = sprites[1];
        }
        else if (randomVal >= 20 && randomVal < 80)
        {
            tileData.sprite = sprites[2];
        }
        else if (randomVal >= 80 && randomVal < 90)
        {
            tileData.sprite = sprites[3];
        }
        else if (randomVal > 90)
        {
            tileData.sprite = sprites[4];
        }
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
