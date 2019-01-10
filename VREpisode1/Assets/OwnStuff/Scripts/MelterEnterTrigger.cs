using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK.Controllables.PhysicsBased;

public class MelterEnterTrigger : MonoBehaviour {
    [SerializeField]
    private int amountOfMeltedObjects;
    private TextMeshPro melterText;
    private bool notMeltedYet;
    Animator PoolLid;
    GameObject MelterActivatorButton;
    GameObject MelterDeActivatorButton;

    private void Start()
    {
        notMeltedYet = true;
        MelterDeActivatorButton = GameObject.Find("MelterDeActivatorButton");
        MelterActivatorButton = GameObject.Find("MelterActivatorButton");
        PoolLid = GameObject.Find("PoolLidAnimated").GetComponent<Animator>();
        melterText = GameObject.Find("ObjectRegistererText").GetComponent<TextMeshPro>();
        amountOfMeltedObjects = 5;
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
        if (amountOfMeltedObjects >= 5 && MelterActivatorButton.GetComponent<VRTK_PhysicsPusher>().GetNormalizedValue() == 1f  && notMeltedYet)
        {
            notMeltedYet = false;
            PoolLid.SetBool("Melt", true);            
            StartCoroutine("WaitForAnimation");            
            //the press goes down
        }
        if (MelterDeActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed
            && MelterDeActivatorButton.GetComponent<VRTK_PhysicsPusher>().GetNormalizedValue() == 1f)
        {
            PoolLid.SetBool("Melt", false);
            //the press goes back up
        }
    }
    IEnumerator WaitForAnimation()
    {
        yield return new WaitForSecondsRealtime(10);  //animation takes 5 seconds, then add press sounds for 5 secs
        if (!MelterDeActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed)
        {
            Debug.Log("stayPressedMelter");
            MelterDeActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = true;
        }
    }
}
