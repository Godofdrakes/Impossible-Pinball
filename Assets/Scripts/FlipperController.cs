﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(HingeJoint))]
public class FlipperController : MonoBehaviour
{
    public int torqueValue = 500;


    private HingeJoint hj;
    private Rigidbody rb;

    public float activeAngle = 35;
    public float passiveAngle = -35;


    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        hj = GetComponent<HingeJoint>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
	    if (Input.GetMouseButton(0))
        {
            Swing(activeAngle, torqueValue);
        }
	    else
        {
            Swing(passiveAngle, torqueValue);
        }
    }

    void Swing(float angle, float force)
    {
        var JointSpring = new JointSpring();
        JointSpring.spring = force;
        JointSpring.targetPosition = angle;
        JointSpring.damper = hj.spring.damper;
        hj.spring = JointSpring;
    }
}
