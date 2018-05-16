using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHook : MonoBehaviour
{
    public Transform[] waypoints;
    public Transform[] boxWaypoints;
    public int start;
    public int currentWaypoint;
    public float speed;
    public float grabSpeed = 1;
    public float animationTime = 2;

    private Transform box;
    private Transform boxParent;
    private RaycastHit2D hit;
    private Animator hookAnim;
    private bool boxDetected = false;
    private bool stopMovement;

    // Use this for initialization
    void Start()
    {
        transform.position = waypoints[start].position;
        hookAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopMovement) Movement();
    }

    public void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);

        if (transform.position == waypoints[currentWaypoint].position)
        {
            currentWaypoint++;
            if (currentWaypoint == waypoints.Length) currentWaypoint = 0;
        }

        DetectBox();
        StartCoroutine(OpenHook());
        StartCoroutine(GrabBox());
        StartCoroutine(DropBox());
        StartCoroutine(CloseHook());
    }

    private IEnumerator OpenHook()
    {
        if (transform.position == boxWaypoints[0].position)
        {
            if (!boxDetected)
            {
                hookAnim.SetBool("Open", true);
                stopMovement = true;
            }

            yield return new WaitForSeconds(animationTime);

            hookAnim.SetBool("Open", false);
            stopMovement = false;
        }
    }

    private IEnumerator GrabBox()
    {
        if (boxDetected)
        {
            if (transform.position == boxWaypoints[1].position)
            {
                hookAnim.SetBool("Close", true);

                box.position = Vector2.MoveTowards(box.position, transform.position, grabSpeed * Time.deltaTime);
                stopMovement = true;

                yield return new WaitForSeconds(animationTime);

                if (box.position == transform.position)
                {
                    box.SetParent(transform);
                    box.GetComponent<Rigidbody2D>().isKinematic = true;
                }
                else
                {
                    boxDetected = false;
                }

                hookAnim.SetBool("Close", false);
                stopMovement = false;

            }
        }
    }

    private IEnumerator DropBox()
    {
        if (transform.position == boxWaypoints[2].position)
        {
            hookAnim.SetBool("Open", true);
            stopMovement = true;

            yield return new WaitForSeconds(animationTime);

            //box.SetParent(boxParent);
            // box.GetComponent<Rigidbody2D>().isKinematic = false;

            hookAnim.SetBool("Open", false);
            stopMovement = false;
        }
    }

    private IEnumerator CloseHook()
    {
        if (transform.position == boxWaypoints[3].position)
        {
            hookAnim.SetBool("Close", true);
            stopMovement = true;

            yield return new WaitForSeconds(animationTime);

            hookAnim.SetBool("Close", false);
            stopMovement = false;
        }
    }

    public void DetectBox()
    {
        hit = Physics2D.Raycast(transform.position, Vector3.down, 0.8f);

        if (hit.collider != null && (hit.collider.tag == "HeavyBox" || hit.collider.tag == "LightBox"))
        {
            box = hit.transform;
            boxDetected = true;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z));
    }
}
