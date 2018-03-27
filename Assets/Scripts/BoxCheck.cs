using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCheck : MonoBehaviour
{
    public bool foundBox = false;
    public float distance = 2f;
    public float angle;
    public GameObject player;
    public Vector2 offset;
    public bool grabbed = false;

    private RaycastHit2D hitLeft;
    private RaycastHit2D hitRight;
    private RaycastHit2D[] hitUp = new RaycastHit2D[3];
    private RaycastHit2D[] hitDown = new RaycastHit2D[3];
    //private Collider2D hitPlayer;
    private int count = 0;
    private Vector2 resetOffset;
    private float slowSpeed;

    // Use this for initialization
    void Start()
    {
        offset = transform.Find("ColliderSide").GetComponent<Collider2D>().offset;
        resetOffset = offset;
    }

    // Update is called once per frame
    void Update()
    {
        angle = player.GetComponent<GrabBox>().angle;
       // slowSpeed = GetComponent<PlatformerCharacter2D>().slowSpeed;
       // hitPlayer = player.GetComponent<GrabBox>().hit.collider;

        FlipBoxCollider();

        /* Initialize raycasts in all 4 directions */
        hitLeft = Physics2D.Raycast(transform.position, Vector2.left, distance);
        hitRight = Physics2D.Raycast(transform.position, Vector2.right, distance);
        hitUp[0] = Physics2D.Raycast(transform.position - new Vector3(0.7f, 0, 0), Vector2.up, distance);
        hitUp[1] = Physics2D.Raycast(transform.position, Vector2.up, distance);
        hitUp[2] = Physics2D.Raycast(transform.position + new Vector3(0.7f, 0, 0), Vector2.up, distance);
        hitDown[0] = Physics2D.Raycast(transform.position - new Vector3(0.7f, 0, 0), Vector2.down, distance);
        hitDown[1] = Physics2D.Raycast(transform.position, Vector2.down, distance);
        hitDown[2] = Physics2D.Raycast(transform.position + new Vector3(0.7f, 0, 0), Vector2.down, distance);

        /* Detect collision to left raycast */
        if (hitLeft.collider != null && hitLeft.collider.tag == "BoxColliders")
        {
            foundBox = true;
        }
        if (hitLeft.collider == null)
        {
            foundBox = false;
        }

        /* Detect collision to right raycast */
        if (hitRight.collider != null && hitRight.collider.tag == "BoxColliders")
        {
            foundBox = true;
        }
        if (hitRight.collider == null)
        {
            foundBox = false;
        }

        /* Detect collision to up raycast */
        if ((hitUp[0].collider != null && hitUp[0].collider.tag == "BoxColliders") ||
            (hitUp[1].collider != null && hitUp[1].collider.tag == "BoxColliders") ||
            (hitUp[2].collider != null && hitUp[2].collider.tag == "BoxColliders"))
        {
            foundBox = true;
            player.GetComponent<GrabBox>().box.GetComponent<Rigidbody2D>().isKinematic = false;
            player.GetComponent<GrabBox>().box.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            player.GetComponent<GrabBox>().box.GetComponent<Collider2D>().enabled = true;
            player.GetComponent<GrabBox>().grabbed = false;

            player.GetComponent<GrabBox>().box.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        }
        if (hitUp[0].collider == null || hitUp[1].collider == null || hitUp[2].collider == null)
        {
            foundBox = false;
        }

        /* Detect collision to down raycast */
        if ((hitDown[0].collider != null && hitDown[0].collider.tag == "BoxColliders") ||
            (hitDown[1].collider != null && hitDown[1].collider.tag == "BoxColliders") ||
            (hitDown[2].collider != null && hitDown[2].collider.tag == "BoxColliders"))
        {
            foundBox = true;
        }
        if (hitDown[0].collider == null || hitDown[1].collider == null || hitDown[2].collider == null)
        {
            foundBox = false;
        }

    }

    public void FlipBoxCollider()
    {
        if (angle < -90 || angle > 90 && count == 1)
        {
            transform.Find("ColliderSide").GetComponent<Collider2D>().offset = resetOffset;
        }

        if (angle > -90 && angle < 90)
        {
            count = 1;
            transform.Find("ColliderSide").GetComponent<Collider2D>().offset = -offset;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(new Vector3(transform.position.x - 0.7f, transform.position.y, 0), new Vector3(transform.position.x - 0.7f, transform.position.y + distance, 0));
    }

    /*public void TwoBoxesVertical()
    {
        if(hitPlayer.gameObject.name == "LightBox")
        {
            if (hitUp[0].collider.gameObject.name == "LightBox" ||
                hitUp[1].collider.gameObject.name == "LightBox" ||
                hitUp[2].collider.gameObject.name == "LightBox")
            {
                player.GetComponent<PlatformerCharacter2D>().m_MaxSpeed = slowSpeed;
                hitUp[0].collider.gameObject.transform.position = new Vector2(transform.position.x, hitUp[0].collider.gameObject.transform.position.y);
                hitUp[1].collider.gameObject.transform.position = new Vector2(transform.position.x, hitUp[1].collider.gameObject.transform.position.y);
                hitUp[2].collider.gameObject.transform.position = new Vector2(transform.position.x, hitUp[2].collider.gameObject.transform.position.y);
            }
        }
    }*/

}
