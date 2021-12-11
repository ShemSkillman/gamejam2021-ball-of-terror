using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PufferFish pufferFish = collision.gameObject.GetComponent<PufferFish>();

        if (pufferFish != null)
        {
            pufferFish.TakeDamage(Mathf.RoundToInt(rb.velocity.magnitude));
        }
    }
}