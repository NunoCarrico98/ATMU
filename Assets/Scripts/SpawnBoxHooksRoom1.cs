using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoxHooksRoom1 : MonoBehaviour
{

    public GameObject[] prefab = new GameObject[6];
    public float startTime = 0f;
    public float spawnTime = 2f;

    public int maxNumberOfBoxes;

    private int numberOfBoxes = 0;

    private GameObject[] newPrefab = new GameObject[6];
    private int prefabNumber = 1;


    // Use this for initialization
    void Start()
    {
        prefab[0].transform.GetChild(0).GetComponent<BoxHook>().enabled = false;

        for (int i = 1; i < prefab.Length; i ++)
        {
            prefab[i].transform.GetChild(0).GetComponent<BoxHook>().enabled = false;
            prefab[i].transform.GetChild(0).transform.GetChild(0).GetComponent<Rigidbody2D>().isKinematic = true;
        }

        InvokeRepeating("Spawn", startTime, spawnTime);
    }

    private void GetRandomForSpawn()
    {
        prefabNumber = Random.Range(0, 5);
    }

    private void Spawn()
    {
        if (numberOfBoxes <= maxNumberOfBoxes) GetRandomForSpawn();

        if (numberOfBoxes > maxNumberOfBoxes) prefabNumber = 0;

        switch (prefabNumber)
        {
            case (0):
                newPrefab[0] = Instantiate(prefab[0], transform.position, transform.rotation);
                newPrefab[0].transform.GetChild(0).GetComponent<BoxHook>().enabled = true;
                break;

            case (1):
                newPrefab[1] = Instantiate(prefab[1], transform.position, transform.rotation);
                //newPrefab[1].transform.GetChild(0).transform.GetChild(0).GetComponent<Rigidbody2D>().isKinematic = false;
                newPrefab[1].transform.GetChild(0).GetComponent<BoxHook>().enabled = true;

                break;

            case (2):
                newPrefab[2] = Instantiate(prefab[2], transform.position, transform.rotation);
                //newPrefab[2].transform.GetChild(0).transform.GetChild(0).GetComponent<Rigidbody2D>().isKinematic = false;
                newPrefab[2].transform.GetChild(0).GetComponent<BoxHook>().enabled = true;
                break;

            case (3):
                newPrefab[3] = Instantiate(prefab[3], transform.position, transform.rotation);
                //newPrefab[3].transform.GetChild(0).transform.GetChild(0).GetComponent<Rigidbody2D>().isKinematic = false;
                newPrefab[3].transform.GetChild(0).GetComponent<BoxHook>().enabled = true;
                break;

            case (4):
                newPrefab[4] = Instantiate(prefab[4], transform.position, transform.rotation);
                //newPrefab[4].transform.GetChild(0).transform.GetChild(0).GetComponent<Rigidbody2D>().isKinematic = false;
                newPrefab[4].transform.GetChild(0).GetComponent<BoxHook>().enabled = true;
                break;

            case (5):
                newPrefab[5] = Instantiate(prefab[5], transform.position, transform.rotation);
                //newPrefab[5].transform.GetChild(0).transform.GetChild(0).GetComponent<Rigidbody2D>().isKinematic = false;
                newPrefab[5].transform.GetChild(0).GetComponent<BoxHook>().enabled = true;
                break;
        }
    }

    /*private IEnumerator Spawn()
    {
                yield return new WaitForSeconds(spawnTime);

    }*/
}
