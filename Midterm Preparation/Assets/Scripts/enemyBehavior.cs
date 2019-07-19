using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController2D controller;
    public Animator animator;

    protected int health;
    public GameObject bulletPrefab;
    public GameObject enemyDeathEffect;
    private bool invulnerable = false;

    public Transform firePoint;
    public Transform rayCasting1;
    protected void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    protected void Update()
    {
        
    }

    //protected void FixedUpdate()
    //{
        
    //}

    protected void shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private void takeDamage(int damage)
    {
        health -= damage;
        if(health <=0)
        {
            decease();
        }
    }

    private void decease()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
