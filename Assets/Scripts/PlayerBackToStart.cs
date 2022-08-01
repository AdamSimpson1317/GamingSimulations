using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBackToStart : MonoBehaviour
{
    public GameObject Player;
    public Vector3 StartPosition;
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = Player.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Player.transform.position = StartPosition;
        }
    }
}
