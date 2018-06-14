using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashHeavyBox : MonoBehaviour
{



    public GameObject prefabHeavyRagdoll1;
    public GameObject prefabHeavyRagdoll2;
    public GameObject prefabCrateRagdoll;

    public GameObject smallerHeavyRag1;
    public GameObject smallerHeavyRag2;
    public GameObject smallerHeavyRag3;

    public GameObject smallerCrateRag1;
    public GameObject smallerCrateRag2;
    public GameObject smallerCrateRag3;

    public GameObject tinyRag1;
    public GameObject tinyRag2;
    public GameObject tinyRag3;


    public Transform ragParent;

    private GameObject[] pieces = new GameObject[9];
    private GameObject box;
    private Vector2 velocity;
    private float angularVelocity;
    private bool activate1 = false;
    private bool activate2 = false;
    private bool activate3 = false;
    private int rand;
    private int number;
    private int counter = 0;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (activate1)
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                pieces[i] = prefabHeavyRagdoll1.transform.GetChild(i).gameObject;
                pieces[i].GetComponent<Rigidbody2D>().velocity = velocity;
                pieces[i].GetComponent<Rigidbody2D>().angularVelocity = angularVelocity;
                if (i == pieces.Length - 1) activate1 = false;
            }
        }

        if (activate2)
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                pieces[i] = prefabHeavyRagdoll2.transform.GetChild(i).gameObject;
                pieces[i].GetComponent<Rigidbody2D>().velocity = velocity;
                pieces[i].GetComponent<Rigidbody2D>().angularVelocity = angularVelocity;
                if (i == pieces.Length - 1) activate2 = false;
            }
        }

        if (activate3)
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                pieces[i] = prefabCrateRagdoll.transform.GetChild(i).gameObject;
                pieces[i].GetComponent<Rigidbody2D>().velocity = velocity;
                pieces[i].GetComponent<Rigidbody2D>().angularVelocity = angularVelocity;
                if (i == pieces.Length - 1) activate3 = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        counter = 0;

        if (col.tag == "HeavyBox" || col.tag == "LightBox")
        {
            box = col.gameObject;
            GetVelocity();

            if (box.name == "HeavyBox1" || box.name == "HeavyBox2")
            {
                Instantiate(prefabHeavyRagdoll1, col.transform.position, box.transform.GetChild(0).transform.rotation);
                activate1 = true;
            }

            if (box.name == "HeavyBox3" || box.name == "HeavyBox4")
            {
                Instantiate(prefabHeavyRagdoll2, col.transform.position, box.transform.GetChild(0).transform.rotation);
                activate2 = true;
            }

            if (box.name == "Crate1" || box.name == "Crate2")
            {
                Instantiate(prefabCrateRagdoll, col.transform.position, box.transform.GetChild(0).transform.rotation);
                activate3 = true;
            }

            if(col.tag == "LightBox" && (col.name != "Crate1" && col.name != "Crate2"))
            {
                col.transform.GetComponent<DestroyLightBox>().DestroyBox2();
            }
            else
            {
                Destroy(col.gameObject);
                counter++;
            }
        }

        if (col.tag == "HeavyBoxPiece" && transform.parent.name != "Destroyer (1)" && counter == 0)
        {
            box = col.gameObject;

            GetVelocity();

            rand = GetRandomNumber();

            switch (rand)
            {
                case 1:
                    Instantiate(smallerHeavyRag1, col.transform.position, transform.rotation);
                    break;
                case 2:
                    Instantiate(smallerHeavyRag2, col.transform.position, transform.rotation);
                    break;
                case 3:
                    Instantiate(smallerHeavyRag3, col.transform.position, transform.rotation);
                    break;
            }

            Destroy(col.gameObject);
        }
        if (col.tag == "CratePiece" && transform.parent.name != "Destroyer (1)" && counter == 0)
        {
            box = col.gameObject;
            GetVelocity();

            rand = GetRandomNumber();

            switch (rand)
            {
                case 1:
                    Instantiate(smallerCrateRag1, col.transform.position, transform.rotation);
                    break;
                case 2:
                    Instantiate(smallerCrateRag2, col.transform.position, transform.rotation);
                    break;
                case 3:
                    Instantiate(smallerCrateRag3, col.transform.position, transform.rotation);
                    break;
            }

            Destroy(col.gameObject);
            counter++;
        }


        if (col.tag == "HeavyBoxPiece2" && transform.parent.name != "Destroyer (1)" && transform.parent.name != "Destroyer (2)" && counter == 0)
        {
            box = col.gameObject;
            GetVelocity();

            rand = GetRandomNumber();

            switch (rand)
            {
                case 1:
                    Instantiate(tinyRag1, col.transform.position, transform.rotation);
                    break;
                case 2:
                    Instantiate(tinyRag2, col.transform.position, transform.rotation);
                    break;
                case 3:
                    Instantiate(tinyRag3, col.transform.position, transform.rotation);
                    break;
            }

            Destroy(col.gameObject);
        }
    }

    private int GetRandomNumber()
    {
        number = Random.Range(1, 3);
        return number;
    }

    private void GetVelocity()
    {
        velocity = box.GetComponent<Rigidbody2D>().velocity;
        angularVelocity = box.GetComponent<Rigidbody2D>().angularVelocity;
    }
}
