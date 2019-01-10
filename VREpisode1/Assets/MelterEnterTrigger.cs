using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelterEnterTrigger : MonoBehaviour {
    [SerializeField]
    private int amountOfMeltedObjects;

    private void Start()
    {
        amountOfMeltedObjects = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ConveyorBeltMetal"))
        {
            amountOfMeltedObjects += 1;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ConveyorBeltMetal"))
        {
            amountOfMeltedObjects -= 1;
        }
    }
    private void Update()
    {
        if (amountOfMeltedObjects >= 5)
        {
            //ready the melting button/lever
        }
    }
}
