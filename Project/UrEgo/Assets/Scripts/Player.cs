using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using System;


public class Player : MonoBehaviour {
    
    private Transform tr;
    private float currentHealth;
    private float maxHealth;
    private Tilemap grasses_tm;
    private Tilemap start_hole_tm;
    private Tilemap stage1_tm;
    private String thisScene;


    void Start () {
        maxHealth = 5.0f;
        currentHealth = maxHealth;
        setHealthBar();
        
        tr = transform;
        
        Grid grid = GameObject.FindObjectOfType<Grid>();
        grasses_tm = Array.Find(FindObjectsOfType<Tilemap>(), x => x.name == "grasses");
        start_hole_tm = Array.Find(FindObjectsOfType<Tilemap>(), x => x.name == "start_hole");
        stage1_tm = Array.Find(FindObjectsOfType<Tilemap>(), x => x.name == "stage1_tm");

        thisScene = SceneManager.GetActiveScene().name;
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

        if (thisScene == "Main Scene" && isStartHole())
        {
            Application.LoadLevel("Stage1 Seen");
        }
    }

    private bool isStartHole()
    {
        TileBase cell = start_hole_tm.GetTile(start_hole_tm.WorldToCell(tr.position) + Vector3Int.down);
        return cell != null && cell.name == "Startholetile1";
    }

    private void MoveUp()
    {
        Tilemap tm;
        if (thisScene == "Main Scene")
        {
            tm = grasses_tm;
        }
        else
        {
            tm = stage1_tm;
        }

        Vector3Int cell = tm.WorldToCell(tr.position) + Vector3Int.up;
        if (tm.GetTile(cell + Vector3Int.down) == null)
        {
            tr.position = tm.CellToWorld(cell);
        }
    }

    private void MoveDown()
    {
        Tilemap tm;
        if (thisScene == "Main Scene")
        {
            tm = grasses_tm;
        }
        else
        {
            tm = stage1_tm;
        }

        Vector3Int cell = tm.WorldToCell(tr.position) + Vector3Int.down;
        if (tm.GetTile(cell + Vector3Int.down) == null)
        {
            tr.position = tm.CellToWorld(cell);
        }
    }

    private void MoveLeft()
    {
        Tilemap tm;
        if (thisScene == "Main Scene")
        {
            tm = grasses_tm;
        }
        else
        {
            tm = stage1_tm;
        }

        Vector3Int cell = tm.WorldToCell(tr.position) + Vector3Int.left;
        if (tm.GetTile(cell + Vector3Int.down) == null)
        {
            tr.position = tm.CellToWorld(cell);
        }
    }

    private void MoveRight()
    {
        Tilemap tm;
        if (thisScene == "Main Scene")
        {
            tm = grasses_tm;
        }
        else
        {
            tm = stage1_tm;
        }

        Vector3Int cell = tm.WorldToCell(tr.position) + Vector3Int.right;
        if (tm.GetTile(cell + Vector3Int.down) == null)
        {
            tr.position = tm.CellToWorld(cell);
        }
    }


}
