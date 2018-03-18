using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadRotation : MonoBehaviour {

    public float angle;
    public int rotationOffSet = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;      //Subtracting the position of the player with the mouse position
        //difference.Normalize();     //Normalizing the vector. Meaning that all the sum of the vector will be equal to one
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;       //Find the angle in degrees
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffSet);*/
        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        //Apply rotation
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + rotationOffSet));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}

