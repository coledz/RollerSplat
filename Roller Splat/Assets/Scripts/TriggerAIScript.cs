using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAIScript : MonoBehaviour
{
     public Transform target;
    public Transform myTransform;
    public Rigidbody rb;
    public float speed = 2;

    private bool isTraveling;
    private Vector3 travelDirection;

    private Vector3 nextCollisionPosition;

    private void FixedUpdate()
    {
        // Set the balls speed when it should travel
        if (isTraveling)
        {
            rb.velocity = travelDirection * speed;
        }

        // Check if we have reached our destination
        if (nextCollisionPosition != Vector3.zero)
        {
            if (Vector3.Distance(transform.position, nextCollisionPosition) < 1)
            {
                isTraveling = false;
                travelDirection = Vector3.zero;
                nextCollisionPosition = Vector3.zero;
            }
        }

        if (isTraveling)
            return;
    }

    private void SetDestination(Vector3 direction)
    {
        travelDirection = direction;

        // Check with which object we will collide
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, 100f))
        {
            nextCollisionPosition = hit.point;
        }

        isTraveling = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
