using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public GameObject ragdoll;

    private GameObject player;
    private Transform playerGraphics;
    private Vector2 velocity;
    private bool killPlayer = false;
    private int counter = 0;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerGraphics = player.transform.Find("Graphics");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R)) killPlayer = true;
        Kill();
        //ragdoll.GetComponent<Rigidbody2D>().velocity = velocity*10;
    }


    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player")
        {
            Debug.Log("Detected");
            killPlayer = true;
        }
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DeathZone")
        {
            Debug.Log("Detected");
            killPlayer = true;
        }
    }

    private void Kill()
    {
        if (killPlayer == true && counter == 0)
        {
            velocity = player.GetComponent<Rigidbody2D>().velocity;
            Instantiate(ragdoll, player.transform.position, player.transform.rotation);

            Destroy(player);
            ragdoll.GetComponent<Rigidbody2D>().velocity = velocity;
            counter = 1;
        }
    }
}
