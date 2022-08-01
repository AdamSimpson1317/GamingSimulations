using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToSpawn : MonoBehaviour
{
    //Puts the player back to the spawn position.
    public Vector3 StartPosition;
    public GameObject Player;
    public void OnCollisionEnter(Collision buttonCollision)
    {
        Player.transform.position = StartPosition;
    }
}
