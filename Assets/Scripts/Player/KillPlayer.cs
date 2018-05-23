using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public GameObject ragdollPreFab;
    public GameObject ragdoll;
    public Vector2 respawnPosition;
    public LevelManager gameLevelManager;
    public Camera camera;

    private GameObject[] bodyparts = new GameObject[8];
    private GameObject player;
    private Transform playerGraphics;
    private Transform playerHead;
    private Vector2 velocity;
    private float angularVelocity;
    /*private bool killPlayer = false;
    private int counter = 0;*/

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameLevelManager = FindObjectOfType<LevelManager>();

        respawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GetVelocity();
        if (Input.GetKey(KeyCode.R)) KillRagdoll();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player"  && other.tag != "DeathZone")
        {
            KillRagdoll();
        }

        if (other.tag == "DeathZone")
        {
            camera.transform.SetParent(null);
            gameLevelManager.RespawnAfterDeath();
        }

        if (other.tag == "Checkpoint")
        {
            respawnPosition = other.transform.position;
        }
    }

    private void GetVelocity()
    {
        velocity = player.GetComponent<Rigidbody2D>().velocity;
        angularVelocity = player.GetComponent<Rigidbody2D>().angularVelocity;
    }

    private void KillRagdoll()
    {
        //  if (/*killPlayer == true &&*/ counter < 2)
        // {
        // Destroy(player);
        player.SetActive(false);
        // if (counter < 1)
        //  {

        ragdoll = Instantiate(ragdollPreFab, player.transform.position, player.transform.rotation);
        // counter = 1;
        //   }
        for (int i = 0; i < bodyparts.Length; i++)
        {
            bodyparts[i] = ragdoll.transform.GetChild(i).gameObject;
            bodyparts[i].GetComponent<Rigidbody2D>().velocity = velocity;
            bodyparts[i].GetComponent<Rigidbody2D>().angularVelocity = angularVelocity;
        }
        /*  if (bodyparts[7].GetComponent<Rigidbody2D>().velocity != new Vector2(0, 0)) counter = 2;
          if (counter == 2)
          {
              Destroy(player);

          }*/
        //player.SetActive(false);
        gameLevelManager.RespawnAfterDeath();
    }
    //}
}
