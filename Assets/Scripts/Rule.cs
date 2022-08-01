using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule : MonoBehaviour
{
    public string Identifier;
    public Vector3 GoalPosition;
    public string Required;
    public Rule()
    {
        Identifier = "0";
        GoalPosition = Vector3.zero;
        Required = "None";
    }

    static void Main(string[] args)
    {
        Rule NewRule = new Rule();
    }
    
}
