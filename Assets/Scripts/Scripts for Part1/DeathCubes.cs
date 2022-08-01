using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCubes : MonoBehaviour
{
    //Put on the cubes when sliding down the ice, so that they put you back to the spawn if you hit them.
    public Vector3 StartPosition;
    public GameObject Player;
    public void OnCollisionEnter(Collision buttonCollision)
    {
        Player.transform.position = StartPosition;
    }
}
