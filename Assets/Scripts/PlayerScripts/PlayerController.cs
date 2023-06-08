using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //movement
    public float movementSpeed, jumpForce;
    public bool isFacingRight, isJumping;
    Rigidbody2D rb;

    //ground check
    public float radius;
    public Transform groundChecker;
    public LayerMask whatIsGround;

    //animation
    Animator anim;
    string walk_parameter = "Walk";
    string idle_parameter = "Idle";
    string jump_parameter = "Jump";
    string land_parameter = "Land";


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * movementSpeed, rb.velocity.y);

        if(move != 0)
        {
            anim.SetTrigger(walk_parameter);
        }
        else
        {
            anim.SetTrigger(idle_parameter);
        }

        if(move > 0 && !isFacingRight)
        {
            transform.eulerAngles = Vector2.zero;
            isFacingRight = true;
        }
        else if(move < 0 && isFacingRight)
        {
            transform.eulerAngles = Vector2.up * 180;
            isFacingRight = false;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        if(!isGrounded() && !isJumping)
        {
            anim.SetTrigger(jump_parameter);
            isJumping = true;
        }
        else if(isGrounded() && isJumping)
        {
            anim.SetTrigger(land_parameter);
            isJumping = false;
        }
    }

    bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundChecker.position, radius, whatIsGround);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundChecker.position, radius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HolyWater"))
        {
            GoalManager.singleton.CollectHolyWater();
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Goal"))
        {
            if(GoalManager.singleton.canEnter)
            {
                print("Congrats, you won the game!");
            }
        }
    }
}
