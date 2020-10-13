using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorObjectDetector : MonoBehaviour {

    public FuseboxFunctionality fuseBox;

    private bool janInInt;
    private bool janOutInt;
    private bool bonsInInt;
    private bool bonsOutInt;
    private bool mfToCInt;
    private bool cToMFInt;
    private bool mfToMeltInt;
    private bool meltToMFInt;
    private bool mfToBriInt;
    private bool briToMFInt;

    private void Start()
    {      
        fuseBox = GameObject.Find("FuseBoxFunctionality").GetComponent<FuseboxFunctionality>();
        
        janInInt = false;
        janOutInt = false;
        bonsInInt = false;
        bonsOutInt = false;
        mfToCInt = false;
        cToMFInt = false;
        mfToMeltInt = false;
        meltToMFInt = false;
        mfToBriInt = false;
        briToMFInt = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.gameObject.CompareTag("Wall") && collider.gameObject.GetComponent<DoorObjectDetector>() == null && collider.gameObject.GetComponent<BackpackFunctionality>() == null)
        {
            if (transform.parent.parent.name == "InnerDoorToJanitorRoom" && !fuseBox.janitorToCorridorDoorClosed)
            {
                janInInt = true;
            }
            if (transform.parent.parent.name == "OuterDoorToJanitorRoom" && !fuseBox.corridorToJanitorDoorClosed)
            {
                janOutInt = true;
            }
            if (transform.parent.parent.name == "MF_ToCorridorDoor" && !fuseBox.mfToCorridorDoorClosed && !fuseBox.mfToCorridorDoorOpening)  //opening checked elsewhere too
            {
                mfToCInt = true;
                Debug.Log("detected");
            }
            if (transform.parent.parent.name == "Corridor_ToMFDoor" && !fuseBox.corridorToMFDoorClosed && !fuseBox.corridorToMFDoorOpening)
            {
                cToMFInt = true;
                Debug.Log("detected1");
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (!collider.gameObject.CompareTag("Wall") && collider.gameObject.GetComponent<DoorObjectDetector>() == null && collider.gameObject.GetComponent<BackpackFunctionality>() == null)
        {
            if (transform.parent.parent.name == "InnerDoorToJanitorRoom")
            {
                janInInt = false;
            }
            if (transform.parent.parent.name == "OuterDoorToJanitorRoom")
            {
                janOutInt = false;
            }
            if (transform.parent.parent.name == "MF_ToCorridorDoor")
            {
                mfToCInt = false;
                Debug.Log("detectedout");
            }
            if (transform.parent.parent.name == "Corridor_ToMFDoor")
            {
                cToMFInt = false;
                Debug.Log("detectedout1");
            }
        }
    }

    // Update is called once per frame
    void Update ()
    {
        CheckCollisions();
	}


    private void CheckCollisions()
    {

        if (janInInt)
        {
            FuseboxFunctionality.janitorInnerDoorInterrupted = true;
        }
        else
        {
            FuseboxFunctionality.janitorInnerDoorInterrupted = false;
        }
        if (janOutInt)
        {
            FuseboxFunctionality.janitorOuterDoorInterrupted = true;
        }
        else
        {
            FuseboxFunctionality.janitorOuterDoorInterrupted = false;
        }
        if (bonsInInt)
        {
            FuseboxFunctionality.bonsaiInnerDoorInterrupted = true;
        }
        else
        {
            FuseboxFunctionality.bonsaiInnerDoorInterrupted = false;
        }
        if (bonsOutInt)
        {
            FuseboxFunctionality.bonsaiOuterDoorInterrupted = true;
        }
        else
        {
            FuseboxFunctionality.bonsaiOuterDoorInterrupted = false;
        }
        if (mfToCInt)
        {
            FuseboxFunctionality.mf_ToCorridorDoorInterrupted = true;
        }
        else
        {
            FuseboxFunctionality.mf_ToCorridorDoorInterrupted = false;
        }
        if (cToMFInt)
        {
            FuseboxFunctionality.corridor_ToMFDoorInterrupted = true;
        }
        else
        {
            FuseboxFunctionality.corridor_ToMFDoorInterrupted = false;
        }
        if (mfToMeltInt)
        {
            FuseboxFunctionality.mf_ToMelterDoorInterrupted = true;
        }
        else
        {
            FuseboxFunctionality.mf_ToMelterDoorInterrupted = false;
        }
        if (meltToMFInt)
        {
            FuseboxFunctionality.melter_ToMFDoorInterrupted = true;
        }
        else
        {
            FuseboxFunctionality.melter_ToMFDoorInterrupted = false;
        }
        if (mfToBriInt)
        {
            FuseboxFunctionality.mf_ToBridgeDoorInterrupted = true;
        }
        else
        {
            FuseboxFunctionality.mf_ToBridgeDoorInterrupted = false;
        }
        if (briToMFInt)
        {
            FuseboxFunctionality.bridge_ToMFDoorInterrupted = true;
        }
        else
        {
            FuseboxFunctionality.bridge_ToMFDoorInterrupted = false;
        }
    }
}
