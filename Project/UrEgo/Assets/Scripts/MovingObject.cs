using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using System;


public class MovingObject : MonoBehaviour {
    
    protected float currentHealth;
    protected float maxHealth;
    public Vector3Int cell;
    

    protected bool isStartHole()
    {
        Tilemap start_hole_tm = Array.Find(FindObjectsOfType<Tilemap>(), x => x.name == "start_hole");
        TileBase cell = start_hole_tm.GetTile(start_hole_tm.WorldToCell(transform.position) + Vector3Int.down);
        return cell != null && cell.name == "Startholetile1";
    }

    protected void Step(Vector3Int v)
    {
        Tilemap tm = GetTilemap();

        if (Check(v) != null && this.name == "Player" && Check(v).name.StartsWith("item"))
        {
            switch (Check(v).name)
            {
                case "item1":
                    ((Player)this).RestoreHealth(1);
                    break;

                case "item2":
                    ((Player)this).RestoreHealth(2);
                    break;

                case "item3":
                    ((Player)this).UpgradeHealth(1);
                    break;
            }
            GetTilemap().SetTile(tm.WorldToCell(transform.position) + v + Vector3Int.down, null);
        }

        if (Check(v) == null)
        {
            Vector3Int cell = tm.WorldToCell(transform.position) + v;
            transform.position = tm.CellToWorld(cell);
            this.cell = cell;
        }
    }

    protected TileBase Check(Vector3Int v)
    {
        Tilemap tm = GetTilemap();
        return tm.GetTile(tm.WorldToCell(transform.position) + v + Vector3Int.down);
    }

    static public Tilemap GetTilemap()
    {
        if (SceneManager.GetActiveScene().name == "Main Scene")
        {
            return Array.Find(FindObjectsOfType<Tilemap>(), x => x.name == "grasses");
        }
        else
        {
            return Array.Find(FindObjectsOfType<Tilemap>(), x => x.name == "stage1_tm");
        }
    }
}
