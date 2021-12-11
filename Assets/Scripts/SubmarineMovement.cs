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
        float x = Mathf.Max(Mathf.Min(Input.GetAxis("Mouse X"), 1f), -1f);
        float y = Mathf.Max(Mathf.Min(Input.GetAxis("Mouse Y"), 1f), -1f);

        

        if (_rigidbody.velocity.x < 0)
            _renderer.flipX = true;
        else
            _renderer.flipX = false;
        //_rigidbody.velocity = new Vector2(x * Speed * Time.deltaTime, y * Speed * Time.deltaTime);

        Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        dir = dir.normalized * Speed * _rigidbody.mass;

        _rigidbody.AddForce(dir);
    }
}
