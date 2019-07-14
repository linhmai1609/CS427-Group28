using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Keys
{
    UP, DOWN, LEFT, RIGHT,
    Z, X, C
}

public class atkHandlerTrie
{
    static readonly int AVAILABLE_BUTTONS_NUM = 7;

    class trieNode
    {
        public trieNode[] children = new trieNode[AVAILABLE_BUTTONS_NUM];

        public bool endOfCombo;

        public trieNode()
        {
            endOfCombo = false;
            for (int i = 0; i < AVAILABLE_BUTTONS_NUM; i++)
                children[i] = null;
        }
    }

    static trieNode root;

    // If not present, inserts key into trie 
    // If the key is prefix of trie node,  
    // just marks leaf node 
    static void insert(String[] key)
    {
        int level;
        int length = key.Length;
        int index;

        trieNode pCrawl = root;

        for (level = 0; level < length; level++)
        {
            
            if (pCrawl.children[index] == null)
                pCrawl.children[index] = new trieNode();

            pCrawl = pCrawl.children[index];
        }

        // mark last node as leaf 
        pCrawl.endOfCombo = true;
    }

    // Returns true if key  
    // presents in trie, else false 
    static bool search(String key)
    {
        int level;
        int length = key.Length;
        int index;
        trieNode pCrawl = root;

        for (level = 0; level < length; level++)
        {
            index = key[level] - 'a';

            if (pCrawl.children[index] == null)
                return false;

            pCrawl = pCrawl.children[index];
        }

        return (pCrawl != null && pCrawl.isEndOfWord);
    }

}

public class zeroBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 zeroPosition;

    atkHandlerTrie

    public float speed;
    public float force;
    private float slashCounter = 0;
    private Animator animator;
    //[SerializeField]
    //private PolygonCollider2D[] colliders;
    //private int currentColliderIndex = 0;

    public bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

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
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetBool("isJumping", true);
            StartCoroutine(jumpTimer());
        }
    }

    private void FixedUpdate()
    {
        checkSurroundings();
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
        animator.SetBool("isJumping", false);
    }

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


