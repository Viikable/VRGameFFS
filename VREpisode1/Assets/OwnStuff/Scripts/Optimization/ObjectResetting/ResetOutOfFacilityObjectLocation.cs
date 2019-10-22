using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ResetOutOfFacilityObjectLocation : MonoBehaviour {
    //this class handles object location resetting if they go outside of the game walls and hit the seabed

    public GameObject MainHallResetLocation;
    public GameObject FirstShaftResetLocation;
    public GameObject SecondShaftResetLocation;
    public GameObject BonsaiRoomResetLocation;
    public GameObject MelterRoomResetLocation;
    public GameObject OctoRoomResetLocation;
    public GameObject JanitorsLodgeResetLocation;

    public static string PlayerResetLocation;

    private void Start()
    {
        MainHallResetLocation = GameObject.Find("MainHallResetLocation");
        FirstShaftResetLocation = GameObject.Find("FirstShaftResetLocation");
        SecondShaftResetLocation = GameObject.Find("SecondShaftResetLocation");
        MelterRoomResetLocation = GameObject.Find("MelterRoomResetLocation");
        OctoRoomResetLocation = GameObject.Find("OctoRoomResetLocation");
        BonsaiRoomResetLocation = GameObject.Find("BonsaiRoomResetLocation");
        JanitorsLodgeResetLocation = GameObject.Find("JanitorsLodgeResetLocation");

        PlayerResetLocation = "MainHall";
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<VRTK_InteractableObject>() != null)
        {
            if (other.GetComponent<LocationReset>() != null)
            {
            other.GetComponent<LocationReset>().ResetLocation();
            }
        }
        else if (other.transform.parent.GetComponent<VRTK_InteractableObject>() != null)
        {
            other.transform.parent.GetComponent<LocationReset>().ResetLocation();
        }
        else if (other.CompareTag("Player") || other.transform.parent.CompareTag("Player"))
        {
            if (PlayerResetLocation == "MainHall")
            {
                GameObject.FindGameObjectWithTag("Player").transform.position = MainHallResetLocation.GetComponent<Transform>().position;
            }
            else if (PlayerResetLocation == "FirstShaft")
            {
                GameObject.FindGameObjectWithTag("Player").transform.position = FirstShaftResetLocation.GetComponent<Transform>().position;
            }
            else if (PlayerResetLocation == "SecondShaft")
            {
                GameObject.FindGameObjectWithTag("Player").transform.position = SecondShaftResetLocation.GetComponent<Transform>().position;
            }
            else if (PlayerResetLocation == "OctoRoom")
            {
                GameObject.FindGameObjectWithTag("Player").transform.position = OctoRoomResetLocation.GetComponent<Transform>().position;
            }
            else if (PlayerResetLocation == "BonsaiRoom")
            {
                GameObject.FindGameObjectWithTag("Player").transform.position = BonsaiRoomResetLocation.GetComponent<Transform>().position;
            }
            else if (PlayerResetLocation == "MelterRoom")
            {
                GameObject.FindGameObjectWithTag("Player").transform.position = MelterRoomResetLocation.GetComponent<Transform>().position;
            }
            else if (PlayerResetLocation == "JanitorsLodge")
            {
                GameObject.FindGameObjectWithTag("Player").transform.position = JanitorsLodgeResetLocation.GetComponent<Transform>().position;
            }
        }     
    }
}
