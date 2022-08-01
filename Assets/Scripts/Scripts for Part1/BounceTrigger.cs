using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceTrigger : MonoBehaviour
{
    //Changes the material on the floor so that it is bouncy and jumping is not required to get on to the obstacles.
    public GameObject BounceObject;
    public GameObject ButtonPressed;
    public GameObject OtherButton;
    public float Bounciness;
    public Collider BounceObjectCollider;
    public void OnCollisionEnter(Collision buttonCollision)
    {
        BounceObjectCollider = BounceObject.GetComponent<Collider>();
        BounceObjectCollider.material.bounciness = Bounciness;
        ButtonPressed.SetActive(false);
        OtherButton.SetActive(true);
    }
}
