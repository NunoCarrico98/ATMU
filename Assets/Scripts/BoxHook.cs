using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHook : MonoBehaviour
{
    public Transform[] waypoints;
    public Transform[] boxWaypoints;
    public Transform boxParent;
    public int start;
    public int currentWaypoint;
    public float speed;
    public float lowSpeed;
    public float grabSpeed = 1;
    public float animationTime = 2;
    public float stopMovementTime = 0.5f;
    public bool boxDetected = false;
    public bool pickBox = false;
    public bool dropBox = false;
    public bool startsWithBox = false;
    public bool destroyAfterLastWaypoint = false;

    private Transform box;
    private RaycastHit2D hit;
    private Animator hookAnim;
    private bool stopMovement;
    private bool hasBox;
    private float currentSpeed;

    // Use this for initialization
    private void Start()
    {
        transform.position = waypoints[start].position;
        hookAnim = GetComponent<Animator>();

        currentSpeed = speed;

        if (startsWithBox) LockBox();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!stopMovement) Movement();

        if(!startsWithBox) DetectBox();

        if (pickBox)
        {
            StartCoroutine(OpenHook());
            StartCoroutine(CloseHook());
        }
        if (dropBox)
        {
            StartCoroutine(GrabBox());
            StartCoroutine(DropBox());
        }
    }

    public void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, currentSpeed * Time.deltaTime);

        if (transform.position == waypoints[currentWaypoint].position)
        {
            currentWaypoint++;
            if (currentWaypoint == waypoints.Length && !destroyAfterLastWaypoint) currentWaypoint = 0;
            if (currentWaypoint == waypoints.Length && destroyAfterLastWaypoint) Destroy(gameObject);
        }
    }

    private IEnumerator OpenHook()
    {
        if (transform.position == boxWaypoints[0].position)
        {
            if (!hasBox)
            {
                hookAnim.SetBool("Open", true);
                stopMovement = true;

                yield return new WaitForSeconds(animationTime);

                hookAnim.SetBool("Open", false);
                stopMovement = false;
            }
        }
    }

    private IEnumerator CloseHook()
    {
        if (transform.position == boxWaypoints[3].position)
        {
            if (!hasBox)
            {
                hookAnim.SetBool("Close", true);
                stopMovement = true;

                yield return new WaitForSeconds(animationTime);

                boxDetected = false;
                hookAnim.SetBool("Close", false);
                stopMovement = false;
            }
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
                    hasBox = true;
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
            if (hasBox || !hasBox)
            {
                hookAnim.SetBool("Open", true);
                stopMovement = true;

                yield return new WaitForSeconds(animationTime);

                boxDetected = false;
                hasBox = false;
                box.SetParent(boxParent);
                box.GetComponent<Rigidbody2D>().isKinematic = false;

                hookAnim.SetBool("Open", false);
                yield return new WaitForSeconds(stopMovementTime);
                stopMovement = false;
            }
        }
    }

    private void LockBox()
    {
        box = transform.GetChild(0);
        hasBox = true;
        box.GetComponent<Rigidbody2D>().isKinematic = true;

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
