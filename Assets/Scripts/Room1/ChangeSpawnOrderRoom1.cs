using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpawnOrderRoom1 : MonoBehaviour {

    private SpawnBoxHooksRoom1 spawnBoxHooks;

	// Use this for initialization
	void Start () {
        spawnBoxHooks = FindObjectOfType<SpawnBoxHooksRoom1>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (name == "StopRandomCollider")
            {
                spawnBoxHooks.stopRandomSpawn = true;
            }
            if(name == "StopPlayerMove")
            {
                spawnBoxHooks.moreHeavys = true;
            }
        }
    }
}
