using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyingStrayBullets : MonoBehaviour
{
    //Destroys projectiles fired so that they dont keep going for as long as the level is on for.
    public GameObject bullet;
    void Update()
    {
        StartCoroutine(DestroyObject());
    }
    public IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(15);
        Destroy(bullet);
    }
}
