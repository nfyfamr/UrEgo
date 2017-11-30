using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySystem : MonoBehaviour {

    public float blockCreationTime = 1.0f;
    private float blockTime = 0.0f;
    public int maxBlock = 5;
    private static List<GameObject> blocks = new List<GameObject>();

    private float blockXPosBase = -330.0f;
    private float blockXPosOffset = 20.0f;

    [SerializeField]
    public GameObject[] blocks_prefab;
	
	void Start()
    {
        GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Player>().setHealthBar();
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

		if (true) {
			go = (GameObject) Instantiate (Resources.Load ("blocks/Ability_up2"), gameObject.transform);
		} else {
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
