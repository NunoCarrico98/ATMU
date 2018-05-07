using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigElevator : MonoBehaviour
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

    private void Start()
    {
        newPos = GameObject.Find("BigElevator").transform.Find("Waypoint").transform.position;
        newPos2 = GameObject.Find("BigElevator").transform.Find("Waypoint2").transform.position;
        endPos = GameObject.Find("BigElevator").transform.Find("Waypoint3").transform.position;
    }

    private void Update()
    {
        
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

    private IEnumerator LowerElevatorHeavyBox()
    {
        yield return new WaitForSeconds(waitTime);
        transform.position = Vector3.Lerp(transform.position, newPos, heavyPercent);
    }

    private IEnumerator LowerElevatorLightBox()
    {
        yield return new WaitForSeconds(waitTime);
        transform.position = Vector3.Lerp(transform.position, newPos, lightPercent);
    }

    private IEnumerator UpElevatorHeavyBox()
    {
        yield return new WaitForSeconds(waitTime);
        transform.position = Vector3.Lerp(transform.position, newPos, 1);
    }

    private IEnumerator UpElevatorLightBox()
    {
        yield return new WaitForSeconds(waitTime);
        transform.position = Vector3.Lerp(transform.position, newPos, 1);
    }
}
