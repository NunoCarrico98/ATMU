using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLightBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "HeavyBox" && this.transform.Find("ColliderForBoxes").GetComponent<Collider2D>().tag == "BoxCollider")
        {
            Destroy(this.gameObject, 0.05f);
        }

    }
}
