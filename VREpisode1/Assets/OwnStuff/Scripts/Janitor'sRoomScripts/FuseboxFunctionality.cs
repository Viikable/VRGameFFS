using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class FuseboxFunctionality : MonoBehaviour {

    //Maintenance
    public VRTK_SnapDropZone MaintenanceLights;
    public VRTK_SnapDropZone MaintenanceMachinery;
    public VRTK_SnapDropZone MaintenanceDoors;

    //Main Facility
    public VRTK_SnapDropZone MainFacilityLights;
    public VRTK_SnapDropZone MainFacilityMachinery;
    public VRTK_SnapDropZone MainFacilityDoors;

    //Bridge
    public VRTK_SnapDropZone BridgeLights;
    public VRTK_SnapDropZone BridgeMachinery;
    public VRTK_SnapDropZone BridgeDoors;

    //Melter
    public VRTK_SnapDropZone MelterLights;
    public VRTK_SnapDropZone MelterMachinery;
    public VRTK_SnapDropZone MelterDoors;

    
    void Start () {

        MaintenanceLights = transform.Find("MaintenanceAreaLights").GetComponent<VRTK_SnapDropZone>();
        MaintenanceMachinery = transform.Find("MaintenanceAreaMachinery").GetComponent<VRTK_SnapDropZone>();
        MaintenanceDoors = transform.Find("MaintenanceAreaDoors").GetComponent<VRTK_SnapDropZone>();

        MainFacilityLights = transform.Find("MainFacilityLights").GetComponent<VRTK_SnapDropZone>();
        MainFacilityMachinery = transform.Find("MainFacilityMachinery").GetComponent<VRTK_SnapDropZone>();
        MainFacilityDoors = transform.Find("MainFacilityDoors").GetComponent<VRTK_SnapDropZone>();

        BridgeLights = transform.Find("BridgeLights").GetComponent<VRTK_SnapDropZone>();
        BridgeMachinery = transform.Find("BridgeMachinery").GetComponent<VRTK_SnapDropZone>();
        BridgeDoors = transform.Find("BridgeDoors").GetComponent<VRTK_SnapDropZone>();

        MelterLights = transform.Find("MelterLights").GetComponent<VRTK_SnapDropZone>();
        MelterMachinery = transform.Find("MelterMachinery").GetComponent<VRTK_SnapDropZone>();
        MelterDoors = transform.Find("MelterDoors").GetComponent<VRTK_SnapDropZone>();

    }
	
	
	void Update ()
    {

        CheckLights();
        CheckMachinery();
        CheckDoors();
	}

    public void CheckLights()
    {
        if (MaintenanceLights.GetCurrentSnappedObject() != null)
        {
            //turn Maintenancelights on
        }
        else
        {
            //turn Maintenancelights off
        }

        if (MainFacilityLights.GetCurrentSnappedObject() != null)
        {
            //turn MainFacilitylights on
        }
        else
        {
            //turn MainFacilitylights off
        }

        if (BridgeLights.GetCurrentSnappedObject() != null)
        {
            //turn Bridgelights on
        }
        else
        {
            //turn Bridgelights off
        }

        if (MelterLights.GetCurrentSnappedObject() != null)
        {
            //turn Melterlights on
        }
        else
        {
            //turn Melterlights off
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
        }
        else
        {
            //turn BridgeMachinery off
        }

        if (MelterMachinery.GetCurrentSnappedObject() != null)
        {
            //turn MelterMachinery on
        }
        else
        {
            //turn MelterMachinery off
        }
    }

    public void CheckDoors()
    {
        if (MaintenanceDoors.GetCurrentSnappedObject() != null)
        {
            //turn MaintenanceDoors on
        }
        else
        {
            //turn MaintenanceDoors off
        }

        if (MainFacilityDoors.GetCurrentSnappedObject() != null)
        {
            //turn MainFacilityDoors on
        }
        else
        {
            //turn MainFacilityDoors off
        }

        if (BridgeDoors.GetCurrentSnappedObject() != null)
        {
            //turn BridgeDoors on
        }
        else
        {
            //turn BridgeDoors off
        }

        if (MelterDoors.GetCurrentSnappedObject() != null)
        {
            //turn MelterDoors on
        }
        else
        {
            //turn MelterDoors off
        }
    }
}
