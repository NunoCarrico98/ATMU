﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public float respawnDelay;
    public KillPlayer gamePlayer;

    private GameObject deadPlayer;

	// Use this for initialization
	void Start () {
        gamePlayer = FindObjectOfType<KillPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Respawn()
    {
        StartCoroutine(RespawnPlayerDelay());
    }

    public IEnumerator RespawnPlayerDelay()
    {
        yield return new WaitForSeconds(respawnDelay);
        Destroy(gamePlayer.ragdoll);
        gamePlayer.transform.parent.transform.position = gamePlayer.respawnPosition;
        gamePlayer.transform.parent.gameObject.SetActive(true);
    }
}
