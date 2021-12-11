using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockAgent AgentPrefab;
    private List<FlockAgent> _agents = new List<FlockAgent>();
    public FlockBehaviour Behaviour;

    [Range(10, 500)]
    public int StartingCount = 250;
    private const float _agentDensity = 0.08f;

    [Range(1f, 100f)]
    public float DriveFactor = 10f;
    [Range(1f, 100f)]
    public float MaxSpeed = 5f;
    [Range(1f, 10f)]
    public float NeighbourRadius = 1.5f;
    [Range(1f, 1f)]
    public float AvoidanceRadiusMultiplier = 0.5f;

    private float _squareMaxSpeed;
    private float _squareNeighbourRadius;
    private float _squareAvoidanceRadius;

    public float SquareAvoidanceRadius { get { return _squareAvoidanceRadius; } }

    private void Start()
    {
        _squareMaxSpeed = MaxSpeed * MaxSpeed;
        _squareNeighbourRadius = NeighbourRadius * NeighbourRadius;
        _squareAvoidanceRadius = _squareNeighbourRadius * AvoidanceRadiusMultiplier * AvoidanceRadiusMultiplier;

        for (int  i = 0;  i < StartingCount;  i++)
        {
            FlockAgent theAgent = Instantiate(AgentPrefab,
                                            Random.insideUnitCircle * StartingCount * _agentDensity,
                                            Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                                            transform);
            theAgent.name = "Agent " + i;
            _agents.Add(theAgent);
        }
    }

    private void Update()
    {
        foreach(FlockAgent agent in _agents)
        {
            List<Transform> context = GetNearbyObjects(agent);
            Vector2 move = Behaviour.CalculateMove(agent, context, this);
            move *= DriveFactor;
            if(move.sqrMagnitude > _squareMaxSpeed)
            {
                move = move.normalized * MaxSpeed;
            }
            agent.Move(move);
        }
    }

    private List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        List<Transform> context = new List<Transform>();
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, NeighbourRadius);

        foreach(Collider2D c in contextColliders)
        {
            if(c != agent.AgentCollider)
            {
                context.Add(c.transform);
            }
        }

        return context;
    }
}
