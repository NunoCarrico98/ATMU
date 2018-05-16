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
    private RaycastHit2D hit;
    private bool boxDetected = false;
    private bool stopMovement;

    // Use this for initialization
    void Start()
    {
        transform.position = waypoints[start].position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!stopMovement) Movement();
        DetectBox();
        StartCoroutine(GrabBox());
    }

    public void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position,
            waypoints[currentWaypoint].position, speed * Time.deltaTime);

        if (transform.position == waypoints[currentWaypoint].position)
        {
            currentWaypoint++;
            if (currentWaypoint == waypoints.Length) currentWaypoint = 0;
        }
    }

    public void OpenHook()
    {
        if (transform.position == boxWaypoints[0].position)
        {
            // Abrir
        }
    }

    private IEnumerator GrabBox()
    {
        if (boxDetected)
        {
            if (transform.position == boxWaypoints[1].position)
            {
                // Faz animaçao de fechar

                box.position = Vector2.MoveTowards(box.position, transform.position, grabSpeed * Time.deltaTime);
                stopMovement = true;
                yield return new WaitForSeconds(animationTime);
                stopMovement = false;

                if (box.position == transform.position)
                {
                    box.SetParent(transform);
                    box.GetComponent<Rigidbody2D>().isKinematic = true;
                }
                else
                {
                    boxDetected = false;
                }

            }
        }
    }

    public void DropBox()
    {
        if (transform.position == boxWaypoints[2].position)
        {
            // Faz animaçao de abrir
        }
    }

    public void CloseHook()
    {
        if (transform.position == boxWaypoints[4].position)
        {
            // Fechar
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
