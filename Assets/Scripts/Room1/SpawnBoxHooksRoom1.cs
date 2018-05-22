using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoxHooksRoom1 : MonoBehaviour
{

    public GameObject[] prefab = new GameObject[9];
    public Transform boxHooks;
    public float startTime = 0f;
    public double spawnTime = 2f;
    public bool stopRandomSpawn = false;
    public int maxNumberOfBoxes;

    private GameObject[] newPrefab = new GameObject[9];
    private int numberOfBoxes = 0;
    private int prefabNumber = 1;
    private int counter = 0;
    private int counter2 = 0;
    private double timer = 0;
    private double timer2;

    // Use this for initialization
    void Start()
    {
        prefab[0].transform.GetChild(0).GetComponent<BoxHook>().enabled = false;

        for (int i = 1; i < prefab.Length; i ++)
        {
            prefab[i].transform.GetChild(0).GetComponent<BoxHook>().enabled = false;
            prefab[i].transform.GetChild(0).transform.GetChild(0).GetComponent<Rigidbody2D>().isKinematic = true;
        }

        newPrefab = new GameObject[prefab.Length];

        //InvokeRepeating("Spawn", startTime, spawnTime);
    }

    private void FixedUpdate()
    {
        timer2 += Time.deltaTime;
        timer += Time.deltaTime;
        if (timer > startTime && counter == 0)
        {
            Spawn();
            counter = 1;
            timer = 0;
        }
        if(counter == 1 && timer > spawnTime)
        {
            Spawn();
            timer = 0;
        }

        Debug.Log(timer2);
        //1.18 SEGUNDOS A FAZER MERDA QUANDO ESTÁ NO UPDATE
        //1.30 SEGUNDOS A FAZER MERDA QUANDO ESTÁ NO FIXEDUPDATE
    }


    private void GetRandomForSpawn()
    {
        prefabNumber = Random.Range(0, 8);
    }

    private void GetRandom()
    {
        prefabNumber = Random.Range(1, 8);
    }

    private void Spawn()
    {
    
        if (stopRandomSpawn == false)
        {
            GetRandomBoxHook();
        }
        else
        {
            if (counter2 % 2 == 0)
            {
                //Instanciate empty hook
                newPrefab[0] = Instantiate(prefab[0], transform.position, transform.rotation);
                newPrefab[0].transform.GetChild(0).GetComponent<BoxHook>().enabled = true;
            }
            if(counter2 % 2 != 0)
            {
                GetRandomBox();
            }

            counter2++;


        }
    }

    private void GetRandomBox()
    {

        if (numberOfBoxes <= maxNumberOfBoxes) GetRandom();

        if (numberOfBoxes > maxNumberOfBoxes) prefabNumber = 1;

        switch (prefabNumber)
        {

            case 1:
                newPrefab[1] = Instantiate(prefab[1], transform.position, transform.rotation);
                newPrefab[1].transform.GetChild(0).GetComponent<BoxHook>().enabled = true;
                newPrefab[1].transform.SetParent(boxHooks);
                break;

            case 2:
                newPrefab[2] = Instantiate(prefab[2], transform.position, transform.rotation);
                newPrefab[2].transform.GetChild(0).GetComponent<BoxHook>().enabled = true;
                newPrefab[2].transform.SetParent(boxHooks);
                break;

            case 3:
                newPrefab[3] = Instantiate(prefab[3], transform.position, transform.rotation);
                newPrefab[3].transform.GetChild(0).GetComponent<BoxHook>().enabled = true;
                newPrefab[3].transform.SetParent(boxHooks);
                break;

            case 4:
                newPrefab[4] = Instantiate(prefab[4], transform.position, transform.rotation);
                newPrefab[4].transform.GetChild(0).GetComponent<BoxHook>().enabled = true;
                newPrefab[4].transform.SetParent(boxHooks);
                break;

            case 5:
                newPrefab[5] = Instantiate(prefab[5], transform.position, transform.rotation);
                newPrefab[5].transform.GetChild(0).GetComponent<BoxHook>().enabled = true;
                newPrefab[5].transform.SetParent(boxHooks);
                break;
            case 6:
                newPrefab[6] = Instantiate(prefab[6], transform.position, transform.rotation);
                newPrefab[6].transform.GetChild(0).GetComponent<BoxHook>().enabled = true;
                newPrefab[6].transform.SetParent(boxHooks);
                break;

            case 7:
                newPrefab[7] = Instantiate(prefab[7], transform.position, transform.rotation);
                newPrefab[7].transform.GetChild(0).GetComponent<BoxHook>().enabled = true;
                newPrefab[7].transform.SetParent(boxHooks);
                break;

            case 8:
                newPrefab[8] = Instantiate(prefab[8], transform.position, transform.rotation);
                newPrefab[8].transform.GetChild(0).GetComponent<BoxHook>().enabled = true;
                newPrefab[8].transform.SetParent(boxHooks);
                break;
        }
    }

    private void GetRandomBoxHook()
    {

        if (numberOfBoxes <= maxNumberOfBoxes) GetRandomForSpawn();

        if (numberOfBoxes > maxNumberOfBoxes) prefabNumber = 0;

        switch (prefabNumber)
        {
            case 0:
                newPrefab[0] = Instantiate(prefab[0], transform.position, transform.rotation);
                newPrefab[0].transform.GetChild(0).GetComponent<BoxHook>().enabled = true;
                newPrefab[0].transform.SetParent(boxHooks);
                break;

            case 1:
                newPrefab[1] = Instantiate(prefab[1], transform.position, transform.rotation);
                newPrefab[1].transform.GetChild(0).GetComponent<BoxHook>().enabled = true;
                newPrefab[1].transform.SetParent(boxHooks);
                break;

            case 2:
                newPrefab[2] = Instantiate(prefab[2], transform.position, transform.rotation);
                newPrefab[2].transform.GetChild(0).GetComponent<BoxHook>().enabled = true;
                newPrefab[2].transform.SetParent(boxHooks);
                break;

            case 3:
                newPrefab[3] = Instantiate(prefab[3], transform.position, transform.rotation);
                newPrefab[3].transform.GetChild(0).GetComponent<BoxHook>().enabled = true;
                newPrefab[3].transform.SetParent(boxHooks);
                break;

            case 4:
                newPrefab[4] = Instantiate(prefab[4], transform.position, transform.rotation);
                newPrefab[4].transform.GetChild(0).GetComponent<BoxHook>().enabled = true;
                newPrefab[4].transform.SetParent(boxHooks);
                break;

            case 5:
                newPrefab[5] = Instantiate(prefab[5], transform.position, transform.rotation);
                newPrefab[5].transform.GetChild(0).GetComponent<BoxHook>().enabled = true;
                newPrefab[5].transform.SetParent(boxHooks);
                break;
            case 6:
                newPrefab[6] = Instantiate(prefab[6], transform.position, transform.rotation);
                newPrefab[6].transform.GetChild(0).GetComponent<BoxHook>().enabled = true;
                newPrefab[6].transform.SetParent(boxHooks);
                break;

            case 7:
                newPrefab[7] = Instantiate(prefab[7], transform.position, transform.rotation);
                newPrefab[7].transform.GetChild(0).GetComponent<BoxHook>().enabled = true;
                newPrefab[7].transform.SetParent(boxHooks);
                break;

            case 8:
                newPrefab[8] = Instantiate(prefab[8], transform.position, transform.rotation);
                newPrefab[8].transform.GetChild(0).GetComponent<BoxHook>().enabled = true;
                newPrefab[8].transform.SetParent(boxHooks);
                break;
        }
    }
}
