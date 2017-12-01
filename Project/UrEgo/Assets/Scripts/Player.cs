using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using System;


public class Player : MonoBehaviour {

    private Rigidbody2D m_Rigidbody;
    private Vector3 pos;
    private Transform tr;
    private float currentHealth;
    private float maxHealth;
    private Tilemap grasses_tm;
    
    void Start () {
        maxHealth = 5.0f;
        currentHealth = maxHealth;
        setHealthBar();

        pos = transform.position;
        tr = transform;
        grasses_tm = Array.Find(FindObjectsOfType<Tilemap>(), x => x.name == "grasses");


    }

    void Update () {

    }

    public void setHealthBar()
    {
        GameObject go = GameObject.Find("HealthBar");
        if (go != null)
        {
            Slider healthBar = go.GetComponent<Slider>();
            healthBar.value = currentHealth / maxHealth;
            healthBar.GetComponentInChildren<Text>().text = currentHealth + " / " + maxHealth;
        }
    }

    public void doBehavior(string command)
    {
        Debug.Log(grasses_tm.WorldToCell(tr.position));
        switch (command)
        {
            case "up1":
                MoveUp();
                break;

            case "up2":
                MoveUp();
                MoveUp();
                break;

            case "down1":
                MoveDown();
                break;

            case "down2":
                MoveDown();
                MoveDown();
                break;

            case "left1":
                MoveLeft();
                break;

            case "left2":
                MoveLeft();
                MoveLeft();
                break;

            case "right1":
                MoveRight();
                break;

            case "right2":
                MoveRight();
                MoveRight();
                break;

            case "attack":
                // do something.
                break;
        }
    }

    private void MoveUp()
    {
        Vector3Int cell = grasses_tm.WorldToCell(tr.position) + Vector3Int.up;
        if (grasses_tm.GetTile(cell + Vector3Int.down) == null)
        {
            tr.position = grasses_tm.CellToWorld(cell);
        }
    }

    private void MoveDown()
    {
        Vector3Int cell = grasses_tm.WorldToCell(tr.position) + Vector3Int.down;
        if (grasses_tm.GetTile(cell + Vector3Int.down) == null)
        {
            tr.position = grasses_tm.CellToWorld(cell);
        }
    }

    private void MoveLeft()
    {
        Vector3Int cell = grasses_tm.WorldToCell(tr.position) + Vector3Int.left;
        if (grasses_tm.GetTile(cell + Vector3Int.down) == null)
        {
            tr.position = grasses_tm.CellToWorld(cell);
        }
    }

    private void MoveRight()
    {
        Vector3Int cell = grasses_tm.WorldToCell(tr.position) + Vector3Int.right;
        if (grasses_tm.GetTile(cell + Vector3Int.down) == null)
        {
            tr.position = grasses_tm.CellToWorld(cell);
        }
    }


}
