using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SubmarineMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    public float Speed;

    private Camera theCam;
    public SpriteRenderer Renderer;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        theCam = Camera.main;
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if (x < 0)
            Renderer.flipX = true;
        else
            Renderer.flipX = false;
        _rigidbody.velocity = new Vector2(x * Speed * Time.deltaTime, y * Speed * Time.deltaTime);
    }
}
