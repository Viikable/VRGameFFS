using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorObjectDetector : MonoBehaviour
{

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
            if (transform.parent.parent.name == "InnerDoorToJanitorRoom" && !fuseBox.janitorToCorridorDoorClosed && !fuseBox.janitorToCorridorDoorOpening)
            {
                FuseboxFunctionality.janitorInnerDoorInterrupted = true;
            }
            if (transform.parent.parent.name == "OuterDoorToJanitorRoom" && !fuseBox.corridorToJanitorDoorClosed && !fuseBox.corridorToJanitorDoorOpening)
            {
                FuseboxFunctionality.janitorOuterDoorInterrupted = true;
            }
            if (transform.parent.parent.name == "OuterBonsaiRoomDoor" && !fuseBox.corridorToBonsaiDoorClosed && !fuseBox.corridorToBonsaiDoorOpening)
            {
                FuseboxFunctionality.janitorOuterDoorInterrupted = true;
            }
            if (transform.parent.parent.name == "InnerBonsaiRoomDoor" && !fuseBox.bonsaiToCorridorDoorClosed && !fuseBox.bonsaiToCorridorDoorOpening)
            {
                FuseboxFunctionality.bonsaiInnerDoorInterrupted = true;
            }
            if (transform.parent.parent.name == "MF_ToCorridorDoor" && !fuseBox.mfToCorridorDoorClosed && !fuseBox.mfToCorridorDoorOpening)  //opening checked elsewhere too
            {
                FuseboxFunctionality.mf_ToCorridorDoorInterrupted = true;
            }
            if (transform.parent.parent.name == "Corridor_ToMFDoor" && !fuseBox.corridorToMFDoorClosed && !fuseBox.corridorToMFDoorOpening)
            {
                FuseboxFunctionality.corridor_ToMFDoorInterrupted = true;
            }
            if (transform.parent.parent.name == "Bridge_DoorToMF" && !fuseBox.bridgeToMFDoorClosed && !fuseBox.bridgeToMFDoorOpening)
            {
                FuseboxFunctionality.bridge_ToMFDoorInterrupted = true;
            }
            if (transform.parent.parent.name == "MF_DoorToBridge" && !fuseBox.mfToBridgeDoorClosed && !fuseBox.mfToBridgeDoorOpening)
            {
                FuseboxFunctionality.mf_ToBridgeDoorInterrupted = true;
            }
            if (transform.parent.parent.name == "MF_DoorToMelter" && !fuseBox.mfToMelterDoorClosed && !fuseBox.mfToMelterDoorOpening)
            {
                FuseboxFunctionality.mf_ToMelterDoorInterrupted = true;
            }
            if (transform.parent.parent.name == "MelterDoorTo_MF" && !fuseBox.melterToMFDoorClosed && !fuseBox.melterToMFDoorOpening)
            {
                FuseboxFunctionality.melter_ToMFDoorInterrupted = true;
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (!collider.gameObject.CompareTag("Wall") && collider.gameObject.GetComponent<DoorObjectDetector>() == null && collider.gameObject.GetComponent<BackpackFunctionality>() == null)
        {
            if (transform.parent.parent.name == "InnerDoorToJanitorRoom" && !fuseBox.janitorToCorridorDoorClosed && !fuseBox.janitorToCorridorDoorOpening)
            {
                FuseboxFunctionality.janitorInnerDoorInterrupted = false;
            }
            if (transform.parent.parent.name == "OuterDoorToJanitorRoom" && !fuseBox.corridorToJanitorDoorClosed && !fuseBox.corridorToJanitorDoorOpening)
            {
                FuseboxFunctionality.janitorOuterDoorInterrupted = false;
            }
            if (transform.parent.parent.name == "OuterBonsaiRoomDoor" && !fuseBox.corridorToBonsaiDoorClosed && !fuseBox.corridorToBonsaiDoorOpening)
            {
                FuseboxFunctionality.bonsaiOuterDoorInterrupted = false;
            }
            if (transform.parent.parent.name == "InnerBonsaiRoomDoor" && !fuseBox.bonsaiToCorridorDoorClosed && !fuseBox.bonsaiToCorridorDoorOpening)
            {
                FuseboxFunctionality.bonsaiInnerDoorInterrupted = false;
            }
            if (transform.parent.parent.name == "MF_ToCorridorDoor" && !fuseBox.mfToCorridorDoorClosed && !fuseBox.mfToCorridorDoorOpening)
            {
                FuseboxFunctionality.mf_ToCorridorDoorInterrupted = true;
            }
            if (transform.parent.parent.name == "Corridor_ToMFDoor" && !fuseBox.corridorToMFDoorClosed && !fuseBox.corridorToMFDoorOpening)
            {
                FuseboxFunctionality.corridor_ToMFDoorInterrupted = true;
            }
            if (transform.parent.parent.name == "Bridge_DoorToMF" && !fuseBox.bridgeToMFDoorClosed && !fuseBox.bridgeToMFDoorOpening)
            {
                FuseboxFunctionality.bridge_ToMFDoorInterrupted = true;
            }
            if (transform.parent.parent.name == "MF_DoorToBridge" && !fuseBox.mfToBridgeDoorClosed && !fuseBox.mfToBridgeDoorOpening)
            {
                FuseboxFunctionality.mf_ToBridgeDoorInterrupted = true;
            }
            if (transform.parent.parent.name == "MF_DoorToMelter" && !fuseBox.mfToMelterDoorClosed && !fuseBox.mfToMelterDoorOpening)
            {
                FuseboxFunctionality.mf_ToMelterDoorInterrupted = true;
            }
            if (transform.parent.parent.name == "MelterDoorTo_MF" && !fuseBox.melterToMFDoorClosed && !fuseBox.melterToMFDoorOpening)
            {
                FuseboxFunctionality.melter_ToMFDoorInterrupted = true;
            }
        }
    }
}
