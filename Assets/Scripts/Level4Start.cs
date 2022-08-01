using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4Start : MonoBehaviour
{
    public GOAPRules GOAP;
    public CollectablesManager Collect;
    public FlockManager FManager;
    public GameObject CurrentObject;

    // Start is called before the first frame update
    void Start()
    {
        //Sets up the first rule for the flock and sets the flock managers position for the flock to follow
        Collect.ChosenCollectable = CurrentObject;
        GOAP.Resources.Add("none");
        GOAP.CreateRule("none");
        FManager.transform.Translate(Collect.ChosenCollectable.transform.position);
        
    }

    private void Update()
    {
        //Chooses a rule and then keeps changing the position of the manager so that the Flock knows where to go
        GOAP.ChooseRule();
        FManager.transform.position = Collect.ChosenCollectable.transform.position;

    }


}
