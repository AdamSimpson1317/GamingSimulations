using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOAPRules : MonoBehaviour
{
    public List<RuleBroken> Rules = new List<RuleBroken>();
    public List<string> Resources = new List<string>();

    public RuleBroken NewRule;
    public string Identifier;
    public string Required;

    public CollectablesManager Collect;

    public GameObject Player;
    public Vector3 GoalPosition;
    public string TacTic = "Have it";

    //Creates a new rule for the enemies to follow
    public void CreateRule(string ReqRule)
    {
        GoalPosition = Collect.ChosenCollectable.transform.position;
        Identifier = Collect.ChosenCollectable.name;
        Required = ReqRule;

        RuleBroken NewRule = new RuleBroken();
        NewRule.Identifier = Identifier;
        NewRule.GoalPosition = GoalPosition;
        NewRule.Required = ReqRule;

        Rules.Add(NewRule);
        string check = Rules[0].Identifier;
        Vector3 check2 = Rules[0].GoalPosition;
        string check3 = Rules[0].Required;
    }

    //Adds a resource that the enemies can use to follow the player and send him back to the start.
    public void AddResource()
    {
        Resources.Add(TacTic);
    }

    //Deletes a rule once it has been completed by either the player or the enemies to make it more dynamic.
    //I thought making it dynamic would give it the complexity it needs since i do not have many different resources. 
    public void DeleteRule(string Identifier)
    {
        for(int i = 0; i <= Rules.Count; i++)
        {
            if(Rules[i].Identifier == Identifier)
            {
                Rules.Remove(Rules[i]);
            }
        }
        
    }
    
    //Deletes the Resource after is has been used up by the enemy.
    public void DeleteResources()
    {
        Resources.Remove(TacTic);
    }

    public void ChooseRule()
    {
        bool HasRule = false;
        int count = 0;
        string NameIdentifier;
        GameObject IdentifiedObject;
        while(!HasRule)
        {
            if (Rules[count].Equals(null))
            {
                
                HasRule = true;
            }
            else
            {
                if (Rules[count].Required == "Have it" || Resources.Contains("Have it"))
                {
                    Collect.ChosenCollectable.transform.position = Player.transform.position;
                }
                else if (Rules[count].Required == "none")
                {
                    NameIdentifier = Rules[count].name;
                    IdentifiedObject = GameObject.Find(NameIdentifier);
                    Collect.ChosenCollectable = IdentifiedObject;
                }
                HasRule = true;
            }
            count += 1;
        }
    }
}
