using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ResetOutOfFacilityObjectLocation : MonoBehaviour {
    //this class handles object location resetting if they go outside of the game walls and hit the seabed

    public GameObject MainHallLobbyResetLocation;
    public GameObject MainHallBridgeResetLocation;
    public GameObject FirstShaftResetLocation;
    public GameObject SecondShaftResetLocation;
    public GameObject BonsaiRoomResetLocation;
    public GameObject MelterRoomResetLocation;
    public GameObject OctoRoomResetLocation;
    public GameObject JanitorsLodgeResetLocation;
    public GameObject MaintenanceCorridorResetLocation;

    public static PlayerCurrentLocation playerLocation;

    private void Start()
    {
        MainHallLobbyResetLocation = GameObject.Find("MainHallLobbyResetLocation");
        MainHallBridgeResetLocation = GameObject.Find("MainHallBridgeResetLocation");
        FirstShaftResetLocation = GameObject.Find("FirstShaftResetLocation");
        SecondShaftResetLocation = GameObject.Find("SecondShaftResetLocation");
        MelterRoomResetLocation = GameObject.Find("MelterRoomResetLocation");
        OctoRoomResetLocation = GameObject.Find("OctoRoomResetLocation");
        BonsaiRoomResetLocation = GameObject.Find("BonsaiRoomResetLocation");
        JanitorsLodgeResetLocation = GameObject.Find("JanitorsLodgeResetLocation");
        MaintenanceCorridorResetLocation = GameObject.Find("MaintenanceCorridorResetLocation");

        playerLocation = PlayerCurrentLocation.MaintenanceCorridor;
    }

    public enum PlayerCurrentLocation
    {
        MaintenanceCorridor,
        JanitorRoom,
        BonsaiRoom,
        MainHallLobby,
        MainHallBridge,
        MelterRoom,
        FirstShaft,
        SecondShaft,
        OctopusRoom,
        LastShaft,
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<XRGrabInteractable>() != null)
        {
            if (other.GetComponent<LocationReset>() != null)
            {
            other.GetComponent<LocationReset>().ResetLocation();
            }
        }
        else if (other.transform.parent.GetComponent<XRGrabInteractable>() != null && other.transform.parent.GetComponent<LocationReset>() != null)
        {
            other.transform.parent.GetComponent<LocationReset>().ResetLocation();
        }
        else if (other.CompareTag("Player") || other.transform.parent.CompareTag("Player"))
        {
            if (playerLocation == PlayerCurrentLocation.MainHallLobby)
            {
                GameObject.FindGameObjectWithTag("Player").transform.position = MainHallLobbyResetLocation.GetComponent<Transform>().position;
            }
            else if (playerLocation == PlayerCurrentLocation.MainHallBridge)
            {
                GameObject.FindGameObjectWithTag("Player").transform.position = MainHallBridgeResetLocation.GetComponent<Transform>().position;
            }
            else if (playerLocation == PlayerCurrentLocation.FirstShaft)
            {
                GameObject.FindGameObjectWithTag("Player").transform.position = FirstShaftResetLocation.GetComponent<Transform>().position;
            }
            else if (playerLocation == PlayerCurrentLocation.SecondShaft)
            {
                GameObject.FindGameObjectWithTag("Player").transform.position = SecondShaftResetLocation.GetComponent<Transform>().position;
            }
            else if (playerLocation == PlayerCurrentLocation.OctopusRoom)
            {
                GameObject.FindGameObjectWithTag("Player").transform.position = OctoRoomResetLocation.GetComponent<Transform>().position;
            }
            else if (playerLocation == PlayerCurrentLocation.BonsaiRoom)
            {
                GameObject.FindGameObjectWithTag("Player").transform.position = BonsaiRoomResetLocation.GetComponent<Transform>().position;
            }
            else if (playerLocation == PlayerCurrentLocation.MelterRoom)
            {
                GameObject.FindGameObjectWithTag("Player").transform.position = MelterRoomResetLocation.GetComponent<Transform>().position;
            }
            else if (playerLocation == PlayerCurrentLocation.JanitorRoom)
            {
                GameObject.FindGameObjectWithTag("Player").transform.position = JanitorsLodgeResetLocation.GetComponent<Transform>().position;
            }
            else if (playerLocation == PlayerCurrentLocation.MaintenanceCorridor)
            {
                GameObject.FindGameObjectWithTag("Player").transform.position = MaintenanceCorridorResetLocation.GetComponent<Transform>().position;
            }
        }     
    }
}
