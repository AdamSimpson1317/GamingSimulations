using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockManager Manager;
    public float speed;
    bool turning = false;
    
    void Start()
    {
        //Gets a speed within a range
        speed = Random.Range(Manager.MinimumSpeed, Manager.MaximumSpeed);
    }

    
    void Update()
    {
        //Creates an area where the boids can be within.
        Bounds b = new Bounds(Manager.transform.position, Manager.Limits * 2);

        //RayCast is used for detecting something in front of the boid and for debugging later on.
        RaycastHit hit = new RaycastHit();
        Vector3 direction = Vector3.zero;

        //Movement rules for the boids 
        if (!b.Contains(transform.position))
        {
            turning = true;
            direction = Manager.transform.position - transform.position;
        }
        else if (Physics.Raycast(transform.position, this.transform.forward * 50, out hit))
        {
            turning = true;
            direction = Vector3.Reflect(this.transform.forward, hit.normal);
            Debug.DrawRay(this.transform.position, this.transform.forward * 50, Color.black);
        }
        else
        {
            turning = false;
        }
        if (turning)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                  Quaternion.LookRotation(direction),
                                                  Manager.RotationSpeed * Time.deltaTime);
        }
        else
        {
            if (Random.Range(0, 100) < 10)
            {
                speed = Random.Range(Manager.MinimumSpeed, Manager.MaximumSpeed);
            }
            if (Random.Range(0, 100) < 20)
            {
                ApplyRules();
            }
        }

        transform.Translate(0, 0, Time.deltaTime * speed);
    }

    //Applying the movemenet rules to make the boids move as a group if close to a neighbour. 
    void ApplyRules()
    {
        //Array that holds all enemies that have been instantiated.
        GameObject[] EnemyHolder;
        EnemyHolder = Manager.AllEnemies;

        Vector3 VectorCentre = Vector3.zero;
        Vector3 VectorAvoid = Vector3.zero;
        float AverageSpeed = 0.01f;
        float NeighbourDistance;
        int GroupSize = 0;

        //for loop to check through all other boids and get their distance from the current boid and average speed.
        foreach(GameObject enemy in EnemyHolder)
        {
            if(enemy != this.gameObject)
            {
                NeighbourDistance = Vector3.Distance(enemy.transform.position, this.transform.position);
                if(NeighbourDistance <= Manager.NeighbourDistance)
                {
                    VectorCentre += enemy.transform.position;
                    GroupSize++;

                    if(NeighbourDistance < 1f)
                    {
                        VectorAvoid += (this.transform.position - enemy.transform.position);
                    }

                    Flock AnotherFlock = enemy.GetComponent<Flock>();
                    AverageSpeed += AnotherFlock.speed;
                }
            }
        }

        //Checks if there is more than 1 boid and if there is calculates the seperation, speed, rotation of the boids. 
        if(GroupSize > 0)
        {
            VectorCentre = VectorCentre / GroupSize + (Manager.GoalPosition + this.transform.position);
            speed = AverageSpeed / GroupSize;

            Vector3 direction = (VectorCentre + VectorAvoid) - transform.position;
            if(direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation,
                                                      Quaternion.LookRotation(direction),
                                                      Manager.RotationSpeed * Time.deltaTime);
            }
        }
    }
}
