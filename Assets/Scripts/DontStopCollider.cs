using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontStopCollider : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "HeavyBoxPiece" || col.tag == "HeavyBoxPiece2" || 
            col.tag == "HeavyBoxPiece3" || col.tag == "CratePiece" || 
            (col.tag == "LightBox" && col.name != "Container" &&
            col.name != "Crate1" && col.name != "Crate2"))
        {
            if (name == "LimitsCollider")
            {
                if (col.transform.parent != null && col.transform.parent.childCount == 1)
                {
                    Destroy(col.transform.gameObject);
                    Destroy(col.transform.parent.gameObject);
                }
                else
                {
                    Destroy(col.transform.gameObject);
                }
            }
        }
    }
}
