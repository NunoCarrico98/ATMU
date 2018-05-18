using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public GameObject ragdollPreFab;
    public GameObject ragdoll;
    public Vector2 respawnPosition;
    public LevelManager gameLevelManager;

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
        if (Input.GetKey(KeyCode.R)) Kill();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DeathZone")
        {
            Debug.Log("Detected");
            Kill();
        }

        if (other.tag == "Checkpoint")
        {
            respawnPosition = other.transform.position;
        }
    }

    private void GetVelocity()
    {
        velocity = player.GetComponent<Rigidbody2D>().velocity;
        Debug.Log("Velocity is: " + velocity);
        angularVelocity = player.GetComponent<Rigidbody2D>().angularVelocity;
    }

    private void Kill()
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

                Debug.Log("Velocity of parts is: " + bodyparts[i].GetComponent<Rigidbody2D>().velocity);
                Debug.Log("Angular velocity of parts is: " + bodyparts[i].GetComponent<Rigidbody2D>().angularVelocity);
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
