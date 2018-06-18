using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayerMoveTunnel : MonoBehaviour
{
    public static bool isDisabled;
    public static bool canSpawn = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && (name == "StopPlayerMove" || name == "StopPlayerMove2"))
        {
            col.GetComponent<PlayerMovement>().enabled = false;
            col.GetComponent<PlayerMovement>().characterAnim.SetFloat("Speed", 0);
            col.GetComponent<PlayerMovement>().characterAnim.SetBool("Ground", true);
            if (name == "StopPlayerMove")
            {
                isDisabled = true;
                col.transform.Find("ConveyorCollider").GetComponent<Collider2D>().enabled = false;
            }
            //col.GetComponent<PlayerMovement>().characterAnim.Play("IdleAnim");
        }

        if (col.tag == "Player" && name == "ResetPlayerMove")
        {
            isDisabled = false;
            col.GetComponent<PlayerMovement>().enabled = true;
            col.transform.Find("ConveyorCollider").GetComponent<Collider2D>().enabled = true;
            //FindObjectOfType<KillPlayer>().enabled = true;
            canSpawn = true;
        }
    }
}
