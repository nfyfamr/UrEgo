using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MovingObject {

    private Player player;
    private float colapsedTime = 0f;
    private float actionDelta = 1f;
    private int damage;

    // Use this for initialization
    void Start () {
        maxHealth = 3.0f;
        currentHealth = maxHealth;
        damage = 1;

        player = GameObject.FindWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        colapsedTime += Time.deltaTime / actionDelta;
        if (colapsedTime > actionDelta)
        {
            colapsedTime = 0;

            int dx = Mathf.Abs(player.cell.x - cell.x);
            int dy = Mathf.Abs(player.cell.y - cell.y);

            if ((dx == 1 && dy == 0) || (dx == 0 && dy == 1))
            {
                player.GetDamage(damage);
            } else
            {
                if (dx > dy)
                {
                    if (player.cell.x > cell.x)
                    {
                        Step(Vector3Int.right);
                    }
                    else
                    {
                        Step(Vector3Int.left);
                    }
                }
                else
                {
                    if (player.cell.y > cell.y)
                    {
                        Step(Vector3Int.up);
                    }
                    else
                    {
                        Step(Vector3Int.down);
                    }
                }
            }
        }
    }
}
