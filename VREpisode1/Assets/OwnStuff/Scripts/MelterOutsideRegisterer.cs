using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelterOutsideRegisterer : MonoBehaviour {
    int x;
    public bool notCompletelyInsideMelter;

    private void Start()
    {
        x = 0;
        notCompletelyInsideMelter = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ConveyorBeltMetal"))
        {
            x += 1;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ConveyorBeltMetal"))
        {
            x -= 1;
        }
    }
    private void Update()
    {
        if (x == 0)
        {
           notCompletelyInsideMelter = false;
        }
        else
        {
            notCompletelyInsideMelter = true;
        }
    }
}
