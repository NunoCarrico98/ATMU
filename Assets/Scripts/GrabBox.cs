using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBox : MonoBehaviour
{

    private Transform graphics;
    private int count = 0;

    public bool grabbed;
    RaycastHit2D hit;
    public float distance = 2f;
    public Transform holdpoint;
    public float throwforce;
    public LayerMask notgrabbed;
    public float angle;
    public int rotationOffSet = 0;


    // Use this for initialization
    void Start()
    {
        graphics = transform.Find("Graphics");
    }

    // Update is called once per frame
    void Update()
    {
        FollowMouse();


        if (Input.GetButtonDown("Fire2"))
        {

            if (!grabbed)
            {
                Physics2D.queriesStartInColliders = false;

                if (angle > -90 && angle < 90)
                {
                    count = 1;
                    hit = Physics2D.Raycast(transform.position, Vector2.right * -1, distance);
                    //holdpoint.Translate(new Vector2(holdpoint.transform.position.x * -1, holdpoint.transform.position.y);
                }
                if (angle < -90 || angle > 90 && count == 1)
                {
                    hit = Physics2D.Raycast(transform.position, Vector2.right, distance);
                    //holdpoint.Translate(new Vector2(holdpoint.transform.position.x * -1, holdpoint.transform.position.y));
                }

                if (hit.collider != null && hit.collider.tag == "Grabbable")
                {
                    grabbed = true;

                }
            }
            else if (!Physics2D.OverlapPoint(holdpoint.position, notgrabbed))
            {
                grabbed = false;

                if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {

                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * throwforce;
                }
            }
        }

        if (grabbed)
        {
            hit.collider.gameObject.transform.position = holdpoint.position;
        }


    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance);
    }


    public void FollowMouse()
    {
        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
    }

    public float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}

