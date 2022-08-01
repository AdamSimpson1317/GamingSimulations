using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectablesManager : MonoBehaviour
{
    public List<GameObject> Collectables = new List<GameObject>();

    public int PlayerScore;
    public int EnemyScore;
    public int CoinFlip;

    public GOAPRules GOAP;

    public GameObject ChosenCollectable;

    public GameObject Panel;
    public Text PlayerScoreText;
    public Text EnemyScoreText;
    public Text WhoWonText;

    //Sets the canvas up each frame so that when it is activated it shows score for both "teams"
    public void SetCanvas()
    {
        if (Collectables.Count == 0 || PlayerScore + EnemyScore == 10)
        {
            PlayerScoreText.text = ("Player Score: " + PlayerScore);
            EnemyScoreText.text = "Opponents Score: " + EnemyScore;
            if(PlayerScore > EnemyScore)
            {
                WhoWonText.text = "Player Won";
            }
            
            if(EnemyScore > PlayerScore)
            {
                WhoWonText.text = "Opponents Won";
            }

            if(PlayerScore == EnemyScore)
            {
                WhoWonText.text = "Both the teams have scored the same. The game is a draw";
            }

            Panel.SetActive(true);
        }
    }

    //Method for when the player scores a point
    public void PlayerScores(GameObject Object)
    {
        string Identifier = Object.name;
        GOAP.DeleteRule(Identifier);
        if (Collectables.Count > 0)
        {
            ChooseNewCollectable();
            GOAP.CreateRule("none");
        }
        ChooseNewCollectable();
        GOAP.CreateRule("none");
        PlayerScore += 1;
        CoinFlip = Random.Range(0, 100);
        if (CoinFlip > 50)
        {
            if (Collectables.Count > 0)
            {
                ChooseNewCollectable();
                GOAP.CreateRule("none");
            }
        }
    }

    //Method for when the enemy scores a point
    public void EnemyScores(GameObject Object)
    {
        string Identifier = Object.name;
        GOAP.DeleteRule(Identifier);
        ChooseNewCollectable();
        GOAP.CreateRule("none");
        GOAP.CreateRule(GOAP.TacTic);
        EnemyScore += 1;
        CoinFlip = Random.Range(0, 100);
        if (CoinFlip > 50)
        {
            ChooseNewCollectable();
            GOAP.CreateRule("none");
        }
    }
    //Chooses a new collectable for the player and enemies to collect when called 
    public void ChooseNewCollectable()
    {
        int RandomNumber = Random.Range(0, Collectables.Count);
        GameObject Chosen;
        Collectables[RandomNumber].SetActive(true);
        Chosen = Collectables[RandomNumber];
        ChosenCollectable = Chosen;

    }
    
}
