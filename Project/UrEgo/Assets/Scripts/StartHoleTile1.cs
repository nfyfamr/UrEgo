using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartHoleTile1: Tile {
    
    [SerializeField]
	private Sprite[] m_AnimatedSprites;
	public float m_AnimationSpeed = 1f;
	public float m_AnimationStartTime;

	public override void GetTileData(Vector3Int location, ITilemap tileMap, ref TileData tileData)
	{
		if (m_AnimatedSprites != null && m_AnimatedSprites.Length > 0)
		{
			tileData.sprite = m_AnimatedSprites[m_AnimatedSprites.Length - 1];
		}
	}

	public override bool GetTileAnimationData(Vector3Int location, ITilemap tileMap, ref TileAnimationData tileAnimationData)
	{
		if (m_AnimatedSprites != null && m_AnimatedSprites.Length > 0)
		{
			tileAnimationData.animatedSprites = m_AnimatedSprites;
			tileAnimationData.animationSpeed = m_AnimationSpeed;
			tileAnimationData.animationStartTime = m_AnimationStartTime;
			return true;
		}
		return false;
	}

#if UNITY_EDITOR
	[MenuItem("Assets/Create/Tiles/StartHoleTile1")]
    public static void CreateStartHoleTile1()
    {
        string path = EditorUtility.SaveFilePanelInProject("Start HoleTile1", "New Startholetile1", "asset", "Save start_hole_tile1", "Assets");
        if (path == "")
        {
            return;
        }
		AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<StartHoleTile1>(), path);
    }
#endif
}
