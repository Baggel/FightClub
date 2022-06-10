using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat : MonoBehaviour
{   
    public Animator animator;
    public Transform AttackPoint;
    public float AttackRange = 0.5f;
    public LayerMask PlayerLayers;
    void Update()
    {

        //when you press the attack button you attack
        if (Input.GetKey(KeyCode.P))
        {
            Attack();
        }


        void Attack()
        {
            //plays attack animation
            animator.SetTrigger("Attacking");
            //Checks for hitboxes 
            Collider2D[] HitPlayer = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, PlayerLayers);

            foreach (Collider2D Player in HitPlayer)
            {
                //if you hit somone it says we hit them
                Debug.Log("We Hit Them!!");
            }


        }

       
    }
    private void OnDrawGizmosSelected()
    {
        //if it does not find a player do nothing
        if (AttackPoint == null)
            return;
        //Attck hitbox
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }

}
