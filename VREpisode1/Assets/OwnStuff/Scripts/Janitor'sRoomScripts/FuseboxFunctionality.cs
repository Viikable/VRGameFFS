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
    //inner
    public AudioSource InnerJanitorDoorOpeningSound;
    public AudioSource InnerJanitorDoorOpenSound;
    public AudioSource InnerJanitorDoorClosingSound;
    public AudioSource InnerJanitorDoorClosedSound;
    public AudioSource InnerJanitorDoorAlarmSound;

    public AudioSource[] InnerJanitorDoorCountdown;
    
    //outer
    public AudioSource OuterJanitorDoorOpeningSound;
    public AudioSource OuterJanitorDoorOpenSound;
    public AudioSource OuterJanitorDoorClosingSound;
    public AudioSource OuterJanitorDoorClosedSound;
    public AudioSource OuterJanitorDoorAlarmSound;

    public AudioSource[] OuterJanitorDoorCountdown;


    [Header("BonsaiSounds")]

    //inner
    public AudioSource InnerBonsaiDoorOpeningSound;
    public AudioSource InnerBonsaiDoorOpenSound;
    public AudioSource InnerBonsaiDoorClosingSound;
    public AudioSource InnerBonsaiDoorClosedSound;
    public AudioSource InnerBonsaiDoorAlarmSound;

    public AudioSource[] InnerBonsaiDoorCountdown;

    //outer
    public AudioSource OuterBonsaiDoorOpeningSound;
    public AudioSource OuterBonsaiDoorOpenSound;
    public AudioSource OuterBonsaiDoorClosingSound;
    public AudioSource OuterBonsaiDoorClosedSound;
    public AudioSource OuterBonsaiDoorAlarmSound;

    public AudioSource[] OuterBonsaiDoorCountdown;

    [Header("CorridorAndMFDoorSounds")]

    //mftocorr
    public AudioSource MF_ToCorridorDoorOpeningSound;
    public AudioSource MF_ToCorridorDoorOpenSound;
    public AudioSource MF_ToCorridorDoorClosingSound;
    public AudioSource MF_ToCorridorDoorClosedSound;
    public AudioSource MF_ToCorridorDoorAlarmSound;
   
    public AudioSource[] MF_ToCorridorDoorCountdown;

    //corrtomf
    public AudioSource Corridor_ToMFDoorOpeningSound;
    public AudioSource Corridor_ToMFDoorOpenSound;
    public AudioSource Corridor_ToMFDoorClosingSound;
    public AudioSource Corridor_ToMFDoorClosedSound;
    public AudioSource Corridor_ToMFDoorAlarmSound;

    public AudioSource[] Corridor_ToMFDoorCountdown;

    [Header("MelterSounds")]

    //mftomelter
    public AudioSource MF_ToMelterDoorOpeningSound;
    public AudioSource MF_ToMelterDoorOpenSound;
    public AudioSource MF_ToMelterDoorClosingSound;
    public AudioSource MF_ToMelterDoorClosedSound;
    public AudioSource MF_ToMelterDoorAlarmSound;

    public AudioSource[] MF_ToMelterDoorCountdown;

    //meltertomf
    public AudioSource Melter_ToMFDoorOpeningSound;
    public AudioSource Melter_ToMFDoorOpenSound;
    public AudioSource Melter_ToMFDoorClosingSound;
    public AudioSource Melter_ToMFDoorClosedSound;
    public AudioSource Melter_ToMFDoorAlarmSound;

    public AudioSource[] Melter_ToMFDoorCountdown;

    //animation waiting
    const string animBaseLayer = "Base Layer";
    int openAnimHash = Animator.StringToHash(animBaseLayer + ".Open");
    int closeAnimHash = Animator.StringToHash(animBaseLayer + ".Close");
    int closeWhenInterruptedAnimHash = Animator.StringToHash(animBaseLayer + ".CloseWhenInterrupted");

    //door interruption control
    public static bool janitorOuterDoorInterrupted;
    public static bool janitorInnerDoorInterrupted;
    public static bool bonsaiOuterDoorInterrupted;
    public static bool bonsaiInnerDoorInterrupted;
    public static bool corridor_ToMFDoorInterrupted;
    public static bool mf_ToCorridorDoorInterrupted;
    public static bool melter_ToMFDoorInterrupted;
    public static bool mf_ToMelterDoorInterrupted;

    private float doorAnimationTime;
    //info about the current state of certain animator
    AnimatorStateInfo animState;

    void Start()
    {

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

        //innner
        InnerJanitorDoorOpeningSound = GameObject.Find("InnerJanitorDoorSounds").transform.Find("JanitorDoorOpeningSound").GetComponent<AudioSource>();
        InnerJanitorDoorOpenSound = GameObject.Find("InnerJanitorDoorSounds").transform.Find("JanitorDoorOpenSound").GetComponent<AudioSource>();
        InnerJanitorDoorClosingSound = GameObject.Find("InnerJanitorDoorSounds").transform.Find("JanitorDoorClosingSound").GetComponent<AudioSource>();
        InnerJanitorDoorClosedSound = GameObject.Find("InnerJanitorDoorSounds").transform.Find("JanitorDoorClosedSound").GetComponent<AudioSource>();
        InnerJanitorDoorAlarmSound = GameObject.Find("InnerJanitorDoorSounds").transform.Find("JanitorDoorAlarmSound").GetComponent<AudioSource>();

        InnerJanitorDoorCountdown = new AudioSource[10];

        for (int i = 0; i < 10; i++)
        {
            InnerJanitorDoorCountdown[i] = GameObject.Find("InnerJanitorDoorSounds").transform.Find("JanitorDoorCountDown" + i).GetComponent<AudioSource>();
            Debug.Log(i);
        }

        // outer

        OuterJanitorDoorOpeningSound = GameObject.Find("OuterJanitorDoorSounds").transform.Find("JanitorDoorOpeningSound").GetComponent<AudioSource>();
        OuterJanitorDoorOpenSound = GameObject.Find("OuterJanitorDoorSounds").transform.Find("JanitorDoorOpenSound").GetComponent<AudioSource>();
        OuterJanitorDoorClosingSound = GameObject.Find("OuterJanitorDoorSounds").transform.Find("JanitorDoorClosingSound").GetComponent<AudioSource>();
        OuterJanitorDoorClosedSound = GameObject.Find("OuterJanitorDoorSounds").transform.Find("JanitorDoorClosedSound").GetComponent<AudioSource>();
        OuterJanitorDoorAlarmSound = GameObject.Find("OuterJanitorDoorSounds").transform.Find("JanitorDoorAlarmSound").GetComponent<AudioSource>();

        OuterJanitorDoorCountdown = new AudioSource[10];

        for (int i = 0; i < 10; i++)
        {
            OuterJanitorDoorCountdown[i] = GameObject.Find("OuterJanitorDoorSounds").transform.Find("JanitorDoorCountDown" + i).GetComponent<AudioSource>();
        }

        //bonsaidoor

        //inner

        InnerBonsaiDoorOpeningSound = GameObject.Find("InnerBonsaiDoorSounds").transform.Find("BonsaiDoorOpeningSound").GetComponent<AudioSource>();
        InnerBonsaiDoorOpenSound = GameObject.Find("InnerBonsaiDoorSounds").transform.Find("BonsaiDoorOpenSound").GetComponent<AudioSource>();
        InnerBonsaiDoorClosingSound = GameObject.Find("InnerBonsaiDoorSounds").transform.Find("BonsaiDoorClosingSound").GetComponent<AudioSource>();
        InnerBonsaiDoorClosedSound = GameObject.Find("InnerBonsaiDoorSounds").transform.Find("BonsaiDoorClosedSound").GetComponent<AudioSource>();
        InnerBonsaiDoorAlarmSound = GameObject.Find("InnerBonsaiDoorSounds").transform.Find("BonsaiDoorAlarmSound").GetComponent<AudioSource>();

        InnerBonsaiDoorCountdown = new AudioSource[10];

        for (int i = 0; i < 10; i++)
        {
            InnerBonsaiDoorCountdown[i] = GameObject.Find("InnerBonsaiDoorSounds").transform.Find("BonsaiDoorCountDown" + i).GetComponent<AudioSource>();
            Debug.Log(i);
        }

        // outer

        OuterBonsaiDoorOpeningSound = GameObject.Find("OuterBonsaiDoorSounds").transform.Find("BonsaiDoorOpeningSound").GetComponent<AudioSource>();
        OuterBonsaiDoorOpenSound = GameObject.Find("OuterBonsaiDoorSounds").transform.Find("BonsaiDoorOpenSound").GetComponent<AudioSource>();
        OuterBonsaiDoorClosingSound = GameObject.Find("OuterBonsaiDoorSounds").transform.Find("BonsaiDoorClosingSound").GetComponent<AudioSource>();
        OuterBonsaiDoorClosedSound = GameObject.Find("OuterBonsaiDoorSounds").transform.Find("BonsaiDoorClosedSound").GetComponent<AudioSource>();
        OuterBonsaiDoorAlarmSound = GameObject.Find("OuterBonsaiDoorSounds").transform.Find("BonsaiDoorAlarmSound").GetComponent<AudioSource>();

        OuterBonsaiDoorCountdown = new AudioSource[10];

        for (int i = 0; i < 10; i++)
        {
            OuterBonsaiDoorCountdown[i] = GameObject.Find("OuterBonsaiDoorSounds").transform.Find("BonsaiDoorCountDown" + i).GetComponent<AudioSource>();
        }

        //corridorToMF door sounds

        MF_ToCorridorDoorOpeningSound = GameObject.Find("MF_ToCorridorDoorSounds").transform.Find("MF_ToCorridorDoorOpeningSound").GetComponent<AudioSource>();
        MF_ToCorridorDoorOpenSound = GameObject.Find("MF_ToCorridorDoorSounds").transform.Find("MF_ToCorridorDoorOpenSound").GetComponent<AudioSource>();
        MF_ToCorridorDoorClosingSound = GameObject.Find("MF_ToCorridorDoorSounds").transform.Find("MF_ToCorridorDoorClosingSound").GetComponent<AudioSource>();
        MF_ToCorridorDoorClosedSound = GameObject.Find("MF_ToCorridorDoorSounds").transform.Find("MF_ToCorridorDoorClosedSound").GetComponent<AudioSource>();
        MF_ToCorridorDoorAlarmSound = GameObject.Find("MF_ToCorridorDoorSounds").transform.Find("MF_ToCorridorDoorAlarmSound").GetComponent<AudioSource>();

        MF_ToCorridorDoorCountdown = new AudioSource[10];

        for (int i = 0; i < 10; i++)
        {
            MF_ToCorridorDoorCountdown[i] = GameObject.Find("MF_ToCorridorDoorSounds").transform.Find("MF_ToCorridorDoorCountDown" + i).GetComponent<AudioSource>();
        }

        Corridor_ToMFDoorOpeningSound = GameObject.Find("Corridor_ToMFDoorSounds").transform.Find("Corridor_ToMFDoorOpeningSound").GetComponent<AudioSource>();
        Corridor_ToMFDoorOpenSound = GameObject.Find("Corridor_ToMFDoorSounds").transform.Find("Corridor_ToMFDoorOpenSound").GetComponent<AudioSource>();
        Corridor_ToMFDoorClosingSound = GameObject.Find("Corridor_ToMFDoorSounds").transform.Find("Corridor_ToMFDoorClosingSound").GetComponent<AudioSource>();
        Corridor_ToMFDoorClosedSound = GameObject.Find("Corridor_ToMFDoorSounds").transform.Find("Corridor_ToMFDoorClosedSound").GetComponent<AudioSource>();
        Corridor_ToMFDoorAlarmSound = GameObject.Find("Corridor_ToMFDoorSounds").transform.Find("Corridor_ToMFDoorAlarmSound").GetComponent<AudioSource>();

        Corridor_ToMFDoorCountdown = new AudioSource[10];

        for (int i = 0; i < 10; i++)
        {
            Corridor_ToMFDoorCountdown[i] = GameObject.Find("Corridor_ToMFDoorSounds").transform.Find("Corridor_ToMFDoorCountDown" + i).GetComponent<AudioSource>();
        }

        //mfToMelter door sounds

        MF_ToMelterDoorOpeningSound = GameObject.Find("MF_ToMelterDoorSounds").transform.Find("MF_ToMelterDoorOpeningSound").GetComponent<AudioSource>();
        MF_ToMelterDoorOpenSound = GameObject.Find("MF_ToMelterDoorSounds").transform.Find("MF_ToMelterDoorOpenSound").GetComponent<AudioSource>();
        MF_ToMelterDoorClosingSound = GameObject.Find("MF_ToMelterDoorSounds").transform.Find("MF_ToMelterDoorClosingSound").GetComponent<AudioSource>();
        MF_ToMelterDoorClosedSound = GameObject.Find("MF_ToMelterDoorSounds").transform.Find("MF_ToMelterDoorClosedSound").GetComponent<AudioSource>();
        MF_ToMelterDoorAlarmSound = GameObject.Find("MF_ToMelterDoorSounds").transform.Find("MF_ToMelterDoorAlarmSound").GetComponent<AudioSource>();

        MF_ToMelterDoorCountdown = new AudioSource[10];

        for (int i = 0; i < 10; i++)
        {
            MF_ToMelterDoorCountdown[i] = GameObject.Find("MF_ToMelterDoorSounds").transform.Find("MF_ToMelterDoorCountDown" + i).GetComponent<AudioSource>();
        }

        Melter_ToMFDoorOpeningSound = GameObject.Find("Melter_ToMFDoorSounds").transform.Find("Melter_ToMFDoorOpeningSound").GetComponent<AudioSource>();
        Melter_ToMFDoorOpenSound = GameObject.Find("Melter_ToMFDoorSounds").transform.Find("Melter_ToMFDoorOpenSound").GetComponent<AudioSource>();
        Melter_ToMFDoorClosingSound = GameObject.Find("Melter_ToMFDoorSounds").transform.Find("Melter_ToMFDoorClosingSound").GetComponent<AudioSource>();
        Melter_ToMFDoorClosedSound = GameObject.Find("Melter_ToMFDoorSounds").transform.Find("Melter_ToMFDoorClosedSound").GetComponent<AudioSource>();
        Melter_ToMFDoorAlarmSound = GameObject.Find("Melter_ToMFDoorSounds").transform.Find("Melter_ToMFDoorAlarmSound").GetComponent<AudioSource>();

        Melter_ToMFDoorCountdown = new AudioSource[10];

        for (int i = 0; i < 10; i++)
        {
            Melter_ToMFDoorCountdown[i] = GameObject.Find("Melter_ToMFDoorSounds").transform.Find("Melter_ToMFDoorCountDown" + i).GetComponent<AudioSource>();
        }

        //interruption control
        janitorOuterDoorInterrupted = false;
        janitorInnerDoorInterrupted = false;
        bonsaiOuterDoorInterrupted = false;
        bonsaiInnerDoorInterrupted = false;
        corridor_ToMFDoorInterrupted = false;
        mf_ToCorridorDoorInterrupted = false;
        melter_ToMFDoorInterrupted = false;
        mf_ToMelterDoorInterrupted = false;

        doorAnimationTime = 3f;
    }
        //testing
        //int i = 0;
	void Update ()
    {
        CheckLights();
        CheckMachinery();
        CheckDoorsPowerStatus();
        OpenDoors();

        //for testing

        //if (i == 0)
        //{
        //    i = 1;
        //    StartCoroutine(Testmethod());
        //}
    }

    IEnumerator Testmethod()
    {
        yield return new WaitForSecondsRealtime(2f);
        Debug.Log("true");
        JanitorDoorOuterAnim.SetBool("OPEN", true);
        yield return new WaitForSecondsRealtime(3f);
        JanitorDoorOuterAnim.SetBool("OPEN", false);
        yield return new WaitForSecondsRealtime(1.5f);
        JanitorDoorOuterAnim.SetFloat("Speed", -1f);      
        //after closing reversed
        yield return new WaitForSecondsRealtime(1.5f);
        //starts closing again
        JanitorDoorOuterAnim.SetFloat("Speed", 1f);
        JanitorDoorOuterAnim.SetBool("OPEN", true);     
        yield return new WaitForSecondsRealtime(1.5f);
        //trying to reverse the closing again
        JanitorDoorOuterAnim.SetFloat("Speed", -1f);
        yield return new WaitForSecondsRealtime(1.5f);
        JanitorDoorOuterAnim.SetFloat("Speed", 1f);
        JanitorDoorOuterAnim.SetBool("OPEN", false);
        //SUCCESPOINT
        yield return new WaitForSecondsRealtime(1.5f);
        JanitorDoorOuterAnim.SetFloat("Speed", -1f);
        yield return new WaitForSecondsRealtime(1.5f);
        JanitorDoorOuterAnim.SetFloat("Speed", 1f);
        JanitorDoorOuterAnim.SetBool("OPEN", true);
        yield return new WaitForSecondsRealtime(3f);
        JanitorDoorOuterAnim.SetFloat("Speed", -1f);
        JanitorDoorOuterAnim.SetBool("OPEN", false);
        Debug.Log("finished");
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

    public void CheckDoorsPowerStatus()
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
                        corridorToJanitorDoorClosingSoon = false;
                    }
                    else if (corridorToJanitorDoorClosing)
                    {
                        corridorToJanitorDoorClosing = false;
                        StartCoroutine("OuterJanitorDoorOpening");                       
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
        for (int i = 0; i < 10; i++)
        {
            InnerJanitorDoorCountdown[i].Play();
            yield return new WaitForSecondsRealtime(1f);
        }
        if (corridorToJanitorDoorOpen && !janitorInnerDoorInterrupted)
        {
            JanitorDoorInnerAnim.SetFloat("Speed", 1f);     //makes the animator go back to normal closing animation, in this case the closing was not interrupted during latest close
            JanitorDoorInnerAnim.SetBool("OPEN", false);
        }
        //door was interrupted by player or object and reopened some point during closing animation, in this case the door will close
        else if (corridorToJanitorDoorOpen)
        {
            JanitorDoorInnerAnim.SetFloat("Speed", -1f);
            JanitorDoorInnerAnim.SetBool("OPEN", false);
        }
        
        janitorToCorridorDoorClosing = true;
        janitorToCorridorDoorOpen = false;
        janitorToCorridorDoorClosingSoon = false;
        InnerJanitorDoorClosingSound.Play();
        yield return new WaitForSecondsRealtime(doorAnimationTime);
        janitorToCorridorDoorClosing = false;
        janitorToCorridorDoorClosed = true;
        InnerJanitorDoorClosingSound.Stop();
        InnerJanitorDoorClosedSound.Play();
    }

    IEnumerator InnerJanitorDoorOpening()
    {
        if (janitorToCorridorDoorClosed)
        {
            JanitorDoorInnerAnim.SetBool("OPEN", true);
        }
        //in case the door is opened while it is already closing, this can occur by player putting a keycard, pressing a button, or by placing themselves or an object between doors
        //this path is taken when the interrupt parameter is true, which is called from an outside OnTriggerEnter, or opendoors method
        else if (janitorToCorridorDoorClosing)
        {
            janitorToCorridorDoorClosing = false;
            JanitorDoorInnerAnim.SetFloat("Speed", -1f);
            InnerJanitorDoorClosingSound.Stop();
            StopCoroutine(DelayedAutomaticCloseInnerJanitor());
            //here we also play either the alarm sound in case the door was stopped by an object or player, or some other sound in case it was key card or button press
        }      
        janitorToCorridorDoorOpening = true;
        janitorToCorridorDoorClosed = false;
        InnerJanitorDoorOpeningSound.Play();
        float waitTime = JanitorDoorOuterAnim.GetCurrentAnimatorStateInfo(0).length;  //check the remaining time of the state, this should calculate how far the door is from the open state
        yield return new WaitForSecondsRealtime(waitTime);
        janitorToCorridorDoorOpening = false;
        janitorToCorridorDoorOpen = true;
        InnerJanitorDoorOpeningSound.Stop();
        InnerJanitorDoorOpenSound.Play();
    }

    IEnumerator DelayedAutomaticCloseOuterJanitor()
    {
        corridorToJanitorDoorClosingSoon = true;
        for (int i = 0; i < 10; i++)
        {
            OuterJanitorDoorCountdown[i].Play();
            yield return new WaitForSecondsRealtime(1f);
        }
        
        if (corridorToJanitorDoorOpen && !JanitorDoorOuterAnim.GetBool("OPENWHENCLOSED"))
        {
            JanitorDoorOuterAnim.SetBool("OPEN", false);
        }
        else
        {
            JanitorDoorOuterAnim.SetBool("OPENWHENCLOSED", false);
        }
        
        corridorToJanitorDoorClosing = true;
        corridorToJanitorDoorOpen = false;
        corridorToJanitorDoorClosingSoon = false;
        OuterJanitorDoorClosingSound.Play();
        yield return new WaitForSecondsRealtime(doorAnimationTime);
        corridorToJanitorDoorClosing = false;
        corridorToJanitorDoorClosed = true;
        OuterJanitorDoorClosingSound.Stop();
        OuterJanitorDoorClosedSound.Play();
    }

    IEnumerator OuterJanitorDoorOpening()
    {
        //checks that the door wasn't closed midway last time and if was then closes it through other transition path
        if (corridorToJanitorDoorClosed)
        {
            JanitorDoorOuterAnim.SetBool("OPEN", true);
        }    
        //in case the door is opened while it is already closing, this can occur by player putting a keycard, pressing a button, or by placing themselves or an object between doors
        else if (corridorToJanitorDoorClosing)  
        {
            corridorToJanitorDoorClosing = false;
            JanitorDoorOuterAnim.SetFloat("Speed", -1f);         
            OuterJanitorDoorClosingSound.Stop();            //stopping the sound of door closing as it will open now, also ending the coroutine so the door won't register as closed after a while (as it will be open)
            StopCoroutine(DelayedAutomaticCloseOuterJanitor());
            //here we also play either the alarm sound in case the door was stopped by an object or player, or some other sound in case it was key card or button press
        }
        corridorToJanitorDoorOpening = true;
        corridorToJanitorDoorClosed = false;
        OuterJanitorDoorOpeningSound.Play();
        //checks the current animation stateinfo from the base layer and its length
        float waitTime = JanitorDoorOuterAnim.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSecondsRealtime(waitTime);
        corridorToJanitorDoorOpening = false;
        corridorToJanitorDoorOpen = true;
        OuterJanitorDoorOpeningSound.Stop();
        OuterJanitorDoorOpenSound.Play();
        //this so that if we opened mid closing then we won't try to open again next time
        JanitorDoorOuterAnim.SetBool("OPENWHENCLOSED", true);
        JanitorDoorOuterAnim.SetFloat("Speed", 1f);
    }

    IEnumerator DelayedAutomaticCloseInnerBonsai()
    {
        bonsaiToCorridorDoorClosingSoon = true;
        for (int i = 0; i < 10; i++)
        {
            InnerBonsaiDoorCountdown[i].Play();
            yield return new WaitForSecondsRealtime(1f);
        }
        //yield return new WaitForSecondsRealtime(10f);
        BonsaiDoorInnerAnim.SetBool("OPEN", false);
        bonsaiToCorridorDoorClosing = true;
        bonsaiToCorridorDoorOpen = false;
        bonsaiToCorridorDoorClosingSoon = false;
        InnerBonsaiDoorClosingSound.Play();
        yield return new WaitForSecondsRealtime(doorAnimationTime); //door closing time is 3s atm
        bonsaiToCorridorDoorClosed = true;
        bonsaiToCorridorDoorClosing = false;
        InnerBonsaiDoorClosingSound.Stop();
        InnerBonsaiDoorClosedSound.Play();
    }

    IEnumerator InnerBonsaiDoorOpening()
    {
        BonsaiDoorInnerAnim.SetBool("OPEN", true);
        bonsaiToCorridorDoorOpening = true;
        bonsaiToCorridorDoorClosed = false;
        InnerBonsaiDoorOpeningSound.Play();
        yield return new WaitForSecondsRealtime(doorAnimationTime); //door opening time is 3s atm
        bonsaiToCorridorDoorOpening = false;
        bonsaiToCorridorDoorOpen = true;
        InnerBonsaiDoorOpeningSound.Stop();
        InnerBonsaiDoorOpenSound.Play();
    }

    IEnumerator DelayedAutomaticCloseOuterBonsai()
    {
        corridorToBonsaiDoorClosingSoon = true;
        for (int i = 0; i < 10; i++)
        {
            OuterBonsaiDoorCountdown[i].Play();
            yield return new WaitForSecondsRealtime(1f);
        }
        //yield return new WaitForSecondsRealtime(10f);
        BonsaiDoorOuterAnim.SetBool("OPEN", false);
        corridorToBonsaiDoorClosing = true;
        corridorToBonsaiDoorOpen = false;
        corridorToBonsaiDoorClosingSoon = false;
        OuterBonsaiDoorClosingSound.Play();
        yield return new WaitForSecondsRealtime(doorAnimationTime); //door closing time is 3s atm
        corridorToBonsaiDoorClosed = true;
        corridorToBonsaiDoorClosing = false;
        OuterBonsaiDoorClosingSound.Stop();
        OuterBonsaiDoorClosedSound.Play();
    }

    IEnumerator OuterBonsaiDoorOpening()
    {
        BonsaiDoorOuterAnim.SetBool("OPEN", true);
        corridorToBonsaiDoorOpening = true;
        corridorToBonsaiDoorClosed = false;
        OuterBonsaiDoorOpeningSound.Play();
        yield return new WaitForSecondsRealtime(doorAnimationTime); //door opening time is 3s atm
        corridorToBonsaiDoorOpening = false;
        corridorToBonsaiDoorOpen = true;
        OuterBonsaiDoorOpeningSound.Stop();
        OuterBonsaiDoorOpenSound.Play();
    }

    IEnumerator DelayedAutomaticCloseCorridorToMF()
    {
        corridorToMFDoorClosingSoon = true;
        for (int i = 0; i < 10; i++)    
        {
            Corridor_ToMFDoorCountdown[i].Play();
            yield return new WaitForSecondsRealtime(1f);
        }       
        //yield return new WaitForSecondsRealtime(10f);
        CorridorToMFDoorAnim.SetBool("OPENCORRIDORSIDE", false);
        corridorToMFDoorClosing = true;
        corridorToMFDoorOpen = false;
        corridorToMFDoorClosingSoon = false;
        Corridor_ToMFDoorClosingSound.Play();
        yield return new WaitForSecondsRealtime(doorAnimationTime);
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
        yield return new WaitForSecondsRealtime(doorAnimationTime); //door closing time is 3s atm
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
        for (int i = 0; i < 10; i++)
        {
            MF_ToCorridorDoorCountdown[i].Play();
            yield return new WaitForSecondsRealtime(1f);
        }
        //yield return new WaitForSecondsRealtime(10f);
        MainFacilityToCorridorDoorAnim.SetBool("OPENMFSIDE", false);
        mfToCorridorDoorClosing = true;
        mfToCorridorDoorOpen = false;
        mfToCorridorDoorClosingSoon = false;
        MF_ToCorridorDoorClosingSound.Play();
        yield return new WaitForSecondsRealtime(doorAnimationTime);
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
        yield return new WaitForSecondsRealtime(doorAnimationTime); //door closing time is 3s atm
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
        yield return new WaitForSecondsRealtime(doorAnimationTime);
        mfToBridgeDoorClosed = true;
        mfToBridgeDoorClosing = false;
    }

    IEnumerator MFToBridgeDoorOpening()
    {
        MainFacilityToBridgeDoorAnim.SetBool("OPENMFSIDE", true);
        mfToBridgeDoorOpening = true;
        mfToBridgeDoorClosed = false;
        yield return new WaitForSecondsRealtime(doorAnimationTime); //door closing time is 3s atm
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
        yield return new WaitForSecondsRealtime(doorAnimationTime);
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
        for (int i = 0; i < 10; i++)
        {
            MF_ToMelterDoorCountdown[i].Play();
            yield return new WaitForSecondsRealtime(1f);
        }       
        MainFacilityToMelterDoorAnim.SetBool("OPENMFSIDE", false);
        mfToMelterDoorClosing = true;
        mfToMelterDoorOpen = false;
        mfToMelterDoorClosingSoon = false;
        MF_ToMelterDoorClosingSound.Play();
        yield return new WaitForSecondsRealtime(doorAnimationTime);
        mfToMelterDoorClosed = true;
        mfToMelterDoorClosing = false;
        MF_ToMelterDoorClosingSound.Stop();
        MF_ToMelterDoorClosedSound.Play();
    }

    IEnumerator MFToMelterDoorOpening()
    {
        MainFacilityToMelterDoorAnim.SetBool("OPENMFSIDE", true);
        mfToMelterDoorOpening = true;
        mfToMelterDoorClosed = false;
        MF_ToMelterDoorOpeningSound.Play();
        yield return new WaitForSecondsRealtime(doorAnimationTime); //door closing time is 3s atm
        mfToMelterDoorOpening = false;
        mfToMelterDoorOpen = true;
        MF_ToMelterDoorOpeningSound.Stop();
        MF_ToMelterDoorOpenSound.Play();
    }

    IEnumerator DelayedAutomaticCloseMelterToMF()
    {
        melterToMFDoorClosingSoon = true;
        for (int i = 0; i < 10; i++)
        {
            Melter_ToMFDoorCountdown[i].Play();
            yield return new WaitForSecondsRealtime(1f);
        }
        MainFacilityToMelterDoorAnim.SetBool("OPENMELTERSIDE", false);
        melterToMFDoorClosing = true;
        melterToMFDoorOpen = false;
        melterToMFDoorClosingSoon = false;
        Melter_ToMFDoorClosingSound.Play();
        yield return new WaitForSecondsRealtime(doorAnimationTime);
        melterToMFDoorClosed = true;
        melterToMFDoorClosing = false;
        Melter_ToMFDoorClosingSound.Stop();
        Melter_ToMFDoorClosedSound.Play();
    }

    IEnumerator MelterToMFDoorOpening()
    {
        MainFacilityToMelterDoorAnim.SetBool("OPENMELTERSIDE", true);
        melterToMFDoorOpening = true;
        melterToMFDoorClosed = false;
        Melter_ToMFDoorOpeningSound.Play();
        yield return new WaitForSecondsRealtime(doorAnimationTime); //door closing time is 3s atm
        melterToMFDoorOpening = false;
        melterToMFDoorOpen = true;
        Melter_ToMFDoorOpeningSound.Stop();
        Melter_ToMFDoorOpenSound.Play();
    }
    //not used rn
    IEnumerator PlayAndWaitForAnim(Animator targetAnim, string stateName)
    {
        //Get hash of animation
        int animHash = 0;
        if (stateName == "Jump")
            animHash = openAnimHash;
        else if (stateName == "Move")
            animHash = closeAnimHash;
        //else if (stateName == "Look")
        //    animHash = openWhenInterruptedAnimHash;

        //targetAnim.Play(stateName);
        targetAnim.CrossFadeInFixedTime(stateName, 0.6f);

        //Wait until we enter the current state
        while (targetAnim.GetCurrentAnimatorStateInfo(0).fullPathHash != animHash)
        {
            yield return null;
        }

        float counter = 0;
        float waitTime = targetAnim.GetCurrentAnimatorStateInfo(0).length;

        //Now, Wait until the current state is done playing
        while (counter < (waitTime))
        {
            counter += Time.deltaTime;
            yield return null;
        }

        //Done playing. Do something below!
        Debug.Log("Done Playing");

    }
}
