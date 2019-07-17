using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class zeroBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 zeroPosition;
    private System.Collections.Generic.Dictionary<KeyCode, bool> keys = new System.Collections.Generic.Dictionary<KeyCode, bool>();

    public float speed;
    public float force;
    private Animator animator;
    //[SerializeField]
    //private PolygonCollider2D[] colliders;
    //private int currentColliderIndex = 0;

    public bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    //solving attack combo
    public int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 0.25f;

    void Start()
    {
        zeroPosition = transform.position;
        animator = gameObject.GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            zeroPosition = transform.position;
            zeroPosition.x -= speed;
            animator.SetBool("isRunning", true);
            transform.localScale = new Vector2(-5, 5);
            transform.position = zeroPosition;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            zeroPosition = transform.position;
            zeroPosition.x += speed;
            animator.SetBool("isRunning", true);
            transform.localScale = new Vector2(5, 5);
            transform.position = zeroPosition;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetBool("isRunning", false);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetBool("isJumping", true);
            StartCoroutine(jumpTimer());
        }        

        if (Input.GetKeyDown(KeyCode.C))
        {
            //OnClick();         
            if (animator.GetBool("isGrounded"))
            {
                lastClickedTime = Time.time;
                print(lastClickedTime);
                print(++noOfClicks + " no1");
                animator.SetInteger("noOfClicks", noOfClicks);
                if (noOfClicks == 1)
                {

                    animator.SetBool("isSlashing1", true);
                }
                noOfClicks = Mathf.Clamp(noOfClicks, 0, 2);
            }
            else
                animator.SetBool("isAirSlashing", true);
            
        }
        if (Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
            animator.SetInteger("noOfClicks", noOfClicks);
            print(noOfClicks + "updated");
        }
        if (noOfClicks == 3)
        {
            noOfClicks = 0;
            animator.SetInteger("noOfClicks", noOfClicks);
        }
    }

    private void FixedUpdate()
    {
        checkSurroundings();        
    }

    IEnumerator jumpTimer()
    {
        for (int i = 0; i < 9; ++i)
        {
            yield return new WaitForSeconds(0.01f);
            zeroPosition = transform.position;
            zeroPosition.y += force;
            transform.position = zeroPosition;
        }
        animator.SetBool("isJumping", false);
    }

    //void OnClick()
    //{
    //    //Record time of last button click
    //    lastClickedTime = Time.time;
    //    ++noOfClicks;
    //    animator.SetInteger("noOfClicks", noOfClicks);
    //    if (noOfClicks == 1)
    //    {
    //        animator.SetBool("isSlashing1", true);
    //    }
    //    //limit/clamp no of clicks between 0 and 3 because you have combo for 3 clicks
    //    noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);
    //}

    //IEnumerator slashTimer()
    //{
    //    switch (slashCount)
    //    {
    //        case 0:
    //            yield return new WaitForSeconds(0.5f);
    //            break;
    //        case 1:
    //            yield return new WaitForSeconds(0.5f);
    //            break;
    //        case 2:
    //            yield return new WaitForSeconds(0.5f);
    //            break;
    //    }
    //    if (Input.GetKey(KeyCode.C) && slashCount == 0)
    //    {
    //        animator.SetInteger("slashCounter", ++slashCount);
    //        StartCoroutine(slashTimer());
    //    }
    //    else if (Input.GetKey(KeyCode.C) && slashCount == 1)
    //    {
    //        animator.SetInteger("slashCounter", ++slashCount);
    //        StartCoroutine(slashTimer());
    //    }
    //    else if (Input.GetKey(KeyCode.C) && slashCount == 2)
    //    {
    //        animator.SetInteger("slashCounter", ++slashCount);
    //        StartCoroutine(slashTimer());
    //    }
    //    else if (Input.GetKey(KeyCode.C) && slashCount == 3)
    //    {
    //        yield return new WaitForSeconds(0.5f);
    //        StartCoroutine(slashTimer());
    //    }
    //    else
    //    {
    //        animator.SetBool("isSlashing", false);
    //        animator.SetInteger("slashCounter", 0);
    //        slashCount = 0;
    //    }
    //}

    private void checkSurroundings()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        animator.SetBool("isGrounded", isGrounded);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}


