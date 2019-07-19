using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1Behavior : enemyBehavior
{
    public float rayCastCheckDistance;
    public float wallCheckDistance;
    private RaycastHit2D rayCastCheckHit;
    private RaycastHit2D wallCheckHit;
    float lastShotTime;
    float shootCooldown = 4f;
    bool flipped = false;

    float horizontalMove = 0f;
    protected float speed = 10f;
    public Transform rayCasting2;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        health = 30;
        lastShotTime = Time.time;
    }

    new void Update()
    {
        base.Update();
       
        if (flipped)
        {
            horizontalMove = -1f*speed;
            Debug.Log(horizontalMove);
        }
        else
        {
            horizontalMove = 1f * speed;
            Debug.Log(horizontalMove);
        }
        //animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }

    private void FixedUpdate()
    {
        Debug.Log(horizontalMove + " Updated");
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);

        wallCheckHit = Physics2D.Raycast(rayCasting2.position, rayCasting2.right, wallCheckDistance);

        if (wallCheckHit)
        {
            if (wallCheckHit.transform.name == "Grid")
            {
                flipped = !flipped;
            }
        }

        rayCastCheckHit = Physics2D.Raycast(rayCasting1.position, rayCasting1.right, rayCastCheckDistance);
        
        if (rayCastCheckHit)
        {
            if (rayCastCheckHit.transform.name == "Zero")
            {
                if (Time.time - lastShotTime >= shootCooldown)
                {
                    animator.SetBool("enemySpotted", true);
                    lastShotTime = Time.time;
                    shoot();
                }
            }            
        }        

        
    }
    // Update is called once per frame
}
