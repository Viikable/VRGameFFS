using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables.PhysicsBased;

public class FuseboxFunctionality : MonoBehaviour {

    [Header("Machinery")]

    public BridgeKeyConfiguration BridgeTerminal;

    public KeyboardMappings MelterTerminal;

    public VRTK_SnapDropZone BonsaiOxygenControlMachinery;

    [Header("MaintenanceArea Lights")]
    public VRTK_SnapDropZone MaintenanceCorridorLights;
    public VRTK_SnapDropZone BonsaiLights;
    public VRTK_SnapDropZone JanitorLights;

    GameObject MaintenanceLightsContainer;

    [Header("Door Power settings")]
    public VRTK_SnapDropZone MaintenanceCorridorDoorsFuse;
    public VRTK_SnapDropZone BonsaiDoorFuse;
    public VRTK_SnapDropZone JanitorDoorFuse;

    public static bool corridorDoorsPowered;
    public static bool bonsaiDoorPowered;
    public static bool janitorDoorPowered;

    [Header("Corridor side doors")]
    public VRTK_SnapDropZone JanitorDoorToCorridorSnapZone;
    public VRTK_SnapDropZone CorridorDoorToJanitorSnapZone;

    [Header("Doors between janitor room and corridor open/close states")]
    public bool janitorToCorridorDoorOpen;
    public bool corridorToJanitorDoorOpen;

    public bool janitorToCorridorDoorClosed;
    public bool corridorToJanitorDoorClosed;

    public bool janitorToCorridorDoorOpening;
    public bool corridorToJanitorDoorOpening;

    public bool janitorToCorridorDoorClosing;
    public bool corridorToJanitorDoorClosing;

    public bool janitorToCorridorDoorClosingSoon;
    public bool corridorToJanitorDoorClosingSoon;

    [Header("Bonsai side doors")]
    public VRTK_SnapDropZone BonsaiDoorToCorridorSnapZone;
    public VRTK_SnapDropZone CorridorDoorToBonsaiSnapZone;

    [Header("Doors between bonsai room and corridor open/close states")]
    public bool bonsaiToCorridorDoorOpen;
    public bool corridorToBonsaiDoorOpen;

    public bool bonsaiToCorridorDoorClosed;
    public bool corridorToBonsaiDoorClosed;

    public bool bonsaiToCorridorDoorOpening;
    public bool corridorToBonsaiDoorOpening;

    public bool bonsaiToCorridorDoorClosing;
    public bool corridorToBonsaiDoorClosing;

    public bool bonsaiToCorridorDoorClosingSoon;
    public bool corridorToBonsaiDoorClosingSoon;

    //public VRTK_SnapDropZone CorridorDoorToMainFacility;  actually works with a button
    public VRTK_PhysicsPusher CorridorDoorToMainFacilityButton;

    [Header("Doors from corridor to MF open/close states")]
    public bool corridorToMFDoorOpen;
    public bool corridorToMFDoorClosed;

    public bool corridorToMFDoorOpening;
    public bool corridorToMFDoorClosing;

    public bool corridorToMFDoorClosingSoon;

    [Header("MainFacility")]
    public VRTK_SnapDropZone MainFacilityLights;
    public VRTK_SnapDropZone MainFacilityMachinery;
    public VRTK_SnapDropZone MainFacilityDoorsFuse;

    GameObject MainFacilityLightsContainer;

    public static bool mainFacilityDoorsPowered;

    //button too
    public VRTK_PhysicsPusher MainFacilityDoorToCorridorButton;

    [Header("Doors from MF to corridor open/close states")]
    public bool mfToCorridorDoorOpen;
    public bool mfToCorridorDoorClosed;

    public bool mfToCorridorDoorOpening;
    public bool mfToCorridorDoorClosing;

    public bool mfToCorridorDoorClosingSoon;

    public VRTK_SnapDropZone MainFacilityDoorToBridgeSnapZone;

    [Header("Doors from MF to Bridge (elevator) open/close states")]
    public bool mfToBridgeDoorOpen;
    public bool mfToBridgeDoorClosed;

    public bool mfToBridgeDoorOpening;
    public bool mfToBridgeDoorClosing;

    public bool mfToBridgeDoorClosingSoon;

    public VRTK_SnapDropZone MainFacilityDoorToMelterSnapZone;

    [Header("Doors from MF to melter open/close states")]
    public bool mfToMelterDoorOpen;
    public bool mfToMelterDoorClosed;

    public bool mfToMelterDoorOpening;
    public bool mfToMelterDoorClosing;

    public bool mfToMelterDoorClosingSoon;

    [Header("Bridge")]
    public VRTK_SnapDropZone BridgeLights;
    public VRTK_SnapDropZone BridgeMachinery;
    public VRTK_SnapDropZone BridgeDoorsFuse;

    GameObject BridgeLightsContainer;

    public static bool bridgeDoorsPowered;

    public VRTK_SnapDropZone BridgeDoorToMainFacilitySnapZone;

    [Header("Doors from bridge to MF open/close states")]
    public bool bridgeToMFDoorOpen;
    public bool bridgeToMFDoorClosed;

    public bool bridgeToMFDoorOpening;
    public bool bridgeToMFDoorClosing;

    public bool bridgeToMFDoorClosingSoon;

    [Header("Melter")]
    public VRTK_SnapDropZone MelterLights;
    public VRTK_SnapDropZone MelterMachinery;
    public VRTK_SnapDropZone MelterDoorsFuse;

    GameObject MelterLightsContainer;

    public static bool melterDoorsPowered;

    public VRTK_SnapDropZone MelterDoorToMainFacilitySnapZone;

    [Header("Doors from melter to MF open/close states")]
    public bool melterToMFDoorOpen;
    public bool melterToMFDoorClosed;

    public bool melterToMFDoorOpening;
    public bool melterToMFDoorClosing;

    public bool melterToMFDoorClosingSoon;

    [Header("DoubleDoorAnimators")]

    public Animator JanitorDoorInnerAnim;
    public Animator JanitorDoorOuterAnim;

    public Animator BonsaiDoorInnerAnim;
    public Animator BonsaiDoorOuterAnim;

    public Animator MainFacilityToCorridorDoorAnim;
    public Animator CorridorToMFDoorAnim;

    public Animator MainFacilityToBridgeDoorAnim;
    public Animator BridgeToMFDoorAnim;

    public Animator MainFacilityToMelterDoorAnim;
    public Animator MelterToMFDoorAnim;

    [Header("Sounds")]

    [Header("JanitorSounds")]

    public AudioSource InnerJanitorDoorOpeningSound;
    public AudioSource InnerJanitorDoorOpenSound;
    public AudioSource InnerJanitorDoorClosingSound;
    public AudioSource InnerJanitorDoorClosedSound;
    public AudioSource InnerJanitorDoorAlarmSound;

    public AudioSource InnerJanitorDoorCountdown;

    public AudioSource OuterJanitorDoorOpeningSound;
    public AudioSource OuterJanitorDoorOpenSound;
    public AudioSource OuterJanitorDoorClosingSound;
    public AudioSource OuterJanitorDoorClosedSound;
    public AudioSource OuterJanitorDoorAlarmSound;

    public AudioSource OuterJanitorDoorCountdown;

    [Header("CorridorAndMFDoorSounds")]

    public AudioSource MF_ToCorridorDoorOpeningSound;
    public AudioSource MF_ToCorridorDoorOpenSound;
    public AudioSource MF_ToCorridorDoorClosingSound;
    public AudioSource MF_ToCorridorDoorClosedSound;
    public AudioSource MF_ToCorridorDoorAlarmSound;

    public AudioSource MF_ToCorridorDoorCountdown;

    public AudioSource Corridor_ToMFDoorOpeningSound;
    public AudioSource Corridor_ToMFDoorOpenSound;
    public AudioSource Corridor_ToMFDoorClosingSound;
    public AudioSource Corridor_ToMFDoorClosedSound;
    public AudioSource Corridor_ToMFDoorAlarmSound;

    public AudioSource Corridor_ToMFDoorCountdown;

    void Start () {

        BridgeTerminal = GameObject.Find("BRIDGE").GetComponentInChildren<BridgeKeyConfiguration>();
        MelterTerminal = GameObject.Find("MelterTerminal").GetComponent<KeyboardMappings>();

        //Maintenance
        MaintenanceCorridorLights = transform.Find("MaintenanceCorridorLights").GetComponent<VRTK_SnapDropZone>();
        BonsaiLights = transform.Find("BonsaiLights").GetComponent<VRTK_SnapDropZone>();
        JanitorLights = transform.Find("JanitorLights").GetComponent<VRTK_SnapDropZone>();

        BonsaiOxygenControlMachinery = transform.Find("BonsaiMachinery").GetComponent<VRTK_SnapDropZone>();

        MaintenanceCorridorDoorsFuse = transform.Find("MaintenanceCorridorDoors").GetComponent<VRTK_SnapDropZone>();
        BonsaiDoorFuse = transform.Find("BonsaiDoor").GetComponent<VRTK_SnapDropZone>();
        JanitorDoorFuse = transform.Find("JanitorDoor").GetComponent<VRTK_SnapDropZone>();

        MaintenanceLightsContainer = GameObject.Find("MaintenanceLightsContainer");

        corridorDoorsPowered = false;
        bonsaiDoorPowered = false;
        janitorDoorPowered = false;

        JanitorDoorToCorridorSnapZone = GameObject.Find("JanitorDoorInnerSnapZone").GetComponentInChildren<VRTK_SnapDropZone>();
        CorridorDoorToJanitorSnapZone = GameObject.Find("JanitorDoorOuterSnapZone").GetComponentInChildren<VRTK_SnapDropZone>();

        janitorToCorridorDoorOpen = false;
        janitorToCorridorDoorClosed = true;

        corridorToJanitorDoorClosed = true;
        corridorToJanitorDoorOpen = false;

        janitorToCorridorDoorOpening = false;
        corridorToJanitorDoorOpening = false;

        janitorToCorridorDoorClosing = false;
        corridorToJanitorDoorClosing = false;

        janitorToCorridorDoorClosingSoon = false;
        corridorToJanitorDoorClosingSoon = false;

        BonsaiDoorToCorridorSnapZone = GameObject.Find("BonsaiDoorInnerSnapZone").GetComponentInChildren<VRTK_SnapDropZone>();
        CorridorDoorToBonsaiSnapZone = GameObject.Find("BonsaiDoorOuterSnapZone").GetComponentInChildren<VRTK_SnapDropZone>();

        bonsaiToCorridorDoorOpen = false;
        corridorToBonsaiDoorOpen = false;

        bonsaiToCorridorDoorClosed = true;
        corridorToBonsaiDoorClosed = true;

        bonsaiToCorridorDoorOpening = false;
        corridorToBonsaiDoorOpening = false;

        bonsaiToCorridorDoorClosing = false;
        corridorToBonsaiDoorClosing = false;

        bonsaiToCorridorDoorClosingSoon = false;
        corridorToBonsaiDoorClosingSoon = false;

        CorridorDoorToMainFacilityButton = GameObject.Find("CorridorDoorToMainFacilityButton").GetComponentInChildren<VRTK_PhysicsPusher>();

        corridorToMFDoorOpen = false;
        corridorToMFDoorClosed = true;

        corridorToMFDoorOpening = false;
        corridorToMFDoorClosing = false;

        corridorToMFDoorClosingSoon = false;

        //Main facility
        MainFacilityLights = transform.Find("MainFacilityLights").GetComponent<VRTK_SnapDropZone>();
        MainFacilityMachinery = transform.Find("MainFacilityMachinery").GetComponent<VRTK_SnapDropZone>();
        MainFacilityDoorsFuse = transform.Find("MainFacilityDoors").GetComponent<VRTK_SnapDropZone>();

        MainFacilityLightsContainer = GameObject.Find("MainFacilityLightsContainer");

        mainFacilityDoorsPowered = false;

        MainFacilityDoorToCorridorButton = GameObject.Find("MainFacilityDoorToCorridorButton").GetComponentInChildren<VRTK_PhysicsPusher>();

        mfToCorridorDoorOpen = false;
        mfToCorridorDoorClosed = true;

        mfToCorridorDoorOpening = false;
        mfToCorridorDoorClosing = false;

        mfToCorridorDoorClosingSoon = false;

        MainFacilityDoorToBridgeSnapZone = GameObject.Find("MainFacilityDoorToBridgeSnapZone").GetComponentInChildren<VRTK_SnapDropZone>();

        mfToBridgeDoorOpen = false;
        mfToBridgeDoorClosed = true;

        mfToBridgeDoorOpening = false;
        mfToBridgeDoorClosing = false;

        mfToBridgeDoorClosingSoon = false;

        MainFacilityDoorToMelterSnapZone = GameObject.Find("MainFacilityDoorToMelterSnapZone").GetComponentInChildren<VRTK_SnapDropZone>();

        mfToMelterDoorOpen = false;
        mfToMelterDoorClosed = true;

        mfToMelterDoorOpening = false;
        mfToMelterDoorClosing = false;

        mfToMelterDoorClosingSoon = false;

        //Bridge
        BridgeLights = transform.Find("BridgeLights").GetComponent<VRTK_SnapDropZone>();
        BridgeMachinery = transform.Find("BridgeMachinery").GetComponent<VRTK_SnapDropZone>();
        BridgeDoorsFuse = transform.Find("BridgeDoors").GetComponent<VRTK_SnapDropZone>();

        BridgeLightsContainer = GameObject.Find("BridgeLightsContainer");

        bridgeDoorsPowered = false;

        BridgeDoorToMainFacilitySnapZone = GameObject.Find("BridgeDoorToMainFacilitySnapZone").GetComponentInChildren<VRTK_SnapDropZone>();

        bridgeToMFDoorOpen = false;
        bridgeToMFDoorClosed = true;

        bridgeToMFDoorOpening = false;
        bridgeToMFDoorClosing = false;

        bridgeToMFDoorClosingSoon = false;

        //Melter
        MelterLights = transform.Find("MelterLights").GetComponent<VRTK_SnapDropZone>();
        MelterMachinery = transform.Find("MelterMachinery").GetComponent<VRTK_SnapDropZone>();
        MelterDoorsFuse = transform.Find("MelterDoors").GetComponent<VRTK_SnapDropZone>();

        MelterLightsContainer = GameObject.Find("MelterLightsContainer");

        melterDoorsPowered = false;

        MelterDoorToMainFacilitySnapZone = GameObject.Find("MelterDoorToMainFacilitySnapZone").GetComponentInChildren<VRTK_SnapDropZone>();

        melterToMFDoorOpen = false;
        melterToMFDoorClosed = true;

        melterToMFDoorOpening = false;
        melterToMFDoorClosing = false;

        melterToMFDoorClosingSoon = false;

        //Double Door Animators

        JanitorDoorInnerAnim = GameObject.Find("InnerDoorToJanitorRoom").GetComponent<Animator>();
        JanitorDoorOuterAnim = GameObject.Find("OuterDoorToJanitorRoom").GetComponent<Animator>();

        BonsaiDoorInnerAnim = GameObject.Find("InnerBonsaiRoomDoor").GetComponent<Animator>();
        BonsaiDoorOuterAnim = GameObject.Find("OuterBonsaiRoomDoor").GetComponent<Animator>();

        MainFacilityToCorridorDoorAnim = GameObject.Find("MF_ToCorridorDoor").GetComponent<Animator>();
        CorridorToMFDoorAnim = GameObject.Find("CorridorTo_MFDoor").GetComponent<Animator>();

        MainFacilityToBridgeDoorAnim = GameObject.Find("MF_DoorToBridge").GetComponent<Animator>();
        BridgeToMFDoorAnim = GameObject.Find("Bridge_DoorToMF").GetComponent<Animator>();

        MainFacilityToMelterDoorAnim = GameObject.Find("MF_DoorToMelter").GetComponent<Animator>();
        MelterToMFDoorAnim = GameObject.Find("MelterDoorTo_MF").GetComponent<Animator>();

        //Sounds

        //janitorSounds

        InnerJanitorDoorOpeningSound = GameObject.Find("InnerJanitorDoorSounds").transform.Find("JanitorDoorOpeningSound").GetComponent<AudioSource>();
        InnerJanitorDoorOpenSound = GameObject.Find("InnerJanitorDoorSounds").transform.Find("JanitorDoorOpenSound").GetComponent<AudioSource>();
        InnerJanitorDoorClosingSound = GameObject.Find("InnerJanitorDoorSounds").transform.Find("JanitorDoorClosingSound").GetComponent<AudioSource>();
        InnerJanitorDoorClosedSound = GameObject.Find("InnerJanitorDoorSounds").transform.Find("JanitorDoorClosedSound").GetComponent<AudioSource>();
        InnerJanitorDoorAlarmSound = GameObject.Find("InnerJanitorDoorSounds").transform.Find("JanitorDoorAlarmSound").GetComponent<AudioSource>();

        InnerJanitorDoorCountdown = GameObject.Find("InnerJanitorDoorSounds").transform.Find("JanitorDoorCountDown").GetComponent<AudioSource>();

        OuterJanitorDoorOpeningSound = GameObject.Find("OuterJanitorDoorSounds").transform.Find("JanitorDoorOpeningSound").GetComponent<AudioSource>();
        OuterJanitorDoorOpenSound = GameObject.Find("OuterJanitorDoorSounds").transform.Find("JanitorDoorOpenSound").GetComponent<AudioSource>();
        OuterJanitorDoorClosingSound = GameObject.Find("OuterJanitorDoorSounds").transform.Find("JanitorDoorClosingSound").GetComponent<AudioSource>();
        OuterJanitorDoorClosedSound = GameObject.Find("OuterJanitorDoorSounds").transform.Find("JanitorDoorClosedSound").GetComponent<AudioSource>();
        OuterJanitorDoorAlarmSound = GameObject.Find("OuterJanitorDoorSounds").transform.Find("JanitorDoorAlarmSound").GetComponent<AudioSource>();

        OuterJanitorDoorCountdown = GameObject.Find("OuterJanitorDoorSounds").transform.Find("JanitorDoorCountDown").GetComponent<AudioSource>();

        //corridorToMF door sounds

        MF_ToCorridorDoorOpeningSound = GameObject.Find("MF_ToCorridorDoorSounds").transform.Find("MF_ToCorridorDoorOpeningSound").GetComponent<AudioSource>();
        MF_ToCorridorDoorOpenSound = GameObject.Find("MF_ToCorridorDoorSounds").transform.Find("MF_ToCorridorDoorOpenSound").GetComponent<AudioSource>();
        MF_ToCorridorDoorClosingSound = GameObject.Find("MF_ToCorridorDoorSounds").transform.Find("MF_ToCorridorDoorClosingSound").GetComponent<AudioSource>();
        MF_ToCorridorDoorClosedSound = GameObject.Find("MF_ToCorridorDoorSounds").transform.Find("MF_ToCorridorDoorClosedSound").GetComponent<AudioSource>();
        MF_ToCorridorDoorAlarmSound = GameObject.Find("MF_ToCorridorDoorSounds").transform.Find("MF_ToCorridorDoorAlarmSound").GetComponent<AudioSource>();

        MF_ToCorridorDoorCountdown = GameObject.Find("MF_ToCorridorDoorSounds").transform.Find("MF_ToCorridorDoorCountDown").GetComponent<AudioSource>();

        Corridor_ToMFDoorOpeningSound = GameObject.Find("Corridor_ToMFDoorSounds").transform.Find("Corridor_ToMFDoorOpeningSound").GetComponent<AudioSource>();
        Corridor_ToMFDoorOpenSound = GameObject.Find("Corridor_ToMFDoorSounds").transform.Find("Corridor_ToMFDoorOpenSound").GetComponent<AudioSource>();
        Corridor_ToMFDoorClosingSound = GameObject.Find("Corridor_ToMFDoorSounds").transform.Find("Corridor_ToMFDoorClosingSound").GetComponent<AudioSource>();
        Corridor_ToMFDoorClosedSound = GameObject.Find("Corridor_ToMFDoorSounds").transform.Find("Corridor_ToMFDoorClosedSound").GetComponent<AudioSource>();
        Corridor_ToMFDoorAlarmSound = GameObject.Find("Corridor_ToMFDoorSounds").transform.Find("Corridor_ToMFDoorAlarmSound").GetComponent<AudioSource>();

        Corridor_ToMFDoorCountdown = GameObject.Find("Corridor_ToMFDoorSounds").transform.Find("Corridor_ToMFDoorCountDown").GetComponent<AudioSource>();

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
        if (MaintenanceCorridorLights.GetCurrentSnappedObject() != null)
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
        if (BonsaiOxygenControlMachinery.GetCurrentSnappedObject() != null)
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
            BridgeTerminal.ActivateMonitor();
            Debug.Log("Bridge on");
        }
        else
        {
            //turn BridgeMachinery off
            BridgeTerminal.DeactivateMonitor();
            Debug.Log("Bridge off");
        }

        if (MelterMachinery.GetCurrentSnappedObject() != null)
        {
            //turn MelterMachinery on
            MelterTerminal.ActivateMonitor();
        }
        else
        {
            //turn MelterMachinery off
            MelterTerminal.DeactivateMonitor();
        }
    }

    public void CheckDoorsOpenStatus()
    {
        if (MaintenanceCorridorDoorsFuse.GetCurrentSnappedObject() != null)
        {
            //turn MaintenanceDoors on
            corridorDoorsPowered = true;
        }
        else
        {
            //turn MaintenanceDoors off
            corridorDoorsPowered = false;
        }

        if (BonsaiDoorFuse.GetCurrentSnappedObject() != null)
        {
            //turn MaintenanceDoors on
            bonsaiDoorPowered = true;
        }
        else
        {
            //turn MaintenanceDoors off
            bonsaiDoorPowered = false;
        }

        if (JanitorDoorFuse.GetCurrentSnappedObject() != null)
        {
            //turn MaintenanceDoors on
            janitorDoorPowered = true;
        }
        else
        {
            //turn MaintenanceDoors off
            janitorDoorPowered = false;
        }

        if (MainFacilityDoorsFuse.GetCurrentSnappedObject() != null)
        {
            //turn MainFacilityDoors on
            mainFacilityDoorsPowered = true;
        }
        else
        {
            //turn MainFacilityDoors off
            mainFacilityDoorsPowered = false;
        }

        if (BridgeDoorsFuse.GetCurrentSnappedObject() != null)
        {
            //turn BridgeDoors on
            bridgeDoorsPowered = true;
        }
        else
        {
            //turn BridgeDoors off
            bridgeDoorsPowered = false;
        }

        if (MelterDoorsFuse.GetCurrentSnappedObject() != null)
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

        if (janitorDoorPowered)
        {
            if (JanitorDoorToCorridorSnapZone.GetCurrentSnappedObject() != null && JanitorDoorToCorridorSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 1
               && !janitorToCorridorDoorClosing && !janitorToCorridorDoorOpening)
            {
                if (janitorToCorridorDoorClosed)
                {
                    //Open Janitor door (from the inside)                                                                                   
                    StartCoroutine("InnerJanitorDoorOpening");
                }
                else if (janitorToCorridorDoorClosingSoon) //aka it is open and no correct key in it
                {
                    StopCoroutine("DelayedAutomaticCloseInnerJanitor");  //ends the 10 second countdown of door closing
                    InnerJanitorDoorCountdown.Stop();
                    janitorToCorridorDoorClosingSoon = false;
                }
                if (corridorDoorsPowered && !corridorToJanitorDoorOpening && !corridorToJanitorDoorClosing) //probably unnecessary to check for closing and opening here too
                {
                    if (corridorToJanitorDoorClosed)
                    {
                        StartCoroutine("OuterJanitorDoorOpening");
                    }
                    else if (corridorToJanitorDoorClosingSoon)
                    {
                        StopCoroutine("DelayedAutomaticCloseOuterJanitor");
                        OuterJanitorDoorCountdown.Stop();
                        corridorToJanitorDoorClosingSoon = false;
                    }
                }
            }
            else if (JanitorDoorToCorridorSnapZone.GetCurrentSnappedObject() != null && JanitorDoorToCorridorSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 1)
            {
                //show that the key is wrong to the player, play sound
            }
            //check when to close the door (no correct key in either lock)
            if (janitorToCorridorDoorOpen && !janitorToCorridorDoorClosingSoon
               && (JanitorDoorToCorridorSnapZone.GetCurrentSnappedObject() == null || JanitorDoorToCorridorSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 1)
               && (CorridorDoorToJanitorSnapZone.GetCurrentSnappedObject() == null || CorridorDoorToJanitorSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 1))
            {
                //waits 10 seconds and then starts closing the door for 3 s
                StartCoroutine("DelayedAutomaticCloseInnerJanitor");
            }
        }
        //BONSAI DOOR
        if (bonsaiDoorPowered)
        {
            if (BonsaiDoorToCorridorSnapZone.GetCurrentSnappedObject() != null && BonsaiDoorToCorridorSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 2
                && !bonsaiToCorridorDoorClosing && !bonsaiToCorridorDoorOpening)
            {
                //in case the player has put another copy of the same key on the other side already, keeping it open, then adding a new key will not re-trigger the opening animation            
                if (bonsaiToCorridorDoorClosed)
                {
                    //Open Bonsai door (from the inside)                                  
                    StartCoroutine("InnerBonsaiDoorOpening");
                }
                else if (bonsaiToCorridorDoorClosingSoon)//aka it is open and no correct key in it
                {
                    StopCoroutine("DelayedAutomaticCloseInnerBonsai");  //ends the 10 second countdown of door closing
                    bonsaiToCorridorDoorClosingSoon = false;
                }
                if (corridorDoorsPowered && !corridorToBonsaiDoorOpening && !corridorToBonsaiDoorClosing) //probably unnecessary to check for closing and opening here too
                {
                    if (corridorToBonsaiDoorClosed)
                    {
                        StartCoroutine("OuterBonsaiDoorOpening");
                    }
                    else if (corridorToBonsaiDoorClosingSoon)
                    {
                        StopCoroutine("DelayedAutomaticCloseOuterBonsai");
                        corridorToBonsaiDoorClosingSoon = false;
                    }
                }
            }
            else if (BonsaiDoorToCorridorSnapZone.GetCurrentSnappedObject() != null && BonsaiDoorToCorridorSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2)
            {
                //show that the key is wrong to the player
            }       
            if (bonsaiToCorridorDoorOpen && !bonsaiToCorridorDoorClosingSoon
               && (BonsaiDoorToCorridorSnapZone.GetCurrentSnappedObject() == null || BonsaiDoorToCorridorSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2)
               && (CorridorDoorToBonsaiSnapZone.GetCurrentSnappedObject() == null || CorridorDoorToBonsaiSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2))
            {
                StartCoroutine("DelayedAutomaticCloseInnerBonsai");
            }
        }
        //CorridorDoorToMainFacility doesn't need a keycard, only button press
        //press starts a countdown of 10s, maybe visible in the door/panel? pressing again resets countdown
        //door has to be fully closed in order to open
        if (corridorDoorsPowered)
        {
            // corridor to MF
            if (CorridorDoorToMainFacilityButton.AtMaxLimit() && !corridorToMFDoorOpening && !corridorToMFDoorClosing)
            {
                //if closed, then open
                if (corridorToMFDoorClosed)
                {
                    StartCoroutine("CorridorToMFDoorOpening");
                }
                //if open already, then reset door timer
                else if (corridorToMFDoorClosingSoon)  //the bool doesn't rly do a lot, could remove maybe
                {
                    StopCoroutine("DelayedAutomaticCloseCorridorToMF");    //stop earlier timer, start a new one              
                    StartCoroutine("DelayedAutomaticCloseCorridorToMF");
                }
                //if MF powered
                if (mainFacilityDoorsPowered && !mfToCorridorDoorClosing && !mfToCorridorDoorOpening)
                {
                    //if MF side door is closed, open it
                    if (mfToCorridorDoorClosed)
                    {
                        StartCoroutine("MFToCorridorDoorOpening");
                    }
                    else if (mfToCorridorDoorClosingSoon) //aka it is open 
                    {
                        StopCoroutine("DelayedAutomaticCloseMFToCorridor");  //ends the 10 second countdown of door closing 
                        StartCoroutine("DelayedAutomaticCloseMFToCorridor");
                    }
                }
            }
            //corridor to Janitor
            if (CorridorDoorToJanitorSnapZone.GetCurrentSnappedObject() != null && CorridorDoorToJanitorSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 1 
                && !corridorToJanitorDoorClosing && !corridorToJanitorDoorOpening)
            {
                //in case the player has put another copy of the same key on the other side already, keeping it open, then adding a new key will not re-trigger the opening animation              
                if (corridorToJanitorDoorClosed)
                {
                    //Open Janitor door (from the outside)                                                                        
                    StartCoroutine("OuterJanitorDoorOpening");
                }
                else if (corridorToJanitorDoorClosingSoon) //aka it is open and no correct key in it
                {
                    StopCoroutine("DelayedAutomaticCloseOuterJanitor");  //ends the 10 second countdown of door closing
                    OuterJanitorDoorCountdown.Stop();
                    corridorToJanitorDoorClosingSoon = false;
                }
                if (janitorDoorPowered && !janitorToCorridorDoorOpening && !corridorToBonsaiDoorClosing) //probably unnecessary to check for closing and opening here too, maybe need to change if want to abrupt closing
                {
                    if (janitorToCorridorDoorClosed)
                    {
                        StartCoroutine("InnerJanitorDoorOpening");
                    }
                    else if (janitorToCorridorDoorClosingSoon)
                    {
                        StopCoroutine("DelayedAutomaticCloseInnerJanitor");
                        InnerJanitorDoorCountdown.Stop();
                        janitorToCorridorDoorClosingSoon = false;
                    }
                }
            }
            else if (CorridorDoorToJanitorSnapZone.GetCurrentSnappedObject() != null && CorridorDoorToJanitorSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 1)
            {
                //show that the key is wrong to the player
            }
            if (corridorToJanitorDoorOpen && !corridorToJanitorDoorClosingSoon
               && (CorridorDoorToJanitorSnapZone.GetCurrentSnappedObject() == null || CorridorDoorToJanitorSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 1)
               && (JanitorDoorToCorridorSnapZone.GetCurrentSnappedObject() == null || JanitorDoorToCorridorSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 1))
            {
                StartCoroutine("DelayedAutomaticCloseOuterJanitor");
            }
            //corridor To Bonsai

            if (CorridorDoorToBonsaiSnapZone.GetCurrentSnappedObject() != null && CorridorDoorToBonsaiSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 2
                && !corridorToBonsaiDoorClosing && !corridorToBonsaiDoorOpening)
            {
                //in case the player has put another copy of the same key on the other side already, keeping it open, then adding a new key will not re-trigger the opening animation              
                if (corridorToBonsaiDoorClosed)
                {
                    //Open Bonsai door (from the outside)                                                                        
                    StartCoroutine("OuterBonsaiDoorOpening");
                }
                else if (corridorToBonsaiDoorClosingSoon) //aka it is open and no correct key in it
                {
                    StopCoroutine("DelayedAutomaticCloseOuterBonsai");  //ends the 10 second countdown of door closing
                    corridorToBonsaiDoorClosingSoon = false;
                }
                if (bonsaiDoorPowered && !bonsaiToCorridorDoorOpening && !corridorToBonsaiDoorClosing) //probably unnecessary to check for closing and opening here too, maybe need to change if want to abrupt closing
                {
                    if (bonsaiToCorridorDoorClosed)
                    {
                        StartCoroutine("InnerBonsaiDoorOpening");
                    }
                    else if (bonsaiToCorridorDoorClosingSoon)
                    {
                        StopCoroutine("DelayedAutomaticCloseInnerBonsai");
                        bonsaiToCorridorDoorClosingSoon = false;
                    }
                }
            }
            else if (CorridorDoorToBonsaiSnapZone.GetCurrentSnappedObject() != null && CorridorDoorToBonsaiSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2)
            {
                //show that the key is wrong to the player
            }
            if (corridorToBonsaiDoorOpen && !corridorToBonsaiDoorClosingSoon
               && (CorridorDoorToBonsaiSnapZone.GetCurrentSnappedObject() == null || CorridorDoorToBonsaiSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2)
               && (BonsaiDoorToCorridorSnapZone.GetCurrentSnappedObject() == null || BonsaiDoorToCorridorSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2))
            {
                StartCoroutine("DelayedAutomaticCloseOuterBonsai");
            }
        }    
        //in case no power doors get stuck in the position they are in
        //else
        //{
        //    //JanitorDoorAnim.SetBool("OPEN", false);
        //    //BonsaiDoorAnim.SetBool("OPEN", false);
        //    //MainFacilityAndCorridorDoorAnim.SetBool("OPENCORRIDORSIDE", false);
        //}

        //MAIN FACILITY DOORS

        //MainFacilityDoorToCorridor doesn't need a keycard

        if (mainFacilityDoorsPowered)
        {          
            //MF to Corridor
            if (MainFacilityDoorToCorridorButton.AtMaxLimit() && !mfToCorridorDoorOpening && !mfToCorridorDoorClosing)
            {
                if (mfToCorridorDoorClosed)
                {
                    StartCoroutine("MFToCorridorDoorOpening");
                }
                //if open already, then reset door timer
                else if (mfToCorridorDoorClosingSoon)
                {
                    StopCoroutine("DelayedAutomaticCloseMFToCorridor");
                    StartCoroutine("DelayedAutomaticCloseMFToCorridor");
                }
                //if corridor powered
                if (corridorDoorsPowered && !corridorToMFDoorOpening && !corridorToMFDoorClosing)
                {
                    //if corridor side door is closed, open it
                    if (corridorToMFDoorClosed)
                    {
                        StartCoroutine("CorridorToMFDoorOpening");
                    }
                    else if (corridorToMFDoorClosingSoon) //aka it is open
                    {
                        StopCoroutine("DelayedAutomaticCloseCorridorToMF");  //ends the 10 second countdown of door closing
                        StartCoroutine("DelayedAutomaticCloseCorridorToMF");
                    }
                }
            }
            //MF to Bridge
            if (MainFacilityDoorToBridgeSnapZone.GetCurrentSnappedObject() != null && MainFacilityDoorToBridgeSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 3
                && !mfToBridgeDoorClosing && !mfToBridgeDoorOpening)
            {
                //open the door to Bridge 
                if (mfToBridgeDoorClosed)
                {
                    StartCoroutine("MFToBridgeDoorOpening");
                }
                else if (mfToBridgeDoorClosingSoon)
                {
                    StopCoroutine("DelayedAutomaticCloseMFToBridge");
                    mfToCorridorDoorClosingSoon = false;
                }
                if (bridgeDoorsPowered && !bridgeToMFDoorOpening && !bridgeToMFDoorClosing) //probably unnecessary to check for closing and opening here too
                {
                    if (bridgeToMFDoorClosed)
                    {
                        StartCoroutine("BridgeToMFDoorOpening");
                    }
                    else if (bridgeToMFDoorClosingSoon)
                    {
                        StopCoroutine("DelayedAutomaticCloseBridgeToMF");
                        bridgeToMFDoorClosingSoon = false;
                    }
                }
            }
            else if (MainFacilityDoorToBridgeSnapZone.GetCurrentSnappedObject() != null && MainFacilityDoorToBridgeSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 3)
            {
                //show that the key is wrong to the player
            }
            //start automatic closing if open and no key on either side
            if (mfToBridgeDoorOpen && !mfToBridgeDoorClosingSoon
                 && (MainFacilityDoorToBridgeSnapZone.GetCurrentSnappedObject() == null || MainFacilityDoorToBridgeSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 3) 
                 && (BridgeDoorToMainFacilitySnapZone.GetCurrentSnappedObject() == null || BridgeDoorToMainFacilitySnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 3))
            {                      
                 StartCoroutine("DelayedAutomaticCloseMFToBridge");
                 if (bridgeDoorsPowered && bridgeToMFDoorOpen && !bridgeToMFDoorClosingSoon)
                 {
                    StartCoroutine("DelayedAutomaticCloseBridgeToMF");
                 }
            }
            //Melter door MF side
            if (MainFacilityDoorToMelterSnapZone.GetCurrentSnappedObject() != null && MainFacilityDoorToMelterSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 2
                && !mfToMelterDoorClosing && !mfToMelterDoorOpening)
            {
                //open the door to melter from MF
                if (mfToMelterDoorClosed)
                {
                    StartCoroutine("MFToMelterDoorOpening");
                }
                else if (mfToMelterDoorClosingSoon)
                {
                    StopCoroutine("DelayedAutomaticCloseMFToMelter");
                    mfToMelterDoorClosingSoon = false;
                }
                if (melterDoorsPowered && !melterToMFDoorOpening && !melterToMFDoorClosing) //probably unnecessary to check for closing and opening here too
                {
                    if (melterToMFDoorClosed)
                    {
                        StartCoroutine("MelterToMFDoorOpening");
                    }
                    else if (melterToMFDoorClosingSoon)
                    {
                        StopCoroutine("DelayedAutomaticCloseMelterToMF");
                        melterToMFDoorClosingSoon = false;
                    }
                }
            }
            else if (MainFacilityDoorToMelterSnapZone.GetCurrentSnappedObject() != null && MainFacilityDoorToMelterSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2)
            {
                //show that the key is wrong to the player
            }

            if (mfToMelterDoorOpen && !mfToMelterDoorClosingSoon
                && (MainFacilityDoorToMelterSnapZone.GetCurrentSnappedObject() == null || MainFacilityDoorToMelterSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2)
                && (MelterDoorToMainFacilitySnapZone.GetCurrentSnappedObject() == null || MelterDoorToMainFacilitySnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2))
            {
                StartCoroutine("DelayedAutomaticCloseMFToMelter");
                if (melterDoorsPowered && melterToMFDoorOpen && !melterToMFDoorClosingSoon)
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
            if (BridgeDoorToMainFacilitySnapZone.GetCurrentSnappedObject() != null && BridgeDoorToMainFacilitySnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 3
            && !bridgeToMFDoorClosing && !bridgeToMFDoorOpening)
            {
                //open the door from Bridge to MF
                if (bridgeToMFDoorClosed)
                {
                    StartCoroutine("BridgeToMFDoorOpening");
                }
                else if (bridgeToMFDoorClosingSoon)
                {
                    StopCoroutine("DelayedAutomaticCloseBridgeToMF");
                    bridgeToMFDoorClosingSoon = false;
                }
                if (mainFacilityDoorsPowered && !mfToBridgeDoorOpening && !mfToBridgeDoorClosing) //probably unnecessary to check for closing and opening here too
                {
                    if (mfToBridgeDoorClosed)
                    {
                        StartCoroutine("MFToBridgeDoorOpening");
                    }
                    else if (mfToBridgeDoorClosingSoon)
                    {
                        StopCoroutine("DelayedAutomaticCloseMFToBridge");
                        mfToBridgeDoorClosingSoon = false;
                    }
                }
            }
            else if (BridgeDoorToMainFacilitySnapZone.GetCurrentSnappedObject() != null && BridgeDoorToMainFacilitySnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 3)
            {
                //show that the key is wrong to the player
            }
           
            if (bridgeToMFDoorOpen && !bridgeToMFDoorClosingSoon
                && (BridgeDoorToMainFacilitySnapZone.GetCurrentSnappedObject() == null || BridgeDoorToMainFacilitySnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 3)
                && (MainFacilityDoorToBridgeSnapZone.GetCurrentSnappedObject() == null || MainFacilityDoorToBridgeSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 3))
            {
                StartCoroutine("DelayedAutomaticCloseBridgeToMF");
                if (mainFacilityDoorsPowered && mfToBridgeDoorOpen && !mfToBridgeDoorClosingSoon)
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
            if (MelterDoorToMainFacilitySnapZone.GetCurrentSnappedObject() != null && MelterDoorToMainFacilitySnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 2
                && !melterToMFDoorClosing && !melterToMFDoorOpening)
            {
                //open the door to MF from Melter
                if (melterToMFDoorClosed)
                {
                    StartCoroutine("MelterToMFDoorOpening");
                }
                else if (melterToMFDoorClosingSoon)
                {
                    StopCoroutine("DelayedAutomaticCloseMelterToMF");
                    melterToMFDoorClosingSoon = false;
                }
                if (mainFacilityDoorsPowered && !mfToMelterDoorOpening && !mfToMelterDoorClosing) //probably unnecessary to check for closing and opening here too
                {
                    if (mfToMelterDoorClosed)
                    {
                        StartCoroutine("MFToMelterDoorOpening");
                    }
                    else if (mfToMelterDoorClosingSoon)
                    {
                        StopCoroutine("DelayedAutomaticCloseMFToMelter");
                        mfToMelterDoorClosingSoon = false;
                    }
                }
            }
            else if (MelterDoorToMainFacilitySnapZone.GetCurrentSnappedObject() != null && MelterDoorToMainFacilitySnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2)
            {
                //show that the key is wrong to the player
            }

            if (melterToMFDoorOpen && !melterToMFDoorClosingSoon
                && (MelterDoorToMainFacilitySnapZone.GetCurrentSnappedObject() == null || MelterDoorToMainFacilitySnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2)
                && (MainFacilityDoorToMelterSnapZone.GetCurrentSnappedObject() == null || MainFacilityDoorToMelterSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2))
            {
                StartCoroutine("DelayedAutomaticCloseMelterToMF");
                if (mainFacilityDoorsPowered && mfToMelterDoorOpen && !mfToMelterDoorClosingSoon)
                {
                    StartCoroutine("DelayedAutomaticCloseMFToMelter");
                }
            }
        }
    }

    IEnumerator DelayedAutomaticCloseInnerJanitor()
    {
        janitorToCorridorDoorClosingSoon = true;
        InnerJanitorDoorCountdown.Play();
        yield return new WaitForSecondsRealtime(10f);
        JanitorDoorInnerAnim.SetBool("OPEN", false);
        janitorToCorridorDoorClosing = true;
        janitorToCorridorDoorOpen = false;
        janitorToCorridorDoorClosingSoon = false;
        InnerJanitorDoorClosingSound.Play();
        yield return new WaitForSecondsRealtime(3f);
        janitorToCorridorDoorClosing = false;
        janitorToCorridorDoorClosed = true;
        InnerJanitorDoorClosingSound.Stop();
        InnerJanitorDoorClosedSound.Play();
    }

    IEnumerator InnerJanitorDoorOpening()
    {
        JanitorDoorInnerAnim.SetBool("OPEN", true);
        janitorToCorridorDoorOpening = true;
        janitorToCorridorDoorClosed = false;
        InnerJanitorDoorOpeningSound.Play();
        yield return new WaitForSecondsRealtime(3f);
        janitorToCorridorDoorOpening = false;
        janitorToCorridorDoorOpen = true;
        InnerJanitorDoorOpeningSound.Stop();
        InnerJanitorDoorOpenSound.Play();
    }

    IEnumerator DelayedAutomaticCloseOuterJanitor()
    {
        corridorToJanitorDoorClosingSoon = true;
        OuterJanitorDoorCountdown.Play();
        yield return new WaitForSecondsRealtime(10f);
        JanitorDoorOuterAnim.SetBool("OPEN", false);
        corridorToJanitorDoorClosing = true;
        corridorToJanitorDoorOpen = false;
        corridorToJanitorDoorClosingSoon = false;
        OuterJanitorDoorClosingSound.Play();
        yield return new WaitForSecondsRealtime(3f);
        corridorToJanitorDoorClosing = false;
        corridorToJanitorDoorClosed = true;
        OuterJanitorDoorClosingSound.Stop();
        OuterJanitorDoorClosedSound.Play();
    }

    IEnumerator OuterJanitorDoorOpening()
    {
        JanitorDoorOuterAnim.SetBool("OPEN", true);
        corridorToJanitorDoorOpening = true;
        corridorToJanitorDoorClosed = false;
        OuterJanitorDoorOpeningSound.Play();
        yield return new WaitForSecondsRealtime(3f);
        corridorToJanitorDoorOpening = false;
        corridorToJanitorDoorOpen = true;
        OuterJanitorDoorOpeningSound.Stop();
        OuterJanitorDoorOpenSound.Play();
    }

    IEnumerator DelayedAutomaticCloseInnerBonsai()
    {
        bonsaiToCorridorDoorClosingSoon = true;
        yield return new WaitForSecondsRealtime(10f);
        BonsaiDoorInnerAnim.SetBool("OPEN", false);
        bonsaiToCorridorDoorClosing = true;
        bonsaiToCorridorDoorOpen = false;
        bonsaiToCorridorDoorClosingSoon = false;
        yield return new WaitForSecondsRealtime(3f); //door closing time is 3s atm
        bonsaiToCorridorDoorClosed = true;
        bonsaiToCorridorDoorClosing = false;
    }

    IEnumerator InnerBonsaiDoorOpening()
    {
        BonsaiDoorInnerAnim.SetBool("OPEN", true);
        bonsaiToCorridorDoorOpening = true;
        bonsaiToCorridorDoorClosed = false;
        yield return new WaitForSecondsRealtime(3f); //door opening time is 3s atm
        bonsaiToCorridorDoorOpening = false;
        bonsaiToCorridorDoorOpen = true;
    }

    IEnumerator DelayedAutomaticCloseOuterBonsai()
    {
        corridorToBonsaiDoorClosingSoon = true;
        yield return new WaitForSecondsRealtime(10f);
        BonsaiDoorOuterAnim.SetBool("OPEN", false);
        corridorToBonsaiDoorClosing = true;
        corridorToBonsaiDoorOpen = false;
        corridorToBonsaiDoorClosingSoon = false;
        yield return new WaitForSecondsRealtime(3f); //door closing time is 3s atm
        corridorToBonsaiDoorClosed = true;
        corridorToBonsaiDoorClosing = false;
    }

    IEnumerator OuterBonsaiDoorOpening()
    {
        BonsaiDoorOuterAnim.SetBool("OPEN", true);
        corridorToBonsaiDoorOpening = true;
        corridorToBonsaiDoorClosed = false;
        yield return new WaitForSecondsRealtime(3f); //door opening time is 3s atm
        corridorToBonsaiDoorOpening = false;
        corridorToBonsaiDoorOpen = true;
    }

    IEnumerator DelayedAutomaticCloseCorridorToMF()
    {
        corridorToMFDoorClosingSoon = true;
        //for (int i = 0; i < 10; i++)    //next time separate sounds to 1 intervals
        //{
        //    Corridor_ToMFDoorCountdown.Play();
        //    yield return new WaitForSecondsRealtime(1f);
        //}
        Corridor_ToMFDoorCountdown.Play();
        yield return new WaitForSecondsRealtime(10f);
        CorridorToMFDoorAnim.SetBool("OPENCORRIDORSIDE", false);
        corridorToMFDoorClosing = true;
        corridorToMFDoorOpen = false;
        corridorToMFDoorClosingSoon = false;
        Corridor_ToMFDoorClosingSound.Play();
        yield return new WaitForSecondsRealtime(3f);
        corridorToMFDoorClosed = true;
        corridorToMFDoorClosing = false;
        Corridor_ToMFDoorClosingSound.Stop();
        Corridor_ToMFDoorClosedSound.Play();

    }

    IEnumerator CorridorToMFDoorOpening()
    {
        CorridorToMFDoorAnim.SetBool("OPENCORRIDORSIDE", true);
        corridorToMFDoorOpening = true;
        corridorToMFDoorClosed = false;
        Corridor_ToMFDoorOpeningSound.Play();
        yield return new WaitForSecondsRealtime(3f); //door closing time is 3s atm
        corridorToMFDoorOpening = false;
        corridorToMFDoorOpen = true;
        Corridor_ToMFDoorOpeningSound.Stop();
        Corridor_ToMFDoorOpenSound.Play();
        //after button press door opens, start counting down for closing
        StartCoroutine("DelayedAutomaticCloseCorridorToMF");
    }

    IEnumerator DelayedAutomaticCloseMFToCorridor()
    {
        mfToCorridorDoorClosingSoon = true;
        MF_ToCorridorDoorCountdown.Play();
        yield return new WaitForSecondsRealtime(10f);
        MainFacilityToCorridorDoorAnim.SetBool("OPENMFSIDE", false);
        mfToCorridorDoorClosing = true;
        mfToCorridorDoorOpen = false;
        mfToCorridorDoorClosingSoon = false;
        MF_ToCorridorDoorClosingSound.Play();
        yield return new WaitForSecondsRealtime(3f);
        mfToCorridorDoorClosed = true;
        mfToCorridorDoorClosing = false;
        MF_ToCorridorDoorClosingSound.Stop();
        MF_ToCorridorDoorClosedSound.Play();
    }

    IEnumerator MFToCorridorDoorOpening()
    {
        MainFacilityToCorridorDoorAnim.SetBool("OPENMFSIDE", true);
        mfToCorridorDoorOpening = true;
        mfToCorridorDoorClosed = false;
        MF_ToCorridorDoorOpeningSound.Play();
        yield return new WaitForSecondsRealtime(3f); //door closing time is 3s atm
        mfToCorridorDoorOpening = false;
        mfToCorridorDoorOpen = true;
        MF_ToCorridorDoorOpeningSound.Stop();
        MF_ToCorridorDoorOpenSound.Play();
        //after button press door opens, start counting down for closing
        StartCoroutine("DelayedAutomaticCloseMFToCorridor");
    }

    IEnumerator DelayedAutomaticCloseMFToBridge()
    {
        mfToBridgeDoorClosingSoon = true;
        yield return new WaitForSecondsRealtime(10f);
        MainFacilityToBridgeDoorAnim.SetBool("OPENMFSIDE", false);
        mfToBridgeDoorClosing = true;
        mfToBridgeDoorOpen = false;
        mfToBridgeDoorClosingSoon = false;
        yield return new WaitForSecondsRealtime(3f);
        mfToBridgeDoorClosed = true;
        mfToBridgeDoorClosing = false;
    }

    IEnumerator MFToBridgeDoorOpening()
    {
        MainFacilityToBridgeDoorAnim.SetBool("OPENMFSIDE", true);
        mfToBridgeDoorOpening = true;
        mfToBridgeDoorClosed = false;
        yield return new WaitForSecondsRealtime(3f); //door closing time is 3s atm
        mfToBridgeDoorOpening = false;
        mfToBridgeDoorOpen = true;     
    }

    IEnumerator DelayedAutomaticCloseBridgeToMF()
    {
        bridgeToMFDoorClosingSoon = true;
        yield return new WaitForSecondsRealtime(10f);
        MainFacilityToBridgeDoorAnim.SetBool("OPENBRIDGESIDE", false);
        bridgeToMFDoorClosing = true;
        bridgeToMFDoorOpen = false;
        bridgeToMFDoorClosingSoon = false;
        yield return new WaitForSecondsRealtime(3f);
        bridgeToMFDoorClosed = true;
        bridgeToMFDoorClosing = false;
    }

    IEnumerator BridgeToMFDoorOpening()
    {
        MainFacilityToBridgeDoorAnim.SetBool("OPENBRIDGESIDE", true);
        bridgeToMFDoorOpening = true;
        bridgeToMFDoorClosed = false;
        yield return new WaitForSecondsRealtime(3f); //door closing time is 3s atm
        bridgeToMFDoorOpening = false;
        bridgeToMFDoorOpen = true;       
    }

    IEnumerator DelayedAutomaticCloseMFToMelter()
    {
        mfToMelterDoorClosingSoon = true;
        yield return new WaitForSecondsRealtime(10f);
        MainFacilityToMelterDoorAnim.SetBool("OPENMFSIDE", false);
        mfToMelterDoorClosing = true;
        mfToMelterDoorOpen = false;
        mfToMelterDoorClosingSoon = false;
        yield return new WaitForSecondsRealtime(3f);
        mfToMelterDoorClosed = true;
        mfToMelterDoorClosing = false;
    }

    IEnumerator MFToMelterDoorOpening()
    {
        MainFacilityToMelterDoorAnim.SetBool("OPENMFSIDE", true);
        mfToMelterDoorOpening = true;
        mfToMelterDoorClosed = false;
        yield return new WaitForSecondsRealtime(3f); //door closing time is 3s atm
        mfToMelterDoorOpening = false;
        mfToMelterDoorOpen = true;      
    }

    IEnumerator DelayedAutomaticCloseMelterToMF()
    {
        melterToMFDoorClosingSoon = true;
        yield return new WaitForSecondsRealtime(10f);
        MainFacilityToMelterDoorAnim.SetBool("OPENMELTERSIDE", false);
        melterToMFDoorClosing = true;
        melterToMFDoorOpen = false;
        melterToMFDoorClosingSoon = false;
        yield return new WaitForSecondsRealtime(3f);
        melterToMFDoorClosed = true;
        melterToMFDoorClosing = false;
    }

    IEnumerator MelterToMFDoorOpening()
    {
        MainFacilityToMelterDoorAnim.SetBool("OPENMELTERSIDE", true);
        melterToMFDoorOpening = true;
        melterToMFDoorClosed = false;
        yield return new WaitForSecondsRealtime(3f); //door closing time is 3s atm
        melterToMFDoorOpening = false;
        melterToMFDoorOpen = true;      
    }
}
