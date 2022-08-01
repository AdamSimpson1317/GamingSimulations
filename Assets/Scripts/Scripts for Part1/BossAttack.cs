using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject Missile;
    public GameObject BossFireTransform1;
    public GameObject BossFireTransform2;
    public GameObject BossFireTransform3;
    public GameObject BossFireTransform4;
    public GameObject BossFireTransform5;
    public ManagerOfGame Manager;
    public FireState fireState = FireState.Firing;
    public ShieldState shieldState = ShieldState.Shielded;
    public bool stateFiring = false;
    public bool stateRecharging = false;
    public int AttackAmount = 0;
    private float RandomMissileValue;
    [SerializeField] Vector3 Direction;
    [SerializeField] float Force;

    void Update()
    {
        //If the boss is not currently firing then they are able to fire or recharge. They can not do both at the same time.
        if (stateFiring == false)
        {
            stateFiring = true;

            //If they have fired 10 times then the boss needs to recharge and the state is changed to recharging.
            if (AttackAmount == 10)
            {
                fireState = FireState.Recharging;
            }
            //If they have not fired 10 times then it will begin the action of firing.
            if (fireState == FireState.Firing)
            {
                //If the boss has no shields left then he can only attack from 3 positions instead of 5. This shown by changing the Shielded state to not Shielded.
                if (Manager.Shields == 0)
                {
                    shieldState = ShieldState.NotShielded;
                }
                //Starts the coroutine dependent on whether the boss has shields or not.
                if (shieldState == ShieldState.NotShielded)
                {
                    StartCoroutine(AttackNotShielded());
                }
                else if (shieldState == ShieldState.Shielded)
                {
                    StartCoroutine(AttackShielded());
                }
            }
            //If the boss has fired 10 times and the state has been changed to recharging then the coroutine starts so that the boss is unable to fire but can fire once a timer is done.
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
    //FireState
    public enum FireState
    {
        Firing,
        Recharging,
    }

    //ShieldState
    public enum ShieldState
    {
        Shielded,
        NotShielded,
    } 

    //Attack When the boss has shields
    public IEnumerator AttackShielded()
    {
        //A random value between 0 and 1 is chosen and that corresponds to 1 of 5 positions where a pellet will be fired by the boss towards the players direction.
        RandomMissileValue = Random.value;
        if (RandomMissileValue <= 0.2f)
        {
            GameObject FiredMissile = Instantiate(Missile, BossFireTransform1.transform.position, BossFireTransform1.transform.rotation);
            FiredMissile.GetComponent<Rigidbody>().AddForce(Direction * Force * Time.deltaTime, ForceMode.Acceleration);
        }
        else if (0.2f < RandomMissileValue && RandomMissileValue <= 0.4)
        {
            GameObject FiredMissile = Instantiate(Missile, BossFireTransform2.transform.position, BossFireTransform2.transform.rotation);
            FiredMissile.GetComponent<Rigidbody>().AddForce(Direction * Force * Time.deltaTime, ForceMode.Acceleration);
        }
        else if (0.4f < RandomMissileValue && RandomMissileValue <= 0.6f)
        {
            GameObject FiredMissile = Instantiate(Missile, BossFireTransform3.transform.position, BossFireTransform3.transform.rotation);
            FiredMissile.GetComponent<Rigidbody>().AddForce(Direction * Force * Time.deltaTime, ForceMode.Acceleration);
        }
        else if (0.6f < RandomMissileValue && RandomMissileValue <= 0.8f)
        {
            GameObject FiredMissile = Instantiate(Missile, BossFireTransform4.transform.position, BossFireTransform4.transform.rotation);
            FiredMissile.GetComponent<Rigidbody>().AddForce(Direction * Force * Time.deltaTime, ForceMode.Acceleration);
        }
        else if (0.8f < RandomMissileValue && RandomMissileValue <= 1.0f)
        {
            GameObject FiredMissile = Instantiate(Missile, BossFireTransform5.transform.position, BossFireTransform5.transform.rotation);
            FiredMissile.GetComponent<Rigidbody>().AddForce(Direction * Force * Time.deltaTime, ForceMode.Acceleration);
        }
        //Waits one second and then changes the bool so that this action can be done again. However it also adds 1 to the amount of attacks done.
        yield return new WaitForSeconds(1);
        stateFiring = false;
        AttackAmount = AttackAmount + 1;
    }

    //Attack When the boss does not have shields
    public IEnumerator AttackNotShielded()
    {
        //A random value between 0 and 1 is chosen and that corresponds to 1 of 3 positions where a pellet will be fired by the boss towards the players direction.
        RandomMissileValue = Random.value;
        if (RandomMissileValue <= 0.33f)
        {
            GameObject FiredMissile = Instantiate(Missile, BossFireTransform2.transform.position, BossFireTransform2.transform.rotation);
            FiredMissile.GetComponent<Rigidbody>().AddForce(Direction * Force * Time.deltaTime, ForceMode.Acceleration);
        }
        else if (0.33f < RandomMissileValue && RandomMissileValue <= 0.66f)
        {
            GameObject FiredMissile = Instantiate(Missile, BossFireTransform4.transform.position, BossFireTransform4.transform.rotation);
            FiredMissile.GetComponent<Rigidbody>().AddForce(Direction * Force * Time.deltaTime, ForceMode.Acceleration);
        }
        else if (0.66f < RandomMissileValue && RandomMissileValue <= 1.0f)
        {
            GameObject FiredMissile = Instantiate(Missile, BossFireTransform5.transform.position, BossFireTransform5.transform.rotation);
            FiredMissile.GetComponent<Rigidbody>().AddForce(Direction * Force * Time.deltaTime, ForceMode.Acceleration);
        }
        //Waits one second and then changes the bool so that this action can be done again. However it also adds 1 to the amount of attacks done.
        yield return new WaitForSeconds(1);
        stateFiring = false;
        AttackAmount = AttackAmount + 1;
    }

    //Allows boss to "Recharge"
    public IEnumerator Recharging()
    {
        //Waits 2 seconds as a recharge because anything longer was too long. Sets attack amount to 0 and the fire state to firing so that the boss can fire again on the next update.
        yield return new WaitForSeconds(2);
        AttackAmount = 0;
        stateRecharging = false;
        stateFiring = false;
        fireState = FireState.Firing;
    }

}
