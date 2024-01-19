using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

        if(currentHealth <= 0)
        {
            PlayerDeath();
        }
    }

    public void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Enemy")
        {
            currentHealth -= enemy.GetComponent<EnemyAttack>().damage;
        }

        if (Col.gameObject.tag == "Large Enemy")
        {
            currentHealth -= enemy.GetComponent<EnemyAttack>().damage;
        }
    }

    public void PlayerDeath()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("DeathScreen");
    }
}
