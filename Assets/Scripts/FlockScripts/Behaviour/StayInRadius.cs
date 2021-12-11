using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour In Radius")]
public class StayInRadius : FlockBehaviour
{
    public Vector2 centre;
    public float Radius;
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        Vector2 centreOffset = centre - (Vector2)agent.transform.position;
        float t = centreOffset.magnitude / Radius;
        if(t < 0.9f)
        {
            return Vector2.zero;
        }

        return centreOffset * t * t;
    }
}
