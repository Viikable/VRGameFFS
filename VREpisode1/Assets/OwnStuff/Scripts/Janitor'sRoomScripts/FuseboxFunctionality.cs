using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class FuseboxFunctionality : MonoBehaviour {

    //Maintenance
    public VRTK_SnapDropZone MaintenanceLights;
    public VRTK_SnapDropZone MaintenanceMachinery;
    public VRTK_SnapDropZone MaintenanceDoors;

    GameObject MaintenanceLightsContainer;

    public static bool MaintenanceDoorsPowered;

    public VRTK_SnapDropZone JanitorDoorInner;
    public VRTK_SnapDropZone JanitorDoorOuter;

    public VRTK_SnapDropZone BonsaiDoorInner;
    public VRTK_SnapDropZone BonsaiDoorOuter;

    public VRTK_SnapDropZone CorridorDoorToMainFacility;

    //Main Facility
    public VRTK_SnapDropZone MainFacilityLights;
    public VRTK_SnapDropZone MainFacilityMachinery;
    public VRTK_SnapDropZone MainFacilityDoors;

    GameObject MainFacilityLightsContainer;

    public static bool MainFacilityDoorsPowered;

    public VRTK_SnapDropZone MainFacilityDoorToCorridor;
    public VRTK_SnapDropZone MainFacilityDoorToBridge;
    public VRTK_SnapDropZone MainFacilityDoorToMelter;

    //Bridge
    public VRTK_SnapDropZone BridgeLights;
    public VRTK_SnapDropZone BridgeMachinery;
    public VRTK_SnapDropZone BridgeDoors;

    GameObject BridgeLightsContainer;

    public static bool BridgeDoorsPowered;

    public VRTK_SnapDropZone BridgeDoorToMainFacility;

    //Melter
    public VRTK_SnapDropZone MelterLights;
    public VRTK_SnapDropZone MelterMachinery;
    public VRTK_SnapDropZone MelterDoors;

    GameObject MelterLightsContainer;

    public static bool MelterDoorsPowered;

    public VRTK_SnapDropZone MelterDoorToMainFacility;


    void Start () {

        //Maintenance
        MaintenanceLights = transform.Find("MaintenanceAreaLights").GetComponent<VRTK_SnapDropZone>();
        MaintenanceMachinery = transform.Find("MaintenanceAreaMachinery").GetComponent<VRTK_SnapDropZone>();
        MaintenanceDoors = transform.Find("MaintenanceAreaDoors").GetComponent<VRTK_SnapDropZone>();

        MaintenanceLightsContainer = GameObject.Find("MaintenanceLightsContainer");

        MaintenanceDoorsPowered = true;

        JanitorDoorInner = GameObject.Find("JanitorDoorInner").GetComponent<VRTK_SnapDropZone>();
        JanitorDoorOuter = GameObject.Find("JanitorDoorOuter").GetComponent<VRTK_SnapDropZone>();

        BonsaiDoorInner = GameObject.Find("BonsaiDoorInner").GetComponent<VRTK_SnapDropZone>();
        BonsaiDoorOuter = GameObject.Find("BonsaiDoorOuter").GetComponent<VRTK_SnapDropZone>();

        CorridorDoorToMainFacility = GameObject.Find("CorridorDoorToMainFacility").GetComponent<VRTK_SnapDropZone>();

        //Main facility
        MainFacilityLights = transform.Find("MainFacilityLights").GetComponent<VRTK_SnapDropZone>();
        MainFacilityMachinery = transform.Find("MainFacilityMachinery").GetComponent<VRTK_SnapDropZone>();
        MainFacilityDoors = transform.Find("MainFacilityDoors").GetComponent<VRTK_SnapDropZone>();

        MainFacilityLightsContainer = GameObject.Find("MainFacilityLightsContainer");

        MainFacilityDoorsPowered = false;

        MainFacilityDoorToCorridor = GameObject.Find("MainFacilityDoorToCorridor").GetComponent<VRTK_SnapDropZone>();
        MainFacilityDoorToBridge = GameObject.Find("MainFacilityDoorToBridge").GetComponent<VRTK_SnapDropZone>();
        MainFacilityDoorToMelter = GameObject.Find("MainFacilityDoorToMelter").GetComponent<VRTK_SnapDropZone>();

        //Bridge
        BridgeLights = transform.Find("BridgeLights").GetComponent<VRTK_SnapDropZone>();
        BridgeMachinery = transform.Find("BridgeMachinery").GetComponent<VRTK_SnapDropZone>();
        BridgeDoors = transform.Find("BridgeDoors").GetComponent<VRTK_SnapDropZone>();

        BridgeLightsContainer = GameObject.Find("BridgeLightsContainer");

        BridgeDoorsPowered = false;

        BridgeDoorToMainFacility = GameObject.Find("BridgeDoorToMainFacility").GetComponent<VRTK_SnapDropZone>();

        //Melter
        MelterLights = transform.Find("MelterLights").GetComponent<VRTK_SnapDropZone>();
        MelterMachinery = transform.Find("MelterMachinery").GetComponent<VRTK_SnapDropZone>();
        MelterDoors = transform.Find("MelterDoors").GetComponent<VRTK_SnapDropZone>();

        MelterLightsContainer = GameObject.Find("MelterLightsContainer");

        MelterDoorsPowered = false;

        MelterDoorToMainFacility = GameObject.Find("MelterDoorToMainFacility").GetComponent<VRTK_SnapDropZone>();
    }
	
	
	void Update ()
    {
        CheckLights();
        CheckMachinery();
        CheckDoorsOpenStatus();
        OpenDoors();
	}

    public void CheckLights()
    {
        if (MaintenanceLights.GetCurrentSnappedObject() != null)
        {
            //turn Maintenancelights on
            foreach (Light light in MaintenanceLightsContainer.GetComponentsInChildren<Light>())
            {
                light.intensity = 2f;
                light.color = Color.white;
            }
        }
        else
        {
            //turn Maintenancelights off
            foreach (Light light in MaintenanceLightsContainer.GetComponentsInChildren<Light>())
            {
                light.intensity = 1f;
                light.color = Color.red;
            }
        }

        if (MainFacilityLights.GetCurrentSnappedObject() != null)
        {
            //turn MainFacilitylights on
            foreach (Light light in MainFacilityLightsContainer.GetComponentsInChildren<Light>())
            {
                light.intensity = 3f;
                light.color = Color.white;
            }
        }
        else
        {
            //turn MainFacilitylights off
            foreach (Light light in MainFacilityLightsContainer.GetComponentsInChildren<Light>())
            {
                light.intensity = 1f;
                light.color = Color.red;
            }
        }

        if (BridgeLights.GetCurrentSnappedObject() != null)
        {
            //turn Bridgelights on
            foreach (Light light in BridgeLightsContainer.GetComponentsInChildren<Light>())
            {
                light.intensity = 3f;
                light.color = Color.white;
            }
        }
        else
        {
            //turn Bridgelights off
            foreach (Light light in BridgeLightsContainer.GetComponentsInChildren<Light>())
            {
                light.intensity = 1f;
                light.color = Color.red;
            }
        }

        if (MelterLights.GetCurrentSnappedObject() != null)
        {
            //turn Melterlights on
            foreach (Light light in MelterLightsContainer.GetComponentsInChildren<Light>())
            {
                light.intensity = 2f;
                light.color = Color.white;
            }
        }
        else
        {
            //turn Melterlights off
            foreach (Light light in MelterLightsContainer.GetComponentsInChildren<Light>())
            {
                light.intensity = 1f;
                light.color = Color.red;
            }
        }
    }

    public void CheckMachinery()
    {
        if (MaintenanceMachinery.GetCurrentSnappedObject() != null)
        {
            //turn MaintenanceMachinery on
        }
        else
        {
            //turn MaintenanceMachinery off
        }

        if (MainFacilityMachinery.GetCurrentSnappedObject() != null)
        {
            //turn MainFacilityMachinery on
            
        }
        else
        {
            //turn MainFacilityMachinery off
            
        }

        if (BridgeMachinery.GetCurrentSnappedObject() != null)
        {
            //turn BridgeMachinery on
            BridgeKeyConfiguration.ActivateMonitor();
        }
        else
        {
            //turn BridgeMachinery off
            BridgeKeyConfiguration.DeactivateMonitor();
        }

        if (MelterMachinery.GetCurrentSnappedObject() != null)
        {
            //turn MelterMachinery on
            KeyboardMappings.ActivateMonitor();
        }
        else
        {
            //turn MelterMachinery off
            KeyboardMappings.DeactivateMonitor();
        }
    }

    public void CheckDoorsOpenStatus()
    {
        if (MaintenanceDoors.GetCurrentSnappedObject() != null)
        {
            //turn MaintenanceDoors on
            MaintenanceDoorsPowered = true;
        }
        else
        {
            //turn MaintenanceDoors off
            MaintenanceDoorsPowered = false;
        }

        if (MainFacilityDoors.GetCurrentSnappedObject() != null)
        {
            //turn MainFacilityDoors on
            MainFacilityDoorsPowered = true;
        }
        else
        {
            //turn MainFacilityDoors off
            MainFacilityDoorsPowered = false;
        }

        if (BridgeDoors.GetCurrentSnappedObject() != null)
        {
            //turn BridgeDoors on
            BridgeDoorsPowered = true;
        }
        else
        {
            //turn BridgeDoors off
            BridgeDoorsPowered = false;
        }

        if (MelterDoors.GetCurrentSnappedObject() != null)
        {
            //turn MelterDoors on
            MelterDoorsPowered = true;
        }
        else
        {
            //turn MelterDoors off
            MelterDoorsPowered = false;
        }

    }

    private void OpenDoors()
    {
        // keys stay inside and do nothing if wrong clearance level

        //Maintenance area 

        if (MaintenanceDoorsPowered)
        {
            if (JanitorDoorInner.GetCurrentSnappedObject() != null && JanitorDoorInner.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 1)
            {
                //in case the player has put another copy of the same key on the other side already, keeping it open, then adding a new key will not re-trigger the opening animation
                //not a problem in double doors
                if (JanitorDoorOuter.GetCurrentSnappedObject() == null || (JanitorDoorOuter.GetCurrentSnappedObject() != null
                    && JanitorDoorOuter.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 1))
                {
                    //Open Janitor door (from the inside)
                }
            }
            else if (JanitorDoorInner.GetCurrentSnappedObject() != null && JanitorDoorInner.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 1)
            {
                //show that the key is wrong to the player
            }

            if (JanitorDoorOuter.GetCurrentSnappedObject() != null && JanitorDoorOuter.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 1)
            {
                //in case the player has put another copy of the same key on the other side already, keeping it open, then adding a new key will not re-trigger the opening animation
                //not a problem in double doors
                if (JanitorDoorInner.GetCurrentSnappedObject() == null || (JanitorDoorInner.GetCurrentSnappedObject() != null
                    && JanitorDoorInner.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 1))
                {
                    //Open Janitor door (from the outside)
                }
            }
            else if (JanitorDoorOuter.GetCurrentSnappedObject() != null && JanitorDoorOuter.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 1)
            {
                //show that the key is wrong to the player
            }

            if (BonsaiDoorInner.GetCurrentSnappedObject() != null && BonsaiDoorInner.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 2)
            {
                //in case the player has put another copy of the same key on the other side already, keeping it open, then adding a new key will not re-trigger the opening animation
                //not a problem in double doors
                if (BonsaiDoorOuter.GetCurrentSnappedObject() == null || (BonsaiDoorOuter.GetCurrentSnappedObject() != null
                    && BonsaiDoorOuter.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2))
                {
                    //Open Janitor door (from the inside)
                }
            }
            else if (BonsaiDoorInner.GetCurrentSnappedObject() != null && BonsaiDoorInner.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2)
            {
                //show that the key is wrong to the player
            }

            if (BonsaiDoorOuter.GetCurrentSnappedObject() != null && BonsaiDoorOuter.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 2)
            {
                //in case the player has put another copy of the same key on the other side already, keeping it open, then adding a new key will not re-trigger the opening animation
                //not a problem in double doors
                if (BonsaiDoorInner.GetCurrentSnappedObject() == null || (BonsaiDoorInner.GetCurrentSnappedObject() != null
                    && BonsaiDoorInner.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2))
                {
                    //Open Janitor door (from the outside)
                }
            }
            else if (BonsaiDoorOuter.GetCurrentSnappedObject() != null && BonsaiDoorOuter.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2)
            {
                //show that the key is wrong to the player
            }
            //CorridorDoorToMainFacility doesn't need a keycard
        }

        //MAIN FACILITY DOORS

        //MainFacilityDoorToCorridor doesn't need a keycard

        if (MainFacilityDoorsPowered)
        {
            if (MainFacilityDoorToBridge.GetCurrentSnappedObject() != null && MainFacilityDoorToBridge.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 3)
            {
                //open the door
            }
            else if (MainFacilityDoorToBridge.GetCurrentSnappedObject() != null && MainFacilityDoorToBridge.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 3)
            {
                //show that the key is wrong to the player
            }

            if (MainFacilityDoorToMelter.GetCurrentSnappedObject() != null && MainFacilityDoorToMelter.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 2)
            {
                //open the door
            }
            else if (MainFacilityDoorToMelter.GetCurrentSnappedObject() != null && MainFacilityDoorToMelter.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2)
            {
                //show that the key is wrong to the player
            }
        }

        //BRIDGE INNER DOOR

        if (BridgeDoorsPowered)
        {
            if (BridgeDoorToMainFacility.GetCurrentSnappedObject() != null && BridgeDoorToMainFacility.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 3)
            {
                //open the door
            }
            else if (BridgeDoorToMainFacility.GetCurrentSnappedObject() != null && BridgeDoorToMainFacility.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 3)
            {
                //show that the key is wrong to the player
            }
        }

        //MELTER DOOR

        if (MelterDoorsPowered)
        {
            if (MelterDoorToMainFacility.GetCurrentSnappedObject() != null && MelterDoorToMainFacility.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 2)
            {
                //open the door
            }
            else if (MelterDoorToMainFacility.GetCurrentSnappedObject() != null && MelterDoorToMainFacility.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2)
            {
                //show that the key is wrong to the player
            }
        }

    }
}
