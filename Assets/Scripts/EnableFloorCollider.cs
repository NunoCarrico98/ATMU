using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableFloorCollider : MonoBehaviour {

    public GameObject newWalls;
    public GameObject newObjects;

    private ContainerBeacon[] containers;
	
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
                Destroy(transform.parent.gameObject);
                newWalls.SetActive(true);
                newObjects.SetActive(true);

            containers = FindObjectsOfType<ContainerBeacon>();

            for(int i = 0; i < containers.Length; i++)
            {
                containers[i].gameObject.layer = 22;
                containers[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sortingLayerName = "Default";
                containers[i].transform.GetChild(1).gameObject.layer = 22;
            }
        }
    }
}
