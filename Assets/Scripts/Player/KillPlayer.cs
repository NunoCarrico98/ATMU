using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public bool pressKeyToRespawn = false;
    public GameObject ragdollPreFab;
    public GameObject ragdoll;
    public Vector2 respawnPosition;
    public bool isDead = false;
    public int counter = 0;

    private LevelManager gameLevelManager;
    private GameObject[] bodyparts = new GameObject[8];
    private GameObject player;
    private Transform playerGraphics;
    private Transform playerHead;
    private Vector2 velocity;
    private GrabBox grabBox;
    private float angularVelocity;
    /*private bool killPlayer = false;
    private int counter = 0;*/

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        gameLevelManager = FindObjectOfType<LevelManager>();
        grabBox = FindObjectOfType<GrabBox>();

        respawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GetVelocity();

        //Allow suicide (dev mode)
        if (Input.GetKeyDown(KeyCode.R)) KillRagdoll();

        //Kill on tunnel puzzle
        if (FindObjectOfType<FallingLavaPuzzle>().kill) NormalKill();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //A ragdoll of the player appears
        if (other.tag != "Player" && other.tag != "DeathZone"
            && other.tag != "DontKillPlayer" && other.tag != "Checkpoint"
            && other.tag != "BoxCollider" && other.tag != "HeavyBoxPiece3")
        {
            KillRagdoll();
        }

        //Respawn in last checkpoint
        if (other.tag == "DeathZone")
        {
            NormalKill();
        }

        //Save checkpoint
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
        if (grabBox.box != null)
        {
            if (grabBox.box.name != "Container")
            {
                grabBox.boxCollider.GetComponent<Collider2D>().enabled = false;
                grabBox.box.transform.Find("ColliderForBoxes").transform.GetComponent<Collider2D>().enabled = true;
                grabBox.box.GetComponent<Rigidbody2D>().isKinematic = false;
                grabBox.box.GetComponent<Rigidbody2D>().velocity = new Vector3(grabBox.box.GetComponent<Rigidbody2D>().velocity.x, 0, 0);
                grabBox.box.GetComponent<Collider2D>().enabled = true;
                grabBox.grabbed = false;
            }
            else
            {
                grabBox.containerCollider.GetComponent<Collider2D>().enabled = false;
                grabBox.box.transform.Find("ColliderForBoxes").transform.GetComponent<Collider2D>().enabled = true;
                grabBox.box.GetComponent<Rigidbody2D>().isKinematic = false;
                grabBox.box.GetComponent<Rigidbody2D>().velocity = new Vector3(grabBox.box.GetComponent<Rigidbody2D>().velocity.x, 0, 0);
                grabBox.box.GetComponent<PolygonCollider2D>().enabled = true;
                grabBox.grabbed = false;
            }
        }
        player.transform.SetParent(null);
        player.SetActive(false);

        ragdoll = Instantiate(ragdollPreFab, player.transform.position, player.transform.rotation);


        for (int i = 0; i < bodyparts.Length; i++)
        {
            bodyparts[i] = ragdoll.transform.GetChild(i).gameObject;
            bodyparts[i].GetComponent<Rigidbody2D>().velocity = velocity;
            bodyparts[i].GetComponent<Rigidbody2D>().angularVelocity = angularVelocity;
        }
        if (pressKeyToRespawn)
        {
            isDead = true;
        }
        else
        {
            gameLevelManager.RespawnAfterRagdoll();
        }
    }

    private void NormalKill()
    {
        player.transform.SetParent(null);
        //player.SetActive(false);
        gameLevelManager.RespawnAfterDeath();
    }
}
