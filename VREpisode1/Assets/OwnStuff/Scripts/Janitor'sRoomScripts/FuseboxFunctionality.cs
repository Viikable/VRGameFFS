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

    public bool MaintenanceDoorsOpen;

    //Main Facility
    public VRTK_SnapDropZone MainFacilityLights;
    public VRTK_SnapDropZone MainFacilityMachinery;
    public VRTK_SnapDropZone MainFacilityDoors;

    GameObject MainFacilityLightsContainer;

    public bool MainFacilityDoorsOpen;

    //Bridge
    public VRTK_SnapDropZone BridgeLights;
    public VRTK_SnapDropZone BridgeMachinery;
    public VRTK_SnapDropZone BridgeDoors;

    GameObject BridgeLightsContainer;

    public bool BridgeDoorsOpen;

    //Melter
    public VRTK_SnapDropZone MelterLights;
    public VRTK_SnapDropZone MelterMachinery;
    public VRTK_SnapDropZone MelterDoors;

    GameObject MelterLightsContainer;

    public bool MelterDoorsOpen;


    void Start () {


        //Maintenance
        MaintenanceLights = transform.Find("MaintenanceAreaLights").GetComponent<VRTK_SnapDropZone>();
        MaintenanceMachinery = transform.Find("MaintenanceAreaMachinery").GetComponent<VRTK_SnapDropZone>();
        MaintenanceDoors = transform.Find("MaintenanceAreaDoors").GetComponent<VRTK_SnapDropZone>();

        MaintenanceLightsContainer = GameObject.Find("MaintenanceLightsContainer");

        MaintenanceDoorsOpen = true;

        //Main facility
        MainFacilityLights = transform.Find("MainFacilityLights").GetComponent<VRTK_SnapDropZone>();
        MainFacilityMachinery = transform.Find("MainFacilityMachinery").GetComponent<VRTK_SnapDropZone>();
        MainFacilityDoors = transform.Find("MainFacilityDoors").GetComponent<VRTK_SnapDropZone>();

        MainFacilityLightsContainer = GameObject.Find("MainFacilityLightsContainer");

        //Bridge
        BridgeLights = transform.Find("BridgeLights").GetComponent<VRTK_SnapDropZone>();
        BridgeMachinery = transform.Find("BridgeMachinery").GetComponent<VRTK_SnapDropZone>();
        BridgeDoors = transform.Find("BridgeDoors").GetComponent<VRTK_SnapDropZone>();

        BridgeLightsContainer = GameObject.Find("BridgeLightsContainer");

        //Melter
        MelterLights = transform.Find("MelterLights").GetComponent<VRTK_SnapDropZone>();
        MelterMachinery = transform.Find("MelterMachinery").GetComponent<VRTK_SnapDropZone>();
        MelterDoors = transform.Find("MelterDoors").GetComponent<VRTK_SnapDropZone>();

        MelterLightsContainer = GameObject.Find("MelterLightsContainer");

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
