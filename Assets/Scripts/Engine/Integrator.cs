using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Integrator
{
    public static void ExplicitEuler(Body body, float dt)
    {
        body.position += body.velocity * dt;
        body.velocity += body.acceleration * dt;
        body.velocity = body.velocity * (1f / (1f + (body.damping * dt)));
    }

    public static void SemiExplicitEuler(Body body, float dt)
    {
        body.velocity += body.acceleration * dt;
        body.position += body.velocity * dt;
        body.velocity = body.velocity * (1f / (1f + (body.damping * dt)));
    }


}
