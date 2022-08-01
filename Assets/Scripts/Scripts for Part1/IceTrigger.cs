using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTrigger : MonoBehaviour
{
    //Changes the material on the floor so that it is icy, so you slide down the slope and not just sit on it.
    public GameObject IceObject;
    public GameObject ButtonPressed;
    public GameObject OtherButton;
    public float DynamicFriction = 0.05f;
    public float StaticFriction = 0.1f;
    public Collider IceObjectCollider;
    public void OnCollisionEnter(Collision buttonCollision)
    {
        IceObjectCollider = IceObject.GetComponent<Collider>();
        IceObjectCollider.material.dynamicFriction = DynamicFriction;
        IceObjectCollider.material.staticFriction = StaticFriction;
        ButtonPressed.SetActive(false);
        OtherButton.SetActive(true);
    }
}
