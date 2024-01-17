using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float enemyHealth = 100f;
    
    
   public void TakeDamage(float damage)
   {
        GetComponent<EnemyAI>().OnDamageTaken();
        enemyHealth -= damage;
        if(enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
   }
}
