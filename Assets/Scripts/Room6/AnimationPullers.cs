using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPullers : MonoBehaviour
{
    public Transform plate;
    public Transform elevator;

    private PressurePlate pp;
    private Elevator elev;
    private Animator anim;
    private bool animate;

    // Use this for initialization
    void Start()
    {
        pp = plate.GetComponent<PressurePlate>();
        elev = elevator.GetComponent<Elevator>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetAnimBool();
        anim.SetBool("Pull", animate);
    }

    private void GetAnimBool()
    {
        if (pp.pressured && elev.transform.position != elev.endPos)
        {
            animate = true;
        }
        
        if(!pp.pressured || elev.transform.position == elev.endPos)
        {
            animate = false;
        }
    }
}
