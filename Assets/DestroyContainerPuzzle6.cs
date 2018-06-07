using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyContainerPuzzle6 : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "LightBox" && col.name == "Container")
        {
            col.transform.GetChild(1).gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("Player").transform.SetParent(null);
            Destroy(col.gameObject);
        }
    }
}
