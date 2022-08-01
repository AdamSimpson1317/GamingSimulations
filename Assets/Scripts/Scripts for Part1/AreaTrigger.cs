using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaTrigger : MonoBehaviour
{
    //Teleports player to the next level
    [SerializeField] int LevelNumber;
    // Update is called once per frame
    public void OnTriggerEnter()
    {
        SceneManager.LoadScene(LevelNumber);
    }
}
