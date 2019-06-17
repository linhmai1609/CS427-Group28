using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroRun : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 zeroPosition;

    public float speed = 0.5f;
    public float force = 0.6f;
    [SerializeField]
    private PolygonCollider2D[] colliders;
    private int currentColliderIndex = 0;

    void Start()
    {
        zeroPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            zeroPosition = transform.position;
            zeroPosition.x -= speed;
            GetComponent<Animator>().SetBool("isRunning", true);
            GetComponent<SpriteRenderer>().flipX = true;
            transform.position = zeroPosition;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            zeroPosition = transform.position;
            zeroPosition.x += speed;
            GetComponent<Animator>().SetBool("isRunning", true);
            GetComponent<SpriteRenderer>().flipX = false;
            transform.position = zeroPosition;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            GetComponent<Animator>().SetBool("isRunning", false);              
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GetComponent<Animator>().SetBool("isJumping", true);
            StartCoroutine(jumpTimer());
        }
    }

    IEnumerator jumpTimer()
    {
        for (int i = 0; i < 7; ++i)
        {
            yield return new WaitForSeconds(0.01f);
            zeroPosition = transform.position;
            zeroPosition.y += force;
            transform.position = zeroPosition;
        }
        GetComponent<Animator>().SetBool("isJumping", false);
    }
}
