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

        if (IsGrounded)
        {
            animator.SetBool("IsJumping", false);
            CanDoubleJump = true;

        }
        else
        {
            animator.SetBool("IsJumping", true);
            CanDoubleJump = true;

        }



        var Movment = Input.GetAxis("Horizontal");
        transform.position += new Vector3(Movment, 0, 0) * Time.deltaTime * MovmentSpeed;

        animator.SetFloat("Speed", Mathf.Abs(Movment));

        IsGrounded = FootCollider.IsTouchingLayers(Ground); 
       


        if (!Mathf.Approximately(0, Movment))
            transform.rotation = Movment > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;


        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody2D.velocity.y) < 0.001f)
        {
            _rigidbody2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            CanDoubleJump = true;
           



        }

       


        else if ( CanDoubleJump && Input.GetButtonDown("Jump"))
        {
            _rigidbody2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            CanDoubleJump = false;
            
        }

       


    }
}
