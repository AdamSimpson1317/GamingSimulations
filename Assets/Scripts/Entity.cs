using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    Vector3 AgentVelocity = new Vector3();

    // Update is called once per frame
    void Update()
    {
        AgentVelocity += FlockBehaviour();
        transform.position += AgentVelocity * Time.deltaTime;
        transform.forward = AgentVelocity.normalized;
    }
    
    Vector3 FlockBehaviour()
    {
        //List<Entity> Flock = 

        Vector3 CohesionVector = new Vector3();
        Vector3 SeperationVector = new Vector3();
        Vector3 ForwardVector = new Vector3();

        int count = 0;

        //for (int i = 0; ; i++;)
        //{

        //}

        Vector3 FlockVector = new Vector3();

        return FlockVector;
    }

}


