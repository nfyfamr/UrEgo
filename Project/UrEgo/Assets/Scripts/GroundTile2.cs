using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GroundTile2 : Tile {
    
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

				if (HasGround(tilemap, nPos)) //If the neighbour has water on it
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
					if (HasGround(tilemap, new Vector3Int(location.x + x, location.y + y, location.z)))
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
        if (composition[6] == 'E')
        {
			if (composition [3] == 'E') 
			{
				tileData.sprite = sprites [0];
			} 
			else if (composition [4] == 'E') 
			{
				tileData.sprite = sprites [2];
			} 
			else 
			{
				tileData.sprite = sprites [1];
			}
        }
        else if (composition[1] == 'E')
		{
			if (composition[3] == 'E') 
			{
				tileData.sprite = sprites [6];
			} 
			else if (composition [4] == 'E') 
			{
				tileData.sprite = sprites [8];
			} 
			else 
			{
				tileData.sprite = sprites [7];
			}
        }
        else if (composition[3] == 'E')
        {
            tileData.sprite = sprites[3];
        }
        else if (composition[4] == 'E')
        {
            tileData.sprite = sprites[5];
        }
        else 
        {
            tileData.sprite = sprites[4];
        }
    }

    private bool HasGround(ITilemap tilemap, Vector3Int position)
    {
        return tilemap.GetTile(position) == this;
    }

#if UNITY_EDITOR
	[MenuItem("Assets/Create/Tiles/GroundTile2")]
	public static void CreateGroundTile2()
    {
		string path = EditorUtility.SaveFilePanelInProject("Save GroundTile2", "New Groundtile2", "asset", "Save ground_tile_2", "Assets");
        if (path == "")
        {
            return;
        }
		AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<GroundTile2>(), path);
    }
#endif
}
