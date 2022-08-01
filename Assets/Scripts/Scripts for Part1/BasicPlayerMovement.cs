using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerMovement : MonoBehaviour
{
    [SerializeField] Vector3 Direction;
    [SerializeField] float Force;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Vector3 jump;

    public bool Grounded;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        //Sets an empty game object on the bottom of the player to check if the player is "grounded"
        Grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        Direction = new Vector3(x, 0, z);
        rb.MovePosition(transform.position + transform.TransformDirection(Direction) * Force * Time.deltaTime);

        //Tried to get camera and movement working so that wherever you turned that would be forward, except this code does not work and would make the player only be able to move forward and backwards.
        float targetAngle = Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        //transform.rotation = Quaternion.Euler(0f, angle, 0f);
        //Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        
        //Player is allowed to jump if space bar is pressed and the empty game object is "touching" the ground
        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            //transform.TransformDirection(jump);
            rb.AddForce(jump);
        }
    }
}
