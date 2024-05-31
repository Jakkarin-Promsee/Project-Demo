using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public bool isFacingRight=true;
    public bool isAttacking = false;
    public bool isHurt = false;
    private Rigidbody2D rb2d;

    public float horizontal;
    public float vertical;

    public float movementSpeed = 1; //100%;
    public float movementlength = 8;
    public float attackSpeed = 1; //100%
    public float attackCooldown = 3;
 
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();

        StartCoroutine(AttackTimer());
    }
 
    void Update()
    {
        horizontal = Input.GetAxis ("Horizontal");
        vertical = Input.GetAxis ("Vertical");
        float move = movementSpeed*movementlength;
        rb2d.velocity = new Vector2 (horizontal*move, vertical*move);
        flip();
    }

    private void flip(){
        if((isFacingRight && horizontal<0) || (!isFacingRight && horizontal>0)){
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    IEnumerator AttackTimer()
    {
        while (true)
        {
            // Wait for 1 second
            yield return new WaitForSeconds(attackCooldown*attackSpeed);
            
            // Set attack to true after 1 second
            isAttacking = true;
            Debug.Log("gg");
        }
    }
}
