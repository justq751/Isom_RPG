using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    private Transform target;
    private float movementVelocity;
    private Ray lastRay;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        UpdateAnimatior();
    }

    private void UpdateAnimatior()
    {
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        animator.SetFloat("forwardSpeed", speed);
    }

    public void MoveTo(Vector3 destination)
    {
        GetComponent<NavMeshAgent>().destination = destination;
    }
}
