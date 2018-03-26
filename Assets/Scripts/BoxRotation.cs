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

    private bool backBox;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        backBox = player.GetComponent<GrabBox>().backBox;

        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        //Apply rotation proportional to the mouse position
        if ((angle < 17 && angle > -180) || (angle == 180) && backBox == false)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + rotationOffSet));
        }

        //If there's a box on player's back
        if ((angle < -60 && angle > -180) || (angle == 180) && backBox == true)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + rotationOffSet));
        }


        /*if(angle >= 17 && angle < 90 && backBox == false)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 17f + rotationOffSet));
        }

        if (angle < 180 && angle >= 90 && backBox == false)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 180f + rotationOffSet));
        }*/
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}

