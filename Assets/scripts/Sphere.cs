﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public bool CanMove = false;

    public float Speed = 50f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (!CanMove) return;

        // initial direction of ball
	    var direction = Vector3.zero;

	    if (Input.GetKey(KeyCode.UpArrow))
	    {
	        direction += Vector3.forward;
	    }
	    if (Input.GetKey(KeyCode.DownArrow))
	    {
	        direction += Vector3.back;

        }
	    if (Input.GetKey(KeyCode.RightArrow))
	    {
	        direction += Vector3.right;

	    }
	   if(Input.GetKey(KeyCode.LeftArrow))
	    {
	        direction += Vector3.left;
	    }

        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(direction * Speed);
	}
}
