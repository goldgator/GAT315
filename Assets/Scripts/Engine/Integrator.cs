using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Integrator
{
    public static void ExplicitEuler(Body body, float dt)
    {
        body.velocity += body.acceleration * dt;
        body.velocity = body.velocity * (1f / (1f + (body.damping * dt)));
        body.position += body.velocity * dt;
    }
}
