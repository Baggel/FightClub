using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int MaxHealth = 100;
    int CurrentHealth;

    void Start()
    {
        //setts player health
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
      //take damage on hit
      CurrentHealth -= damage;

        if (CurrentHealth < 0)
        {
            //if your health reaches 0 die
            Die();
        }

    }



    void Die()
    {
        //when a player dies it says enemy dead
        Debug.Log("Enemy Dead");
    }  
       
       

    
}
