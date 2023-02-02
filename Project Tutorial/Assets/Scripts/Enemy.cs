using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;
    int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    void EnemyDie()
    {
        transform.GetChild(1).gameObject.SetActive(true);
        Destroy(gameObject);
    }

    public void Damaged(int _damage)
    {
        currentHealth -= _damage;
        if(currentHealth <= 0)
        {
            EnemyDie();
        }
    }
}
