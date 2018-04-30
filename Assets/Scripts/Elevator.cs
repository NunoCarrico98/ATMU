using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float elevatorSpeed = 5f;
    public bool pressured;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pressured = GetComponent<PressurePlate>().pressured;

        
    }
}
