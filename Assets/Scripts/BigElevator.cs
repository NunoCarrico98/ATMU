using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigElevator : MonoBehaviour
{
    [Range(0, 1)] public float heavyPercent = 0.4f;
    [Range(0, 1)] public float lightPercent = 0.2f;

    public float waitTime = 0.5f;

    private Vector3 initialPos;
    private Vector3 newPos;

    private void Start()
    {
        initialPos = transform.position;
        newPos = GameObject.Find("BigElevator").transform.Find("Waypoint").transform.position;
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "HeavyBox")
        {
            StartCoroutine(LowerElevatorHeavyBox());
        }

        if (col.transform.tag == "LightBox")
        {
            StartCoroutine(LowerElevatorLightBox());
        }
    }

    private IEnumerator LowerElevatorHeavyBox()
    {
        yield return new WaitForSeconds(waitTime);
        transform.position = Vector3.Lerp(initialPos, newPos, heavyPercent);
    }

    private IEnumerator LowerElevatorLightBox()
    {
        yield return new WaitForSeconds(waitTime);
        transform.position = Vector3.Lerp(newPos, initialPos, lightPercent);
    }
}
