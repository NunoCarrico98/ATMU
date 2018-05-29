using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRustRagdool : MonoBehaviour
{

    public float destroyTime = 0.4f;
    public float timeToStart = 2f;
    private float timer = 0;

    // Update is called once per frame
    void Update()
    {
        DestroyPieces();
    }

    private void DestroyPieces()
    {
        timer += Time.deltaTime;

        if (transform.childCount > 0 && timer >= timeToStart)
        {
            if (destroyTime > 0)
            {
                destroyTime -= 0.001f;
            }
            else if (destroyTime < 0) destroyTime = 0;

            Destroy(transform.GetChild(0).gameObject, destroyTime);
        }
        else if(transform.childCount == 0)
        {
            Destroy(gameObject);
        }
    }
}
