using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    //Allows player to destroy the boss once shields are gone and the boss is at 0 health. Then puts the player back to the menu.
    public GameObject Boss;
    public GameObject Panel;
    public int Health = 10;
    public ManagerOfGame Manager;
    public float volume = 1f;
    [SerializeField] AudioClip clip;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pellet" && Manager.Shields==0)
        {
            Health = Health - 1;
            AudioSource.PlayClipAtPoint(clip, Boss.transform.position, volume);
            Destroy(collision.gameObject);
        }

        if (Health <= 0)
        {
            Destroy(Boss);
            Panel.SetActive(true);
        }
    }
}
