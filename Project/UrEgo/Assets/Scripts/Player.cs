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

    public void moveUp(int n = 1)
    {
        pos += Vector3.up * n;
        tr.position = pos;
    }

    public void moveDown(int n = 1)
    {
        pos += Vector3.down * n;
        tr.position = pos;
    }

    public void moveLeft(int n = 1)
    {
        pos += Vector3.left * n;
        tr.position = pos;
    }

    public void moveRight(int n = 1)
    {
        pos += Vector3.right * n;
        tr.position = pos;
    }

    void Update () {

    }
}
