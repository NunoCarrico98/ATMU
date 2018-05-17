using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLightBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "HeavyBox")
        {
            Destroy(transform.parent.gameObject, 0.05f);
        }
    }
}
