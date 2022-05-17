using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat : MonoBehaviour
{
    public Animator animator;
    void Update()
    {


        if (Input.GetKey(KeyCode.P))
        {
            Attack();
        }


        void Attack()
        {
            animator.SetTrigger("Attacking");
        }
    }
}
