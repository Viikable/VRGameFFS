using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorObjectDetector : MonoBehaviour
{

    public FuseboxFunctionality fuseBox;
  
    private void Start()
    {
        fuseBox = GameObject.Find("FuseBoxFunctionality").GetComponent<FuseboxFunctionality>();      
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.gameObject.CompareTag("Wall") && collider.gameObject.GetComponent<DoorObjectDetector>() == null && collider.gameObject.GetComponent<BackpackFunctionality>() == null)
        {
            if (transform.parent.parent.gameObject == fuseBox.JanitorDoorInnerAnim.gameObject && !fuseBox.janitorToCorridorDoorClosed && !fuseBox.janitorToCorridorDoorOpening)
            {
                FuseboxFunctionality.janitorInnerDoorInterrupted = true;
            }
            if (transform.parent.parent.gameObject == fuseBox.JanitorDoorOuterAnim.gameObject && !fuseBox.corridorToJanitorDoorClosed && !fuseBox.corridorToJanitorDoorOpening)
            {
                FuseboxFunctionality.janitorOuterDoorInterrupted = true;
            }
            if (transform.parent.parent.gameObject == fuseBox.BonsaiDoorOuterAnim.gameObject && !fuseBox.corridorToBonsaiDoorClosed && !fuseBox.corridorToBonsaiDoorOpening)
            {
                FuseboxFunctionality.bonsaiOuterDoorInterrupted = true;
            }
            if (transform.parent.parent.gameObject == fuseBox.BonsaiDoorInnerAnim.gameObject && !fuseBox.bonsaiToCorridorDoorClosed && !fuseBox.bonsaiToCorridorDoorOpening)
            {
                FuseboxFunctionality.bonsaiInnerDoorInterrupted = true;
            }
            if (transform.parent.parent.gameObject == fuseBox.BonsaiControlAnim.gameObject && !fuseBox.bonsaiControlDoorClosed && !fuseBox.bonsaiControlDoorOpening)
            {
                FuseboxFunctionality.bonsaiControlDoorInterrupted = true;
            }
            if (transform.parent.parent.gameObject == fuseBox.MFToCorridorDoorAnim.gameObject && !fuseBox.mfToCorridorDoorClosed && !fuseBox.mfToCorridorDoorOpening)  //opening checked elsewhere too
            {
                FuseboxFunctionality.mf_ToCorridorDoorInterrupted = true;
            }
            if (transform.parent.parent.gameObject == fuseBox.CorridorToMFDoorAnim.gameObject && !fuseBox.corridorToMFDoorClosed && !fuseBox.corridorToMFDoorOpening)
            {
                FuseboxFunctionality.corridor_ToMFDoorInterrupted = true;
            }
            if (transform.parent.parent.gameObject== fuseBox.BridgeToMFDoorAnim.gameObject && !fuseBox.bridgeToMFDoorClosed && !fuseBox.bridgeToMFDoorOpening)
            {
                FuseboxFunctionality.bridge_ToMFDoorInterrupted = true;
            }
            if (transform.parent.parent.gameObject == fuseBox.MFToBridgeDoorAnim.gameObject && !fuseBox.mfToBridgeDoorClosed && !fuseBox.mfToBridgeDoorOpening)
            {
                FuseboxFunctionality.mf_ToBridgeDoorInterrupted = true;
            }
            if (transform.parent.parent.gameObject == fuseBox.MFToMelterDoorAnim.gameObject && !fuseBox.mfToMelterDoorClosed && !fuseBox.mfToMelterDoorOpening)
            {
                FuseboxFunctionality.mf_ToMelterDoorInterrupted = true;
            }
            if (transform.parent.parent.gameObject == fuseBox.MelterToMFDoorAnim.gameObject && !fuseBox.melterToMFDoorClosed && !fuseBox.melterToMFDoorOpening)
            {
                FuseboxFunctionality.melter_ToMFDoorInterrupted = true;
            }
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (!collider.gameObject.CompareTag("Wall") && collider.gameObject.GetComponent<DoorObjectDetector>() == null && collider.gameObject.GetComponent<BackpackFunctionality>() == null)
        {
            if (transform.parent.parent.gameObject == fuseBox.JanitorDoorInnerAnim.gameObject && !fuseBox.janitorToCorridorDoorClosed && !fuseBox.janitorToCorridorDoorOpening)
            {
                FuseboxFunctionality.janitorInnerDoorInterrupted = true;
            }
            if (transform.parent.parent.gameObject == fuseBox.JanitorDoorOuterAnim.gameObject && !fuseBox.corridorToJanitorDoorClosed && !fuseBox.corridorToJanitorDoorOpening)
            {
                FuseboxFunctionality.janitorOuterDoorInterrupted = true;
            }
            if (transform.parent.parent.gameObject == fuseBox.BonsaiDoorOuterAnim.gameObject && !fuseBox.corridorToBonsaiDoorClosed && !fuseBox.corridorToBonsaiDoorOpening)
            {
                FuseboxFunctionality.bonsaiOuterDoorInterrupted = true;
            }
            if (transform.parent.parent.gameObject == fuseBox.BonsaiDoorInnerAnim.gameObject && !fuseBox.bonsaiToCorridorDoorClosed && !fuseBox.bonsaiToCorridorDoorOpening)
            {
                FuseboxFunctionality.bonsaiInnerDoorInterrupted = true;
            }
            if (transform.parent.parent.gameObject == fuseBox.BonsaiControlAnim.gameObject && !fuseBox.bonsaiControlDoorClosed && !fuseBox.bonsaiControlDoorOpening)
            {
                FuseboxFunctionality.bonsaiControlDoorInterrupted = true;
            }
            if (transform.parent.parent.gameObject == fuseBox.MFToCorridorDoorAnim.gameObject && !fuseBox.mfToCorridorDoorClosed && !fuseBox.mfToCorridorDoorOpening)  //opening checked elsewhere too
            {
                FuseboxFunctionality.mf_ToCorridorDoorInterrupted = true;
            }
            if (transform.parent.parent.gameObject == fuseBox.CorridorToMFDoorAnim.gameObject && !fuseBox.corridorToMFDoorClosed && !fuseBox.corridorToMFDoorOpening)
            {
                FuseboxFunctionality.corridor_ToMFDoorInterrupted = true;
            }
            if (transform.parent.parent.gameObject == fuseBox.BridgeToMFDoorAnim.gameObject && !fuseBox.bridgeToMFDoorClosed && !fuseBox.bridgeToMFDoorOpening)
            {
                FuseboxFunctionality.bridge_ToMFDoorInterrupted = true;
            }
            if (transform.parent.parent.gameObject == fuseBox.MFToBridgeDoorAnim.gameObject && !fuseBox.mfToBridgeDoorClosed && !fuseBox.mfToBridgeDoorOpening)
            {
                FuseboxFunctionality.mf_ToBridgeDoorInterrupted = true;
            }
            if (transform.parent.parent.gameObject == fuseBox.MFToMelterDoorAnim.gameObject && !fuseBox.mfToMelterDoorClosed && !fuseBox.mfToMelterDoorOpening)
            {
                FuseboxFunctionality.mf_ToMelterDoorInterrupted = true;
            }
            if (transform.parent.parent.gameObject == fuseBox.MelterToMFDoorAnim.gameObject && !fuseBox.melterToMFDoorClosed && !fuseBox.melterToMFDoorOpening)
            {
                FuseboxFunctionality.melter_ToMFDoorInterrupted = true;
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (!collider.gameObject.CompareTag("Wall") && collider.gameObject.GetComponent<DoorObjectDetector>() == null && collider.gameObject.GetComponent<BackpackFunctionality>() == null)
        {
            if (transform.parent.parent.gameObject == fuseBox.JanitorDoorInnerAnim.gameObject && !fuseBox.janitorToCorridorDoorClosed && !fuseBox.janitorToCorridorDoorOpening)
            {
                FuseboxFunctionality.janitorInnerDoorInterrupted = false;
            }
            if (transform.parent.parent.gameObject == fuseBox.JanitorDoorOuterAnim.gameObject && !fuseBox.corridorToJanitorDoorClosed && !fuseBox.corridorToJanitorDoorOpening)
            {
                FuseboxFunctionality.janitorOuterDoorInterrupted = false;
            }
            if (transform.parent.parent.gameObject == fuseBox.BonsaiDoorOuterAnim.gameObject && !fuseBox.corridorToBonsaiDoorClosed && !fuseBox.corridorToBonsaiDoorOpening)
            {
                FuseboxFunctionality.bonsaiOuterDoorInterrupted = false;
            }
            if (transform.parent.parent.gameObject == fuseBox.BonsaiDoorInnerAnim.gameObject && !fuseBox.bonsaiToCorridorDoorClosed && !fuseBox.bonsaiToCorridorDoorOpening)
            {
                FuseboxFunctionality.bonsaiInnerDoorInterrupted = false;
            }
            if (transform.parent.parent.gameObject == fuseBox.BonsaiControlAnim.gameObject && !fuseBox.bonsaiControlDoorClosed && !fuseBox.bonsaiControlDoorOpening)
            {
                FuseboxFunctionality.bonsaiControlDoorInterrupted = false;
            }
            if (transform.parent.parent.gameObject == fuseBox.MFToCorridorDoorAnim.gameObject && !fuseBox.mfToCorridorDoorClosed && !fuseBox.mfToCorridorDoorOpening)
            {
                FuseboxFunctionality.mf_ToCorridorDoorInterrupted = false;
            }
            if (transform.parent.parent.gameObject == fuseBox.CorridorToMFDoorAnim.gameObject && !fuseBox.corridorToMFDoorClosed && !fuseBox.corridorToMFDoorOpening)
            {
                FuseboxFunctionality.corridor_ToMFDoorInterrupted = false;
            }
            if (transform.parent.parent.gameObject == fuseBox.BridgeToMFDoorAnim.gameObject && !fuseBox.bridgeToMFDoorClosed && !fuseBox.bridgeToMFDoorOpening)
            {
                FuseboxFunctionality.bridge_ToMFDoorInterrupted = false;
            }
            if (transform.parent.parent.gameObject == fuseBox.MFToBridgeDoorAnim.gameObject && !fuseBox.mfToBridgeDoorClosed && !fuseBox.mfToBridgeDoorOpening)
            {
                FuseboxFunctionality.mf_ToBridgeDoorInterrupted = false;
            }
            if (transform.parent.parent.gameObject == fuseBox.MFToMelterDoorAnim.gameObject && !fuseBox.mfToMelterDoorClosed && !fuseBox.mfToMelterDoorOpening)
            {
                FuseboxFunctionality.mf_ToMelterDoorInterrupted = false;
            }
            if (transform.parent.parent.gameObject == fuseBox.MelterToMFDoorAnim.gameObject && !fuseBox.melterToMFDoorClosed && !fuseBox.melterToMFDoorOpening)
            {
                FuseboxFunctionality.melter_ToMFDoorInterrupted = false;
            }
        }
    }

    private void Update()
    {
        DoorInterruptColliderEnabling();
    }
    //turns the interrupt collider off when door is closed so that it won't detect a collision through walls or something
    private void DoorInterruptColliderEnabling()
    {     
        if (fuseBox.janitorToCorridorDoorClosed && transform.parent.parent.gameObject == fuseBox.JanitorDoorInnerAnim.gameObject)
        {
            gameObject.GetComponent<Collider>().enabled = false;
        }
        else if (transform.parent.parent.gameObject == fuseBox.JanitorDoorInnerAnim.gameObject)
        {
            gameObject.GetComponent<Collider>().enabled = true;
        }
        if (fuseBox.corridorToJanitorDoorClosed && transform.parent.parent.gameObject == fuseBox.JanitorDoorOuterAnim.gameObject)
        {
            gameObject.GetComponent<Collider>().enabled = false;
        }
        else if (transform.parent.parent.gameObject == fuseBox.JanitorDoorOuterAnim.gameObject)
        {
            gameObject.GetComponent<Collider>().enabled = true;
        }
        if (fuseBox.bonsaiToCorridorDoorClosed && transform.parent.parent.gameObject == fuseBox.BonsaiDoorInnerAnim.gameObject)
        {
            gameObject.GetComponent<Collider>().enabled = false;
        }
        else if (transform.parent.parent.gameObject == fuseBox.BonsaiDoorInnerAnim.gameObject)
        {
            gameObject.GetComponent<Collider>().enabled = true;
        }
        if (fuseBox.corridorToBonsaiDoorClosed && transform.parent.parent.gameObject == fuseBox.BonsaiDoorOuterAnim.gameObject)
        {
            gameObject.GetComponent<Collider>().enabled = false;
        }
        else if (transform.parent.parent.gameObject == fuseBox.BonsaiDoorOuterAnim.gameObject)
        {
            gameObject.GetComponent<Collider>().enabled = true;
        }
        if (fuseBox.mfToCorridorDoorClosed && transform.parent.parent.gameObject == fuseBox.MFToCorridorDoorAnim.gameObject)
        {
            gameObject.GetComponent<Collider>().enabled = false;          
        }
        else if (transform.parent.parent.gameObject == fuseBox.MFToCorridorDoorAnim.gameObject)
        {
            gameObject.GetComponent<Collider>().enabled = true;          
        }
        if (fuseBox.corridorToMFDoorClosed && transform.parent.parent.gameObject == fuseBox.CorridorToMFDoorAnim.gameObject)
        {
            gameObject.GetComponent<Collider>().enabled = false;
        }
        else if (transform.parent.parent.gameObject == fuseBox.CorridorToMFDoorAnim.gameObject)
        {
            gameObject.GetComponent<Collider>().enabled = true;
        }
        if (fuseBox.bridgeToMFDoorClosed && transform.parent.parent.gameObject == fuseBox.BridgeToMFDoorAnim.gameObject)
        {
            gameObject.GetComponent<Collider>().enabled = false;
        }
        else if (transform.parent.parent.gameObject == fuseBox.BridgeToMFDoorAnim.gameObject)
        {
            gameObject.GetComponent<Collider>().enabled = true;
        }
        if (fuseBox.mfToBridgeDoorClosed && transform.parent.parent.gameObject == fuseBox.MFToBridgeDoorAnim.gameObject)
        {
            gameObject.GetComponent<Collider>().enabled = false;
        }
        else if (transform.parent.parent.gameObject == fuseBox.MFToBridgeDoorAnim.gameObject)
        {
            gameObject.GetComponent<Collider>().enabled = true;
        }
        if (fuseBox.mfToMelterDoorClosed && transform.parent.parent.gameObject == fuseBox.MFToMelterDoorAnim.gameObject)
        {
            gameObject.GetComponent<Collider>().enabled = false;
        }
        else if (transform.parent.parent.gameObject == fuseBox.MFToMelterDoorAnim.gameObject)
        {
            gameObject.GetComponent<Collider>().enabled = true;
        }
        if (fuseBox.melterToMFDoorClosed && transform.parent.parent.gameObject == fuseBox.MelterToMFDoorAnim.gameObject)
        {
            gameObject.GetComponent<Collider>().enabled = false;
        }
        else if (transform.parent.parent.gameObject == fuseBox.MelterToMFDoorAnim.gameObject)
        {
            gameObject.GetComponent<Collider>().enabled = true;
        }
    }
}
