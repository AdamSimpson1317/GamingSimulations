using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePlayerMovement : MonoBehaviour
{
    //Movement for the player when they are in space since, forwards and backwards are unavailable but up and down can be used instead.
    public GameObject Planet;
    public Vector3 jump;
    public Vector3 PlanetDistanceVector;
    public float PlanetDistance;
    public float mass;
    [SerializeField] Vector3 Direction;
    [SerializeField] float Force;
    public float jumpforce = 3.0f;
    public bool Grounded = true;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0, 8, 0);
    }

    void OnCollisionStay()
    {
        Grounded = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Grounded == false)
        {
            transform.Translate(jump);
            rb.AddForce(jump);
        }
        Grounded = true;
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        Direction = new Vector3(x, 0, z);
        rb.MovePosition(transform.position + transform.TransformDirection(Direction) * Force * Time.deltaTime);
        //Tried to have a the planet have a bearing on the movement of the player but this made being accurate very difficult. 
        //PlanetDistanceVector = rb.transform.position - Planet.transform.position;
        //PlanetDistance = Mathf.Sqrt(Mathf.Pow(PlanetDistanceVector.x, 2) + Mathf.Pow(PlanetDistanceVector.y, 2) + Mathf.Pow(PlanetDistanceVector.z, 2));
        //rb.mass = (mass / PlanetDistance)-1;
    }
}
