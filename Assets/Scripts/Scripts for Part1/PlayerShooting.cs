using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject Pellet;
    public GameObject FireTransform;
    public FireState fireState = FireState.ReadyToFire;
    public bool stateReadyToFire = false;
    public bool stateRecharging = false;
    public int AttackAmount = 0;
    [SerializeField] Vector3 Direction;
    [SerializeField] float Force;

    void Update()
    {
        //If the player is not currently firing then they are able to fire or recharge.
        if (stateReadyToFire == false)
        {
            //If they have fired 5 times then the player needs to recharge and the state is changed to recharging.
            if (AttackAmount == 5)
            {
                fireState = FireState.Recharging;
            }

            //If they have not fired 5 times and space bar has been pressed then it will begin the action of firing.
            if (Input.GetKeyDown(KeyCode.Space))
            {
                stateReadyToFire = true;
                if (fireState == FireState.ReadyToFire)
                {
                    StartCoroutine(Fires());
                }

                //If the player has fired 5 times and the state has been changed to recharging then the coroutine starts so that the player is unable to fire but can fire once a timer is done.
                else if (fireState == FireState.Recharging)
                {
                    if (stateRecharging == false)
                    {
                        stateRecharging = true;
                        StartCoroutine(Recharging());
                    }
                }
            }
        }
    }

    public enum FireState
    {
        ReadyToFire,
        Recharging,
    }

    //Fires projectile in front of the player.
    public IEnumerator Fires()
    {
        GameObject projectile = Instantiate(Pellet, FireTransform.transform.position, FireTransform.transform.rotation);
        projectile.GetComponent<Rigidbody>().AddForce(Direction * Force * Time.deltaTime, ForceMode.Acceleration);
        yield return new WaitForSeconds(1);
        stateReadyToFire = false;
        AttackAmount = AttackAmount + 1;
    }


    public IEnumerator Recharging()
    {
        //Waits 2 seconds as a recharge because anything longer was too long. Sets attack amount to 0 and the fire state to firing so that the player can fire again on the next update.
        yield return new WaitForSeconds(2);
        AttackAmount = 0;
        stateRecharging = false;
        stateReadyToFire = false;
        fireState = FireState.ReadyToFire;
    }
}
