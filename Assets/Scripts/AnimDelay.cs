using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimDelay : MonoBehaviour
{
    float delay = 0f;

    Animator animator;

    private float timer;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= delay)
        {
            timer = 0f;
            delay = Random.Range(0f, 3f);
            animator.SetTrigger("crush");
        }
    }
}
