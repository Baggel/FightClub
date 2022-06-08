using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int MaxHealth = 100;
    int CurrentHealth;

    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
      CurrentHealth -= damage;

        if (CurrentHealth < 0)
        {
            Die();
        }

    }



    void Die()
    {
        Debug.Log("Enemy Dead");
    }  
       
       

    
}
