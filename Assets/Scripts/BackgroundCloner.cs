using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (SpriteRenderer))]

public class BackgroundCloner : MonoBehaviour {

    public int offsetX = 2;
    public bool hasRightClone = false;
    public bool hasLeftClone = false;
    public bool reverseScale = false;

    private float spriteWidth = 0f;
    private Camera cam;


    private void Awake()
    {
        cam = Camera.main;
    }
    // Use this for initialization
    void Start () {
        SpriteRenderer spriteR = GetComponent<SpriteRenderer>();
        spriteWidth = spriteR.sprite.bounds.size.x * transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
		if((!hasLeftClone || !hasRightClone) && cam != null)
        {
            float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;

            float edgeVisiblePositionRight = (transform.position.x + spriteWidth / 2) - camHorizontalExtend;
            float edgeVisiblePositionLeft = (transform.position.x - spriteWidth / 2) + camHorizontalExtend;

            if(cam.transform.position.x >= edgeVisiblePositionRight - offsetX && !hasRightClone)
            {
                MakeNewClone(1);
                hasRightClone = true;
            }
            else if (cam.transform.position.x <= edgeVisiblePositionLeft + offsetX && !hasLeftClone)
            {
                MakeNewClone(-1);
                hasLeftClone = true;
            }
        }
	}

    private void MakeNewClone(int rightOrLeft)
    {
        Vector3 newPosition = new Vector3(transform.position.x + spriteWidth * rightOrLeft,
            transform.position.y, transform.position.z);

        Transform newClone = Instantiate(transform, newPosition, transform.rotation) as Transform;

        if(reverseScale)
        {
            newClone.localScale = new Vector3(newClone.localScale.x * -1, newClone.localScale.y, newClone.localScale.z);
        }

        newClone.parent = transform;

        if(rightOrLeft > 0)
        {
            newClone.GetComponent<BackgroundCloner>().hasLeftClone = true;
        } else
        {
            newClone.GetComponent<BackgroundCloner>().hasRightClone = true;
        }
    }
}
