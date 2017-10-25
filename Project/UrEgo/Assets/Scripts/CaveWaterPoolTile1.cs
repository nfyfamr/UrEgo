using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CaveWaterPoolTile1 : Tile {
    
    [SerializeField]
    private Sprite[] sprites;


    public override void RefreshTile(Vector3Int position, ITilemap tilemap)
    {
        for (int y = -1; y <= 1; y++) //Runs through all the tile's neighbours 
        {
            for (int x = -1; x <= 1; x++)
            {
                //We store the position of the neighbour 
                Vector3Int nPos = new Vector3Int(position.x + x, position.y + y, position.z);

                if (HasWater(tilemap, nPos)) //If the neighbour has water on it
                {
                    tilemap.RefreshTile(nPos); //Them we make sure to refresh the neighbour aswell
                }
            }
        }
    }


    public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
    {
        string composition = string.Empty;//Makes an empty string as compostion, we need this so that we change the sprite

        for (int y = -1; y <= 1; y++)//Runs through all neighbours 
        {
            for (int x = -1; x <= 1; x++)
            {
                if (x != 0 || y != 0) //Makes sure that we aren't checking our self
                {
                    //If the value is a watertile
                    if (HasWater(tilemap, new Vector3Int(location.x + x, location.y + y, location.z)))
                    {
                        composition += 'W';
                    }
                    else
                    {
                        composition += 'E';
                    }


                }
            }
        }
        
        //Changes the sprite based on what we see.
        if (composition[1] == 'W' && composition[3] == 'E' && composition[4] == 'W' && composition[6] == 'E')
        {
            tileData.sprite = sprites[0];
        }
        else if (composition[1] == 'W' && composition[3] == 'W' && composition[4] == 'W' && composition[6] == 'E')
        {
            tileData.sprite = sprites[1];
        }
        else if (composition[1] == 'W' && composition[3] == 'W' && composition[4] == 'E' && composition[6] == 'E')
        {
            tileData.sprite = sprites[2];
        }
        else if (composition[1] == 'W' && composition[2] == 'E' && composition[3] == 'W' && composition[4] == 'W' && composition[6] == 'W')
        {
            tileData.sprite = sprites[3];
        }
        else if (composition[0] == 'E' && composition[1] == 'W' && composition[3] == 'W' && composition[4] == 'W' && composition[6] == 'W')
        {
            tileData.sprite = sprites[4];
        }
        else if (composition[1] == 'W' && composition[3] == 'E' && composition[4] == 'W' && composition[6] == 'W')
        {
            tileData.sprite = sprites[5];
        }
        else if (composition[1] == 'W' && composition[3] == 'W' && composition[4] == 'E' && composition[6] == 'W')
        {
            tileData.sprite = sprites[7];
        }
        else if (composition[1] == 'W' && composition[3] == 'W' && composition[4] == 'W' && composition[6] == 'W' && composition[7] == 'E')
        {
            tileData.sprite = sprites[8];
        }
        else if (composition[1] == 'W' && composition[3] == 'W' && composition[4] == 'W' && composition[5] == 'E' && composition[6] == 'W')
        {
            tileData.sprite = sprites[9];
        }
        else if (composition[1] == 'E' && composition[3] == 'E' && composition[4] == 'W' && composition[6] == 'W')
        {
            tileData.sprite = sprites[10];
        }
        else if (composition[1] == 'E' && composition[3] == 'W' && composition[4] == 'W' && composition[6] == 'W')
        {
            tileData.sprite = sprites[11];
        }
        else if (composition[1] == 'E' && composition[3] == 'W' && composition[4] == 'E' && composition[6] == 'W')
        {
            tileData.sprite = sprites[12];
        }
        else
        {
            tileData.sprite = sprites[6];
        }
    }

    private bool HasWater(ITilemap tilemap, Vector3Int position)
    {
        return tilemap.GetTile(position) == this;
    }

#if UNITY_EDITOR
    [MenuItem("Assets/Create/Tiles/CaveWaterPoolTile1")]
    public static void CreateCaveWaterPoolTile1()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save CaveWaterPooltile1", "New CaveWaterPooltile1", "asset", "Save cave_water_pool_tile1", "Assets");
        if (path == "")
        {
            return;
        }
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<CaveWaterPoolTile1>(), path);
    }
#endif
}
