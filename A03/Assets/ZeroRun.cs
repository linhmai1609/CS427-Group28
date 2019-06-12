using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroRun : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 zeroPosition;

    public float speed = 0.5f;
    public float force = 0.5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-speed, 0));
            GetComponent<Rigidbody2D>().AddForce(new Vector2(speed /5, 0));
            GetComponent<Animator>().SetBool("isRunning", true);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0));
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-speed / 5, 0));
            GetComponent<Animator>().SetBool("isRunning", true);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            GetComponent<Animator>().SetBool("isRunning", false);
            zeroPosition = transform.position;
            transform.position = zeroPosition;            
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, force));
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -force/5));
        }
        
    }
}
