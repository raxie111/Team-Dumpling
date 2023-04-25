using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    [Header("Pathfinding")]
    public Transform target;
    public float actviateDistance = 50f;
    public float pathUpdateSeconds = 0.5f;

    [Header("Physics")]
    public float speed = 200f;
    public float nextWayPointDistance = 3f;
    public float jumpNodeheightRequirement = 0.8f;
    public float jumpModifier = 0.3f;
    public float jumpCheckOffset = 0.1f;

    [Header("Custom Behavior")]
    public bool FollowEnabled = true;
    public bool jumpEnabled = true;
    public bool directionLookEnabled = true;

    private Path path;
    private int currentWaypoint = 0;
    bool isGrounded = false;
    Rigidbody2D rb;

    public void Start()
    {
       // seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, pathUpdateSeconds);
    }

    private void FixedUpdate()
    {
        //if (TargetInDistance() && FollowEnabled)
        {
           // PathFollow()
        }
    }

    private void UpdatePath()
    {
        //if (FollowEnabled && TargetInDistance() && seeker.IsDone())
        {
           // Seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    private void PathFollow()
    {
        if (path == null)
        {
            return;
        }

        //See if colliding with anything
        isGrounded = Physics2D.Raycast(transform.position, -Vector3.up, GetComponent<Collider2D>().bounds.extents.y + jumpCheckOffset);

        //Direction Calculation
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
    }
}
