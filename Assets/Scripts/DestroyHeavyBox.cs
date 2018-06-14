using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHeavyBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "DeathZone")
        {
            if (transform.parent.tag == "HeavyBox" || transform.parent.tag == "LightBox")
            {
                Destroy(transform.parent.gameObject, 0.05f);
            }
            if (transform != null)
            {
                if (transform.tag == "HeavyBoxPiece3")
                {
                    if (transform.parent.transform.childCount < 2 && transform.parent.name == "HeavyBoxRagdoll3")
                    {
                        Destroy(transform.parent.gameObject, 0.05f);
                    }
                    else
                    {
                        Destroy(transform.gameObject);
                    }

                }
            }


        }
    }
}

