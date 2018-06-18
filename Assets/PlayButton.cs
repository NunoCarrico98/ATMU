using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {


    public Sprite pressedSprite;
    public Transform blackCanvas;
    public Transform spaceShip;
    public Transform oldRobot;
    public Transform badRobot;
    public Vector3 spaceShipVector;
    public Vector3 oldRobotVector;
    public Vector3 badRobotVector;
    public float spaceShipSpeed;
    public float oldRobotSpeed;
    public float badRobotSpeed;
    public float fadeSpeed;
    public bool play = false;

    private Sprite resetSprite;
    private Color blackColor;
    private float counter = 0;
    private bool stop = false;
    private bool kickAss = false;
    private bool departure = false;
    private bool departure2 = false;



    // Use this for initialization
    void Start () {
        resetSprite = transform.GetComponent<SpriteRenderer>().sprite;

        }
	
	    // Update is called once per frame
	    void Update () {

        if (play)
        {
            if (!stop)
            {
                transform.GetComponent<SpriteRenderer>().sprite = pressedSprite;
                counter += Time.deltaTime;

                if (counter > 0.1f)
                {
                    transform.GetComponent<SpriteRenderer>().sprite = resetSprite;
                    stop = true;
                }
            }

            badRobot.transform.position = Vector3.MoveTowards(badRobot.transform.position, badRobotVector, badRobotSpeed * Time.deltaTime);
            if (badRobot.transform.position == badRobotVector) kickAss = true;

            if(kickAss)
            {
                oldRobot.transform.position = Vector3.MoveTowards(oldRobot.transform.position, oldRobotVector, oldRobotSpeed * Time.deltaTime);
                oldRobot.rotation = Quaternion.FromToRotation(Vector3.up, Vector3.left);
                if (oldRobot.transform.position == oldRobotVector) departure = true;
            }

            if(departure)
            {
                spaceShip.transform.position = Vector3.MoveTowards(spaceShip.transform.position, 
                    new Vector3(spaceShip.transform.position.x, 10 , spaceShip.transform.position.z), spaceShipSpeed/10 * Time.deltaTime);
                if (spaceShip.transform.position == new Vector3(spaceShip.transform.position.x, 10, spaceShip.transform.position.z))
                {
                    departure = false;
                    departure2 = true;
                }
            }

            if (departure2)
            {
                spaceShip.transform.position = Vector3.MoveTowards(spaceShip.transform.position, spaceShipVector, spaceShipSpeed*10 * Time.deltaTime);
                if (spaceShip.transform.position == spaceShipVector)
                {
                    FadeOut();
                    if(blackColor.a >= 1) SceneManager.LoadScene(1);
                }
            }
        }
    }

    private void FadeOut()
    {
        blackColor = blackCanvas.GetComponent<SpriteRenderer>().color;
        blackColor.a += fadeSpeed * Time.deltaTime;
        blackCanvas.GetComponent<SpriteRenderer>().color = blackColor;
    }

    private void OnMouseDown()
    {
        play = true;

    }
}
