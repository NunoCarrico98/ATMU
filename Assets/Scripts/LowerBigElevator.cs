using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerBigElevator : MonoBehaviour
{
    [Range(0, 1)] public float heavyPercent = 0.4f;
    [Range(0, 1)] public float lightPercent = 0.2f;


    public float firstDistance = 0;
    public float distance = 0;
    public float waitTime = 0.5f;

    private bool activateFall = false;

    private Vector3 newPos;
    private Vector3 newPos2;
    private Vector3 endPos;
    private Animator bigEleAnim;
    private GameObject player;

    private void Start()
    {
        newPos = GameObject.Find("BigElevator").transform.Find("Waypoint").transform.position;
        newPos2 = GameObject.Find("BigElevator").transform.Find("Waypoint2").transform.position;
        endPos = GameObject.Find("BigElevator").transform.Find("Waypoint3").transform.position;
        bigEleAnim = GetComponent<Animator>();
        player = GameObject.Find("Player");

        bigEleAnim.enabled = false;
    }

    private void Update()
    {
        ElevatorFalls();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "HeavyBox")
        {
            StartCoroutine(LowerElevatorHeavyBox());
        }

        if (col.tag == "LightBox")
        {
            StartCoroutine(LowerElevatorLightBox());
        }

        if(col.tag == "Player")
        {
            activateFall = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "HeavyBox")
        {
            StartCoroutine(UpElevatorHeavyBox());
        }

        if (col.tag == "LightBox")
        {
            StartCoroutine(UpElevatorLightBox());
        }
    }

    private void ElevatorFalls()
    {
        if (activateFall)
        {
            player.GetComponent<CharacterMovement>().characterAnim.SetFloat("Speed", 0);
            GameObject.Find("Player").GetComponent<CharacterMovement>().enabled = false;
            player.transform.position = transform.Find("GrabPlayer").transform.position;

            if (transform.position == newPos)
            {
                bigEleAnim.enabled = true;
                bigEleAnim.SetBool("Fall", true);
            }
            else
            {
                bigEleAnim.SetBool("Fall", false);
            }

            if (transform.position == newPos2)
            {
                bigEleAnim.SetBool("Fall", true);
            }
        }
    }

    IEnumerator LowerElevatorHeavyBox()
    {
        yield return new WaitForSeconds(waitTime);
        transform.position = Vector3.Lerp(transform.position, newPos, heavyPercent);
    }

    IEnumerator LowerElevatorLightBox()
    {
        yield return new WaitForSeconds(waitTime);
        transform.position = Vector3.Lerp(transform.position, newPos, lightPercent);
    }

    IEnumerator UpElevatorHeavyBox()
    {
        yield return new WaitForSeconds(waitTime);
        transform.position = Vector3.Lerp(transform.position, newPos, 1);
    }

    IEnumerator UpElevatorLightBox()
    {
        yield return new WaitForSeconds(waitTime);
        transform.position = Vector3.Lerp(transform.position, newPos, 1);
    }
}
