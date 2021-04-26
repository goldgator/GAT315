using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Circle
{
    public Vector2 center { get; set; }
    public float radius { get; set; }

    public Circle(Vector2 center, float radius)
    {
        this.center = center;
        this.radius = radius;
    }

    public bool Contains(Vector2 point)
    {
        Vector3 direction = center - point;
        float sqrDistance = direction.sqrMagnitude;
        float sqrRadius = (radius * radius);

        return (sqrDistance <= sqrRadius);
    }

    public bool Contains(Circle other)
    {
        float distance = (other.center - center).magnitude;

        return (distance < (radius + other.radius));
    }
}
