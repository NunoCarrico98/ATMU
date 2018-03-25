using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBox : MonoBehaviour
{

    private int keyCount = 0;
    private Vector2 positionOnScreen;
    private Vector2 mouseOnScreen;
    private float xMouse;
    private float yMouse;
    private Vector2 direction;
    private Transform rotateBoxPoint;

    public bool grabbed;
    RaycastHit2D hit;
    RaycastHit2D hitBack;
    public float distance = 2f;
    public Transform holdpoint;
    public float throwforce;
    public LayerMask notgrabbed;
    public float angle;
    public int angleOffSet = 0;
    public LayerMask notToHit;
    public GameObject box;
    public bool backBox = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        FollowMouse();

        direction = directionVector(positionOnScreen, mouseOnScreen);
        direction = createVersor(direction);

        rotateBoxPoint = transform.Find("RotateBoxPoint");

        if (Input.GetButtonDown("Fire2"))
        {

            if (!grabbed)
            {

                Physics2D.queriesStartInColliders = false;

                if (angle > -90 && angle < 90)
                {
                    hit = Physics2D.Raycast(transform.position, Vector2.left, distance);
                }
                if (angle < -90 || angle > 90)
                {
                    hit = Physics2D.Raycast(transform.position, Vector2.right, distance);
                }

                if (angle < -43 && angle > -120)
                {
                    hit = Physics2D.Raycast(transform.position, direction, 2);
                }

                if (hit.collider != null && hit.collider.tag == "Grabbable")
                {
                    grabbed = true;
                }
            }
        }

        if (grabbed)
        {
            box = hit.collider.gameObject;
            box.transform.position = holdpoint.position;
            box.GetComponent<Rigidbody2D>().isKinematic = true;
            box.GetComponent<Collider2D>().enabled = false;

            if (angle > -90 && angle < 90 && !backBox)
            {
                hitBack = Physics2D.Raycast(transform.position, Vector2.right, distance);
            }
            if (angle < -90 || angle > 90 && !backBox)
            {
                hitBack = Physics2D.Raycast(transform.position, Vector2.left, distance);
            }

            if (hitBack.collider != null && hitBack.collider.gameObject.transform.position.x < transform.position.x)
            {
                backBox = true;

                if (angle >= 17 && angle < 180)
                {
                    rotateBoxPoint.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 180f + 170f));
                }
            }

            if (hitBack.collider != null && hitBack.collider.gameObject.transform.position.x > transform.position.x)
            {
                if (angle >= 17 && angle < 180)
                {
                    rotateBoxPoint.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 17f + 170f));
                }
            }

            if (hitBack.collider == null)
            {
                backBox = false;

                if (angle > -90 && angle < 90)
                {
                    hitBack = Physics2D.Raycast(transform.position, Vector2.left, distance);
                }
                if (angle < -90 || angle > 90)
                {
                    hitBack = Physics2D.Raycast(transform.position, Vector2.right, distance);
                }
            }

            if (box.GetComponent<Rigidbody2D>() != null)
            {
                direction = directionVector(positionOnScreen, mouseOnScreen);
                direction = createVersor(direction);

                if (Input.GetButtonUp("Fire2"))
                {
                    keyCount += 1;
                    if (keyCount >= 2)
                    {
                        keyCount = 2;
                    }
                }

                if (Input.GetButtonUp("Fire2") && keyCount == 2)
                {
                    box.GetComponent<Rigidbody2D>().isKinematic = false;
                    box.GetComponent<Rigidbody2D>().velocity = new Vector3(box.GetComponent<Rigidbody2D>().velocity.x, 0, 0);
                    box.GetComponent<Collider2D>().enabled = true;
                    grabbed = false;
                    keyCount = 0;
                }

                if (Input.GetButtonDown("Fire1"))
                {
                    box.GetComponent<Rigidbody2D>().isKinematic = false;
                    box.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                    box.GetComponent<Collider2D>().enabled = true;
                    box.GetComponent<Rigidbody2D>().AddForce(direction * throwforce, ForceMode2D.Impulse);
                    grabbed = false;
                    keyCount = 0;
                }
            }
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(transform.position, holdpoint.position);
    }


    public void FollowMouse()
    {
        //Get the Screen positions of the object
        positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        mouseOnScreen = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
    }

    public float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        float xA = Mathf.Abs(a.x);
        float xB = Mathf.Abs(b.x);
        float yA = Mathf.Abs(a.y);
        float yB = Mathf.Abs(b.y);
        return Mathf.Atan2(yA - yB, xA - xB) * Mathf.Rad2Deg;
    }

    public Vector2 directionVector(Vector2 a, Vector2 b)
    {
        float xA = a.x;
        float xB = b.x;
        float yA = a.y;
        float yB = b.y;

        return (new Vector2((xB - xA), (yB - yA)));
    }

    public Vector2 createVersor(Vector2 a)
    {
        float norm = Mathf.Sqrt(Vector3.Dot(a, a));

        return a / norm;
    }
}

