using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHeavyBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "DeathZone")
        {
            if (name != "piece (0)" && name != "piece (1)")
            {
                Destroy(transform.parent.gameObject, 0.05f);
            } else
            {
                Destroy(transform.gameObject);
            }
        }
    }
}

