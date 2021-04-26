using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationalForce : MonoBehaviour
{
    public static void ApplyForce(List<Body> bodies, float G)
    {
        for (int i = 0; i < bodies.Count; i++)
        {
            for (int j = i + 1; j < bodies.Count; j++)
            {
                //if (i == j) continue; // don�t apply force to self

                Body bodyA = bodies[i];
                Body bodyB = bodies[j];

                Vector2 direction = bodyA.position - bodyB.position;
                float distanceSqr = Mathf.Max(direction.sqrMagnitude, 1);
                float force = G * ((bodyA.mass * bodyB.mass) / distanceSqr);

                bodyA.AddForce(-direction.normalized * force, Body.eForceMode.Force);
                bodyB.AddForce( direction.normalized * force, Body.eForceMode.Force);
            }
        }

    }
}
