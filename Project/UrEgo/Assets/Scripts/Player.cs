using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using System;


public class Player : MovingObject
{
    private int damage;

    void Start()
    {
        maxHealth = 20.0f;
        currentHealth = maxHealth;
        setHealthBar();
        
        damage = 2;
    }

    void Update()
    {

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
                Step(Vector3Int.up);
                break;

            case "up2":
                Step(Vector3Int.up);
                Step(Vector3Int.up);
                break;

            case "down1":
                Step(Vector3Int.down);
                break;

            case "down2":
                Step(Vector3Int.down);
                Step(Vector3Int.down);
                break;

            case "left1":
                Step(Vector3Int.left);
                break;

            case "left2":
                Step(Vector3Int.left);
                Step(Vector3Int.left);
                break;

            case "right1":
                Step(Vector3Int.right);
                break;

            case "right2":
                Step(Vector3Int.right);
                Step(Vector3Int.right);
                break;

            case "attack":
                Enemy e;
                if ((e = HasEnemy(Vector3Int.up)) != null)
                {
                    e.GetDamage(damage);
                }

                if ((e = HasEnemy(Vector3Int.down)) != null)
                {
                    e.GetDamage(damage);
                }

                if ((e = HasEnemy(Vector3Int.left)) != null)
                {
                    e.GetDamage(damage);
                }

                if ((e = HasEnemy(Vector3Int.right)) != null)
                {
                    e.GetDamage(damage);
                }
                break;
        }

        if (SceneManager.GetActiveScene().name == "Main Scene" && isStartHole())
        {
            AbilitySystem.blocks.Clear();
            SceneManager.LoadScene("Stage1 Seen");
        }
    }

    public override void GetDamage(int damage)
    {
        base.GetDamage(damage);
        setHealthBar();
    }

    public void RestoreHealth(int point)
    {
        currentHealth += point;
        currentHealth = currentHealth > maxHealth ? maxHealth : currentHealth;
        setHealthBar();
    }

    public void UpgradeHealth(int point)
    {
        maxHealth += point;
        setHealthBar();
    }
}