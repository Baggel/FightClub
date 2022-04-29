using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 public class Movment : MonoBehaviour
{
    public float MovmentSpeed = 1;
    public float JumpForce = 1;
    private bool CanDoubleJump;

    private Rigidbody2D _rigidbody2D;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        var Movment = Input.GetAxis("Horizontal");
        transform.position += new Vector3(Movment, 0, 0) * Time.deltaTime * MovmentSpeed;


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
