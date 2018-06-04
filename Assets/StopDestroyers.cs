using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopDestroyers : MonoBehaviour
{

    public Transform[] destroyer;
    public Transform[] pressurePlate;
    public bool[] pressured;

    private int destroyer1Number = 0;
    private int destroyer2Number = 0;
    private int destroyer3Number = 0;
    private int destroyer4Number = 0;
    private int destroyer5Number = 0;

    private int counter1 = 0;
    private int counter2 = 0;
    private int counter3 = 0;
    private int counter4 = 0;
    // Use this for initialization
    void Start()
    {
        pressured = new bool[pressurePlate.Length];
    }

    // Update is called once per frame
    void Update()
    {
        CheckPressuredPlates();
        ConditionsToStop();
        StopDestroyer();
    }

    private void ConditionsToStop()
    {
        //If plate 1 is pressured
        if (pressured[0] && counter1 == 0)
        {
            destroyer1Number++;
            destroyer2Number++;
            destroyer4Number++;
            counter1++;
        }
        //If plate 1 isnt pressured
        if(!pressured[0] && counter1 == 1)
        {
            destroyer1Number--;
            destroyer2Number--;
            destroyer4Number--;
            counter1--;
        }

        //If plate 2 is pressured
        if (pressured[1] && counter2 == 0)
        {
            destroyer1Number++;
            destroyer2Number++;
            destroyer5Number++;
            counter2++;
        }
        //If plate 2 isnt pressured
        if (!pressured[1] && counter2 == 1)
        {
            destroyer1Number--;
            destroyer2Number--;
            destroyer5Number--;
            counter2--;
        }

        //If plate 3 is pressured
        if (pressured[2] && counter3 == 0)
        {
            destroyer2Number++;
            destroyer3Number++;
            destroyer4Number++;
            counter3++;
        }
        //If plate 3 isnt pressured
        if (!pressured[2] && counter3 == 1)
        {
            destroyer2Number--;
            destroyer3Number--;
            destroyer4Number--;
            counter3--;
        }

        //If plate 4 is pressured
        if (pressured[3] && counter4 == 0)
        {
            destroyer2Number++;
            destroyer4Number++;
            destroyer5Number++;
            counter4++;
        }
        //If plate 4 isnt pressured
        if (!pressured[3] && counter4 == 1)
        {
            destroyer2Number--;
            destroyer4Number--;
            destroyer5Number--;
            counter4--;
        }
    }

    private void StopDestroyer()
    {
        //Stop destroyer one if number isnt even
        if(destroyer1Number % 2 == 1)
        {
            destroyer[0].GetComponent<DestroyerOnOff>().on = false;
        } else
        {
            destroyer[0].GetComponent<DestroyerOnOff>().on = true;
        }

        //Stop destroyer one if number isnt even
        if (destroyer2Number % 2 == 1)
        {
            destroyer[1].GetComponent<DestroyerOnOff>().on = false;
        }
        else
        {
            destroyer[1].GetComponent<DestroyerOnOff>().on = true;
        }

        //Stop destroyer one if number isnt even
        if (destroyer3Number % 2 == 1)
        {
            destroyer[2].GetComponent<DestroyerOnOff>().on = false;
        }
        else
        {
            destroyer[2].GetComponent<DestroyerOnOff>().on = true;
        }

        //Stop destroyer one if number isnt even
        if (destroyer4Number % 2 == 1)
        {
            destroyer[3].GetComponent<DestroyerOnOff>().on = false;
        }
        else
        {
            destroyer[3].GetComponent<DestroyerOnOff>().on = true;
        }

        //Stop destroyer one if number isnt even
        if (destroyer5Number % 2 == 1)
        {
            destroyer[4].GetComponent<DestroyerOnOff>().on = false;
        }
        else
        {
            destroyer[4].GetComponent<DestroyerOnOff>().on = true;
        }
    }

    private void CheckPressuredPlates()
    {
        for (int i = 0; i < pressurePlate.Length; i++)
        {
            if (pressurePlate[i].GetComponent<PressurePlate>().pressured)
            {
                pressured[i] = true;
            }
            else
            {
                pressured[i] = false;
            }
        }
    }
}
