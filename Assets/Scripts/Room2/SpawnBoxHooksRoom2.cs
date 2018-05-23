using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoxHooksRoom2 : MonoBehaviour
{

    public GameObject prefab;
    public Transform boxHooks;
    public float spawnTime = 2;
    public float startTime = 0;

    public int maxNumberOfHooks;

    private int numberOfHooks = 0;

    private GameObject newPrefab;


    // Use this for initialization
    void Start()
    {
        prefab.transform.GetChild(0).GetComponent<BoxHook>().enabled = false;
        InvokeRepeating("Spawn", startTime, spawnTime);
    }

    private void Spawn()
    {
        if (numberOfHooks <= maxNumberOfHooks)
        {
            newPrefab = Instantiate(prefab, transform.position, transform.rotation);
            newPrefab.transform.GetChild(0).GetComponent<BoxHook>().enabled = true;
            newPrefab.transform.SetParent(boxHooks);
            numberOfHooks++;
        }
    }
}
