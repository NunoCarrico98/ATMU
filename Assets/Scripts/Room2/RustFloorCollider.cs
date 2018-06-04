using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RustFloorCollider : MonoBehaviour
{

    public GameObject rustFloor;
    public GameObject ragdollPrefab;
    public GameObject collider1;
    public GameObject collider2;

    private PlayerMovement pMove;
    private Transform parent;
    private int counter1 = 0;
    private int counter2 = 0;
    private int counter3 = 0;
    private int counter4 = 0;
    private int counter5 = 0;
    private float timer = 0;

    // Use this for initialization
    void Start()
    {
        parent = transform.parent.transform;
        pMove = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (parent.name == "RustFloor")
        {
            if (transform.parent.GetChild(0).GetChild(0).GetComponent<DestroyRustFloorBox>().activate1
                && counter1 == 0)
            {
                if (timer < 0.1f) timer += Time.deltaTime;
                if (timer > 0.05f)
                {
                    //col.transform.position = new Vector2(parent.position.x, parent.position.y + 5);
                    Instantiate(ragdollPrefab, new Vector2(parent.position.x, parent.position.y), parent.rotation);
                    Destroy(rustFloor);
                    Destroy(collider1);
                    Destroy(collider2);
                    counter1++;

                }
            }
        }
        if (parent.name == "RustFloor2")
        {
            if (transform.parent.GetChild(0).GetChild(0).GetComponent<DestroyRustFloorBox>().activate2
                && counter2 == 0)
            {
                if (timer < 0.1f) timer += Time.deltaTime;
                if (timer > 0.05f)
                {
                    //col.transform.position = new Vector2(parent.position.x, parent.position.y + 5);
                    Instantiate(ragdollPrefab, new Vector2(parent.position.x, parent.position.y), parent.rotation);
                    Destroy(rustFloor);
                    Destroy(collider1);
                    Destroy(collider2);
                    counter2++;

                }
            }
        }
        if (parent.name == "RustWall")
        {
            if (transform.parent.GetChild(0).GetChild(0).GetComponent<DestroyRustFloorBox>().activate3
                && counter3 == 0)
            {
                if (timer < 0.1f) timer += Time.deltaTime;
                if (timer > 0.05f)
                {
                    //col.transform.position = new Vector2(parent.position.x, parent.position.y + 5);
                    Instantiate(ragdollPrefab, new Vector2(parent.position.x, parent.position.y), parent.rotation);
                    Destroy(rustFloor);
                    Destroy(collider1);
                    Destroy(collider2);
                    counter3++;

                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (counter4 == 0 && col.tag == "Player" && name == "FloorCollider" && pMove.grounded)
        {
            if (timer < 0.1f) timer += Time.deltaTime;
            if (timer > 0.05f)
            {
                //col.transform.position = new Vector2(parent.position.x, parent.position.y + 5);
                Instantiate(ragdollPrefab, new Vector2(parent.position.x, parent.position.y), parent.rotation);
                Destroy(rustFloor);
                Destroy(collider1);
                Destroy(collider2);
                counter4++;

            }
        }
        if (counter5 == 0 && col.tag == "Player" && name == "FloorCollider2" && pMove.grounded)
        {
            if (timer < 0.1f) timer += Time.deltaTime;
            if (timer > 0.05f)
            {
                //col.transform.position = new Vector2(parent.position.x, parent.position.y + 5);
                Instantiate(ragdollPrefab, new Vector2(parent.position.x, parent.position.y), parent.rotation);
                Destroy(rustFloor);
                Destroy(collider1);
                Destroy(collider2);
                counter5++;
            }
        }
    }
}
