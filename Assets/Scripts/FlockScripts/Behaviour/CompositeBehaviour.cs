using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Flock/Behavior/Composite")]
public class CompositeBehaviour : FlockBehaviour
{
    public FlockBehaviour[] Behaviours;
    public float[] weights;

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        if(weights.Length != Behaviours.Length)
        {
            Debug.Log("" + name, this);
            return Vector2.zero;
        }

        Vector2 move = Vector2.zero;
        for (int i = 0; i < Behaviours.Length; i++)
        {
            Vector2 partialMove = Behaviours[i].CalculateMove(agent, context, flock) * weights[i];

            if (partialMove != Vector2.zero)
            {
                if(partialMove.sqrMagnitude > weights[i] * weights[i])
                {
                    partialMove.Normalize();
                    partialMove *= weights[i];
                }
                move += partialMove;
            }
        }
        return move;
    }
}
