using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour {

    public Transform[] backgrounds;
    private float[] parallaxScales;
    public float smoothing = 1f;

    private Transform player;
    private Vector3 previousCamPos;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

    // Use this for initialization
    private void Start () {
        previousCamPos = new Vector3(-3, 3.5f, -100);

        parallaxScales = new float[backgrounds.Length];

        for(int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z;
        }
	}

    private void Update()
    {
        ParallaxingEffect();
    }

    private void ParallaxingEffect()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallaxX = (previousCamPos.x - player.position.x) * parallaxScales[i];
            //float parallaxY = (previousCamPos.y - player.position.y) * parallaxScales[i];

            float backgroundTargetPosX = backgrounds[i].position.x + parallaxX;
            //float backgroundTargetPosY = backgrounds[i].position.y + parallaxY;

            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }
        previousCamPos = player.position;
    }
}
