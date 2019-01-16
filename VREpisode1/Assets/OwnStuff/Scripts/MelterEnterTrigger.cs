using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK.Controllables.PhysicsBased;

public class MelterEnterTrigger : MonoBehaviour {
    [SerializeField]
    [Tooltip("The amount of metal objects currently inside the melter")]
    private int amountOfMeltedObjects;

    [Tooltip("Displays the amount of melted objects on the screen")]
    private TextMeshPro melterText;

    [SerializeField]
    [Tooltip("Has the lid gone down yet?")]
    private bool notMeltedYet;

    Animator PoolLid;

    [SerializeField]
    [Tooltip("Shuts the melter lid")]
    GameObject MelterPresserActivatorButton;
    [SerializeField]
    [Tooltip("Lifts the melter lid")]
    GameObject MelterPresserDeActivatorButton;
    [SerializeField]
    [Tooltip("Starts the metal inside the melter scaling down")]
    GameObject MelterActivatorButton;     

    private void Start()
    {
        notMeltedYet = true;
        MelterPresserDeActivatorButton = GameObject.Find("MelterPresserDeActivatorButton");
        MelterPresserActivatorButton = GameObject.Find("MelterPresserActivatorButton");
        MelterActivatorButton = GameObject.Find("MelterActivatorButton");
        PoolLid = GameObject.Find("PoolLidAnimated").GetComponent<Animator>();
        melterText = GameObject.Find("ObjectRegistererText").GetComponent<TextMeshPro>();
        amountOfMeltedObjects = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ConveyorBeltMetal"))
        {
            amountOfMeltedObjects += 1;
            melterText.text = amountOfMeltedObjects.ToString();
            other.GetComponent<MetalHitsTheFan>().InsideTheMelter = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ConveyorBeltMetal"))
        {
            amountOfMeltedObjects -= 1;
            melterText.text = amountOfMeltedObjects.ToString();
            other.GetComponent<MetalHitsTheFan>().InsideTheMelter = false;
        }
    }
    private void Update()
    {
        if (amountOfMeltedObjects >= 5 && MelterActivatorButton.GetComponent<VRTK_PhysicsPusher>().GetNormalizedValue() == 1f)
        {
            MetalHitsTheFan.melterIsReady = true;
        }
        if (amountOfMeltedObjects >= 5 && MelterPresserActivatorButton.GetComponent<VRTK_PhysicsPusher>().GetNormalizedValue() == 1f  && notMeltedYet)
        {            
            notMeltedYet = false;
            PoolLid.SetBool("Melt", true);            
            StartCoroutine("WaitForAnimation");            
            //the press goes down
        }
        if (MelterPresserDeActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed
            && MelterPresserDeActivatorButton.GetComponent<VRTK_PhysicsPusher>().GetNormalizedValue() == 1f)
        {
            PoolLid.SetBool("Melt", false);
            //the press goes back up
        }
    }
    IEnumerator WaitForAnimation()
    {
        yield return new WaitForSecondsRealtime(10);  //animation takes 5 seconds, then add press sounds for 5 secs
        if (!MelterPresserDeActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed)
        {
            Debug.Log("stayPressedMelter");
            MelterPresserDeActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = true;
        }
    }
}
