using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables.PhysicsBased;

public class FuseboxFunctionality : MonoBehaviour {

    [Header("Maintenance")]
    public VRTK_SnapDropZone MaintenanceLights;
    public VRTK_SnapDropZone MaintenanceMachinery;
    public VRTK_SnapDropZone MaintenanceDoors;

    GameObject MaintenanceLightsContainer;

    public static bool MaintenanceDoorsPowered;

    public VRTK_SnapDropZone JanitorDoorInner;
    public VRTK_SnapDropZone JanitorDoorOuter;

    public Animator JanitorDoorAnim;

    public VRTK_SnapDropZone BonsaiDoorInner;
    public VRTK_SnapDropZone BonsaiDoorOuter;

    public Animator BonsaiDoorAnim;

    //public VRTK_SnapDropZone CorridorDoorToMainFacility;  actually works with a button
    public VRTK_PhysicsPusher CorridorDoorToMainFacility;

    [Header("MainFacility")]
    public VRTK_SnapDropZone MainFacilityLights;
    public VRTK_SnapDropZone MainFacilityMachinery;
    public VRTK_SnapDropZone MainFacilityDoors;

    GameObject MainFacilityLightsContainer;

    public static bool MainFacilityDoorsPowered;

    //button too
    public VRTK_PhysicsPusher MainFacilityDoorToCorridor;

    public VRTK_SnapDropZone MainFacilityDoorToBridge;
    public VRTK_SnapDropZone MainFacilityDoorToMelter;
   
    [Header("Bridge")]
    public VRTK_SnapDropZone BridgeLights;
    public VRTK_SnapDropZone BridgeMachinery;
    public VRTK_SnapDropZone BridgeDoors;

    GameObject BridgeLightsContainer;

    public static bool BridgeDoorsPowered;

    public VRTK_SnapDropZone BridgeDoorToMainFacility;
   
    [Header("Melter")]
    public VRTK_SnapDropZone MelterLights;
    public VRTK_SnapDropZone MelterMachinery;
    public VRTK_SnapDropZone MelterDoors;

    GameObject MelterLightsContainer;

    public static bool MelterDoorsPowered;

    public VRTK_SnapDropZone MelterDoorToMainFacility;

    [Header("DoubleDoorAnimators")]

    public Animator MainFacilityAndCorridorDoorAnim;

    public Animator MainFacilityAndBridgeDoorAnim;

    public Animator MainFacilityAndMelterDoorAnim;

    void Start () {

        //Maintenance
        MaintenanceLights = transform.Find("MaintenanceAreaLights").GetComponent<VRTK_SnapDropZone>();
        MaintenanceMachinery = transform.Find("MaintenanceAreaMachinery").GetComponent<VRTK_SnapDropZone>();
        MaintenanceDoors = transform.Find("MaintenanceAreaDoors").GetComponent<VRTK_SnapDropZone>();

        MaintenanceLightsContainer = GameObject.Find("MaintenanceLightsContainer");

        MaintenanceDoorsPowered = false;

        JanitorDoorInner = GameObject.Find("JanitorDoorInner").GetComponentInChildren<VRTK_SnapDropZone>();
        JanitorDoorOuter = GameObject.Find("JanitorDoorOuter").GetComponentInChildren<VRTK_SnapDropZone>();

        JanitorDoorAnim = GameObject.Find("DoorToJanitorRoom").GetComponent<Animator>();

        BonsaiDoorInner = GameObject.Find("BonsaiDoorInner").GetComponentInChildren<VRTK_SnapDropZone>();
        BonsaiDoorOuter = GameObject.Find("BonsaiDoorOuter").GetComponentInChildren<VRTK_SnapDropZone>();

        BonsaiDoorAnim = GameObject.Find("BonsaiRoomDoor").GetComponent<Animator>();

        CorridorDoorToMainFacility = GameObject.Find("CorridorDoorToMainFacility").GetComponentInChildren<VRTK_PhysicsPusher>(); 

        //Main facility
        MainFacilityLights = transform.Find("MainFacilityLights").GetComponent<VRTK_SnapDropZone>();
        MainFacilityMachinery = transform.Find("MainFacilityMachinery").GetComponent<VRTK_SnapDropZone>();
        MainFacilityDoors = transform.Find("MainFacilityDoors").GetComponent<VRTK_SnapDropZone>();

        MainFacilityLightsContainer = GameObject.Find("MainFacilityLightsContainer");

        MainFacilityDoorsPowered = false;

        MainFacilityDoorToCorridor = GameObject.Find("MainFacilityDoorToCorridor").GetComponentInChildren<VRTK_PhysicsPusher>();

        MainFacilityDoorToBridge = GameObject.Find("MainFacilityDoorToBridge").GetComponentInChildren<VRTK_SnapDropZone>();
       
        MainFacilityDoorToMelter = GameObject.Find("MainFacilityDoorToMelter").GetComponentInChildren<VRTK_SnapDropZone>();

        //Bridge
        BridgeLights = transform.Find("BridgeLights").GetComponent<VRTK_SnapDropZone>();
        BridgeMachinery = transform.Find("BridgeMachinery").GetComponent<VRTK_SnapDropZone>();
        BridgeDoors = transform.Find("BridgeDoors").GetComponent<VRTK_SnapDropZone>();

        BridgeLightsContainer = GameObject.Find("BridgeLightsContainer");

        BridgeDoorsPowered = false;

        BridgeDoorToMainFacility = GameObject.Find("BridgeDoorToMainFacility").GetComponentInChildren<VRTK_SnapDropZone>();

        //Melter
        MelterLights = transform.Find("MelterLights").GetComponent<VRTK_SnapDropZone>();
        MelterMachinery = transform.Find("MelterMachinery").GetComponent<VRTK_SnapDropZone>();
        MelterDoors = transform.Find("MelterDoors").GetComponent<VRTK_SnapDropZone>();

        MelterLightsContainer = GameObject.Find("MelterLightsContainer");

        MelterDoorsPowered = false;

        MelterDoorToMainFacility = GameObject.Find("MelterDoorToMainFacility").GetComponentInChildren<VRTK_SnapDropZone>();

        //Double Door Animators

        MainFacilityAndCorridorDoorAnim = GameObject.Find("MainFacilityAndCorridorDoor").GetComponent<Animator>();

        MainFacilityAndBridgeDoorAnim = GameObject.Find("MF_DoorToBridge").GetComponent<Animator>();

        MainFacilityAndMelterDoorAnim = GameObject.Find("ME_DoorToMelter").GetComponent<Animator>();
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
                if (JanitorDoorOuter.GetCurrentSnappedObject() == null || JanitorDoorOuter.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 1)
                {
                    //Open Janitor door (from the inside)
                    StopCoroutine("DelayedAutomaticCloseJanitor");
                    JanitorDoorAnim.SetBool("OPEN", true);                  
                }
            }
            else if (JanitorDoorInner.GetCurrentSnappedObject() != null && JanitorDoorInner.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 1)
            {
                //show that the key is wrong to the player
            }
            if (JanitorDoorOuter.GetCurrentSnappedObject() != null && JanitorDoorOuter.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 1)
            {
                //in case the player has put another copy of the same key on the other side already, keeping it open, then adding a new key will not re-trigger the opening animation              
                if (JanitorDoorInner.GetCurrentSnappedObject() == null || JanitorDoorInner.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 1)
                {
                    //Open Janitor door (from the outside)
                    StopCoroutine("DelayedAutomaticCloseJanitor");
                    JanitorDoorAnim.SetBool("OPEN", true);
                }
            }
            else if (JanitorDoorOuter.GetCurrentSnappedObject() != null && JanitorDoorOuter.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 1)
            {
                //show that the key is wrong to the player
            }

            //check when to close the door (no correct key in either lock)
            if (JanitorDoorAnim.GetBool("OPEN") &&
               (JanitorDoorInner.GetCurrentSnappedObject() == null || JanitorDoorInner.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 1)
               && (JanitorDoorOuter.GetCurrentSnappedObject() == null || JanitorDoorOuter.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 1))
            {
                StartCoroutine("DelayedAutomaticCloseJanitor");
            }

            if (BonsaiDoorInner.GetCurrentSnappedObject() != null && BonsaiDoorInner.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 2)
            {
                //in case the player has put another copy of the same key on the other side already, keeping it open, then adding a new key will not re-trigger the opening animation            
                if (BonsaiDoorOuter.GetCurrentSnappedObject() == null || BonsaiDoorOuter.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2)
                {
                    //Open Bonsai door (from the inside)
                    StopCoroutine("DelayedAutomaticCloseBonsai");
                    BonsaiDoorAnim.SetBool("OPEN", true);
                }
            }
            else if (BonsaiDoorInner.GetCurrentSnappedObject() != null && BonsaiDoorInner.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2)
            {
                //show that the key is wrong to the player
            }

            if (BonsaiDoorOuter.GetCurrentSnappedObject() != null && BonsaiDoorOuter.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 2)
            {
                //in case the player has put another copy of the same key on the other side already, keeping it open, then adding a new key will not re-trigger the opening animation              
                if (BonsaiDoorInner.GetCurrentSnappedObject() == null || BonsaiDoorInner.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2)
                {
                    //Open Bonsai door (from the outside)
                    StopCoroutine("DelayedAutomaticCloseBonsai");
                    BonsaiDoorAnim.SetBool("OPEN", true);
                }
            }
            else if (BonsaiDoorOuter.GetCurrentSnappedObject() != null && BonsaiDoorOuter.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2)
            {
                //show that the key is wrong to the player
            }

            if (BonsaiDoorAnim.GetBool("OPEN") &&
               (BonsaiDoorInner.GetCurrentSnappedObject() == null || BonsaiDoorInner.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2)
               && (BonsaiDoorOuter.GetCurrentSnappedObject() == null || BonsaiDoorOuter.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2))
            {
                StartCoroutine("DelayedAutomaticCloseBonsai");
            }

            //CorridorDoorToMainFacility doesn't need a keycard, only button press
            //press starts a countdown of 10s, maybe visible in the door/panel? pressing again resets countdown
            if (CorridorDoorToMainFacility.AtMaxLimit())
            {
                StopCoroutine("DelayedAutomaticCloseCorridorToMF");
                MainFacilityAndCorridorDoorAnim.SetBool("OPENCORRIDORSIDE", true);
                StartCoroutine("DelayedAutomaticCloseCorridorToMF");
                if (MainFacilityDoorsPowered)
                {
                    StopCoroutine("DelayedAutomaticCloseMFToCorridor");
                    MainFacilityAndCorridorDoorAnim.SetBool("OPENMFSIDE", true);
                    StartCoroutine("DelayedAutomaticCloseMFToCorridor");
                }
            }
        }
        //in case no power doors shut instantly automatically no matter the key
        else
        {
            JanitorDoorAnim.SetBool("OPEN", false);
            BonsaiDoorAnim.SetBool("OPEN", false);
            MainFacilityAndCorridorDoorAnim.SetBool("OPENCORRIDORSIDE", false);
        }

        //MAIN FACILITY DOORS

        //MainFacilityDoorToCorridor doesn't need a keycard

        if (MainFacilityDoorsPowered)
        {
            //corridor door has a button no key
            if (MainFacilityDoorToCorridor.AtMaxLimit())
            {
                StopCoroutine("DelayedAutomaticCloseMFToCorridor");
                MainFacilityAndCorridorDoorAnim.SetBool("OPENCORRIDORSIDE", true);
                StartCoroutine("DelayedAutomaticCloseMFToCorridor");
                if (MaintenanceDoorsPowered) //not possible that this is not true in this scenario by design
                {
                    StopCoroutine("DelayedAutomaticCloseCorridorToMF");
                    MainFacilityAndCorridorDoorAnim.SetBool("OPENMFSIDE", true);
                    StartCoroutine("DelayedAutomaticCloseCorridorToMF");
                }
            }

            if (MainFacilityDoorToBridge.GetCurrentSnappedObject() != null && MainFacilityDoorToBridge.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 3
                && (BridgeDoorToMainFacility.GetCurrentSnappedObject() == null || BridgeDoorToMainFacility.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 3))
            {
                //open the door to Bridge 
                StopCoroutine("DelayedAutomaticCloseMFToBridge");
                MainFacilityAndBridgeDoorAnim.SetBool("OPENMFSIDE", true);
                if (BridgeDoorsPowered)
                {
                    StopCoroutine("DelayedAutomaticCloseBridgeToMF");
                    MainFacilityAndBridgeDoorAnim.SetBool("OPENBRIDGESIDE", true);
                }
            }
            else if (MainFacilityDoorToBridge.GetCurrentSnappedObject() != null && MainFacilityDoorToBridge.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 3)
            {
                //show that the key is wrong to the player
            }
            //start automatic closing if open and no key on either side
            if (MainFacilityAndBridgeDoorAnim.GetBool("OPENMFSIDE") && (MainFacilityDoorToBridge.GetCurrentSnappedObject() == null
                 || MainFacilityDoorToBridge.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 3) 
                 && (BridgeDoorToMainFacility.GetCurrentSnappedObject() == null || BridgeDoorToMainFacility.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 3))
            {                      
                 StartCoroutine("DelayedAutomaticCloseMFToBridge");
                 if (MainFacilityAndBridgeDoorAnim.GetBool("OPENBRIDGESIDE"))
                 {
                    StartCoroutine("DelayedAutomaticCloseBridgeToMF");
                 }
            }
            //Melter door MF side
            if (MainFacilityDoorToMelter.GetCurrentSnappedObject() != null && MainFacilityDoorToMelter.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 2
                && (MelterDoorToMainFacility.GetCurrentSnappedObject() == null || MelterDoorToMainFacility.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2))
            {
                //open the door to melter from MF
                StopCoroutine("DelayedAutomaticCloseMFToMelter");
                MainFacilityAndMelterDoorAnim.SetBool("OPENMFSIDE", true);
                if (MelterDoorsPowered)
                {
                    StopCoroutine("DelayedAutomaticCloseMelterToMF");
                    MainFacilityAndMelterDoorAnim.SetBool("OPENMELTERSIDE", true);
                }
            }
            else if (MainFacilityDoorToMelter.GetCurrentSnappedObject() != null && MainFacilityDoorToMelter.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2)
            {
                //show that the key is wrong to the player
            }
        }
        //in case no power doors shut instantly automatically no matter the key
        else
        {
            MainFacilityAndCorridorDoorAnim.SetBool("OPENMFSIDE", false);
            MainFacilityAndBridgeDoorAnim.SetBool("OPENMFSIDE", false);
        }

        //BRIDGE INNER DOOR

        if (BridgeDoorsPowered)
        {
            if (BridgeDoorToMainFacility.GetCurrentSnappedObject() != null && BridgeDoorToMainFacility.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 3
            && (MainFacilityDoorToBridge.GetCurrentSnappedObject() == null || MainFacilityDoorToBridge.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 3))
            {
                //open the door
                StopCoroutine("DelayedAutomaticCloseBridgeToMF");
                MainFacilityAndBridgeDoorAnim.SetBool("OPENBRIDGESIDE", true);
                StartCoroutine("DelayedAutomaticCloseBridgeToMF");
                if (MainFacilityDoorsPowered)
                {
                    StopCoroutine("DelayedAutomaticCloseMFToBridge");
                    MainFacilityAndBridgeDoorAnim.SetBool("OPENMFSIDE", true);
                    StartCoroutine("DelayedAutomaticCloseMFToBridge");
                }
            }
            else if (BridgeDoorToMainFacility.GetCurrentSnappedObject() != null && BridgeDoorToMainFacility.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 3)
            {
                //show that the key is wrong to the player
            }
        }
        else
        {
            MainFacilityAndBridgeDoorAnim.SetBool("OPENBRIDGESIDE", false);
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

    IEnumerator DelayedAutomaticCloseJanitor()
    {
        yield return new WaitForSecondsRealtime(10f);
        JanitorDoorAnim.SetBool("OPEN", false);
    }

    IEnumerator DelayedAutomaticCloseBonsai()
    {
        yield return new WaitForSecondsRealtime(10f);
        BonsaiDoorAnim.SetBool("OPEN", false);
    }

    IEnumerator DelayedAutomaticCloseCorridorToMF()
    {
        yield return new WaitForSecondsRealtime(10f);
        MainFacilityAndCorridorDoorAnim.SetBool("OPENCORRIDORSIDE", false);
    }

    IEnumerator DelayedAutomaticCloseMFToCorridor()
    {
        yield return new WaitForSecondsRealtime(10f);
        MainFacilityAndCorridorDoorAnim.SetBool("OPENMFSIDE", false);
    }

    IEnumerator DelayedAutomaticCloseMFToBridge()
    {
        yield return new WaitForSecondsRealtime(10f);
        MainFacilityAndBridgeDoorAnim.SetBool("OPENMFSIDE", false);
    }

    IEnumerator DelayedAutomaticCloseBridgeToMF()
    {
        yield return new WaitForSecondsRealtime(10f);
        MainFacilityAndBridgeDoorAnim.SetBool("OPENBRIDGESIDE", false);
    }
}
