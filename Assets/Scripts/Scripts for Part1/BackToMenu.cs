using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public int LevelNumber = 0;
    public void ToMenu()
    {
        SceneManager.LoadScene(LevelNumber);
    }
}
