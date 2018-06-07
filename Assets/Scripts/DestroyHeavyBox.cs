using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHeavyBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "DeathZone")
        {
            if (transform.tag == "HeavyBoxPiece3")
            {
                if (col.transform != null && transform.parent.name == "HeavyBoxRagdoll3")
                {
                    Destroy(transform.parent.gameObject, 0.05f);
                }
                else
                {
                    Destroy(transform.gameObject);
                }

            }
            if (transform.tag == "HeavyBox")
            {
                Destroy(transform.parent.gameObject, 0.05f);
            }
        }
    }
}

