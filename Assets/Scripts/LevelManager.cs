using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public float respawnDelay;
    public float respawnDelayRagdoll;
    public KillPlayer gamePlayer;

    private Transform player;

    // Use this for initialization
    void Start()
    {
        gamePlayer = FindObjectOfType<KillPlayer>();
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnAfterRagdoll()
    {
        StartCoroutine(RespawnPlayerRagdoll());
    }

    public void RespawnAfterDeath()
    {
        StartCoroutine(RespawnPlayer());
    }

    private IEnumerator RespawnPlayerRagdoll()
    {
        yield return new WaitForSeconds(respawnDelayRagdoll);
        Destroy(gamePlayer.ragdoll);
        player.transform.position = gamePlayer.respawnPosition;
        player.gameObject.SetActive(true);
    }

    private IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(respawnDelay);
        player.transform.position = gamePlayer.respawnPosition;
        player.gameObject.SetActive(true);
    }

    public void StoreGameObjectPositions()
    {

    }
}
