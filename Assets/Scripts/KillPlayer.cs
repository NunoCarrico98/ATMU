using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    public GameObject ragdoll;
    private GameObject player;
    private bool killPlayer = false;
    private int counter = 0;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKey(KeyCode.R)) killPlayer = true;
        Kill();
	}


   /* void OnTriggerEnter2D(Collider2D other)
    {
        if (other)
        {
            Debug.Log("It was a trigger");
            killPlayer = true;
        }
    }*/

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            Debug.Log("It was a Collider");
            killPlayer = true;
        }

    }*/

    private void Kill()
    {
        if (killPlayer == true && counter == 0)
        {

            Instantiate(ragdoll, transform.parent.position, transform.parent.rotation);
            Destroy(player);
            counter = 1;
        }
    }
}
