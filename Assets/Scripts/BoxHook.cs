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
    public int startWaypoint;
    public bool boxDetected = false;
    public bool openHook = false;
    public bool closeHook = false;
    public bool pickBox = false;
    public bool dropBox = false;
    public bool startsWithBox = false;
    public bool destroyAfterLastWaypoint = false;

    private Transform box;
    private RaycastHit2D hit;
    private Animator hookAnim;
    private bool stopMovement;
    private bool hasBox;
    private bool beginDetection = false;
    private bool stopOpenMethod = true;
    private float currentSpeed;
    private int counter = 0;


    // Use this for initialization
    private void Start()
    {
        //transform.position = waypoints[start].position;
        hookAnim = GetComponent<Animator>();

        currentWaypoint = startWaypoint;

        currentSpeed = speed;

        stopOpenMethod = false;

        if (startsWithBox) LockBox();

        //StartCoroutine(OpenHook());

    }
    private void Update()
    {
        StartCoroutine(OpenHook());

        StartCoroutine(CloseHook());

        if (pickBox)
        {
            StartCoroutine(GrabBox());
        }

        if (dropBox)
        {
            StartCoroutine(DropBox());
        }

    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!stopMovement) Movement();

        if (!startsWithBox && beginDetection) DetectBox();

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

        if (transform.position == boxWaypoints[2].position || transform.position == boxWaypoints[1].position)
        {
            beginDetection = true;

            if (!hasBox && counter == 0)
            {
                hookAnim.SetBool("Open", true);
                stopMovement = true;
                counter = 1;

                yield return new WaitForSeconds(animationTime);

                hookAnim.SetBool("Open", false);

                stopMovement = false;

                yield return new WaitForSeconds(4);

                counter = 0;
            }
        }
    }

    private IEnumerator CloseHook()
    {
        if (transform.position == boxWaypoints[0].position || transform.position == boxWaypoints[3].position)
        {
            if (!hasBox || hasBox)
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
        stopOpenMethod = true;

        if (transform.position == boxWaypoints[0].position)
        {

            if (boxDetected)
            {
                hookAnim.SetBool("Close", true);
                box.position = Vector2.MoveTowards(box.position, transform.position, grabSpeed * Time.deltaTime);
                stopMovement = true;
                Debug.Log("NICEWEEEEEEEE");

                yield return new WaitForSeconds(animationTime);


                if (box.position == transform.position || box.position != transform.position)
                {
                    Debug.Log("NICEWEEEEEEEE   v2");
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
            beginDetection = false;
        }
    }

    private IEnumerator DropBox()
    {
        if (transform.position == boxWaypoints[1].position)
        {
            if (hasBox)
            {
                hookAnim.SetBool("Open", true);
                stopMovement = true;

                yield return new WaitForSeconds(animationTime);

                boxDetected = false;
                hasBox = false;
                if (box != null)
                {
                    box.SetParent(boxParent);
                    box.GetComponent<Rigidbody2D>().isKinematic = false;
                }

                hookAnim.SetBool("Open", false);
                yield return new WaitForSeconds(stopMovementTime);
                stopMovement = false;
                stopOpenMethod = false;
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
