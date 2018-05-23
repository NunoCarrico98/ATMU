using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLightBox : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)
    {
        int childCount = transform.parent.transform.childCount - 1;

        if (col.gameObject.tag == "HeavyBox")
        {
            if (col.GetComponent<Rigidbody2D>().velocity.y != 0)
            {
                if (transform.parent.transform.GetChild(childCount).tag == "Player")
                {
                    transform.parent.transform.GetChild(childCount).SetParent(null);
                }
                Destroy(transform.parent.gameObject, 0.05f);
            }
        }

        if (col.tag == "DeathZone")
        {
            Destroy(transform.parent.gameObject, 0.05f);
        }
    }
}
