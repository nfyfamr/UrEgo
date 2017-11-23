using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterClick : MonoBehaviour {
    
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
        if (startUI != null)
        {
            Destroy(gameObject);
        } else
        {
            Debug.Log("Cannot find StartUI by tag.");
        }
    }
}
