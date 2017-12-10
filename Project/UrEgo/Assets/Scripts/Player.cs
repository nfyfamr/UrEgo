using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using System;


public class Player : MovingObject
{

    void Start()
    {
        maxHealth = 5.0f;
        currentHealth = maxHealth;
        setHealthBar();

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
                // do something.
                break;
        }

        if (SceneManager.GetActiveScene().name == "Main Scene" && isStartHole())
        {
            SceneManager.LoadScene("Stage1 Seen");
        }
    }

    public void GetDamage(int damage)
    {
        currentHealth -= damage;
        setHealthBar();
    }

    public void RestoreHealth(int point)
    {
        currentHealth += point;
        currentHealth = currentHealth > maxHealth ? maxHealth : currentHealth;
    }

    public void UpgradeHealth(int point)
    {
        maxHealth += point;
    }
}