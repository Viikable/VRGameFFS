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

    public static bool maintenanceDoorsPowered;

    public VRTK_SnapDropZone JanitorDoorInner;
    public VRTK_SnapDropZone JanitorDoorOuter;

    public bool janitorDoorOpen;
    public bool janitorDoorClosed;

    public bool janitorDoorOpening;
    public bool janitorDoorClosing;

    public Animator JanitorDoorAnim;

    public VRTK_SnapDropZone BonsaiDoorInner;
    public VRTK_SnapDropZone BonsaiDoorOuter;

    public bool bonsaiDoorOpen;
    public bool bonsaiDoorClosed;

    public bool bonsaiDoorOpening;
    public bool bonsaiDoorClosing;

    public Animator BonsaiDoorAnim;

    //public VRTK_SnapDropZone CorridorDoorToMainFacility;  actually works with a button
    public VRTK_PhysicsPusher CorridorDoorToMainFacility;

    public bool corridorToMFDoorOpen;
    public bool corridorToMFDoorClosed;

    public bool corridorToMFDoorOpening;
    public bool corridorToMFDoorClosing;

    [Header("MainFacility")]
    public VRTK_SnapDropZone MainFacilityLights;
    public VRTK_SnapDropZone MainFacilityMachinery;
    public VRTK_SnapDropZone MainFacilityDoors;

    GameObject MainFacilityLightsContainer;

    public static bool mainFacilityDoorsPowered;

    //button too
    public VRTK_PhysicsPusher MainFacilityDoorToCorridor;

    public bool mfToCorridorDoorOpen;
    public bool mfToCorridorDoorClosed;

    public bool mfToCorridorDoorOpening;
    public bool mfToCorridorDoorClosing;

    public VRTK_SnapDropZone MainFacilityDoorToBridge;

    public bool mfToBridgeDoorOpen;
    public bool mfToBridgeDoorClosed;

    public bool mfToBridgeDoorOpening;
    public bool mfToBridgeDoorClosing;

    public VRTK_SnapDropZone MainFacilityDoorToMelter;

    public bool mfToMelterDoorOpen;
    public bool mfToMelterDoorClosed;

    public bool mfToMelterDoorOpening;
    public bool mfToMelterDoorClosing;

    [Header("Bridge")]
    public VRTK_SnapDropZone BridgeLights;
    public VRTK_SnapDropZone BridgeMachinery;
    public VRTK_SnapDropZone BridgeDoors;

    GameObject BridgeLightsContainer;

    public static bool bridgeDoorsPowered;

    public VRTK_SnapDropZone BridgeDoorToMainFacility;

    public bool bridgeToMFDoorOpen;
    public bool bridgeToMFDoorClosed;

    public bool bridgeToMFDoorOpening;
    public bool bridgeToMFDoorClosing;

    [Header("Melter")]
    public VRTK_SnapDropZone MelterLights;
    public VRTK_SnapDropZone MelterMachinery;
    public VRTK_SnapDropZone MelterDoors;

    GameObject MelterLightsContainer;

    public static bool melterDoorsPowered;

    public VRTK_SnapDropZone MelterDoorToMainFacility;

    public bool melterToMFDoorOpen;
    public bool melterToMFDoorClosed;

    public bool melterToMFDoorOpening;
    public bool melterToMFDoorClosing;

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

        maintenanceDoorsPowered = false;

        JanitorDoorInner = GameObject.Find("JanitorDoorInner").GetComponentInChildren<VRTK_SnapDropZone>();
        JanitorDoorOuter = GameObject.Find("JanitorDoorOuter").GetComponentInChildren<VRTK_SnapDropZone>();

        janitorDoorOpen = false;
        janitorDoorClosed = true;

        janitorDoorOpening = false;
        janitorDoorClosing = false;

        JanitorDoorAnim = GameObject.Find("DoorToJanitorRoom").GetComponent<Animator>();

        BonsaiDoorInner = GameObject.Find("BonsaiDoorInner").GetComponentInChildren<VRTK_SnapDropZone>();
        BonsaiDoorOuter = GameObject.Find("BonsaiDoorOuter").GetComponentInChildren<VRTK_SnapDropZone>();

        bonsaiDoorOpen = false;
        bonsaiDoorClosed = true;

        bonsaiDoorOpening = false;
        bonsaiDoorClosing = false;

        BonsaiDoorAnim = GameObject.Find("BonsaiRoomDoor").GetComponent<Animator>();

        CorridorDoorToMainFacility = GameObject.Find("CorridorDoorToMainFacility").GetComponentInChildren<VRTK_PhysicsPusher>();

        corridorToMFDoorOpen = false;
        corridorToMFDoorClosed = true;

        corridorToMFDoorOpening = false;
        corridorToMFDoorClosing = false;

        //Main facility
        MainFacilityLights = transform.Find("MainFacilityLights").GetComponent<VRTK_SnapDropZone>();
        MainFacilityMachinery = transform.Find("MainFacilityMachinery").GetComponent<VRTK_SnapDropZone>();
        MainFacilityDoors = transform.Find("MainFacilityDoors").GetComponent<VRTK_SnapDropZone>();

        MainFacilityLightsContainer = GameObject.Find("MainFacilityLightsContainer");

        mainFacilityDoorsPowered = false;

        MainFacilityDoorToCorridor = GameObject.Find("MainFacilityDoorToCorridor").GetComponentInChildren<VRTK_PhysicsPusher>();

        mfToCorridorDoorOpen = false;
        mfToCorridorDoorClosed = true;

        mfToCorridorDoorOpening = false;
        mfToCorridorDoorClosing = false;

        MainFacilityDoorToBridge = GameObject.Find("MainFacilityDoorToBridge").GetComponentInChildren<VRTK_SnapDropZone>();

        mfToBridgeDoorOpen = false;
        mfToBridgeDoorClosed = true;

        mfToBridgeDoorOpening = false;
        mfToBridgeDoorClosing = false;

        MainFacilityDoorToMelter = GameObject.Find("MainFacilityDoorToMelter").GetComponentInChildren<VRTK_SnapDropZone>();

        mfToMelterDoorOpen = false;
        mfToMelterDoorClosed = true;

        mfToMelterDoorOpening = false;
        mfToMelterDoorClosing = false;

        //Bridge
        BridgeLights = transform.Find("BridgeLights").GetComponent<VRTK_SnapDropZone>();
        BridgeMachinery = transform.Find("BridgeMachinery").GetComponent<VRTK_SnapDropZone>();
        BridgeDoors = transform.Find("BridgeDoors").GetComponent<VRTK_SnapDropZone>();

        BridgeLightsContainer = GameObject.Find("BridgeLightsContainer");

        bridgeDoorsPowered = false;

        BridgeDoorToMainFacility = GameObject.Find("BridgeDoorToMainFacility").GetComponentInChildren<VRTK_SnapDropZone>();

        bridgeToMFDoorOpen = false;
        bridgeToMFDoorClosed = true;

        bridgeToMFDoorOpening = false;
        bridgeToMFDoorClosing = false;

        //Melter
        MelterLights = transform.Find("MelterLights").GetComponent<VRTK_SnapDropZone>();
        MelterMachinery = transform.Find("MelterMachinery").GetComponent<VRTK_SnapDropZone>();
        MelterDoors = transform.Find("MelterDoors").GetComponent<VRTK_SnapDropZone>();

        MelterLightsContainer = GameObject.Find("MelterLightsContainer");

        melterDoorsPowered = false;

        MelterDoorToMainFacility = GameObject.Find("MelterDoorToMainFacility").GetComponentInChildren<VRTK_SnapDropZone>();

        melterToMFDoorOpen = false;
        melterToMFDoorClosed = true;

        melterToMFDoorOpening = false;
        melterToMFDoorClosing = false;

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
            maintenanceDoorsPowered = true;
        }
        else
        {
            //turn MaintenanceDoors off
            maintenanceDoorsPowered = false;
        }

        if (MainFacilityDoors.GetCurrentSnappedObject() != null)
        {
            //turn MainFacilityDoors on
            mainFacilityDoorsPowered = true;
        }
        else
        {
            //turn MainFacilityDoors off
            mainFacilityDoorsPowered = false;
        }

        if (BridgeDoors.GetCurrentSnappedObject() != null)
        {
            //turn BridgeDoors on
            bridgeDoorsPowered = true;
        }
        else
        {
            //turn BridgeDoors off
            bridgeDoorsPowered = false;
        }

        if (MelterDoors.GetCurrentSnappedObject() != null)
        {
            //turn MelterDoors on
            melterDoorsPowered = true;
        }
        else
        {
            //turn MelterDoors off
            melterDoorsPowered = false;
        }

    }

    private void OpenDoors()
    {
        // keys stay inside and do nothing if wrong clearance level

        //Maintenance area 

        if (maintenanceDoorsPowered)
        {
            if (JanitorDoorInner.GetCurrentSnappedObject() != null && JanitorDoorInner.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 1
               && !janitorDoorClosing && !janitorDoorOpening)
            {                             
                if (janitorDoorClosed)
                    {                    
                    //Open Janitor door (from the inside)                                                                                   
                    StartCoroutine("JanitorDoorOpening");                   
                }
                else //aka it is open
                {
                    StopCoroutine("DelayedAutomaticCloseJanitor");  //ends the 10 second countdown of door closing     
                }
            }
            else if (JanitorDoorInner.GetCurrentSnappedObject() != null && JanitorDoorInner.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 1)
            {
                //show that the key is wrong to the player
            }
            if (JanitorDoorOuter.GetCurrentSnappedObject() != null && JanitorDoorOuter.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 1
               && !janitorDoorClosing && !janitorDoorOpening)
            {
                //in case the player has put another copy of the same key on the other side already, keeping it open, then adding a new key will not re-trigger the opening animation              
                if (janitorDoorClosed)
                {
                    //Open Janitor door (from the outside)                                                                        
                    StartCoroutine("JanitorDoorOpening");
                }
                else //aka it is open
                {
                    StopCoroutine("DelayedAutomaticCloseJanitor");  //ends the 10 second countdown of door closing     
                }
            }
            else if (JanitorDoorOuter.GetCurrentSnappedObject() != null && JanitorDoorOuter.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 1)
            {
                //show that the key is wrong to the player
            }

            //check when to close the door (no correct key in either lock)
            if (janitorDoorOpen &&
               (JanitorDoorInner.GetCurrentSnappedObject() == null || JanitorDoorInner.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 1)
               && (JanitorDoorOuter.GetCurrentSnappedObject() == null || JanitorDoorOuter.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 1))
            {
                //waits 10 seconds and then starts closing the door for 3 s
                StartCoroutine("DelayedAutomaticCloseJanitor");              
            }

            if (BonsaiDoorInner.GetCurrentSnappedObject() != null && BonsaiDoorInner.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 2
                && !bonsaiDoorClosing && !bonsaiDoorOpening)
            {
                //in case the player has put another copy of the same key on the other side already, keeping it open, then adding a new key will not re-trigger the opening animation            
                if (bonsaiDoorClosed)
                {
                    //Open Bonsai door (from the inside)                                  
                    StartCoroutine("BonsaiDoorOpening");
                }
                else //aka it is open
                {
                    StopCoroutine("DelayedAutomaticCloseBonsai");  //ends the 10 second countdown of door closing     
                }
            }
            else if (BonsaiDoorInner.GetCurrentSnappedObject() != null && BonsaiDoorInner.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2)
            {
                //show that the key is wrong to the player
            }

            if (BonsaiDoorOuter.GetCurrentSnappedObject() != null && BonsaiDoorOuter.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 2 
                && !bonsaiDoorClosing && !bonsaiDoorOpening)
            {
                if (bonsaiDoorClosed)
                {
                    //Open Bonsai door (from the inside)                                  
                    StartCoroutine("BonsaiDoorOpening");
                }
                else //aka it is open
                {
                    StopCoroutine("DelayedAutomaticCloseBonsai");  //ends the 10 second countdown of door closing (if there was no key on the other side, otherwise stops a nonexisting co-routine)     
                }
            }
            else if (BonsaiDoorOuter.GetCurrentSnappedObject() != null && BonsaiDoorOuter.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2)
            {
                //show that the key is wrong to the player
            }

            if (bonsaiDoorOpen &&
               (BonsaiDoorInner.GetCurrentSnappedObject() == null || BonsaiDoorInner.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2)
               && (BonsaiDoorOuter.GetCurrentSnappedObject() == null || BonsaiDoorOuter.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2))
            {
                StartCoroutine("DelayedAutomaticCloseBonsai");               
            }

            //CorridorDoorToMainFacility doesn't need a keycard, only button press
            //press starts a countdown of 10s, maybe visible in the door/panel? pressing again resets countdown
            //door has to be fully closed in order to open
            if (CorridorDoorToMainFacility.AtMaxLimit() && !corridorToMFDoorOpening && !corridorToMFDoorClosing)
            {
                //if closed, then open
                if (corridorToMFDoorClosed)
                {                                            
                    StartCoroutine("CorridorToMFDoorOpening");              
                }
                //if open already, then reset door timer
                else
                {
                    StopCoroutine("DelayedAutomaticCloseCorridorToMF");
                }
                //if MF powered
                if (mainFacilityDoorsPowered && !mfToCorridorDoorClosing && !mfToCorridorDoorOpening)
                {
                    //if MF side door is closed, open it
                    if (mfToCorridorDoorClosed)
                    {
                        StartCoroutine("MFToCorridorDoorOpening");
                    }
                    else //aka it is open
                    {
                        StopCoroutine("DelayedAutomaticCloseMFToCorridor");  //ends the 10 second countdown of door closing     
                    }
                }
            }
        }
        //in case no power doors get stuck in the position they are in
        else
        {
            //JanitorDoorAnim.SetBool("OPEN", false);
            //BonsaiDoorAnim.SetBool("OPEN", false);
            //MainFacilityAndCorridorDoorAnim.SetBool("OPENCORRIDORSIDE", false);
        }

        //MAIN FACILITY DOORS

        //MainFacilityDoorToCorridor doesn't need a keycard

        if (mainFacilityDoorsPowered)
        {          
            //MF to Corridor
            if (MainFacilityDoorToCorridor.AtMaxLimit() && !mfToCorridorDoorOpening && !mfToCorridorDoorClosing)
            {
                if (mfToCorridorDoorClosed)
                {
                    StartCoroutine("MFToCorridorDoorOpening");
                }
                //if open already, then reset door timer
                else
                {
                    StopCoroutine("DelayedAutomaticCloseMFToCorridor");
                }
                //if corridor powered
                if (maintenanceDoorsPowered && !corridorToMFDoorOpening && !corridorToMFDoorClosing)
                {
                    //if corridor side door is closed, open it
                    if (corridorToMFDoorClosed)
                    {
                        StartCoroutine("CorridorToMFDoorOpening");
                    }
                    else //aka it is open
                    {
                        StopCoroutine("DelayedAutomaticCloseCorridorToMF");  //ends the 10 second countdown of door closing     
                    }
                }
            }
            //MF to Bridge
            if (MainFacilityDoorToBridge.GetCurrentSnappedObject() != null && MainFacilityDoorToBridge.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 3
                && !mfToBridgeDoorClosing && !mfToBridgeDoorOpening)
            {
                //open the door to Bridge 
                if (mfToBridgeDoorClosed)
                {
                    StartCoroutine("MFToBridgeDoorOpening");
                }
                else
                {
                    StopCoroutine("DelayedAutomaticCloseMFToBridge");
                }
                if (bridgeDoorsPowered && !bridgeToMFDoorOpening && !bridgeToMFDoorClosing) //probably unnecessary to check for closing and opening here too
                {
                    if (bridgeToMFDoorClosed)
                    {
                        StartCoroutine("BridgeToMFDoorOpening");
                    }
                    else
                    {
                        StopCoroutine("DelayedAutomaticCloseBridgeToMF");
                    }
                }
            }
            else if (MainFacilityDoorToBridge.GetCurrentSnappedObject() != null && MainFacilityDoorToBridge.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 3)
            {
                //show that the key is wrong to the player
            }
            //start automatic closing if open and no key on either side
            if (mfToBridgeDoorOpen && 
                (MainFacilityDoorToBridge.GetCurrentSnappedObject() == null || MainFacilityDoorToBridge.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 3) 
                 && (BridgeDoorToMainFacility.GetCurrentSnappedObject() == null || BridgeDoorToMainFacility.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 3))
            {                      
                 StartCoroutine("DelayedAutomaticCloseMFToBridge");
                 if (bridgeDoorsPowered && bridgeToMFDoorOpen)
                 {
                    StartCoroutine("DelayedAutomaticCloseBridgeToMF");
                 }
            }
            //Melter door MF side
            if (MainFacilityDoorToMelter.GetCurrentSnappedObject() != null && MainFacilityDoorToMelter.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 2
                && !mfToMelterDoorClosing && !mfToMelterDoorOpening)
            {
                //open the door to melter from MF
                if (mfToMelterDoorClosed)
                {
                    StartCoroutine("MFToMelterDoorOpening");
                }
                else
                {
                    StopCoroutine("DelayedAutomaticCloseMFToMelter");
                }
                if (melterDoorsPowered && !melterToMFDoorOpening && !melterToMFDoorClosing) //probably unnecessary to check for closing and opening here too
                {
                    if (melterToMFDoorClosed)
                    {
                        StartCoroutine("MelterToMFDoorOpening");
                    }
                    else
                    {
                        StopCoroutine("DelayedAutomaticCloseMelterToMF");
                    }
                }
            }
            else if (MainFacilityDoorToMelter.GetCurrentSnappedObject() != null && MainFacilityDoorToMelter.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2)
            {
                //show that the key is wrong to the player
            }

            if (mfToMelterDoorOpen 
                && (MainFacilityDoorToMelter.GetCurrentSnappedObject() == null || MainFacilityDoorToMelter.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2)
                && (MelterDoorToMainFacility.GetCurrentSnappedObject() == null || MelterDoorToMainFacility.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2))
            {
                StartCoroutine("DelayedAutomaticCloseMFToMelter");
                if (melterDoorsPowered && melterToMFDoorOpen)
                {
                    StartCoroutine("DelayedAutomaticCloseMelterToMF");
                }
            }
        }
        //in case no power doors get stuck to their positions (closed or open) only janitor might get stuck in between thanks to timing
        else
        {
            //MainFacilityAndCorridorDoorAnim.SetBool("OPENMFSIDE", false);
            //MainFacilityAndBridgeDoorAnim.SetBool("OPENMFSIDE", false);
            //MainFacilityAndMelterDoorAnim.SetBool("OPENMFSIDE", false);
        }

        //BRIDGE INNER DOOR

        if (bridgeDoorsPowered)
        {
            if (BridgeDoorToMainFacility.GetCurrentSnappedObject() != null && BridgeDoorToMainFacility.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 3
            && !bridgeToMFDoorClosing && !bridgeToMFDoorOpening)
            {
                //open the door from Bridge to MF
                if (bridgeToMFDoorClosed)
                {
                    StartCoroutine("BridgeToMFDoorOpening");
                }
                else
                {
                    StopCoroutine("DelayedAutomaticCloseBridgeToMF");
                }
                if (mainFacilityDoorsPowered && !mfToBridgeDoorOpening && !mfToBridgeDoorClosing) //probably unnecessary to check for closing and opening here too
                {
                    if (mfToBridgeDoorClosed)
                    {
                        StartCoroutine("MFToBridgeDoorOpening");
                    }
                    else
                    {
                        StopCoroutine("DelayedAutomaticCloseMFToBridge");
                    }
                }
            }
            else if (BridgeDoorToMainFacility.GetCurrentSnappedObject() != null && BridgeDoorToMainFacility.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 3)
            {
                //show that the key is wrong to the player
            }
           
            if (bridgeToMFDoorOpen
                && (BridgeDoorToMainFacility.GetCurrentSnappedObject() == null || BridgeDoorToMainFacility.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 3)
                && (MainFacilityDoorToBridge.GetCurrentSnappedObject() == null || MainFacilityDoorToBridge.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 3))
            {
                StartCoroutine("DelayedAutomaticCloseBridgeToMF");
                if (mainFacilityDoorsPowered && mfToBridgeDoorOpen)
                {
                    StartCoroutine("DelayedAutomaticCloseMFToBridge");
                }
            }          
        }
        else  //doors stay put
        {
            //MainFacilityAndBridgeDoorAnim.SetBool("OPENBRIDGESIDE", false);
        }

        //MELTER DOOR

        if (melterDoorsPowered)
        {
            if (MelterDoorToMainFacility.GetCurrentSnappedObject() != null && MelterDoorToMainFacility.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 2
                && !melterToMFDoorClosing && !melterToMFDoorOpening)
            {
                //open the door to MF from Melter
                if (melterToMFDoorClosed)
                {
                    StartCoroutine("MelterToMFDoorOpening");
                }
                else
                {
                    StopCoroutine("DelayedAutomaticCloseMelterToMF");
                }
                if (mainFacilityDoorsPowered && !mfToMelterDoorOpening && !mfToMelterDoorClosing) //probably unnecessary to check for closing and opening here too
                {
                    if (mfToMelterDoorClosed)
                    {
                        StartCoroutine("MFToMelterDoorOpening");
                    }
                    else
                    {
                        StopCoroutine("DelayedAutomaticCloseMFToMelter");
                    }
                }
            }
            else if (MelterDoorToMainFacility.GetCurrentSnappedObject() != null && MelterDoorToMainFacility.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2)
            {
                //show that the key is wrong to the player
            }

            if (melterToMFDoorOpen
                && (MelterDoorToMainFacility.GetCurrentSnappedObject() == null || MelterDoorToMainFacility.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2)
                && (MainFacilityDoorToMelter.GetCurrentSnappedObject() == null || MainFacilityDoorToMelter.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2))
            {
                StartCoroutine("DelayedAutomaticCloseMelterToMF");
                if (mainFacilityDoorsPowered && mfToMelterDoorOpen)
                {
                    StartCoroutine("DelayedAutomaticCloseMFToMelter");
                }
            }
        }
    }

    IEnumerator DelayedAutomaticCloseJanitor()
    {
        yield return new WaitForSecondsRealtime(10f);
        JanitorDoorAnim.SetBool("OPEN", false);
        janitorDoorClosing = true;
        janitorDoorOpen = false;
        yield return new WaitForSecondsRealtime(3f);
        janitorDoorClosing = false;
        janitorDoorClosed = true;
    }

    IEnumerator JanitorDoorOpening()
    {
        JanitorDoorAnim.SetBool("OPEN", true);
        janitorDoorOpening = true;
        janitorDoorClosed = false;
        yield return new WaitForSecondsRealtime(3f);
        janitorDoorOpening = false;
        janitorDoorOpen = true;
    }

    IEnumerator DelayedAutomaticCloseBonsai()
    {
        yield return new WaitForSecondsRealtime(10f);
        BonsaiDoorAnim.SetBool("OPEN", false);
        bonsaiDoorClosing = true;
        bonsaiDoorOpen = false;
        yield return new WaitForSecondsRealtime(3f); //door closing time is 3s atm
        bonsaiDoorClosed = true;
        bonsaiDoorClosing = false;
    }

    IEnumerator BonsaiDoorOpening()
    {
        BonsaiDoorAnim.SetBool("OPEN", true);
        bonsaiDoorOpening = true;
        bonsaiDoorClosed = false;
        yield return new WaitForSecondsRealtime(3f); //door opening time is 3s atm
        bonsaiDoorOpening = false;
        bonsaiDoorOpen = true;
    }

    IEnumerator DelayedAutomaticCloseCorridorToMF()
    {
        yield return new WaitForSecondsRealtime(10f);
        MainFacilityAndCorridorDoorAnim.SetBool("OPENCORRIDORSIDE", false);
        corridorToMFDoorClosing = true;
        corridorToMFDoorOpen = false;
        yield return new WaitForSecondsRealtime(3f);
        corridorToMFDoorClosed = true;
        corridorToMFDoorClosing = false;
    }

    IEnumerator CorridorToMFDoorOpening()
    {
        MainFacilityAndCorridorDoorAnim.SetBool("OPENCORRIDORSIDE", true);
        corridorToMFDoorOpening = true;
        corridorToMFDoorClosed = false;
        yield return new WaitForSecondsRealtime(3f); //door closing time is 3s atm
        corridorToMFDoorOpening = false;
        corridorToMFDoorOpen = true;
        //after button press door opens, start counting down for closing
        StartCoroutine("DelayedAutomaticCloseCorridorToMF");
    }

    IEnumerator DelayedAutomaticCloseMFToCorridor()
    {
        yield return new WaitForSecondsRealtime(10f);
        MainFacilityAndCorridorDoorAnim.SetBool("OPENMFSIDE", false);
        mfToCorridorDoorClosing = true;
        mfToCorridorDoorOpen = false;
        yield return new WaitForSecondsRealtime(3f);
        mfToCorridorDoorClosed = true;
        mfToCorridorDoorClosing = false;
    }

    IEnumerator MFToCorridorDoorOpening()
    {
        MainFacilityAndCorridorDoorAnim.SetBool("OPENMFSIDE", true);
        mfToCorridorDoorOpening = true;
        mfToCorridorDoorClosed = false;
        yield return new WaitForSecondsRealtime(3f); //door closing time is 3s atm
        mfToCorridorDoorOpening = false;
        mfToCorridorDoorOpen = true;
        //after button press door opens, start counting down for closing
        StartCoroutine("DelayedAutomaticCloseMFToCorridor");
    }

    IEnumerator DelayedAutomaticCloseMFToBridge()
    {
        yield return new WaitForSecondsRealtime(10f);
        MainFacilityAndBridgeDoorAnim.SetBool("OPENMFSIDE", false);
        mfToBridgeDoorClosing = true;
        mfToBridgeDoorOpen = false;
        yield return new WaitForSecondsRealtime(3f);
        mfToBridgeDoorClosed = true;
        mfToBridgeDoorClosing = false;
    }

    IEnumerator MFToBridgeDoorOpening()
    {
        MainFacilityAndBridgeDoorAnim.SetBool("OPENMFSIDE", true);
        mfToBridgeDoorOpening = true;
        mfToBridgeDoorClosed = false;
        yield return new WaitForSecondsRealtime(3f); //door closing time is 3s atm
        mfToBridgeDoorOpening = false;
        mfToBridgeDoorOpen = true;     
    }

    IEnumerator DelayedAutomaticCloseBridgeToMF()
    {
        yield return new WaitForSecondsRealtime(10f);
        MainFacilityAndBridgeDoorAnim.SetBool("OPENBRIDGESIDE", false);
        bridgeToMFDoorClosing = true;
        bridgeToMFDoorOpen = false;
        yield return new WaitForSecondsRealtime(3f);
        bridgeToMFDoorClosed = true;
        bridgeToMFDoorClosing = false;
    }

    IEnumerator BridgeToMFDoorOpening()
    {
        MainFacilityAndBridgeDoorAnim.SetBool("OPENBRIDGESIDE", true);
        bridgeToMFDoorOpening = true;
        bridgeToMFDoorClosed = false;
        yield return new WaitForSecondsRealtime(3f); //door closing time is 3s atm
        bridgeToMFDoorOpening = false;
        bridgeToMFDoorOpen = true;       
    }

    IEnumerator DelayedAutomaticCloseMFToMelter()
    {
        yield return new WaitForSecondsRealtime(10f);
        MainFacilityAndMelterDoorAnim.SetBool("OPENMFSIDE", false);
        mfToMelterDoorClosing = true;
        mfToMelterDoorOpen = false;
        yield return new WaitForSecondsRealtime(3f);
        mfToMelterDoorClosed = true;
        mfToMelterDoorClosing = false;
    }

    IEnumerator MFToMelterDoorOpening()
    {
        MainFacilityAndBridgeDoorAnim.SetBool("OPENMFSIDE", true);
        mfToMelterDoorOpening = true;
        mfToMelterDoorClosed = false;
        yield return new WaitForSecondsRealtime(3f); //door closing time is 3s atm
        mfToMelterDoorOpening = false;
        mfToMelterDoorOpen = true;      
    }

    IEnumerator DelayedAutomaticCloseMelterToMF()
    {
        yield return new WaitForSecondsRealtime(10f);
        MainFacilityAndMelterDoorAnim.SetBool("OPENMELTERSIDE", false);
        melterToMFDoorClosing = true;
        melterToMFDoorOpen = false;
        yield return new WaitForSecondsRealtime(3f);
        melterToMFDoorClosed = true;
        melterToMFDoorClosing = false;
    }

    IEnumerator MelterToMFDoorOpening()
    {
        MainFacilityAndBridgeDoorAnim.SetBool("OPENMELTERSIDE", true);
        melterToMFDoorOpening = true;
        melterToMFDoorClosed = false;
        yield return new WaitForSecondsRealtime(3f); //door closing time is 3s atm
        melterToMFDoorOpening = false;
        melterToMFDoorOpen = true;      
    }
}
