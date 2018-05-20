using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRotation : MonoBehaviour
{
    /* This Script is used on a GameObject Within the Character's GameObject
    * 
    *  It alows us to rotate a Box Hold Point accordingly to the mouse position
    *  This way when the player is holding the box, it looks more dynamic to the player
    *  
    */

    public float angle;
    public int rotationOffSet = 0;
    public Transform player;

    private bool backBoxR;
    private bool backBoxL;
    private bool stopRotation;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        backBoxR = player.GetComponent<GrabBox>().backBoxR;
        backBoxL = player.GetComponent<GrabBox>().backBoxL;

        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        //Apply rotation proportional to the mouse position
        if (((angle < 15 && angle > -180) || (angle == 180)) && (backBoxR == false && backBoxL == false))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + rotationOffSet));
        }

        if((angle > 15 && angle < 90) && (backBoxR == false && backBoxL == false))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 15f + rotationOffSet));
        }

        if ((angle < 180 && angle >= 90) && (backBoxR == false && backBoxL == false))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 180f + rotationOffSet));
        }

        //If there's a box on player's back
        if (((angle < -55 && angle > -180) || (angle == 180)) && backBoxL == true)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + rotationOffSet));
        }

        //If there's a box on player's back
        if ((angle < 15 && angle > -110) && backBoxR == true)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + rotationOffSet));
        }
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}

