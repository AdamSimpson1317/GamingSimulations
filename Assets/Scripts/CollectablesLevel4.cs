using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesLevel4: MonoBehaviour
{
    public List<GameObject> Collectables = new List<GameObject>();
    public CollectableTrigger Collect;

    // Start is called before the first frame update
    void Start()
    {
        Choose.ChooseNewCollectable();
    }

    public void ChooseNewColletable()
    {
        int RandomNumber = Random.Range(0, Collectables.Count);

        Collectables[RandomNumber].SetActive(true);
    }
}
