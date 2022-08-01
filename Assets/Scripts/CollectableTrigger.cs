using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableTrigger : MonoBehaviour
{
    public CollectablesManager CollectManager;
    public GOAPRules GOAP;

    //OnCollision method that sets up the next collectable and removes the current collectible from the list 
    //and destroys it from the world.
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CollectManager.Collectables.Remove(gameObject);
            CollectManager.PlayerScores(gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            CollectManager.Collectables.Remove(gameObject);
            CollectManager.EnemyScores(gameObject);
            GOAP.AddResource();
            Destroy(gameObject);
        }

        
        CollectManager.SetCanvas();
    }

}
