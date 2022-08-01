using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightfulTrigger : MonoBehaviour
{
    //Changes the mass of the player to very high so that they will not be able to jump as high.
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
