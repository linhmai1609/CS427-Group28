using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zeroBehavior : player
{
    // Start is called before the first frame update  
    Vector2 zeroPosition;

    public Transform wallCheck;
    private RaycastHit2D wallCheckHit;

    //solving attack combo
    public int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 0.25f;
    public float wallCheckDistance;

    new void Start()
    {
        base.Start();
        zeroPosition = transform.position;     
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();        

        if (Input.GetKeyDown(KeyCode.C))
        {
            //OnClick();         
            if (animator.GetFloat("Speed") <= 0.01)
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
        }
        if (noOfClicks == 3)
        {
            noOfClicks = 0;
            animator.SetInteger("noOfClicks", noOfClicks);
        }
    }

    new void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public new void OnLanding()
    {
        base.OnLanding();
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

    
}


