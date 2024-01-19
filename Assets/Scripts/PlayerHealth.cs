using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] float currentHealth;

    public Slider healthBar;

    private GameObject enemy;

    private void Start()
    {
        currentHealth = health;
        healthBar.maxValue = health;
        enemy = GameObject.Find("Enemy");
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
    }
}
