using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MelterEnterTrigger : MonoBehaviour {
    [SerializeField]
    private int amountOfMeltedObjects;
    private TextMeshPro melterText;

    private void Start()
    {
        melterText = GameObject.Find("ObjectRegistererText").GetComponent<TextMeshPro>();
        amountOfMeltedObjects = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ConveyorBeltMetal"))
        {
            amountOfMeltedObjects += 1;
            melterText.text = amountOfMeltedObjects.ToString();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ConveyorBeltMetal"))
        {
            amountOfMeltedObjects -= 1;
            melterText.text = amountOfMeltedObjects.ToString();
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
