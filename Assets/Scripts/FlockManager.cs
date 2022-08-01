using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public int NumberOfEnemies = 10;
    public GameObject[] AllEnemies;
    public Vector3 Limits = new Vector3(5, 5, 5);
    public Vector3 GoalPosition;

    //Sliders for min and max forward speed, neighbour distance that will affect other boids and rotation speed.
    //Kept the slider as an example for myself if I need a slider in the future.
    [Header("Enemy Settings")]
    [Range(0.0f, 5.0f)]
    public float MinimumSpeed;
    [Range(0.0f, 5.0f)]
    public float MaximumSpeed;
    [Range(1.0f, 100.0f)]
    public float NeighbourDistance;
    [Range(0.0f,5.0f)]
    public float RotationSpeed;

    void Start()
    {
        //Takes all the enemies and adjusts their positions when the game starts and gives them their target goal.
        AllEnemies = new GameObject[NumberOfEnemies];
        for(int i = 0; i < NumberOfEnemies; i++)
        {
            Vector3 position = this.transform.position = new Vector3(Random.Range(-Limits.x, Limits.x) + -90,
                                                                     Random.Range(-Limits.y, Limits.y) + 56,
                                                                     Random.Range(-Limits.z, Limits.z) + -90);
            AllEnemies[i] = (GameObject)Instantiate(EnemyPrefab, position, Quaternion.identity);
            AllEnemies[i].GetComponent<Flock>().Manager = this;
        }
        GoalPosition = this.transform.position;
    }
 
    void Update()
    {
        //Updates the goal position that the boids must get to every frame
        GoalPosition = this.transform.position;

        //This is how to make a random goal position, again kept in in case I ever need something similar in the future.
        /*if (Random.Range(0, 100) < 10)
        {
            GoalPosition = this.transform.position + new Vector3(Random.Range(-Limits.x, Limits.x),
                                                                 Random.Range(-Limits.y, Limits.y),
                                                                 Random.Range(-Limits.z, Limits.z));

        }*/
    }
}
