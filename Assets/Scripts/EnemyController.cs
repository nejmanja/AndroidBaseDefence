using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyController : MonoBehaviour
{

    public Transform target;
    public float speed = 200f;
    public float nextWaypointDsitance = 3f;
    public float maxHealth = 100f;
    float currentHealth;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath;

    Seeker seeker;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        seeker = GetComponent<Seeker>();
        currentHealth = maxHealth;
        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    void UpdatePath()
    {
        if(seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(path == null)
        {
            return;
        }

        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force);
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if(distance < nextWaypointDsitance)
        {
            currentWaypoint++;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 11)
        {
            Debug.Log("collided with other");
            ProjectileController projectile = other.GetComponent<ProjectileController>();
            projectile.Deactivate();
            currentHealth -= projectile.damage;
            if (currentHealth <= 0f)
            {
                CancelInvoke("UpdatePath");
                gameObject.SetActive(false);
                EnemySpawner.enemyCount--;
            }


            return;
        }
    }
}
