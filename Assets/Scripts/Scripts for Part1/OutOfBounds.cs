using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    public Vector3 StartPosition;
    public GameObject Player;
    //If player goes out of bounds they move back to the start position.
    public void OnTriggerEnter()
    {
        Player.transform.position = StartPosition;
    }
}
