using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FlockAgent : MonoBehaviour
{
    //private Flock _flock;
    //public FlockAgent AgentFlock { get { return AgentFlock;} }

    private Collider2D _agentCollider;
    public Collider2D AgentCollider { get { return _agentCollider; } }

    private void Start()
    {
        _agentCollider = GetComponent<Collider2D>();
    }

    //public void Initialize(FlockAgent flock)
    //{
    //    AgentFlock = flock;
    //}

    public void Move(Vector2 velocity)
    {
        transform.up = velocity;
        transform.position += (Vector3)velocity * Time.deltaTime;
    }
}
