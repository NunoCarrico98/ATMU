using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLightBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "HeavyBox")
        {
            if(transform.parent.transform.childCount > 1
                && transform.parent.transform.GetChild(1).tag == "Player")
            {
                transform.parent.transform.GetChild(1).SetParent(null);
            }
            Destroy(transform.parent.gameObject, 0.05f);
        }
    }
}
