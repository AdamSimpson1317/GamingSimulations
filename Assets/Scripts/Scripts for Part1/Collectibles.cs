using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collectibles : MonoBehaviour
{
    //Just a script to destroy the collectible when its picked up and make sure manager changes how many collectibles are left.
    public ManagerOfGame Manager;
    public GameObject Collectible;
    public GameObject Panel;
    [SerializeField] Timer timer;
    public float volume = 1f;
    [SerializeField] AudioClip clip;
    public void OnCollisionEnter(Collision buttonCollision)
    {
        Manager.AmountOfCollectibles();
        AudioSource.PlayClipAtPoint(clip, Collectible.transform.position, volume);
        Destroy(Collectible);
        if (Manager.Collectibles == 0)
        {
            timer.IsPanelActive = true;
            Panel.SetActive(true);
        }
    }
}
