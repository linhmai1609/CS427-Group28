using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 10f;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        Destroy(gameObject);
        zeroBehavior zero = collision.GetComponent<zeroBehavior>();
        if (zero != null)
        {
            //zero.takeDamage(damage);
        }
    }
}
