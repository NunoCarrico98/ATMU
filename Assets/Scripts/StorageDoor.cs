using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageDoor : MonoBehaviour
{

    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;

    public Transform spawnPoint;
    public Transform spawnPoint2;
    public Transform parent;
    public float openTime = 0.4f;
    public int instancesCounter = 6;

    private bool open = false;
    private bool close = true;
    private static bool allow = true;
    private float timer = 0;
    private int counter1 = 0;
    private int counter2 = 0;
    private int resetCounter = 0;
    private int rand;



    // Use this for initialization
    void Start()
    {
        resetCounter = instancesCounter;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (open)
        {
            if (counter1 == 0)
            {
                counter2++;
                counter1++;
            }
            Open();

        }
    }

    private void Open()
    {
        if (instancesCounter > 0)
        {
            rand = Random.Range(1, 3);

            switch (rand)
            {
                case 1:
                    Instantiate(prefab1, spawnPoint.position, transform.rotation, parent);
                    break;
                case 2:
                    Instantiate(prefab2, spawnPoint.position, transform.rotation, parent);
                    break;
                case 3:
                    Instantiate(prefab3, spawnPoint.position, transform.rotation, parent);
                    break;
            }

            if (counter2 % 2 == 0)
            {
                if (StopPlayerMoveTunnel.canSpawn)
                {
                    switch (rand)
                    {
                        case 1:
                            Instantiate(prefab1, spawnPoint2.position, transform.rotation, parent);
                            Instantiate(prefab1,
                                new Vector3(spawnPoint2.position.x - 1, spawnPoint2.position.y, spawnPoint2.position.z),
                                transform.rotation, parent);
                            break;

                        case 2:
                            Instantiate(prefab2, spawnPoint2.position, transform.rotation, parent);
                            Instantiate(prefab2,
                                new Vector3(spawnPoint2.position.x - 1, spawnPoint2.position.y, spawnPoint2.position.z),
                                transform.rotation, parent);
                            break;

                        case 3:
                            Instantiate(prefab3, spawnPoint2.position, transform.rotation, parent);
                            Instantiate(prefab3,
                                new Vector3(spawnPoint2.position.x - 1, spawnPoint2.position.y, spawnPoint2.position.z),
                                transform.rotation, parent);
                            break;
                    }
                }
            }

            instancesCounter--;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "LightBox" && name == "OpenCollider" && allow)
        {
            open = true;
        }

        if (col.tag == "Player" && name == "DetectPlayer")
        {
            allow = false;
            if (!allow)
            {
                open = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player" && name == "DetectPlayer")
        {
            allow = true;
        }
        if (col.tag == "LightBox" && name == "OpenCollider" && allow)
        {
            open = false;
            counter1 = 0;
            instancesCounter = resetCounter;
        }
    }
}
