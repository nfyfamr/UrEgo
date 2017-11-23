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
        GameObject startUI = GameObject.FindGameObjectsWithTag("StartUI")[0];
        if (startUI != null)
        {
            Destroy(startUI);
        } else
        {
            Debug.Log("Cannot find StartUI by tag.");
        }
    }
}
