using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FlockAgent : MonoBehaviour
{
    private Collider2D _agentCollider;
    public Collider2D AgentCollider { get { return _agentCollider; } }

    private void Start()
    {
        _agentCollider = GetComponent<Collider2D>();
    }

    public void Move(Vector2 velocity)
    {
        transform.up = velocity;
        transform.position = velocity * Time.deltaTime;
    }
}
