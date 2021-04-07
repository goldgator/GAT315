using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{

    public BoolData simulate;
    public FloatData gravity;

    static World instance;
    public static World Instance { get
        {
            return instance;
        } }

    public Vector2 Gravity { get { return new Vector2(0, gravity.value); } }


    private void Awake()
    {
        instance = this;
    }

    public List<Body> bodies { get; set; } = new List<Body>();

    void Update()
    {
        if (!simulate.value) return;

        float dt = Time.deltaTime;

        bodies.ForEach(body => body.Step(dt));
        bodies.ForEach(body => Integrator.ExplicitEuler(body, dt));

        bodies.ForEach(body => body.force = Vector2.zero);
        bodies.ForEach(body => body.acceleration = Vector2.zero);
    }
}
