using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsForPlayers : MonoBehaviour
{
    public GameObject Door;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(OpenDoor());
        }
    }
    public IEnumerator OpenDoor()
    {
        MeshRenderer mesh = GetComponent<MeshRenderer>();
        BoxCollider collider = GetComponent<BoxCollider>();
        mesh.enabled = !mesh.enabled;
        collider.enabled = !collider.enabled;
        Debug.Log("Step 1");
        yield return new WaitForSeconds(5);
        Debug.Log("Step 2");
        mesh.enabled = !mesh.enabled;
        collider.enabled = !collider.enabled;
    }
}
