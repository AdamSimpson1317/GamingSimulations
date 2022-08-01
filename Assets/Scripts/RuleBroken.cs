using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleBroken : MonoBehaviour
{
    public string Identifier;
    public Vector3 GoalPosition;
    public string Required;
    public RuleBroken()
    {
        Identifier = "0";
        GoalPosition = Vector3.zero;
        Required = "None";
    }

    static void Main(string[] args)
    {
        RuleBroken NewRule = new RuleBroken();
    }

}
