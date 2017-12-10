using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestroyAfterClick : MonoBehaviour {
    
    public int max_enemy;

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            DestroyAndLoadControllor();
        } else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            DestroyAndLoadControllor();
        }
        
	}

    public void DestroyAndLoadControllor()
    {
        Destroy(gameObject);

        Instantiate(Resources.Load("ControllerUI"));

        for (int i=0; i<max_enemy; ++i)
        {
            Vector3 pos = MovingObject.GetTilemap().CellToWorld(new Vector3Int(Random.Range(-10, 10), Random.Range(-10, -50), 0));
            Instantiate(Resources.Load("enemies/Enemy" + Random.Range(1, 5)), pos, transform.rotation);
        }

        for (int i=0; i<20; ++i)
        {
            MovingObject.GetTilemap().SetTile(new Vector3Int(Random.Range(-10, 10), Random.Range(-10, -50), 0), Resources.Load<Tile>("items/item" + Random.Range(1, 4)));
        }
    }
}
