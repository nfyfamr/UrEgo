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
	
	// Update is called once per frame
	void Update () {

        blockTime += Time.deltaTime / blockCreationTime;
        if (blockTime > blockCreationTime)
        {
            blockTime = 0;
            if (blocks.Count < maxBlock)
            {
                int rand_index = Random.Range(0, blocks_prefab.Length);
                GameObject go = (GameObject)Instantiate(blocks_prefab[rand_index], gameObject.transform);

                blocks.Add(go);
                ArrangeBlocks();
            }
        }
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
        blocks.Remove(baseEventData.selectedObject);
        Destroy(baseEventData.selectedObject);
        ArrangeBlocks();
    }
}
