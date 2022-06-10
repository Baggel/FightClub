using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 public class Movment : MonoBehaviour
{
    public float MovmentSpeed = 1;
    public float JumpForce = 1;
    private bool CanDoubleJump;
    public Animator animator;
    private Rigidbody2D _rigidbody2D;
    public bool IsGrounded;
    public LayerMask Ground;
    public Collider2D FootCollider;


   




    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    
    void Update()
    {
        //Checks if you are on the ground and plays or dosent play the jump animation
        if (IsGrounded)
        {
            animator.SetBool("IsJumping", false);
            

        }
        else
        {
            animator.SetBool("IsJumping", true);
            

        }


        //when you press a or d you move left or right 
        var Movment = Input.GetAxis("Horizontal");
        transform.position += new Vector3(Movment, 0, 0) * Time.deltaTime * MovmentSpeed;

        animator.SetFloat("Speed", Mathf.Abs(Movment));

        IsGrounded = FootCollider.IsTouchingLayers(Ground); 
       

        //when you move a direction the player flips in that direction
        if (!Mathf.Approximately(0, Movment))
            transform.rotation = Movment > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

        //when you press the jump button and have a velocity higher than 0.001 jump
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody2D.velocity.y) < 0.001f)
        {
            _rigidbody2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            CanDoubleJump = true;
           



        }

       

        //Allows the player to double jump
        else if ( CanDoubleJump && Input.GetButtonDown("Jump"))
        {
            _rigidbody2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            CanDoubleJump = false;
            
        }

       


    }
}
