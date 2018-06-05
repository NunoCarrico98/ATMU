using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControll : MonoBehaviour {

    public bool activateTimeScale = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            activateTimeScale = true;
        }
        if (Input.GetKeyUp(KeyCode.Return))
        {
            activateTimeScale = false;
        }

        if(activateTimeScale)
        {

            Time.timeScale = 4F;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        } else
        {
            Time.timeScale = 1.0f;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }
    }
}
