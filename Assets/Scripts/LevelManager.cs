using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public float respawnDelay;
    public float respawnDelayRagdoll;

    private KillPlayer gamePlayer;

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
        if (gamePlayer.isDead) RespawnAfterRagdoll2();
    }

    public void RespawnAfterRagdoll()
    {
        StartCoroutine(RespawnPlayerRagdoll());
    }

    public void RespawnAfterRagdoll2()
    {
        if(Input.anyKeyDown)
        {
            Destroy(gamePlayer.ragdoll);
            player.GetComponent<PlayerMovement>().enabled = true;
            player.transform.position = gamePlayer.respawnPosition;
            player.gameObject.SetActive(true);
            player.SetParent(null);
            gamePlayer.isDead = false;
        }
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
        player.SetParent(null);
        player.gameObject.SetActive(true);
    }

    private IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(respawnDelay);
        player.gameObject.SetActive(false);
        player.transform.position = gamePlayer.respawnPosition;
        player.SetParent(null);
        player.gameObject.SetActive(true);
    }

    public void StoreGameObjectPositions()
    {

    }
}
