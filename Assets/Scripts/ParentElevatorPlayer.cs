using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentElevatorPlayer : MonoBehaviour {

    private void OnColliderEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Player")
        {
            col.transform.SetParent(transform);
        }
    }

    private void OnColliderExit2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            col.transform.SetParent(null);
        }
    }
}
