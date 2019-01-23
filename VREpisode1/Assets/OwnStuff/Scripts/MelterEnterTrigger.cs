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

    [SerializeField]
    [Tooltip("can we lift the lid now?")]
    private bool liftable;

    bool check;

    Animator PoolLid;

    Animator LavaAnim;

    [SerializeField]
    [Tooltip("Shuts the melter lid")]
    GameObject MelterMeltPressActivatorButton;
    [SerializeField]
    [Tooltip("Lifts the melter lid")]
    GameObject MelterPresserDeActivatorButton;
    [SerializeField]
    [Tooltip("Starts the metal inside the melter scaling down")]
    GameObject MelterPressPressActivatorButton;

    GameObject PressedMetal1;
    GameObject PressedMetal2;
    GameObject PressedMetal3;
    GameObject PressedMetal4;
    GameObject PressedMetal5;
    GameObject PressedMetal6;

    Transform PressedMetalTrans1;
    Transform PressedMetalTrans2;
    Transform PressedMetalTrans3;
    Transform PressedMetalTrans4;
    Transform PressedMetalTrans5;
    Transform PressedMetalTrans6;

    int index1;
    int index2;         //to find transforms from the list
    int index3;
    int index4;
    int index5;
    int index6;

    List<Transform> metalTransforms = new List<Transform>();
    
    private void Start()
    {
        PressedMetal1 = GameObject.Find("PressedMetal1");
        PressedMetal2 = GameObject.Find("PressedMetal2");
        PressedMetal3 = GameObject.Find("PressedMetal3");
        PressedMetal4 = GameObject.Find("PressedMetal4");
        PressedMetal5 = GameObject.Find("PressedMetal5");
        PressedMetal6 = GameObject.Find("PressedMetal6");
        PressedMetalTrans1 = PressedMetal1.transform;             //so we can easily reset the picked up compressed boxes back into the correct positions when remelting
        PressedMetalTrans2 = PressedMetal2.transform;
        PressedMetalTrans3 = PressedMetal3.transform;
        PressedMetalTrans4 = PressedMetal4.transform;
        PressedMetalTrans5 = PressedMetal5.transform;
        PressedMetalTrans6 = PressedMetal6.transform;
        metalTransforms.Add(PressedMetalTrans1);
        metalTransforms.Add(PressedMetalTrans2);
        metalTransforms.Add(PressedMetalTrans3);
        metalTransforms.Add(PressedMetalTrans4);
        metalTransforms.Add(PressedMetalTrans5);
        metalTransforms.Add(PressedMetalTrans6);
        index1 = metalTransforms.IndexOf(PressedMetalTrans1);
        index2 = metalTransforms.IndexOf(PressedMetalTrans2);
        index3 = metalTransforms.IndexOf(PressedMetalTrans3);
        index4 = metalTransforms.IndexOf(PressedMetalTrans4);
        index5 = metalTransforms.IndexOf(PressedMetalTrans5);
        index6 = metalTransforms.IndexOf(PressedMetalTrans6);
        notMeltedYet = true;
        liftable = false;
        MelterPresserDeActivatorButton = GameObject.Find("MelterPresserDeActivatorContainer/MelterPresserDeActivatorButton");
        MelterMeltPressActivatorButton = GameObject.Find("MelterMeltPressActivatorContainer/MelterMeltPressActivatorButton");
        MelterPressPressActivatorButton = GameObject.Find("MelterPressPressActivatorContainer/MelterPressPressActivatorButton");
        PoolLid = GameObject.Find("PoolLidAnimated").GetComponent<Animator>();
        LavaAnim = GameObject.Find("LavaSurface").GetComponent<Animator>();
        melterText = GameObject.Find("ObjectRegistererText").GetComponent<TextMeshPro>();
        amountOfMeltedObjects = 6;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ConveyorBeltMetal"))
        {
            amountOfMeltedObjects += 1;
            melterText.text = amountOfMeltedObjects.ToString();
            other.GetComponent<MetalHitsTheFan>().InsideTheMelter = true;
            if (amountOfMeltedObjects == 6 && !MetalHitsTheFan.melterIsReady)
            {
                melterText.color = Color.green;
            }
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
        //metal compression
        if (amountOfMeltedObjects == 6 && MelterPressPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().AtMaxLimit() == true
            && MelterPressPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed && !notMeltedYet)
        {
            //causes the press to go down after melting to compress metal
            Debug.Log("press with 6");
            PoolLid.SetBool("Press", true);
            PoolLid.SetBool("Melt", true);
            PoolLid.speed = 1f;
            //MelterPresserDeActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
            notMeltedYet = true;
            StartCoroutine("WaitForPressing");
        }
        else if (amountOfMeltedObjects <= 5 && amountOfMeltedObjects >=1 && MelterPressPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().AtMaxLimit() == true
            && MelterPressPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed && !notMeltedYet && MetalHitsTheFan.melterIsReady)
        {
            PoolLid.SetBool("Press", true);
            PoolLid.SetBool("Melt", true);
            //MelterPresserDeActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
            notMeltedYet = true;

            StartCoroutine("WaitForPressing");
        }
       
        else if (amountOfMeltedObjects == 0 && MelterPressPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().AtMaxLimit() == true
            && MelterPressPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed && !notMeltedYet && MetalHitsTheFan.melterIsReady)
        {
            MelterPressPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
            StartCoroutine("WaitForPressing");      //should just bounce the button back up doing nothing
            //add a sound need at least one metal object to melt here
        }

        //MELTING CASES
        if (amountOfMeltedObjects >= 6 && MelterMeltPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().AtMaxLimit() == true
            && notMeltedYet && MelterMeltPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed)
        {
            Debug.Log("melt with 6");
            notMeltedYet = false;
            MetalHitsTheFan.melterIsReady = true;   //melter is ready
            LavaAnim.SetBool("Rise", true);
            //MelterPresserDeActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
            LavaAnim.speed = 1f;
            
            PoolLid.SetBool("Melt", true);            //causes press to go down to melt metal into lava
            PoolLid.SetBool("Press", true);
            StartCoroutine("WaitForMelting");
        }
        if (amountOfMeltedObjects == 5 && MelterMeltPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().AtMaxLimit() == true
            && notMeltedYet && MelterMeltPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed)
        {
            notMeltedYet = false;
            //MelterPresserDeActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
            LavaAnim.SetBool("Rise", true);
            LavaAnim.speed = 1f;
            PoolLid.SetBool("Melt", true);            //causes press to go down to melt metal into lava
            PoolLid.SetBool("Press", true);
            StartCoroutine("AdjustLavaHeight", 8.34f);
            StartCoroutine("WaitForMelting");
        }
        if (amountOfMeltedObjects == 4 && MelterMeltPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().AtMaxLimit() == true
           && notMeltedYet && MelterMeltPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed)
        {
            notMeltedYet = false;
            //MelterPresserDeActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
            LavaAnim.SetBool("Rise", true);
            LavaAnim.speed = 1f;
            PoolLid.SetBool("Melt", true);            //causes press to go down to melt metal into lava
            PoolLid.SetBool("Press", true);
            StartCoroutine("AdjustLavaHeight", 6.68f);
            StartCoroutine("WaitForMelting");
        }
        if (amountOfMeltedObjects == 3 && MelterMeltPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().AtMaxLimit() == true
           && notMeltedYet && MelterMeltPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed)
        {
            notMeltedYet = false;
            //MelterPresserDeActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
            LavaAnim.SetBool("Rise", true);
            LavaAnim.speed = 1f;
            PoolLid.SetBool("Melt", true);            //causes press to go down to melt metal into lava
            PoolLid.SetBool("Press", true);
            StartCoroutine("AdjustLavaHeight", 5.02f);
            StartCoroutine("WaitForMelting");
        }

        if (amountOfMeltedObjects == 2 && MelterMeltPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().AtMaxLimit() == true
            && notMeltedYet && MelterMeltPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed)
        {
            notMeltedYet = false;
            //MelterPresserDeActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
            LavaAnim.SetBool("Rise", true);
            LavaAnim.speed = 1f;
            PoolLid.SetBool("Melt", true);            //causes press to go down to melt metal into lava
            PoolLid.SetBool("Press", true);
            StartCoroutine("AdjustLavaHeight", 3.36f);
            StartCoroutine("WaitForMelting");
        }
        if (amountOfMeltedObjects == 1 && MelterMeltPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().AtMaxLimit() == true
            && notMeltedYet && MelterMeltPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed)
        {
            notMeltedYet = false;
            //MelterPresserDeActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
            LavaAnim.SetBool("Rise", true);
            LavaAnim.speed = 1f;
            PoolLid.SetBool("Melt", true);            //causes press to go down to melt metal into lava
            PoolLid.SetBool("Press", true);
            StartCoroutine("AdjustLavaHeight", 1.7f);
            StartCoroutine("WaitForMelting");
        }
        if (amountOfMeltedObjects == 0 && MelterMeltPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().AtMaxLimit() == true
            && notMeltedYet && MelterMeltPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed)
        {
            MelterMeltPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
            StartCoroutine("WaitForMelting");
        }
        //What happens when the melterlifterbutton is pressed
        if (MelterPresserDeActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed
            && MelterPresserDeActivatorButton.GetComponent<VRTK_PhysicsPusher>().AtMaxLimit() == true && liftable)
        {
            Debug.Log("melter lifted");
            PoolLid.SetBool("Melt", false);
            PoolLid.SetBool("Press", false);
            //MelterPresserDeActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
            liftable = false;
            if (!notMeltedYet)
            {
                MelterPressPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = true;
            }
            else
            {
                MelterMeltPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = true;
            }
            check = true;
            //the press goes back up
        }
        //if (MelterPresserDeActivatorButton.GetComponent<VRTK_PhysicsPusher>().AtMaxLimit() == true &&
        //    MelterPresserDeActivatorButton.GetComponent<VRTK_PhysicsPusher>().AtMinLimit() == true && check)
        //{
        //    MelterPresserDeActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
        //    check = false;
        //}
    }
    IEnumerator WaitForMelting()     //waits for the lid to come down and melting to happen under
    {
        if (amountOfMeltedObjects != 0)  //sets it instaback if is 0
        {
            MelterPresserDeActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
            Debug.Log("deactivator false");
            yield return new WaitForSecondsRealtime(10);  //animation takes 5 seconds, then add press sounds for 5 secs           
            MelterPresserDeActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = true;
            Debug.Log("stayPressedMelter");
            MelterMeltPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
            liftable = true;
            int amount = 1;
            foreach (GameObject metalPart in GameObject.FindGameObjectsWithTag("ConveyorBeltMetal"))
            {
                if (metalPart.GetComponent<MetalHitsTheFan>().InsideTheMelter && amount == 1)
                {
                    metalPart.GetComponent<Rigidbody>().isKinematic = true;
                    metalPart.GetComponent<Rigidbody>().useGravity = false;
                    metalPart.GetComponent<Collider>().enabled = false;
                    metalPart.GetComponent<MeshRenderer>().enabled = false;
                    metalPart.transform.rotation = metalTransforms[index1].rotation;
                    metalPart.transform.position = metalTransforms[index1].position;
                    Debug.Log("firstoff");
                }
                if (metalPart.GetComponent<MetalHitsTheFan>().InsideTheMelter && amount == 2)
                {
                    metalPart.GetComponent<Rigidbody>().isKinematic = true;
                    metalPart.GetComponent<Rigidbody>().useGravity = false;
                    metalPart.GetComponent<Collider>().enabled = false;
                    metalPart.GetComponent<MeshRenderer>().enabled = false;
                    metalPart.transform.rotation = metalTransforms[index2].rotation;
                    metalPart.transform.position = metalTransforms[index2].position;
                }
                if (metalPart.GetComponent<MetalHitsTheFan>().InsideTheMelter && amount == 3)
                {
                    metalPart.GetComponent<Rigidbody>().isKinematic = true;
                    metalPart.GetComponent<Rigidbody>().useGravity = false;
                    metalPart.GetComponent<Collider>().enabled = false;
                    metalPart.GetComponent<MeshRenderer>().enabled = false;
                    metalPart.transform.rotation = metalTransforms[index3].rotation;
                    metalPart.transform.position = metalTransforms[index3].position;
                }
                if (metalPart.GetComponent<MetalHitsTheFan>().InsideTheMelter && amount == 4)
                {
                    metalPart.GetComponent<Rigidbody>().isKinematic = true;
                    metalPart.GetComponent<Rigidbody>().useGravity = false;
                    metalPart.GetComponent<Collider>().enabled = false;
                    metalPart.GetComponent<MeshRenderer>().enabled = false;
                    metalPart.transform.rotation = metalTransforms[index4].rotation;
                    metalPart.transform.position = metalTransforms[index4].position;
                }
                if (metalPart.GetComponent<MetalHitsTheFan>().InsideTheMelter && amount == 5)
                {
                    metalPart.GetComponent<Rigidbody>().isKinematic = true;
                    metalPart.GetComponent<Rigidbody>().useGravity = false;
                    metalPart.GetComponent<Collider>().enabled = false;
                    metalPart.GetComponent<MeshRenderer>().enabled = false;
                    metalPart.transform.rotation = metalTransforms[index5].rotation;
                    metalPart.transform.position = metalTransforms[index5].position;
                }
                if (metalPart.GetComponent<MetalHitsTheFan>().InsideTheMelter && amount == 6)
                {
                    metalPart.GetComponent<Rigidbody>().isKinematic = true;
                    metalPart.GetComponent<Rigidbody>().useGravity = false;
                    metalPart.GetComponent<Collider>().enabled = false;
                    metalPart.GetComponent<MeshRenderer>().enabled = false;
                    metalPart.transform.rotation = metalTransforms[index6].rotation;
                    metalPart.transform.position = metalTransforms[index6].position;
                }
                amount++;
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
        {
            MelterPresserDeActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;
            Debug.Log("deactivator false");
            yield return new WaitForSecondsRealtime(10);
            MelterPresserDeActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = true;  //so that we can press the melting button again
            MelterPressPressActivatorButton.GetComponent<VRTK_PhysicsPusher>().stayPressed = false;           
            Debug.Log("ReadyToReMelt");
            liftable = true;
            LavaAnim.SetBool("Rise", false);
            int amount = 1;     //this helps with the iteration of the objects

            foreach (GameObject metalPart in GameObject.FindGameObjectsWithTag("ConveyorBeltMetal"))
            {
                if (metalPart.GetComponent<MetalHitsTheFan>().InsideTheMelter && amount == 1)
                {
                    metalPart.GetComponent<Rigidbody>().isKinematic = true;
                    metalPart.GetComponent<Rigidbody>().useGravity = false;
                    metalPart.GetComponent<Collider>().enabled = true;
                    metalPart.transform.rotation = metalTransforms[index1].rotation;
                    metalPart.transform.position = metalTransforms[index1].position;
                    metalPart.GetComponent<MeshRenderer>().enabled = true;
                    Debug.Log("first");
                    amountOfMeltedObjects -= 1;
                }
                if (metalPart.GetComponent<MetalHitsTheFan>().InsideTheMelter && amount == 2)
                {
                    metalPart.GetComponent<Rigidbody>().useGravity = false;
                    metalPart.GetComponent<Rigidbody>().isKinematic = true;
                    metalPart.GetComponent<Collider>().enabled = true;
                    metalPart.transform.rotation = metalTransforms[index2].rotation;
                    metalPart.transform.position = metalTransforms[index2].position;
                    metalPart.GetComponent<MeshRenderer>().enabled = true;
                    Debug.Log("second");
                    amountOfMeltedObjects -= 1;
                }
                if (metalPart.GetComponent<MetalHitsTheFan>().InsideTheMelter && amount == 3)
                {
                    metalPart.GetComponent<Rigidbody>().useGravity = false;
                    metalPart.GetComponent<Rigidbody>().isKinematic = true;
                    metalPart.GetComponent<Collider>().enabled = true;
                    metalPart.transform.rotation = metalTransforms[index3].rotation;
                    metalPart.transform.position = metalTransforms[index3].position;
                    metalPart.GetComponent<MeshRenderer>().enabled = true;
                    Debug.Log("third");
                    amountOfMeltedObjects -= 1;
                }
                if (metalPart.GetComponent<MetalHitsTheFan>().InsideTheMelter && amount == 4)
                {
                    metalPart.GetComponent<Rigidbody>().isKinematic = true;
                    metalPart.GetComponent<Rigidbody>().useGravity = false;
                    metalPart.GetComponent<Collider>().enabled = true;
                    metalPart.transform.rotation = metalTransforms[index4].rotation;
                    metalPart.transform.position = metalTransforms[index4].position;
                    metalPart.GetComponent<MeshRenderer>().enabled = true;
                    Debug.Log("fourth");
                    amountOfMeltedObjects -= 1;
                }
                if (metalPart.GetComponent<MetalHitsTheFan>().InsideTheMelter && amount == 5)
                {
                    metalPart.GetComponent<Rigidbody>().useGravity = false;
                    metalPart.GetComponent<Rigidbody>().isKinematic = true;
                    metalPart.GetComponent<Collider>().enabled = true;
                    metalPart.transform.rotation = metalTransforms[index5].rotation;
                    metalPart.transform.position = metalTransforms[index5].position;
                    metalPart.GetComponent<MeshRenderer>().enabled = true;
                    Debug.Log("fifth");
                    amountOfMeltedObjects -= 1;
                }
                if (metalPart.GetComponent<MetalHitsTheFan>().InsideTheMelter && amount == 6)
                {
                    metalPart.GetComponent<Rigidbody>().isKinematic = true;
                    metalPart.GetComponent<Rigidbody>().useGravity = false;
                    metalPart.GetComponent<Collider>().enabled = true;
                    metalPart.transform.rotation = metalTransforms[index6].rotation;
                    metalPart.transform.position = metalTransforms[index6].position;
                    metalPart.GetComponent<MeshRenderer>().enabled = true;
                    Debug.Log("sixth");
                    amountOfMeltedObjects -= 1;
                }
                amount++;
            }
            foreach (GameObject metalPart in GameObject.FindGameObjectsWithTag("ConveyorBeltMetal"))
            {
                if (metalPart.GetComponent<MetalHitsTheFan>().InsideTheMelter)
                {
                    Debug.Log("nonkinematic");
                    metalPart.GetComponent<Rigidbody>().isKinematic = false;
                }
            }
            foreach (GameObject metalPart in GameObject.FindGameObjectsWithTag("ConveyorBeltMetal"))
            {
                if (metalPart.GetComponent<MetalHitsTheFan>().InsideTheMelter)
                {
                    Debug.Log("gravital");
                    metalPart.GetComponent<Rigidbody>().useGravity = true;
                }
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
        LavaAnim.speed = 0f;
    }
 }

