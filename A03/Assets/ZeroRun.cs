using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroRun : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 zeroPosition;

    public float speed = 0.2f;
    void Start()
    {
        zeroPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            zeroPosition.x -= speed;
            GetComponent<Animator>().SetBool("isRunning", true);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            zeroPosition.x += speed;
            GetComponent<Animator>().SetBool("isRunning", true);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            GetComponent<Animator>().SetBool("isRunning", false);
        transform.position = zeroPosition;
    }
}
