using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    public float currentHealth;

    public Slider healthBar;

    private GameObject enemy;
    private GameObject largeEnemy;

    private void Start()
    {
        currentHealth = health;
        healthBar.maxValue = health;
        enemy = GameObject.Find("Enemy");
        largeEnemy = GameObject.Find("Large Enemy");
    }

    private void Update()
    {
        healthBar.value = currentHealth;
    }

    public void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Enemy" && enemy.GetComponent<EnemyAI>().isAggro)
        {
            currentHealth -= enemy.GetComponent<EnemyAttack>().damage;
        }

        if (Col.gameObject.tag == "Large Enemy" && largeEnemy.GetComponent<EnemyAI>().isAggro)
        {
            currentHealth -= enemy.GetComponent<EnemyAttack>().damage;
        }
    }
}
