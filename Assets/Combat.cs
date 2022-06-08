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


        if (Input.GetKey(KeyCode.P))
        {
            Attack();
        }


        void Attack()
        {
            animator.SetTrigger("Attacking");

            Collider2D[] HitPlayer = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, PlayerLayers);

            foreach (Collider2D Player in HitPlayer)
            {
                Player.GetComponent<Play>
            }


        }

       
    }
    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;
        
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }

}
