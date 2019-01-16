using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK.Controllables.PhysicsBased;

public class MelterEnterTrigger : MonoBehaviour
{
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
    GameObject MelterMeltPressActivatorButton;
    [SerializeField]
    [Tooltip("Lifts the melter lid")]
    GameObject MelterPresserDeActivatorButton;
    [SerializeField]
    [Tooltip("Starts the metal inside the melter scaling down")]
    GameObject MelterPressPressActivatorButton;

    private void Start()
    {
        notMeltedYet = true;
        MelterPresserDeActivatorButton = GameObject.Find("MelterPresserDeActivatorButton");
        MelterMeltPressActivatorButton = GameObject.Find("MelterMeltPressActivatorButton");
        MelterPressPressActivatorButton = GameObject.Find("MelterPressPressActivatorButton");
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
    private void Update()    //if certain amount of objects, the amount of lava (height of the animation) changes
    {
        
        if (amountOfMeltedObjects >= 4 && MelterPressPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().GetNormalizedValue() == 1f
            && MelterPressPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed && !notMeltedYet)
        {
            MetalHitsTheFan.melterIsReady = true;      //causes the press to go down after melting to compress metal
            PoolLid.SetBool("Press", true);
            PoolLid.SetBool("Melt", true);
            PoolLid.speed = 1f;
            MelterMeltPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
            notMeltedYet = true;
            StartCoroutine("WaitForPressing");
        }
        //SPECIAL CASES FOR LESS THAN 4 METAL OBJECTS INSIDE THE MELTER WHEN PRESSING
        else if (amountOfMeltedObjects == 3 && MelterPressPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().GetNormalizedValue() == 1f
            && MelterPressPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed && !notMeltedYet && MetalHitsTheFan.melterIsReady)
        {
            PoolLid.SetBool("Press", true);
            PoolLid.SetBool("Melt", true);
            MelterMeltPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
            notMeltedYet = true;
            
            StartCoroutine("WaitForPressing");
        }
        else if (amountOfMeltedObjects == 2 && MelterPressPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().GetNormalizedValue() == 1f
            && MelterPressPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed && !notMeltedYet && MetalHitsTheFan.melterIsReady)
        {
            PoolLid.SetBool("Press", true);
            PoolLid.SetBool("Melt", true);
            MelterMeltPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
            notMeltedYet = true;
            
            StartCoroutine("WaitForPressing");
        }
        else if (amountOfMeltedObjects == 1 && MelterPressPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().GetNormalizedValue() == 1f
            && MelterPressPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed && !notMeltedYet && MetalHitsTheFan.melterIsReady)
        {
            PoolLid.SetBool("Press", true);
            PoolLid.SetBool("Melt", true);
            MelterMeltPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
            notMeltedYet = true;
            
            StartCoroutine("WaitForPressing");
        }
        else if (amountOfMeltedObjects == 0 && MelterPressPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().GetNormalizedValue() == 1f
            && MelterPressPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed && !notMeltedYet && MetalHitsTheFan.melterIsReady)
        {
            MelterPressPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
            StartCoroutine("WaitForPressing");      //should just bounce the button back up doing nothing
            //add a sound need at least one metal object to melt here
        }

        //MELTING CASES
        if (amountOfMeltedObjects >= 4 && MelterMeltPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().GetNormalizedValue() == 1f
            && notMeltedYet && MelterMeltPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed)
        {
            notMeltedYet = false;
            PoolLid.speed = 1f;
            if (PoolLid.GetBool("Melt") == false)
            {
                PoolLid.SetBool("Melt", true);            //causes press to go down to melt metal into lava
            }
            else
            {
                PoolLid.SetBool("Melt", false);
            }
            StartCoroutine("WaitForMelting");
        }
        if (amountOfMeltedObjects == 3 && MelterMeltPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().GetNormalizedValue() == 1f
            && notMeltedYet && MelterMeltPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed)
        {
            notMeltedYet = false;
            PoolLid.speed = 1f;
            if (PoolLid.GetBool("Melt") == false)
            {
                PoolLid.SetBool("Melt", true);            //causes press to go down to melt metal into lava
            }
            else
            {
                PoolLid.SetBool("Melt", false);
            }
            StartCoroutine("AdjustLavaHeight", 7.5f);
            StartCoroutine("WaitForMelting");
        }
        if (amountOfMeltedObjects == 2 && MelterMeltPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().GetNormalizedValue() == 1f
            && notMeltedYet && MelterMeltPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed)
        {
            notMeltedYet = false;
            PoolLid.speed = 1f;
            if (PoolLid.GetBool("Melt") == false)
            {
                PoolLid.SetBool("Melt", true);            //causes press to go down to melt metal into lava
            }
            else
            {
                PoolLid.SetBool("Melt", false);
            }
            StartCoroutine("AdjustLavaHeight", 5.0f);
            StartCoroutine("WaitForMelting");
        }
        if (amountOfMeltedObjects == 1 && MelterMeltPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().GetNormalizedValue() == 1f
            && notMeltedYet && MelterMeltPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed)
        {
            notMeltedYet = false;
            PoolLid.speed = 1f;
            if (PoolLid.GetBool("Melt") == false)
            {
                PoolLid.SetBool("Melt", true);            //causes press to go down to melt metal into lava
            }
            else
            {
                PoolLid.SetBool("Melt", false);
            }
            StartCoroutine("AdjustLavaHeight", 2.5f);
            StartCoroutine("WaitForMelting");
        }
        if (amountOfMeltedObjects == 0 && MelterMeltPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().GetNormalizedValue() == 1f
            && notMeltedYet && MelterMeltPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed)
        {
            
            StartCoroutine("WaitForMelting");
        }





        if (MelterPresserDeActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed
            && MelterPresserDeActivatorButton.GetComponent<VRTK_PhysicsPusher>().GetNormalizedValue() == 1f)
        {
            PoolLid.SetBool("Melt", false);
            PoolLid.speed = 1f;
            MelterPresserDeActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
            //the press goes back up
        }



    }
    IEnumerator WaitForMelting()     //waits for the lid to come down and melting to happen under
    {
        if (amountOfMeltedObjects != 0)  //sets it instaback if is 0
        {
            yield return new WaitForSecondsRealtime(10);  //animation takes 5 seconds, then add press sounds for 5 secs
            if (!MelterPresserDeActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed)
            {
                Debug.Log("stayPressedMelter");
                MelterPresserDeActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = true;
            }
        }
        else
        {
            yield return new WaitForSecondsRealtime(1);
            MelterMeltPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = true;
        }
    }
    IEnumerator WaitForPressing()    //waits for lid to come and compress lava
    {
        if (amountOfMeltedObjects != 0)  //sets it instaback if is 0
        {                                                   //so that we can press the melting button again
            yield return new WaitForSecondsRealtime(10);
            if (MelterPressPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed)
            {
                MelterPressPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
                Debug.Log("ReadyToReMelt");

            }
        }
        else
        {
            yield return new WaitForSecondsRealtime(1);    //this is so that when no metal in melter the button bounces back
            MelterPressPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = true;
        }
    }

    IEnumerator AdjustLavaHeight(float animationTime)     //this stops the animation at a certain height
    {
        yield return new WaitForSecondsRealtime(animationTime);
        PoolLid.speed = 0f;
    }
 }

