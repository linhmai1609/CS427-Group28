using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public CharacterController2D controller;
    protected int health = 100;
    protected float speed = 140f;
    float horizontalMove = 0f;
    protected bool jump = false;

    protected float force;
    protected Animator animator;


    //public bool isGrounded;
    //public Transform groundCheck;
    //public float groundCheckRadius;
    //public LayerMask whatIsGround;

    // Start is called before the first frame update
    protected void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        //controller = gameObject.GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    protected void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
            //isGrounded = false;            
        }

        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    zeroPosition = transform.position;
        //    zeroPosition.x -= speed;
        //    animator.SetBool("isRunning", true);
        //    transform.localScale = new Vector2(-5, 5);
        //    transform.position = zeroPosition;
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    zeroPosition = transform.position;
        //    zeroPosition.x += speed;
        //    animator.SetBool("isRunning", true);
        //    transform.localScale = new Vector2(5, 5);
        //    transform.position = zeroPosition;
        //}
        //if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        //{
        //    animator.SetBool("isRunning", false);
        //}
        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    animator.SetBool("isJumping", true);
        //    StartCoroutine(jumpTimer());
        //}  
    }

    protected void FixedUpdate()
    {
        //checkSurroundings();

        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;

        //wallCheckHit = Physics2D.Raycast(wallCheck.position, wallCheck.right, wallCheckDistance, whatIsGround);

        //if (wallCheckHit)
        //{
        //    Debug.Log("isTouching Ground");
        //}
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    //IEnumerator jumpTimer()
    //{
    //    for (int i = 0; i < 9; ++i)
    //    {
    //        yield return new WaitForSeconds(0.01f);
    //        zeroPosition = transform.position;
    //        zeroPosition.y += force;
    //        transform.position = zeroPosition;
    //    }
    //    animator.SetBool("isJumping", false);
    //}

    //private void checkSurroundings()
    //{
    //    isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    //    animator.SetBool("isGrounded", isGrounded);
    //}

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    //}
}
