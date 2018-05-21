using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoxHooksRoom2 : MonoBehaviour
{

    public GameObject prefab;
    public float spawnTime = 2;

    public int maxNumberOfBoxes;

    private int numberOfBoxes = 0;

    private GameObject newPrefab;
    private int prefabNumber = 1;


    // Use this for initialization
    void Start()
    {
        prefab.transform.GetChild(0).GetComponent<BoxHook>().enabled = false;
        InvokeRepeating("Spawn", 0f, spawnTime);
    }

    private void Spawn()
    {
        newPrefab = Instantiate(prefab, transform.position, transform.rotation);
        newPrefab.transform.GetChild(0).GetComponent<BoxHook>().enabled = true;
    }
}
