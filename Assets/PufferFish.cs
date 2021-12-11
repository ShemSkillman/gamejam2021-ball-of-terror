using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PufferFish : MonoBehaviour
{
    [SerializeField] private float moveSpeed, rotationSpeed, waitTime = 3f;
    [SerializeField] private int health;
    [SerializeField] private Rigidbody2D rb;
    private float directionChangeCount;
    [SerializeField]private float directionChangeTime = 5f;
    private bool facingRight;
    private SpriteRenderer sr;
    


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        facingRight = true;
        directionChangeCount = directionChangeTime;
      
    }
    void FixedUpdate()
    {
        
        waitTime -= Time.deltaTime;
        if (waitTime <= 0)
        {
            waitTime = 0;
           
            SwimIdle();
        }
    }
    void FlipFish()
    {
        if (facingRight)
        {
            facingRight = false;
            sr.flipX = true;
        }
        else if (!facingRight)
        {
            facingRight = true;
            sr.flipX = false;
        }
    }

    void SwimIdle()
    {
        directionChangeCount -= Time.deltaTime;
        if (directionChangeCount <= 0)
        {
            FlipFish();
            directionChangeCount = directionChangeTime;
        }
        if (facingRight)
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        else if (!facingRight)
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
    }

    void TakeDamage(int damage)
    {


        if (health <= 0)
        {
            health = 0;
            JustDie();
        }
    }

    void JustDie()
    {
        sr.flipY = true;
        rb.velocity = new Vector2(0f, moveSpeed);
        Destroy(gameObject, 2f);
    }



}
