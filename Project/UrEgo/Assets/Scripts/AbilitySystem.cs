using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySystem : MonoBehaviour {

    public float blockCreationTime = 1.0f;
    private float blockTime = 0.0f;
    public int maxBlock = 5;
    private static List<GameObject> blocks = new List<GameObject>();
    private string[] directives = { "up1", "up2", "down1", "down2", "left1", "left2", "right1", "right2", "attack" };

    private float blockXPosBase = -330.0f;
    private float blockXPosOffset = 20.0f;
    	
	void Start()
    {
        GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Player>().setHealthBar();
        for (int i=0; i<maxBlock; ++i)
        {
            AddBlock();
        }
    }

	void Update () {

        blockTime += Time.deltaTime / blockCreationTime;
        if (blockTime > blockCreationTime)
        {
            blockTime = 0;
			if (blocks.Count < maxBlock) {
				AddBlock ();
			}
        }
    }
    
	public void AddBlock()
	{
		GameObject go;

        if (!blocks.Exists(o => o.name.Substring(8, o.name.Length - 16) == "up"))
        {
            go = (GameObject)Instantiate(Resources.Load("blocks/Ability_up" + Random.Range(1, 3)), gameObject.transform);
        }
        else if (!blocks.Exists(o => o.name.Substring(8, o.name.Length - 16) == "down"))
        {
            go = (GameObject)Instantiate(Resources.Load("blocks/Ability_down" + Random.Range(1, 3)), gameObject.transform);
        }
        else if (!blocks.Exists(o => o.name.Substring(8, o.name.Length - 16) == "left"))
        {
            go = (GameObject)Instantiate(Resources.Load("blocks/Ability_left" + Random.Range(1, 3)), gameObject.transform);
        }
        else if (!blocks.Exists(o => o.name.Substring(8, o.name.Length - 16) == "right"))
        {
            go = (GameObject)Instantiate(Resources.Load("blocks/Ability_right" + Random.Range(1, 3)), gameObject.transform);
        }
        else
        {
            go = (GameObject)Instantiate(Resources.Load("blocks/Ability_" + directives[Random.Range(0, directives.Length)]), gameObject.transform);
        }
        
        blocks.Add(go);
		ArrangeBlocks();
	}
		

    public void ArrangeBlocks()
    {
        for (int i=0; i< blocks.Count; ++i)
        {
            Transform t = blocks[i].transform;
            t.localPosition = new Vector3(blockXPosBase + (blockXPosOffset + ((RectTransform)t).rect.width) * i, t.localPosition.y, t.localPosition.z);
        }
    }

    public void DestroyBlock(UnityEngine.EventSystems.BaseEventData baseEventData)
    {
        GameObject go = baseEventData.selectedObject;
        
        Player p = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Player>();
        p.doBehavior(go.name.Substring(8, go.name.Length - 15));

        blocks.Remove(go);
        Destroy(go);
        ArrangeBlocks();

    }
}
