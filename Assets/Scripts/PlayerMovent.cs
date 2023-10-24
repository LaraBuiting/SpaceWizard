using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovent : MonoBehaviour
{


    // Reference to rigidbody that is on the player
    private Rigidbody2D rb;

    // This variable is used so we can check if the player is on the ground
    private bool grounded;

    // Speed variable it is public so we can change it in unity without having to change it in the code
    public float speed = 2;

    public float jump = 100;

    public Animator animator;

    private float horizontal;
    private bool isFacingRight = true;

    public Transform groundcheck;
    public LayerMask groundlayer;

    // A awake method is called when the script instance is being loaded
    private void Awake()
    {
        // Getcomponent is used to access the rigidbody
        rb = GetComponent<Rigidbody2D>();
    }

    // Update method loads every frame
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(horizontal > 0 )
        {
            transform.rotation = new Quaternion(0,0,0,0);
        } else if (horizontal < 0)
        {
            transform.rotation = new Quaternion(0,180,0,0); 
        }




         //bd.velocity moves the player
         //Vector is a collection on numbers to for example assign speed in all two directions
         //input.getaxis horizontal is a value defined by unity and everytime you press the left
         //button or the a key it goes to minus one
         //if you press the right button or the d key it goes to 1.
         //Multiply the input.getaxis horizontal with speed to make it go faster
        
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        Debug.Log(horizontal);

        //if (horizontal > 0.01f)
        //    transform.localScale = Vector3.one;
        //else if (horizontal < -0.01f)
        //    transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();

        animator.SetBool("grounded", grounded);

    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundlayer);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jump * 1.5f);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
            grounded = true;
    }
}