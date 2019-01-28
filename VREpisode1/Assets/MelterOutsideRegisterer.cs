using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelterOutsideRegisterer : MonoBehaviour {
    int x;

    private void Start()
    {
        x = 0;
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
            MetalHitsTheFan.notCompletelyInsideMelter = false;
        }
        else
        {
            MetalHitsTheFan.notCompletelyInsideMelter = true;
        }
    }
}
