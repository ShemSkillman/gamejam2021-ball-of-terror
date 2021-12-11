using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SubmarineMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    public float Speed;

    private Camera theCam;
    private SpriteRenderer _renderer;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        theCam = Camera.main;
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if (x < 0)
            _renderer.flipX = true;
        else
            _renderer.flipX = false;
        _rigidbody.velocity = new Vector2(x * Speed * Time.deltaTime, y * Speed * Time.deltaTime);
    }
}
