﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverController : MonoBehaviour {
    Mover discover;
    public Planet planet;
    public Vector2 wind;
    public Vector2 gravity;

    public float frictionCoeff = 0.01f;

	// Use this for initialization
	void Start () {
        discover = GameObject.Find("Discover").GetComponent<Mover>();
        wind = new Vector2(0.01f, 0.0f);
        gravity = new Vector2(0.0f, -0.1f);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            discover.Reset();
        }

        //Attract
        float distance = ((Vector2)discover.transform.position - (Vector2)planet.transform.position).magnitude;
        if(distance > planet.minDistance && distance < planet.maxDistance)
        {
            discover.ApplyForce(planet.Attract(discover));
        }

        discover.Move();
    }

    Vector2 GetFriction(Mover m)
    {
        Vector2 friction = m.velocity;
        friction *= -1.0f;
        friction = friction.normalized;
        friction *= frictionCoeff;
        return friction;
    }
}
