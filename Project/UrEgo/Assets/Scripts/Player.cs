using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour {

    private Rigidbody2D m_Rigidbody;
    private Vector3 pos;
    private Transform tr;

    void Start () {
        pos = transform.position;
        tr = transform;
    }

    void Update () {

    }

    public void doBehavior(string command)
    {
        switch (command)
        {
            case "up":
                pos += Vector3.up;
                tr.position = pos;
                break;

            case "up2":
                pos += Vector3.up * 2;
                tr.position = pos;
                break;

            case "down":
                pos += Vector3.down;
                tr.position = pos;
                break;

            case "down2":
                pos += Vector3.down * 2;
                tr.position = pos;
                break;

            case "left":
                pos += Vector3.left;
                tr.position = pos;
                break;

            case "left2":
                pos += Vector3.left * 2;
                tr.position = pos;
                break;

            case "right":
                pos += Vector3.right;
                tr.position = pos;
                break;

            case "right2":
                pos += Vector3.right * 2;
                tr.position = pos;
                break;

            case "attack":
                // do something.
                break;
        }
    }


}
