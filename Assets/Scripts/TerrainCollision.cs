using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainCollision : MonoBehaviour
{
    public bool collidingTerrain = false;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Terrain")
        {
            collidingTerrain = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        collidingTerrain = false;
    }
}
