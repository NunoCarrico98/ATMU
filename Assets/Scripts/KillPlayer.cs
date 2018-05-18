using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public GameObject ragdoll;
    private GameObject[] bodyparts = new GameObject[8];

    private GameObject player;
    private Transform playerGraphics;
    private Vector2 velocity;
    private float angularVelocity;
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
        if (killPlayer == true && counter < 2)
        {
            if (counter < 1)
            {
                velocity = player.GetComponent<Rigidbody2D>().velocity;
                Debug.Log("Velocity is: " + velocity);
                angularVelocity = player.GetComponent<Rigidbody2D>().angularVelocity;
                ragdoll = Instantiate(ragdoll, player.transform.position, player.transform.rotation);
                counter = 1;
            }
            for (int i = 0; i < bodyparts.Length; i++)
            {
                bodyparts[i] = ragdoll.transform.GetChild(i).gameObject;
                bodyparts[i].GetComponent<Rigidbody2D>().velocity = velocity;
                bodyparts[i].GetComponent<Rigidbody2D>().angularVelocity = angularVelocity;

                Debug.Log("Velocity of parts is: " + bodyparts[i].GetComponent<Rigidbody2D>().velocity);
                Debug.Log("Angular velocity of parts is: " + bodyparts[i].GetComponent<Rigidbody2D>().angularVelocity);
            }
            if (bodyparts[7].GetComponent<Rigidbody2D>().velocity != new Vector2(0, 0)) counter = 2;
            if (counter == 2)
            {
                Destroy(player);
            }
        }
    }
}
