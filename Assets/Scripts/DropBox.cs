using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBox : MonoBehaviour
{
    public GameObject[] box;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            for (int i = 0; i < box.Length; i++)
            {
                box[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}
