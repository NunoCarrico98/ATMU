using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float fireRate = 5;
    public float damage = 10;
    public float distance = 100;
    public LayerMask notToHit;

    float timeToFire = 0;
    Transform firePoint;


	// Use this for initialization
	void Awake ()
    {
        firePoint = transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("BRUHHH! There's no firepoint!!");
        }
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //If weapon is single-burst
		if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        if (fireRate != 0)
        {
            if (Input.GetButton("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
	}

    void Shoot ()
    {
        //Vector2 mouseOnScreen = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        Vector2 mouseOnScreen = GetWorldPositionOnPlane(Input.mousePosition, 0);
        //Vector2 firePointPosition = Camera.main.WorldToViewportPoint(firePoint.position);
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mouseOnScreen-firePointPosition, distance, notToHit);
        //RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, distance, notToHit);
        Debug.DrawLine(firePointPosition, (mouseOnScreen-firePointPosition)*100, Color.red);
        if (hit.collider != null)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.black);
            Debug.Log("We hit " + hit.collider.name + "and did " + damage + "damage!");
        }
    }

    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }
}
