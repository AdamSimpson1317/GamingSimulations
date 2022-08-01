using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTrigger : MonoBehaviour
{
    //Changes the mass of the player to very low so that they will jump higher.
    //The class name is misleading because speed is in reference to this section being quick since you can jump up to the end and finish very quickly, while the others are quite slow.
    public GameObject ButtonPressed;
    public GameObject OtherButton;
    public float mass;
    public Rigidbody rb;
    public void OnCollisionEnter(Collision buttonCollision)
    {
        rb.GetComponent<Rigidbody>();
        rb.mass = mass;
        ButtonPressed.SetActive(false);
        OtherButton.SetActive(true);
    }
}
