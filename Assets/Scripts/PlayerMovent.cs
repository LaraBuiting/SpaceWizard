using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovent : MonoBehaviour
{


    // Reference to rigidbody that is on the player
    private Rigidbody2D bd;

    // This variable is used so we can check if the player is on the ground
    private bool grounded;

    // Speed variable it is public so we can change it in unity without having to change it in the code
    public float speed = 2;

    public Animator animator;

    private float horizontal;
    private bool isFacingRight = true;

    public Transform groundcheck;
    public LayerMask groundlayer;

    // A awake method is called when the script instance is being loaded
    private void Awake()
    {
        // Getcomponent is used to access the rigidbody
        bd = GetComponent<Rigidbody2D>();
    }

    // Update method loads every frame
    private void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");

        Flip();

        // bd.velocity moves the player
        // Vector is a collection on numbers to for example assign speed in all two directions
        // input.getaxis horizontal is a value defined by unity and everytime you press the left
        // button or the a key it goes to minus one
        // if you press the right button or the d key it goes to 1.
        // Multiply the input.getaxis horizontal with speed to make it go faster
        bd.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, bd.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        // Here we make the jump mechanic
        // If you press the spacebar or w key do this code
        if (Input.GetKey(KeyCode.Space) && grounded || Input.GetKey(KeyCode.W) && grounded ||
            Input.GetKey(KeyCode.UpArrow) && grounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        bd.velocity = new Vector2(bd.velocity.x, speed * 1.5f);
        grounded = false;
    }

    // OnCollisionEnder2D method is called when in this case the player (with collider2D and rigidBody2D)
    // is touching another object (with rigidbody2D/collider2D) in my case the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    private void FixedUpdate()
    {
        bd.velocity = new Vector2(horizontal * speed, bd.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundlayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}