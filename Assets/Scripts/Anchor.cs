using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PufferFish pufferFish = collision.gameObject.GetComponent<PufferFish>();

        if (pufferFish != null)
        {

            pufferFish.TakeDamage(2);
        }
    }
}