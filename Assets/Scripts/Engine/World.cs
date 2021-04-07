using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{

    public BoolData simulate;
    public FloatData gravity;
    public FloatData fixedFPS;
    public StringData FPSData;
    public FloatData FPSRawValue;

    private float timeAccumulator;
    public float fixedDeltaTime { get { return 1.0f / fixedFPS.value; } }


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
        timeAccumulator += dt;

        while (timeAccumulator > fixedDeltaTime)
        {
            float smoothing = .95f;
            float rawFPS = (1.0f / timeAccumulator);
            FPSRawValue.value = (rawFPS * smoothing) + (FPSRawValue.value * (1.0f - smoothing));
            FPSData.value = FPSRawValue.value + "";

            bodies.ForEach(body => body.Step(fixedDeltaTime));
            bodies.ForEach(body => Integrator.ExplicitEuler(body, fixedDeltaTime));

            bodies.ForEach(body => body.force = Vector2.zero);
            bodies.ForEach(body => body.acceleration = Vector2.zero);

            timeAccumulator -= fixedDeltaTime;
        }
    }
}
