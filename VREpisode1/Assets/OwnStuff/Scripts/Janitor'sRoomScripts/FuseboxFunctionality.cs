using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables.PhysicsBased;
using TMPro;

public class FuseboxFunctionality : MonoBehaviour {

    [Header("Machinery")]

    public BridgeKeyConfiguration BridgeTerminal;

    public KeyboardMappings MelterTerminal;

    public VRTK_SnapDropZone BonsaiOxygenControlMachinery;

    [Header("MaintenanceArea Lights")]
    public VRTK_SnapDropZone MaintenanceCorridorLights;
    public VRTK_SnapDropZone BonsaiLights;
    public VRTK_SnapDropZone JanitorLights;

    GameObject BonsaiLightsContainer;
    GameObject JanitorLightsContainer;
    GameObject MaintenanceCorridorLightsContainer;

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
    public VRTK_SnapDropZone BonsaiControlToBonsaiSnapZone;
    public VRTK_SnapDropZone BonsaiToControlBonsaiSnapZone;

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

    //bonsai first door is a button door now too
    public VRTK_PhysicsPusher CorridorDoorToBonsaiButton;

    public VRTK_PhysicsPusher BonsaiDoorToCorridorButton;

    [Header("Door which lets the player into bonsai control room open/close states")]
    public bool bonsaiControlDoorOpen;
   
    public bool bonsaiControlDoorClosed;
    
    public bool bonsaiControlDoorOpening;
  
    public bool bonsaiControlDoorClosing;

    public bool bonsaiControlDoorClosingSoon;

    //actually works with a button
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

    public Animator MFToCorridorDoorAnim;
    public Animator CorridorToMFDoorAnim;

    public Animator MFToBridgeDoorAnim;
    public Animator BridgeToMFDoorAnim;

    public Animator MFToMelterDoorAnim;
    public Animator MelterToMFDoorAnim;

    [Header("Single door animators")]

    public Animator BonsaiControlAnim;

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

    public AudioSource[] BonsaiControlDoorCountdown;

    public AudioSource BonsaiControlDoorOpeningSound;
    public AudioSource BonsaiControlDoorOpenSound;
    public AudioSource BonsaiControlDoorClosingSound;
    public AudioSource BonsaiControlDoorClosedSound;
    public AudioSource BonsaiControlDoorAlarmSound;

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

    [Header("BridgeSounds")]

    //mftobridge
    public AudioSource MF_ToBridgeDoorOpeningSound;
    public AudioSource MF_ToBridgeDoorOpenSound;
    public AudioSource MF_ToBridgeDoorClosingSound;
    public AudioSource MF_ToBridgeDoorClosedSound;
    public AudioSource MF_ToBridgeDoorAlarmSound;

    public AudioSource[] MF_ToBridgeDoorCountdown;

    //bridgetomf
    public AudioSource Bridge_ToMFDoorOpeningSound;
    public AudioSource Bridge_ToMFDoorOpenSound;
    public AudioSource Bridge_ToMFDoorClosingSound;
    public AudioSource Bridge_ToMFDoorClosedSound;
    public AudioSource Bridge_ToMFDoorAlarmSound;

    public AudioSource[] Bridge_ToMFDoorCountdown;

    //animation waiting, not used right now
    //const string animBaseLayer = "Base Layer";
    //int openAnimHash = Animator.StringToHash(animBaseLayer + ".Open");
    //int closeAnimHash = Animator.StringToHash(animBaseLayer + ".Close");
    //int closeWhenInterruptedAnimHash = Animator.StringToHash(animBaseLayer + ".CloseWhenInterrupted");

    //door interruption control
    public static bool janitorOuterDoorInterrupted;
    public static bool janitorInnerDoorInterrupted;
    public static bool bonsaiOuterDoorInterrupted;
    public static bool bonsaiInnerDoorInterrupted;
    public static bool bonsaiControlDoorInterrupted;
    public static bool corridor_ToMFDoorInterrupted;
    public static bool mf_ToCorridorDoorInterrupted;
    public static bool melter_ToMFDoorInterrupted;
    public static bool mf_ToMelterDoorInterrupted;
    public static bool bridge_ToMFDoorInterrupted;
    public static bool mf_ToBridgeDoorInterrupted;

    private float doorAnimationTime;

    //animation timer counters
    float outerJanitorTimer;
    float innerJanitorTimer;
    float outerBonsaiTimer;
    float innerBonsaiTimer;
    float bonsaiControlTimer;
    float corridor_ToMFTimer;
    float mf_ToCorridorTimer;
    float melter_ToMFTimer;
    float mf_ToMelterTimer;
    float bridge_ToMFTimer;
    float mf_ToBridgeTimer;

    //info about the current state of certain animator
    //AnimatorStateInfo animState;

    [Header("DoorCounters")]

    public TextMeshPro JanitorInnerCounter;
    public TextMeshPro JanitorOuterCounter;
    public TextMeshPro BonsaiInnerCounter;
    public TextMeshPro BonsaiOuterCounter;
    public TextMeshPro BonsaiControlCounterOuter;
    public TextMeshPro BonsaiControlCounterInner;
    public TextMeshPro MFToCorridorCounter;
    public TextMeshPro CorridorToMFCounter;
    public TextMeshPro MFToBridgeCounter;
    public TextMeshPro BridgeToMFCounter;
    public TextMeshPro MFToMelterCounter;
    public TextMeshPro MelterToMFCounter;

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

        JanitorLightsContainer = GameObject.Find("JanitorLightsContainer");
        BonsaiLightsContainer = GameObject.Find("BonsaiLightsContainer");
        MaintenanceCorridorLightsContainer = GameObject.Find("MaintenanceLightsContainer");

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

        BonsaiControlToBonsaiSnapZone = GameObject.Find("BONSAI_ROOM/BonsaiRoomDoubleDoor/BonsaiControlToBonsaiDoorSnapZone").GetComponentInChildren<VRTK_SnapDropZone>();
        BonsaiToControlBonsaiSnapZone = GameObject.Find("BONSAI_ROOM/BonsaiRoomDoubleDoor/BonsaiToControlBonsaiDoorSnapZone").GetComponentInChildren<VRTK_SnapDropZone>();

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

        CorridorDoorToBonsaiButton = GameObject.Find("BONSAI_ROOM/BonsaiRoomDoubleDoor/CorridorDoorToBonsai/CorridorDoorToBonsaiButton").GetComponentInChildren<VRTK_PhysicsPusher>();

        BonsaiDoorToCorridorButton = GameObject.Find("BONSAI_ROOM/BonsaiRoomDoubleDoor/BonsaiToCorridor/BonsaiDoorToCorridorButton").GetComponentInChildren<VRTK_PhysicsPusher>();

        bonsaiControlDoorOpen = false;

        bonsaiControlDoorClosed = true;

        bonsaiControlDoorOpening = false;

        bonsaiControlDoorClosing = false;

        bonsaiControlDoorClosingSoon = false;

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

        BonsaiDoorInnerAnim = GameObject.Find("BONSAI_ROOM/BonsaiRoomDoubleDoor/InnerBonsaiRoomDoor").GetComponent<Animator>();
        BonsaiDoorOuterAnim = GameObject.Find("BONSAI_ROOM/BonsaiRoomDoubleDoor/OuterBonsaiRoomDoor").GetComponent<Animator>();

        MFToCorridorDoorAnim = GameObject.Find("MF_ToCorridorDoor").GetComponent<Animator>();
        CorridorToMFDoorAnim = GameObject.Find("CorridorTo_MFDoor").GetComponent<Animator>();

        MFToBridgeDoorAnim = GameObject.Find("MF_DoorToBridge").GetComponent<Animator>();
        BridgeToMFDoorAnim = GameObject.Find("Bridge_DoorToMF").GetComponent<Animator>();

        MFToMelterDoorAnim = GameObject.Find("MF_DoorToMelter").GetComponent<Animator>();
        MelterToMFDoorAnim = GameObject.Find("MelterDoorTo_MF").GetComponent<Animator>();

        //Single door animators

        BonsaiControlAnim = GameObject.Find("BonsaiControlDoor").GetComponent<Animator>();

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

        InnerBonsaiDoorOpeningSound = GameObject.Find("BONSAI_ROOM/BonsaiRoomDoubleDoor/InnerBonsaiDoorSounds").transform.Find("BonsaiDoorOpeningSound").GetComponent<AudioSource>();
        InnerBonsaiDoorOpenSound = GameObject.Find("BONSAI_ROOM/BonsaiRoomDoubleDoor/InnerBonsaiDoorSounds").transform.Find("BonsaiDoorOpenSound").GetComponent<AudioSource>();
        InnerBonsaiDoorClosingSound = GameObject.Find("BONSAI_ROOM/BonsaiRoomDoubleDoor/InnerBonsaiDoorSounds").transform.Find("BonsaiDoorClosingSound").GetComponent<AudioSource>();
        InnerBonsaiDoorClosedSound = GameObject.Find("BONSAI_ROOM/BonsaiRoomDoubleDoor/InnerBonsaiDoorSounds").transform.Find("BonsaiDoorClosedSound").GetComponent<AudioSource>();
        InnerBonsaiDoorAlarmSound = GameObject.Find("BONSAI_ROOM/BonsaiRoomDoubleDoor/InnerBonsaiDoorSounds").transform.Find("BonsaiDoorAlarmSound").GetComponent<AudioSource>();

        InnerBonsaiDoorCountdown = new AudioSource[10];

        for (int i = 0; i < 10; i++)
        {
            InnerBonsaiDoorCountdown[i] = GameObject.Find("BONSAI_ROOM/BonsaiRoomDoubleDoor/InnerBonsaiDoorSounds").transform.Find("BonsaiDoorCountDown" + i).GetComponent<AudioSource>();         
        }

        // outer

        OuterBonsaiDoorOpeningSound = GameObject.Find("BONSAI_ROOM/BonsaiRoomDoubleDoor/OuterBonsaiDoorSounds").transform.Find("BonsaiDoorOpeningSound").GetComponent<AudioSource>();
        OuterBonsaiDoorOpenSound = GameObject.Find("BONSAI_ROOM/BonsaiRoomDoubleDoor/OuterBonsaiDoorSounds").transform.Find("BonsaiDoorOpenSound").GetComponent<AudioSource>();
        OuterBonsaiDoorClosingSound = GameObject.Find("BONSAI_ROOM/BonsaiRoomDoubleDoor/OuterBonsaiDoorSounds").transform.Find("BonsaiDoorClosingSound").GetComponent<AudioSource>();
        OuterBonsaiDoorClosedSound = GameObject.Find("BONSAI_ROOM/BonsaiRoomDoubleDoor/OuterBonsaiDoorSounds").transform.Find("BonsaiDoorClosedSound").GetComponent<AudioSource>();
        OuterBonsaiDoorAlarmSound = GameObject.Find("BONSAI_ROOM/BonsaiRoomDoubleDoor/OuterBonsaiDoorSounds").transform.Find("BonsaiDoorAlarmSound").GetComponent<AudioSource>();

        OuterBonsaiDoorCountdown = new AudioSource[10];

        for (int i = 0; i < 10; i++)
        {
            OuterBonsaiDoorCountdown[i] = GameObject.Find("BONSAI_ROOM/BonsaiRoomDoubleDoor/OuterBonsaiDoorSounds").transform.Find("BonsaiDoorCountDown" + i).GetComponent<AudioSource>();
        }

        //control

        BonsaiControlDoorOpeningSound = GameObject.Find("BonsaiControlDoorSounds").transform.Find("BonsaiDoorOpeningSound").GetComponent<AudioSource>();
        BonsaiControlDoorOpenSound = GameObject.Find("BonsaiControlDoorSounds").transform.Find("BonsaiDoorOpenSound").GetComponent<AudioSource>();
        BonsaiControlDoorClosingSound = GameObject.Find("BonsaiControlDoorSounds").transform.Find("BonsaiDoorClosingSound").GetComponent<AudioSource>();
        BonsaiControlDoorClosedSound = GameObject.Find("BonsaiControlDoorSounds").transform.Find("BonsaiDoorClosedSound").GetComponent<AudioSource>();
        BonsaiControlDoorAlarmSound = GameObject.Find("BonsaiControlDoorSounds").transform.Find("BonsaiDoorAlarmSound").GetComponent<AudioSource>();

        BonsaiControlDoorCountdown = new AudioSource[10];

        for (int i = 0; i < 10; i++)
        {
            BonsaiControlDoorCountdown[i] = GameObject.Find("BonsaiControlDoorSounds").transform.Find("BonsaiDoorCountDown" + i).GetComponent<AudioSource>();
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

        //bridgetoMF door sounds

        MF_ToBridgeDoorOpeningSound = GameObject.Find("MF_ToBridgeDoorSounds").transform.Find("MF_ToBridgeDoorOpeningSound").GetComponent<AudioSource>();
        MF_ToBridgeDoorOpenSound = GameObject.Find("MF_ToBridgeDoorSounds").transform.Find("MF_ToBridgeDoorOpenSound").GetComponent<AudioSource>();
        MF_ToBridgeDoorClosingSound = GameObject.Find("MF_ToBridgeDoorSounds").transform.Find("MF_ToBridgeDoorClosingSound").GetComponent<AudioSource>();
        MF_ToBridgeDoorClosedSound = GameObject.Find("MF_ToBridgeDoorSounds").transform.Find("MF_ToBridgeDoorClosedSound").GetComponent<AudioSource>();
        MF_ToBridgeDoorAlarmSound = GameObject.Find("MF_ToBridgeDoorSounds").transform.Find("MF_ToBridgeDoorAlarmSound").GetComponent<AudioSource>();

        MF_ToBridgeDoorCountdown = new AudioSource[10];

        for (int i = 0; i < 10; i++)
        {
            MF_ToBridgeDoorCountdown[i] = GameObject.Find("MF_ToBridgeDoorSounds").transform.Find("MF_ToBridgeDoorCountDown" + i).GetComponent<AudioSource>();
        }

        Bridge_ToMFDoorOpeningSound = GameObject.Find("Bridge_ToMFDoorSounds").transform.Find("Bridge_ToMFDoorOpeningSound").GetComponent<AudioSource>();
        Bridge_ToMFDoorOpenSound = GameObject.Find("Bridge_ToMFDoorSounds").transform.Find("Bridge_ToMFDoorOpenSound").GetComponent<AudioSource>();
        Bridge_ToMFDoorClosingSound = GameObject.Find("Bridge_ToMFDoorSounds").transform.Find("Bridge_ToMFDoorClosingSound").GetComponent<AudioSource>();
        Bridge_ToMFDoorClosedSound = GameObject.Find("Bridge_ToMFDoorSounds").transform.Find("Bridge_ToMFDoorClosedSound").GetComponent<AudioSource>();
        Bridge_ToMFDoorAlarmSound = GameObject.Find("Bridge_ToMFDoorSounds").transform.Find("Bridge_ToMFDoorAlarmSound").GetComponent<AudioSource>();

        Bridge_ToMFDoorCountdown = new AudioSource[10];

        for (int i = 0; i < 10; i++)
        {
            Bridge_ToMFDoorCountdown[i] = GameObject.Find("Bridge_ToMFDoorSounds").transform.Find("Bridge_ToMFDoorCountDown" + i).GetComponent<AudioSource>();
        }

        //interruption control
        janitorOuterDoorInterrupted = false;    
        janitorInnerDoorInterrupted = false;
        bonsaiOuterDoorInterrupted = false;
        bonsaiInnerDoorInterrupted = false;
        bonsaiControlDoorInterrupted = false;
        corridor_ToMFDoorInterrupted = false;
        mf_ToCorridorDoorInterrupted = false;
        melter_ToMFDoorInterrupted = false;
        mf_ToMelterDoorInterrupted = false;
        mf_ToBridgeDoorInterrupted = false;
        bridge_ToMFDoorInterrupted = false;

        doorAnimationTime = 3f;

        //animationtimercounters
        outerJanitorTimer = 0f;
        innerJanitorTimer = 0f;
        outerBonsaiTimer = 0f;
        innerBonsaiTimer = 0f;
        bonsaiControlTimer = 0f;
        corridor_ToMFTimer = 0f;
        mf_ToCorridorTimer = 0f;
        melter_ToMFTimer = 0f;
        mf_ToMelterTimer = 0f;
        bridge_ToMFTimer = 0f;
        mf_ToBridgeTimer = 0f;

        //doorcounters
        JanitorInnerCounter = GameObject.Find("JanitorInnerCounter").GetComponent<TextMeshPro>();
        JanitorOuterCounter = GameObject.Find("JanitorOuterCounter").GetComponent<TextMeshPro>();
        BonsaiInnerCounter = GameObject.Find("BONSAI_ROOM/BonsaiRoomDoubleDoor/BonsaiInnerCounter").GetComponent<TextMeshPro>();
        BonsaiOuterCounter = GameObject.Find("BONSAI_ROOM/BonsaiRoomDoubleDoor/BonsaiOuterCounter").GetComponent<TextMeshPro>();
        BonsaiControlCounterOuter = GameObject.Find("BonsaiControlCounterOuter").GetComponent<TextMeshPro>();
        BonsaiControlCounterInner = GameObject.Find("BonsaiControlCounterInner").GetComponent<TextMeshPro>();
        MFToCorridorCounter = GameObject.Find("MF_ToCorridorCounter").GetComponent<TextMeshPro>();
        CorridorToMFCounter = GameObject.Find("Corridor_ToMFCounter").GetComponent<TextMeshPro>();
        MFToBridgeCounter = GameObject.Find("MF_ToBridgeCounter").GetComponent<TextMeshPro>();
        BridgeToMFCounter = GameObject.Find("Bridge_ToMFCounter").GetComponent<TextMeshPro>();
        MFToMelterCounter = GameObject.Find("MF_ToMelterCounter").GetComponent<TextMeshPro>();
        MelterToMFCounter = GameObject.Find("Melter_ToMFCounter").GetComponent<TextMeshPro>();
    }
        
	void Update ()
    {
        CheckLights();
        CheckMachinery();
        CheckDoorsPowerStatus();
        OpenDoors();         
    }

    public void CheckLights()
    {
        if (MaintenanceCorridorLights.GetCurrentSnappedObject() != null)
        {
            //turn Maintenancelights on
            foreach (Light light in MaintenanceCorridorLightsContainer.GetComponentsInChildren<Light>())
            {
                light.intensity = 2f;
                light.color = Color.white;
            }
        }
        else
        {
            //turn Maintenancelights off
            foreach (Light light in MaintenanceCorridorLightsContainer.GetComponentsInChildren<Light>())
            {
                light.intensity = 1f;
                light.color = Color.red;
            }
        }
        if (JanitorLights.GetCurrentSnappedObject() != null)
        {
            //turn Maintenancelights on
            foreach (Light light in JanitorLightsContainer.GetComponentsInChildren<Light>())
            {
                light.intensity = 2f;
                light.color = Color.white;
            }
        }
        else
        {
            //turn Maintenancelights off
            foreach (Light light in JanitorLightsContainer.GetComponentsInChildren<Light>())
            {
                light.intensity = 1f;
                light.color = Color.red;
            }
        }
        if (BonsaiLights.GetCurrentSnappedObject() != null)
        {
            //turn Maintenancelights on
            foreach (Light light in BonsaiLightsContainer.GetComponentsInChildren<Light>())
            {
                light.intensity = 2f;
                light.color = Color.white;
            }
        }
        else
        {
            //turn Maintenancelights off
            foreach (Light light in BonsaiLightsContainer.GetComponentsInChildren<Light>())
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
            //Debug.Log("Bridge on");
        }
        else
        {
            //turn BridgeMachinery off
            BridgeTerminal.DeactivateMonitor();
            //Debug.Log("Bridge off");
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
        // keys get ejected from the scanners if wrong clearance level

        //Maintenance area 
        //JANITOR ROOM
        if (janitorDoorPowered)
        {
            if (((JanitorDoorToCorridorSnapZone.GetCurrentSnappedObject() != null && JanitorDoorToCorridorSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 1) || janitorInnerDoorInterrupted)
               /*&& !janitorToCorridorDoorOpening*/)
            {
                if (janitorToCorridorDoorClosed || janitorToCorridorDoorClosing)  //THIS CHANGE TO ALLL!!!!! 
                {
                    //Open Janitor door (from the inside), or if it was closing, the coroutine will instead interrupt the closing and open it                                                                                   
                    StartCoroutine("InnerJanitorDoorOpening");
                }
                else if (janitorToCorridorDoorClosingSoon) //aka it is open and no correct key in it
                {
                    StopCoroutine("DelayedAutomaticCloseInnerJanitor");  //ends the 10 second countdown of door closing
                    JanitorInnerCounter.text = 10.ToString();
                    JanitorInnerCounter.color = Color.white;
                    janitorToCorridorDoorClosingSoon = false;
                }
                if (corridorDoorsPowered && !corridorToJanitorDoorOpening && JanitorDoorToCorridorSnapZone.GetCurrentSnappedObject() != null && JanitorDoorToCorridorSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 1) //probably unnecessary to check for closing and opening here too
                {
                    if (corridorToJanitorDoorClosed || corridorToJanitorDoorClosing)  //change ienumerator too
                    {
                        StartCoroutine("OuterJanitorDoorOpening");
                    }
                    else if (corridorToJanitorDoorClosingSoon)
                    {
                        StopCoroutine("DelayedAutomaticCloseOuterJanitor");
                        corridorToJanitorDoorClosingSoon = false;
                        JanitorOuterCounter.text = 10.ToString();
                        JanitorOuterCounter.color = Color.white;
                    }
                }
            }
            else if (JanitorDoorToCorridorSnapZone.GetCurrentSnappedObject() != null && JanitorDoorToCorridorSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 1)
            {
                //show that the key is wrong to the player, play sound
                InnerJanitorDoorAlarmSound.Play();
                JanitorDoorToCorridorSnapZone.ForceUnsnap();

            }
            //check when to close the door (no correct key in either lock)
            if (janitorToCorridorDoorOpen && !janitorToCorridorDoorClosingSoon
               && (JanitorDoorToCorridorSnapZone.GetCurrentSnappedObject() == null || JanitorDoorToCorridorSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 1)
               && (CorridorDoorToJanitorSnapZone.GetCurrentSnappedObject() == null || CorridorDoorToJanitorSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 1 || !corridorDoorsPowered)
               && !janitorInnerDoorInterrupted)
            {
                //waits 10 seconds and then starts closing the door for 3 s
                StartCoroutine("DelayedAutomaticCloseInnerJanitor");
            }
        }
        //BONSAI DOOR
        if (bonsaiDoorPowered)
        {
            //bonsai to corridor with button
            if (BonsaiDoorToCorridorButton.AtMaxLimit() || bonsaiInnerDoorInterrupted)
            {
                //if closed, then open
                if (bonsaiToCorridorDoorClosed || bonsaiToCorridorDoorClosing)
                {
                    StartCoroutine("InnerBonsaiDoorOpening");
                }
                //if open already, then reset door timer
                else if (bonsaiToCorridorDoorClosingSoon)
                {
                    StopCoroutine("DelayedAutomaticCloseInnerBonsai");    //stop earlier timer, start a new one  
                    BonsaiInnerCounter.text = 10.ToString();
                    BonsaiInnerCounter.color = Color.white;
                    bonsaiToCorridorDoorClosingSoon = false;
                }
                //if corridor powered
                if (corridorDoorsPowered && !corridorToBonsaiDoorOpening && BonsaiDoorToCorridorButton.AtMaxLimit())
                {
                    //if corridor side door is closed, open it
                    if (corridorToBonsaiDoorClosed || corridorToBonsaiDoorClosing)
                    {
                        StartCoroutine("OuterBonsaiDoorOpening");
                    }
                    else if (corridorToBonsaiDoorClosingSoon) //aka it is open 
                    {
                        StopCoroutine("DelayedAutomaticCloseOuterBonsai");  //ends the 10 second countdown of door closing
                        BonsaiOuterCounter.text = 10.ToString();
                        BonsaiOuterCounter.color = Color.white;
                        if (!bonsaiOuterDoorInterrupted)
                        {
                            StartCoroutine("DelayedAutomaticCloseOuterBonsai");
                        }
                        else
                        {
                            bonsaiToCorridorDoorClosingSoon = false;
                        }
                    }
                }
            }
            if (bonsaiToCorridorDoorOpen && !bonsaiToCorridorDoorClosingSoon && !bonsaiInnerDoorInterrupted)
            {
                StartCoroutine("DelayedAutomaticCloseInnerBonsai");
            }
            
            //control door
            
            //bonsaiToControlBonsai
            if ((BonsaiToControlBonsaiSnapZone.GetCurrentSnappedObject() != null && BonsaiToControlBonsaiSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 3) || bonsaiControlDoorInterrupted)
            {
                //in case the player has put another copy of the same key on the other side already, keeping it open, then adding a new key will not re-trigger the opening animation              
                if (bonsaiControlDoorClosed || bonsaiControlDoorClosing)
                {
                    //Open ControlBonsai door                                                                 
                    StartCoroutine("ControlBonsaiDoorOpening");
                }
                else if (bonsaiControlDoorClosingSoon) //aka it is open and no correct key in it
                {
                    StopCoroutine("DelayedAutomaticCloseControlBonsai");  //ends the 10 second countdown of door closing
                    bonsaiControlDoorClosingSoon = false;
                    BonsaiControlCounterOuter.text = 10.ToString();
                    BonsaiControlCounterOuter.color = Color.white;
                    BonsaiControlCounterInner.text = 10.ToString();
                    BonsaiControlCounterInner.color = Color.white;
                }
            }
            else if (BonsaiToControlBonsaiSnapZone.GetCurrentSnappedObject() != null && BonsaiToControlBonsaiSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 3)
            {
                //show that the key is wrong to the player
                BonsaiControlDoorAlarmSound.Play();
                BonsaiToControlBonsaiSnapZone.ForceUnsnap();
            }
           
            //controlBonsaiToBonsai
            if (BonsaiControlToBonsaiSnapZone.GetCurrentSnappedObject() != null && BonsaiControlToBonsaiSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 3) /*|| bonsaiControlDoorInterrupted*/ //not necessary as checked in the other above
            {
                //in case the player has put another copy of the same key on the other side already, keeping it open, then adding a new key will not re-trigger the opening animation              
                if (bonsaiControlDoorClosed || bonsaiControlDoorClosing)
                {
                    //Open ControlBonsai door                                                                        
                    StartCoroutine("ControlBonsaiDoorOpening");
                }
                else if (bonsaiControlDoorClosingSoon) //aka it is open and no correct key in it
                {
                    StopCoroutine("DelayedAutomaticCloseControlBonsai");  //ends the 10 second countdown of door closing
                    bonsaiControlDoorClosingSoon = false;
                    BonsaiControlCounterOuter.text = 10.ToString();
                    BonsaiControlCounterOuter.color = Color.white;
                    BonsaiControlCounterInner.text = 10.ToString();
                    BonsaiControlCounterInner.color = Color.white;
                }
            }
            else if (BonsaiControlToBonsaiSnapZone.GetCurrentSnappedObject() != null && BonsaiControlToBonsaiSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 3)
            {
                //show that the key is wrong to the player
                BonsaiControlDoorAlarmSound.Play();
                BonsaiControlToBonsaiSnapZone.ForceUnsnap();
            }

            //this is joint for both sides of the door naturally
            if (bonsaiControlDoorOpen && !bonsaiControlDoorClosingSoon && !bonsaiControlDoorInterrupted
               && (BonsaiToControlBonsaiSnapZone.GetCurrentSnappedObject() == null || BonsaiToControlBonsaiSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 3)
               && (BonsaiControlToBonsaiSnapZone.GetCurrentSnappedObject() == null || BonsaiControlToBonsaiSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 3))

            {
                StartCoroutine("DelayedAutomaticCloseControlBonsai");
            }
        }
        //CORRIDOR DOORS
        //CorridorDoorToMainFacility doesn't need a keycard, only button press
        //press starts a countdown of 10s, visible in the door, pressing again resets countdown      
        if (corridorDoorsPowered)
        {
            // corridor to MF
            if (CorridorDoorToMainFacilityButton.AtMaxLimit() || corridor_ToMFDoorInterrupted)
            {
                //if closed, then open
                if (corridorToMFDoorClosed || corridorToMFDoorClosing)
                {
                    StartCoroutine("CorridorToMFDoorOpening");
                }
                //if open already, then reset door timer
                else if (corridorToMFDoorClosingSoon)
                {
                    StopCoroutine("DelayedAutomaticCloseCorridorToMF");    //stop earlier timer, start a new one  
                    CorridorToMFCounter.text = 10.ToString();
                    CorridorToMFCounter.color = Color.white;
                    corridorToMFDoorClosingSoon = false;
                }
                //if MF powered
                if (mainFacilityDoorsPowered && !mfToCorridorDoorOpening && CorridorDoorToMainFacilityButton.AtMaxLimit())
                {
                    //if MF side door is closed, open it
                    if (mfToCorridorDoorClosed || mfToCorridorDoorClosing)
                    {
                        StartCoroutine("MFToCorridorDoorOpening");
                    }
                    else if (mfToCorridorDoorClosingSoon) //aka it is open 
                    {
                        StopCoroutine("DelayedAutomaticCloseMFToCorridor");  //ends the 10 second countdown of door closing
                        MFToCorridorCounter.text = 10.ToString();
                        MFToCorridorCounter.color = Color.white;
                        if (!mf_ToCorridorDoorInterrupted)
                        {
                            StartCoroutine("DelayedAutomaticCloseMFToCorridor");
                        }
                        else
                        {
                            mfToCorridorDoorClosingSoon = false;
                        }
                    }
                }
            }
            if (corridorToMFDoorOpen && !corridorToMFDoorClosingSoon && !corridor_ToMFDoorInterrupted)
            {
                StartCoroutine("DelayedAutomaticCloseCorridorToMF");
            }
            //Corridor to Bonsai with button
            if (CorridorDoorToBonsaiButton.AtMaxLimit() || bonsaiOuterDoorInterrupted)
            {
                //if closed, then open
                if (corridorToBonsaiDoorClosed || corridorToBonsaiDoorClosing)
                {
                    StartCoroutine("OuterBonsaiDoorOpening");
                }
                //if open already, then reset door timer
                else if (corridorToBonsaiDoorClosingSoon)
                {
                    StopCoroutine("DelayedAutomaticCloseOuterBonsai");    //stop earlier timer, start a new one  
                    BonsaiOuterCounter.text = 10.ToString();
                    BonsaiOuterCounter.color = Color.white;
                    corridorToBonsaiDoorClosingSoon = false;
                }
                //if bonsai powered
                if (bonsaiDoorPowered && !bonsaiToCorridorDoorOpening && CorridorDoorToBonsaiButton.AtMaxLimit())
                {
                    //if MF side door is closed, open it
                    if (bonsaiToCorridorDoorClosed || bonsaiToCorridorDoorClosing)
                    {
                        StartCoroutine("InnerBonsaiDoorOpening");
                    }
                    else if (bonsaiToCorridorDoorClosingSoon) //aka it is open 
                    {
                        StopCoroutine("DelayedAutomaticCloseInnerBonsai");  //ends the 10 second countdown of door closing
                        BonsaiInnerCounter.text = 10.ToString();
                        BonsaiInnerCounter.color = Color.white;
                        bonsaiToCorridorDoorClosingSoon = false;
                    }
                }
            }
            if (corridorToBonsaiDoorOpen && !corridorToBonsaiDoorClosingSoon && !bonsaiOuterDoorInterrupted)
            {
                StartCoroutine("DelayedAutomaticCloseOuterBonsai");
            }
            //corridor to Janitor
            if (((CorridorDoorToJanitorSnapZone.GetCurrentSnappedObject() != null && CorridorDoorToJanitorSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 1) || janitorOuterDoorInterrupted)
                /*&& !corridorToJanitorDoorOpening*/)
            {
                //in case the player has put another copy of the same key on the other side already, keeping it open, then adding a new key will not re-trigger the opening animation              
                if (corridorToJanitorDoorClosed || corridorToJanitorDoorClosing)
                {
                    //Open Janitor door (from the outside), or if it was closing, the coroutine will instead interrupt the closing and open it                                                                                         
                    StartCoroutine("OuterJanitorDoorOpening");
                }
                else if (corridorToJanitorDoorClosingSoon) //aka it is open and no correct key in it
                {
                    StopCoroutine("DelayedAutomaticCloseOuterJanitor");  //ends the 10 second countdown of door closing                   
                    corridorToJanitorDoorClosingSoon = false;
                    JanitorOuterCounter.text = 10.ToString();
                    JanitorOuterCounter.color = Color.white;
                }
                if (janitorDoorPowered && !janitorToCorridorDoorOpening && CorridorDoorToJanitorSnapZone.GetCurrentSnappedObject() != null && CorridorDoorToJanitorSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 1) 
                {
                    if (janitorToCorridorDoorClosed || janitorToCorridorDoorClosing)
                    {
                        //Open Janitor door (from the inside), or if it was closing, the coroutine will instead interrupt the closing and open it                                                                                   
                        StartCoroutine("InnerJanitorDoorOpening");
                    }
                    else if (janitorToCorridorDoorClosingSoon)
                    {
                        StopCoroutine("DelayedAutomaticCloseInnerJanitor");
                        janitorToCorridorDoorClosingSoon = false;
                        JanitorInnerCounter.text = 10.ToString();
                        JanitorInnerCounter.color = Color.white;
                    }
                }
            }
            else if (CorridorDoorToJanitorSnapZone.GetCurrentSnappedObject() != null && CorridorDoorToJanitorSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 1)
            {
                //show that the key is wrong to the player
                OuterJanitorDoorAlarmSound.Play();               
                CorridorDoorToJanitorSnapZone.ForceUnsnap();
            }
            if (corridorToJanitorDoorOpen && !corridorToJanitorDoorClosingSoon
               && (CorridorDoorToJanitorSnapZone.GetCurrentSnappedObject() == null || CorridorDoorToJanitorSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 1)
               && (JanitorDoorToCorridorSnapZone.GetCurrentSnappedObject() == null || JanitorDoorToCorridorSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 1 || !janitorDoorPowered)
               && !janitorOuterDoorInterrupted)
            {
                StartCoroutine("DelayedAutomaticCloseOuterJanitor");
            }
            //in case no power doors get stuck in the position they are in

            //MAIN FACILITY DOORS

            //MainFacilityDoorToCorridor doesn't need a keycard

            if (mainFacilityDoorsPowered)
            {
                //MF to Corridor
                if ((MainFacilityDoorToCorridorButton.AtMaxLimit() || mf_ToCorridorDoorInterrupted) /*&& !mfToCorridorDoorOpening*/)
                {
                    if (mfToCorridorDoorClosed || mfToCorridorDoorClosing)
                    {
                        StartCoroutine("MFToCorridorDoorOpening");
                    }
                    //if open already, then reset door timer
                    else if (mfToCorridorDoorClosingSoon)
                    {
                        StopCoroutine("DelayedAutomaticCloseMFToCorridor");
                        MFToCorridorCounter.text = 10.ToString();
                        MFToCorridorCounter.color = Color.white;                                              
                        mfToCorridorDoorClosingSoon = false;
                    }
                    //if corridor powered
                    if (corridorDoorsPowered && !corridorToMFDoorOpening && MainFacilityDoorToCorridorButton.AtMaxLimit())
                    {
                        //if corridor side door is closed, open it
                        if (corridorToMFDoorClosed || corridorToMFDoorClosing)
                        {
                            StartCoroutine("CorridorToMFDoorOpening");
                        }
                        else if (corridorToMFDoorClosingSoon) //aka it is open
                        {
                            StopCoroutine("DelayedAutomaticCloseCorridorToMF");  //ends the 10 second countdown of door closing
                            CorridorToMFCounter.text = 10.ToString();
                            CorridorToMFCounter.color = Color.white;
                            if (!corridor_ToMFDoorInterrupted)
                            {
                                StartCoroutine("DelayedAutomaticCloseCorridorToMF");
                            }
                            else
                            {
                                corridorToMFDoorClosingSoon = false;
                            }
                        }
                    }
                }
                if (mfToCorridorDoorOpen && !mfToCorridorDoorClosingSoon && !mf_ToCorridorDoorInterrupted)
                {
                    StartCoroutine("DelayedAutomaticCloseMFToCorridor");
                }

                //MF to Bridge
                if (((MainFacilityDoorToBridgeSnapZone.GetCurrentSnappedObject() != null && MainFacilityDoorToBridgeSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 3) || mf_ToBridgeDoorInterrupted)
                    /*&& !mfToBridgeDoorOpening*/)
                {
                    //open the door to Bridge 
                    if (mfToBridgeDoorClosed || mfToBridgeDoorClosing)
                    {
                        StartCoroutine("MFToBridgeDoorOpening");
                    }
                    else if (mfToBridgeDoorClosingSoon)
                    {
                        StopCoroutine("DelayedAutomaticCloseMFToBridge");
                        mfToBridgeDoorClosingSoon = false;
                        MFToBridgeCounter.text = 10.ToString();
                        MFToBridgeCounter.color = Color.white;
                    }
                    if (bridgeDoorsPowered && !bridgeToMFDoorOpening) //probably unnecessary to check for closing and opening here too
                    {
                        if (bridgeToMFDoorClosed || bridgeToMFDoorClosing && MainFacilityDoorToBridgeSnapZone.GetCurrentSnappedObject() != null && MainFacilityDoorToBridgeSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 3)
                        {
                            StartCoroutine("BridgeToMFDoorOpening");
                        }
                        else if (bridgeToMFDoorClosingSoon)  //bridge is different and will stay open if only one of the doors is jammed
                        {
                            StopCoroutine("DelayedAutomaticCloseBridgeToMF");
                            bridgeToMFDoorClosingSoon = false;
                            BridgeToMFCounter.text = 10.ToString();
                            BridgeToMFCounter.color = Color.white;
                        }
                    }
                }
                else if (MainFacilityDoorToBridgeSnapZone.GetCurrentSnappedObject() != null && MainFacilityDoorToBridgeSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 3)
                {
                    //show that the key is wrong to the player
                    MF_ToBridgeDoorAlarmSound.Play();
                    MainFacilityDoorToBridgeSnapZone.ForceUnsnap();
                }
                //start automatic closing if open and no key on either side, think about the elevator functionality here!
                if (mfToBridgeDoorOpen && !mfToBridgeDoorClosingSoon
                     && (MainFacilityDoorToBridgeSnapZone.GetCurrentSnappedObject() == null || MainFacilityDoorToBridgeSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 3)
                     && (BridgeDoorToMainFacilitySnapZone.GetCurrentSnappedObject() == null || BridgeDoorToMainFacilitySnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 3 || !bridgeDoorsPowered)
                     && !mf_ToBridgeDoorInterrupted)
                {
                    StartCoroutine("DelayedAutomaticCloseMFToBridge");
                }
                //Melter door MF side
                if (((MainFacilityDoorToMelterSnapZone.GetCurrentSnappedObject() != null && MainFacilityDoorToMelterSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 2) || mf_ToMelterDoorInterrupted)
                    /*&& !mfToMelterDoorOpening*/)
                {
                    //open the door to melter from MF
                    if (mfToMelterDoorClosed || mfToMelterDoorClosing)
                    {
                        StartCoroutine("MFToMelterDoorOpening");
                    }
                    else if (mfToMelterDoorClosingSoon)
                    {
                        StopCoroutine("DelayedAutomaticCloseMFToMelter");
                        mfToMelterDoorClosingSoon = false;
                        MFToMelterCounter.text = 10.ToString();
                        MFToMelterCounter.color = Color.white;
                    }
                    if (melterDoorsPowered && !melterToMFDoorOpening && MainFacilityDoorToMelterSnapZone.GetCurrentSnappedObject() != null && MainFacilityDoorToMelterSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 2)
                    {
                        if (melterToMFDoorClosed || melterToMFDoorClosing)
                        {
                            StartCoroutine("MelterToMFDoorOpening");
                        }
                        else if (melterToMFDoorClosingSoon)
                        {
                            StopCoroutine("DelayedAutomaticCloseMelterToMF");
                            melterToMFDoorClosingSoon = false;
                            MelterToMFCounter.text = 10.ToString();
                            MelterToMFCounter.color = Color.white;
                        }
                    }
                }
                else if (MainFacilityDoorToMelterSnapZone.GetCurrentSnappedObject() != null && MainFacilityDoorToMelterSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2)
                {
                    //show that the key is wrong to the player
                    MF_ToMelterDoorAlarmSound.Play();
                    MainFacilityDoorToMelterSnapZone.ForceUnsnap();
                }

                if (mfToMelterDoorOpen && !mfToMelterDoorClosingSoon
                    && (MainFacilityDoorToMelterSnapZone.GetCurrentSnappedObject() == null || MainFacilityDoorToMelterSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2)
                    && (MelterDoorToMainFacilitySnapZone.GetCurrentSnappedObject() == null || MelterDoorToMainFacilitySnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2 || !melterDoorsPowered)
                    && !mf_ToMelterDoorInterrupted)
                {
                    StartCoroutine("DelayedAutomaticCloseMFToMelter");
                }
            }
            //in case no power doors get stuck to their positions (closed or open) only janitor might get stuck in between thanks to timing
            else
            {             
            }

            //BRIDGE INNER DOOR

            if (bridgeDoorsPowered)
            {
                if (((BridgeDoorToMainFacilitySnapZone.GetCurrentSnappedObject() != null && BridgeDoorToMainFacilitySnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 3) || bridge_ToMFDoorInterrupted)
                /*&& !bridgeToMFDoorOpening*/)
                {
                    //open the door from Bridge to MF
                    if (bridgeToMFDoorClosed || bridgeToMFDoorClosing)
                    {
                        StartCoroutine("BridgeToMFDoorOpening");
                    }
                    else if (bridgeToMFDoorClosingSoon)
                    {
                        StopCoroutine("DelayedAutomaticCloseBridgeToMF");
                        bridgeToMFDoorClosingSoon = false;
                        BridgeToMFCounter.text = 10.ToString();
                        BridgeToMFCounter.color = Color.white;
                    }
                    if (mainFacilityDoorsPowered && !mfToBridgeDoorOpening) //probably unnecessary to check for closing and opening here too
                    {
                        if (mfToBridgeDoorClosed || mfToBridgeDoorClosing && BridgeDoorToMainFacilitySnapZone.GetCurrentSnappedObject() != null && BridgeDoorToMainFacilitySnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 3)
                        {
                            StartCoroutine("MFToBridgeDoorOpening");
                        }
                        else if (mfToBridgeDoorClosingSoon)   //Bridge should be different as it is the elevator
                        {
                            StopCoroutine("DelayedAutomaticCloseMFToBridge");
                            mfToBridgeDoorClosingSoon = false;
                        }
                    }
                }
                else if (BridgeDoorToMainFacilitySnapZone.GetCurrentSnappedObject() != null && BridgeDoorToMainFacilitySnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 3)
                {
                    //show that the key is wrong to the player
                    Bridge_ToMFDoorAlarmSound.Play();
                    BridgeDoorToMainFacilitySnapZone.ForceUnsnap();
                }

                if (bridgeToMFDoorOpen && !bridgeToMFDoorClosingSoon
                    && (BridgeDoorToMainFacilitySnapZone.GetCurrentSnappedObject() == null || BridgeDoorToMainFacilitySnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 3)
                    && (MainFacilityDoorToBridgeSnapZone.GetCurrentSnappedObject() == null || MainFacilityDoorToBridgeSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 3 || !mainFacilityDoorsPowered)
                    && !bridge_ToMFDoorInterrupted)
                {
                    StartCoroutine("DelayedAutomaticCloseBridgeToMF");                
                }
            }
            else  //doors stay put
            {
                
            }

            //MELTER DOOR

            if (melterDoorsPowered)
            {
                if (((MelterDoorToMainFacilitySnapZone.GetCurrentSnappedObject() != null && MelterDoorToMainFacilitySnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 2) || melter_ToMFDoorInterrupted)
                   /*&& !melterToMFDoorOpening*/)
                {
                    //open the door to MF from Melter
                    if (melterToMFDoorClosed || melterToMFDoorClosing)
                    {
                        StartCoroutine("MelterToMFDoorOpening");
                    }
                    else if (melterToMFDoorClosingSoon)
                    {
                        StopCoroutine("DelayedAutomaticCloseMelterToMF");
                        melterToMFDoorClosingSoon = false;
                        MelterToMFCounter.text = 10.ToString();
                        MelterToMFCounter.color = Color.white;
                    }
                    if (mainFacilityDoorsPowered && !mfToMelterDoorOpening && MelterDoorToMainFacilitySnapZone.GetCurrentSnappedObject() != null && MelterDoorToMainFacilitySnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 2) //probably unnecessary to check for closing and opening here too
                    {
                        if (mfToMelterDoorClosed || mfToMelterDoorClosing)
                        {
                            StartCoroutine("MFToMelterDoorOpening");
                        }
                        else if (mfToMelterDoorClosingSoon)
                        {
                            StopCoroutine("DelayedAutomaticCloseMFToMelter");
                            mfToMelterDoorClosingSoon = false;
                            MFToMelterCounter.text = 10.ToString();
                            MFToMelterCounter.color = Color.white;
                        }
                    }
                }
                else if (MelterDoorToMainFacilitySnapZone.GetCurrentSnappedObject() != null && MelterDoorToMainFacilitySnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2)
                {
                    //show that the key is wrong to the player
                    Melter_ToMFDoorAlarmSound.Play();
                    MelterDoorToMainFacilitySnapZone.ForceUnsnap();
                }

                if (melterToMFDoorOpen && !melterToMFDoorClosingSoon
                    && (MelterDoorToMainFacilitySnapZone.GetCurrentSnappedObject() == null || MelterDoorToMainFacilitySnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2)
                    && (MainFacilityDoorToMelterSnapZone.GetCurrentSnappedObject() == null || MainFacilityDoorToMelterSnapZone.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 2 || !mainFacilityDoorsPowered)
                    && !melter_ToMFDoorInterrupted)
                {
                    StartCoroutine("DelayedAutomaticCloseMelterToMF");
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
            JanitorInnerCounter.text = (10 - i).ToString();
            if (i < 7)
            {
                JanitorInnerCounter.color = Color.white;
            }
            else if (i == 7 || i == 8)
            {
                JanitorInnerCounter.color = Color.yellow;
            }
            else
            {
                JanitorInnerCounter.color = Color.red;
            }
            yield return new WaitForSecondsRealtime(1f);
        }
        if (janitorToCorridorDoorOpen && JanitorDoorInnerAnim.GetInteger("INTERRUPTED") == 0)
        {
            JanitorDoorInnerAnim.SetBool("OPEN", false);
            JanitorDoorInnerAnim.SetFloat("Speed", 1f);     //makes the animator go to normal closing animation, in this case the closing was not interrupted during latest close
        }
        //door was interrupted by player or object and reopened some point during closing animation, in this case the door will close but at different part of the animator
        else if (janitorToCorridorDoorOpen)
        {
            JanitorDoorInnerAnim.SetBool("OPEN", false);
            JanitorDoorInnerAnim.SetFloat("Speed", 1f);
        }
        JanitorInnerCounter.text = 0.ToString();
        janitorToCorridorDoorClosing = true;
        janitorToCorridorDoorOpen = false;
        janitorToCorridorDoorClosingSoon = false;
        InnerJanitorDoorClosingSound.Play();
        innerJanitorTimer = 0f;
        StartCoroutine(CounterInners("InnerJanitor"));    //this calculates how long it takes for this animation to finish, this is needed in order to see how long it takes until possible interruption
        yield return new WaitForSecondsRealtime(doorAnimationTime);
        janitorToCorridorDoorClosing = false;
        janitorToCorridorDoorClosed = true;
        InnerJanitorDoorClosingSound.Stop();
        InnerJanitorDoorClosedSound.Play();
    }

    IEnumerator InnerJanitorDoorOpening()
    {
        JanitorInnerCounter.text = 10.ToString();
        JanitorInnerCounter.color = Color.white;
        if (janitorToCorridorDoorClosed)
        {
            JanitorDoorInnerAnim.SetInteger("INTERRUPTED", 0);
            JanitorDoorInnerAnim.SetBool("OPEN", true);
            JanitorDoorOuterAnim.SetFloat("Speed", 1f);
        }
        //in case the door is opened while it is already closing, this can occur by player putting a keycard, pressing a button, or by placing themselves or an object between doors
        //this path is taken when the interrupt parameter is true, which is called from an outside OnTriggerEnter, or opendoors method
        else if (janitorToCorridorDoorClosing)
        {
            StopCoroutine("DelayedAutomaticCloseInnerJanitor");
            janitorToCorridorDoorClosing = false;
            JanitorDoorInnerAnim.SetFloat("Speed", -1f);
            JanitorDoorInnerAnim.SetBool("OPEN", true);
            if (JanitorDoorInnerAnim.GetInteger("INTERRUPTED") == 0)
            {
                JanitorDoorInnerAnim.SetInteger("INTERRUPTED", 1);
            }
            else if (JanitorDoorInnerAnim.GetInteger("INTERRUPTED") == 1)
            {
                JanitorDoorInnerAnim.SetInteger("INTERRUPTED", 2);
            }
            else if (JanitorDoorInnerAnim.GetInteger("INTERRUPTED") == 2) //this happens when two interruptions in a row, animator cycle moves to previous
            {
                JanitorDoorInnerAnim.SetInteger("INTERRUPTED", 1);
            }
            InnerJanitorDoorClosingSound.Stop();
            //here we also play either the alarm sound in case the door was stopped by an object or player, or some other sound in case it was key card or button press
        }      
        janitorToCorridorDoorOpening = true;
        janitorToCorridorDoorClosed = false;
        InnerJanitorDoorOpeningSound.Play();
        float waitTime = JanitorDoorInnerAnim.GetCurrentAnimatorStateInfo(0).length - (doorAnimationTime - innerJanitorTimer);  //check the remaining time of the state, this should calculate how far the door is from the open state
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
            JanitorOuterCounter.text = (10 - i).ToString();
            if (i < 7)
            {
                JanitorOuterCounter.color = Color.white;
            }
            else if (i == 7 || i == 8)
            {
                JanitorOuterCounter.color = Color.yellow;
            }
            else
            {
                JanitorOuterCounter.color = Color.red;
            }
            yield return new WaitForSecondsRealtime(1f);
        }       
        if (corridorToJanitorDoorOpen && JanitorDoorOuterAnim.GetInteger("INTERRUPTED") == 0)
        {            
            JanitorDoorOuterAnim.SetBool("OPEN", false);
            JanitorDoorOuterAnim.SetFloat("Speed", 1f);     //makes the animator go to normal closing animation, in this case the closing was not interrupted during latest close            
        }
        //door was interrupted by player or object and reopened some point during closing animation, in this case the door will close but at different part of the animator
        else if (corridorToJanitorDoorOpen)
        {
            JanitorDoorOuterAnim.SetBool("OPEN", false);   //changed
            JanitorDoorOuterAnim.SetFloat("Speed", 1f);
        }
        JanitorOuterCounter.text = 0.ToString();
        corridorToJanitorDoorClosing = true;
        corridorToJanitorDoorOpen = false;
        corridorToJanitorDoorClosingSoon = false;
        OuterJanitorDoorClosingSound.Play();
        outerJanitorTimer = 0f;
        StartCoroutine(CounterOuters("OuterJanitor"));    //this calculates how long it takes for this animation to finish, this is needed in order to see how long it takes until possible interruption
        yield return new WaitForSecondsRealtime(doorAnimationTime);
        corridorToJanitorDoorClosing = false;
        corridorToJanitorDoorClosed = true;
        OuterJanitorDoorClosingSound.Stop();
        OuterJanitorDoorClosedSound.Play();
        Debug.Log("doorclosed");
    }

    IEnumerator OuterJanitorDoorOpening()
    {
        JanitorOuterCounter.text = 10.ToString();
        JanitorOuterCounter.color = Color.white;
        //checks that the door wasn't closed midway last time and if was then closes it through other transition path
        if (corridorToJanitorDoorClosed)
        {
            JanitorDoorOuterAnim.SetInteger("INTERRUPTED", 0);
            JanitorDoorOuterAnim.SetBool("OPEN", true);
            JanitorDoorOuterAnim.SetFloat("Speed", 1f);          
        }    
        //in case the door is opened while it is already closing, this can occur by player putting a keycard, pressing a button, or by placing themselves or an object between doors
        else if (corridorToJanitorDoorClosing)  
        {           
            StopCoroutine("DelayedAutomaticCloseOuterJanitor");
            corridorToJanitorDoorOpening = true;
            corridorToJanitorDoorClosing = false;
            JanitorDoorOuterAnim.SetFloat("Speed", -1f);         
            JanitorDoorOuterAnim.SetBool("OPEN", true);
            if (JanitorDoorOuterAnim.GetInteger("INTERRUPTED") == 0)
            {
                JanitorDoorOuterAnim.SetInteger("INTERRUPTED", 1);
            }
            else  if (JanitorDoorOuterAnim.GetInteger("INTERRUPTED") == 1) 
            {
                JanitorDoorOuterAnim.SetInteger("INTERRUPTED", 2);
            }
            else if (JanitorDoorOuterAnim.GetInteger("INTERRUPTED") == 2) //this happens when two interruptions in a row, animator cycle moves to previous
            {
                JanitorDoorOuterAnim.SetInteger("INTERRUPTED", 1);
            }
            OuterJanitorDoorClosingSound.Stop();            //stopping the sound of door closing as it will open now, also ending the coroutine so the door won't register as closed after a while (as it will be open)
            //here we also play either the alarm sound in case the door was stopped by an object or player, or some other sound in case it was key card or button press
        }
        corridorToJanitorDoorOpening = true;
        corridorToJanitorDoorClosed = false;
        OuterJanitorDoorOpeningSound.Play();
        //checks the current animation stateinfo from the base layer and its length     
        yield return new WaitForSecondsRealtime(JanitorDoorOuterAnim.GetCurrentAnimatorStateInfo(0).length - (doorAnimationTime - outerJanitorTimer));
        corridorToJanitorDoorOpening = false;
        corridorToJanitorDoorOpen = true;
        OuterJanitorDoorOpeningSound.Stop();
        OuterJanitorDoorOpenSound.Play();
        Debug.Log(corridorToJanitorDoorClosed + "wat");
    }
    //calculates time of closing animation to see when was interrupted, this has controlBonsai as well
    IEnumerator CounterOuters(string doorName)
    {
        if (doorName == "OuterJanitor")
        {           
            if (corridorToJanitorDoorClosing)
            {
                outerJanitorTimer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
                StartCoroutine(CounterOuters("OuterJanitor"));
            }           
            yield return null;
        }             
        else if (doorName == "OuterBonsai")
        {
            if (corridorToBonsaiDoorClosing)
            {
                outerBonsaiTimer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
                StartCoroutine(CounterOuters("OuterBonsai"));
            }
            yield return null;
        }
        else if (doorName == "ControlBonsai")
        {
            if (bonsaiControlDoorClosing)
            {
                bonsaiControlTimer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
                StartCoroutine(CounterOuters("ControlBonsai"));
            }
            yield return null;
        }
        else if (doorName == "MFToCorridor")
        {
            if (mfToCorridorDoorClosing)
            {
                mf_ToCorridorTimer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
                StartCoroutine(CounterOuters("MFToCorridor"));
            }
            yield return null;
        }
        else if (doorName == "MFToBridge")
        {
            if (mfToBridgeDoorClosing)
            {
                mf_ToBridgeTimer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
                StartCoroutine(CounterOuters("MFToBridge"));
            }
            yield return null;
        }
        else if (doorName == "MFToMelter")
        {
            if (mfToMelterDoorClosing)
            {
                mf_ToMelterTimer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
                StartCoroutine(CounterOuters("MFToMelter"));
            }
            yield return null;
        }
        else
        {
            yield return null;
        }
    }
    // the points of separating these two is that then the double door won't get confused on its countdown
    IEnumerator CounterInners(string doorName)
    {
        if (doorName == "InnerJanitor")
        {
            if (janitorToCorridorDoorClosing)
            {
                innerJanitorTimer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
                StartCoroutine(CounterInners("InnerJanitor"));
            }
            yield return null;
        }
        else if (doorName == "InnerBonsai")
        {
            if (bonsaiToCorridorDoorClosing)
            {
                innerBonsaiTimer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
                StartCoroutine(CounterInners("InnerBonsai"));
            }
            yield return null;
        }
        else if (doorName == "CorridorToMF")
        {
            if (corridorToMFDoorClosing)
            {
                corridor_ToMFTimer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
                StartCoroutine(CounterInners("CorridorToMF"));
            }
            yield return null;
        }
        else if (doorName == "BridgeToMF")
        {
            if (bridgeToMFDoorClosing)
            {
                bridge_ToMFTimer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
                StartCoroutine(CounterInners("BridgeToMF"));
            }
            yield return null;
        }
        else if (doorName == "MelterToMF")
        {
            if (mfToMelterDoorClosing)
            {
                mf_ToBridgeTimer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
                StartCoroutine(CounterInners("MelterToMF"));
            }
            yield return null;
        }
        else
        {
            yield return null;
        }
    }
    IEnumerator DelayedAutomaticCloseInnerBonsai()
    {
        bonsaiToCorridorDoorClosingSoon = true;
        for (int i = 0; i < 10; i++)
        {
            InnerBonsaiDoorCountdown[i].Play();
            BonsaiInnerCounter.text = (10 - i).ToString();
            if (i < 7)
            {
                BonsaiInnerCounter.color = Color.white;
            }
            else if (i == 7 || i == 8)
            {
                BonsaiInnerCounter.color = Color.yellow;
            }
            else
            {
                BonsaiInnerCounter.color = Color.red;
            }
            yield return new WaitForSecondsRealtime(1f);
        }
        if (bonsaiToCorridorDoorOpen && BonsaiDoorInnerAnim.GetInteger("INTERRUPTED") == 0)
        {
            BonsaiDoorInnerAnim.SetBool("OPEN", false);
            BonsaiDoorInnerAnim.SetFloat("Speed", 1f);
        }
        else if (bonsaiToCorridorDoorOpen)
        {
            BonsaiDoorInnerAnim.SetBool("OPEN", false);
            BonsaiDoorInnerAnim.SetFloat("Speed", 1f);
        }
        BonsaiInnerCounter.text = 0.ToString();
        bonsaiToCorridorDoorClosing = true;
        bonsaiToCorridorDoorOpen = false;
        bonsaiToCorridorDoorClosingSoon = false;
        InnerBonsaiDoorClosingSound.Play();
        innerBonsaiTimer = 0f;
        StartCoroutine(CounterInners("InnerBonsai"));
        yield return new WaitForSecondsRealtime(doorAnimationTime); //door closing time is 3s atm
        bonsaiToCorridorDoorClosed = true;
        bonsaiToCorridorDoorClosing = false;
        InnerBonsaiDoorClosingSound.Stop();
        InnerBonsaiDoorClosedSound.Play();
    }
    
    IEnumerator InnerBonsaiDoorOpening()
    {
        BonsaiInnerCounter.text = 10.ToString();
        BonsaiInnerCounter.color = Color.white;
        if (bonsaiToCorridorDoorClosed)
        {
            BonsaiDoorInnerAnim.SetInteger("INTERRUPTED", 0);
            BonsaiDoorInnerAnim.SetBool("OPEN", true);
            BonsaiDoorInnerAnim.SetFloat("Speed", 1f);
        }
        else if (bonsaiToCorridorDoorClosing)
        {
            StopCoroutine("DelayedAutomaticCloseInnerBonsai");
            bonsaiToCorridorDoorClosing = false;
            BonsaiDoorInnerAnim.SetFloat("Speed", -1f);
            BonsaiDoorInnerAnim.SetBool("OPEN", true);
            if (BonsaiDoorInnerAnim.GetInteger("INTERRUPTED") == 0)
            {
                BonsaiDoorInnerAnim.SetInteger("INTERRUPTED", 1);
            }
            else if (BonsaiDoorInnerAnim.GetInteger("INTERRUPTED") == 1)
            {
                BonsaiDoorInnerAnim.SetInteger("INTERRUPTED", 2);
            }
            else if (BonsaiDoorInnerAnim.GetInteger("INTERRUPTED") == 2) //this happens when two interruptions in a row, animator cycle moves to previous
            {
                BonsaiDoorInnerAnim.SetInteger("INTERRUPTED", 1);
            }
            InnerBonsaiDoorClosingSound.Stop();
            //here we also play either the alarm sound in case the door was stopped by an object or player, or some other sound in case it was key card or button press
        }

        bonsaiToCorridorDoorOpening = true;
        bonsaiToCorridorDoorClosed = false;
        InnerBonsaiDoorOpeningSound.Play();
        yield return new WaitForSecondsRealtime(BonsaiDoorInnerAnim.GetCurrentAnimatorStateInfo(0).length - (doorAnimationTime - innerBonsaiTimer)); //door opening time is 3s atm
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
            BonsaiOuterCounter.text = (10 - i).ToString();
            if (i < 7)
            {
                BonsaiOuterCounter.color = Color.white;
            }
            else if (i == 7 || i == 8)
            {
                BonsaiOuterCounter.color = Color.yellow;
            }
            else
            {
                BonsaiOuterCounter.color = Color.red;
            }
            yield return new WaitForSecondsRealtime(1f);
        }
        if (corridorToBonsaiDoorOpen && BonsaiDoorOuterAnim.GetInteger("INTERRUPTED") == 0)
        {
            BonsaiDoorOuterAnim.SetBool("OPEN", false);
            BonsaiDoorOuterAnim.SetFloat("Speed", 1f);
        }
        else if (corridorToBonsaiDoorOpen)
        {
            BonsaiDoorOuterAnim.SetBool("OPEN", false);
            BonsaiDoorOuterAnim.SetFloat("Speed", 1f);
        }
        BonsaiOuterCounter.text = 0.ToString();
        corridorToBonsaiDoorClosing = true;
        corridorToBonsaiDoorOpen = false;
        corridorToBonsaiDoorClosingSoon = false;
        OuterBonsaiDoorClosingSound.Play();
        outerBonsaiTimer = 0f;
        StartCoroutine(CounterOuters("OuterBonsai"));
        yield return new WaitForSecondsRealtime(doorAnimationTime); //door closing time is 3s atm
        corridorToBonsaiDoorClosed = true;
        corridorToBonsaiDoorClosing = false;
        OuterBonsaiDoorClosingSound.Stop();
        OuterBonsaiDoorClosedSound.Play();
    }

    IEnumerator OuterBonsaiDoorOpening()
    {
        BonsaiOuterCounter.text = 10.ToString();
        BonsaiOuterCounter.color = Color.white;
        if (corridorToBonsaiDoorClosed)
        {
            BonsaiDoorOuterAnim.SetInteger("INTERRUPTED", 0);
            BonsaiDoorOuterAnim.SetBool("OPEN", true);
            BonsaiDoorOuterAnim.SetFloat("Speed", 1f);
        }
        else if (corridorToBonsaiDoorClosing)
        {
            StopCoroutine("DelayedAutomaticCloseOuterBonsai");
            corridorToBonsaiDoorClosing = false;
            BonsaiDoorOuterAnim.SetFloat("Speed", -1f);
            BonsaiDoorOuterAnim.SetBool("OPEN", true);
            if (BonsaiDoorOuterAnim.GetInteger("INTERRUPTED") == 0)
            {
                BonsaiDoorOuterAnim.SetInteger("INTERRUPTED", 1);
            }
            else if (BonsaiDoorOuterAnim.GetInteger("INTERRUPTED") == 1)
            {
                BonsaiDoorOuterAnim.SetInteger("INTERRUPTED", 2);
            }
            else if (BonsaiDoorOuterAnim.GetInteger("INTERRUPTED") == 2) //this happens when two interruptions in a row, animator cycle moves to previous
            {
                BonsaiDoorOuterAnim.SetInteger("INTERRUPTED", 1);
            }
            OuterBonsaiDoorClosingSound.Stop();
            //here we also play either the alarm sound in case the door was stopped by an object or player, or some other sound in case it was key card or button press
        }
        corridorToBonsaiDoorOpening = true;
        corridorToBonsaiDoorClosed = false;
        OuterBonsaiDoorOpeningSound.Play();
        yield return new WaitForSecondsRealtime(BonsaiDoorOuterAnim.GetCurrentAnimatorStateInfo(0).length - (doorAnimationTime - outerBonsaiTimer)); 
        corridorToBonsaiDoorOpening = false;
        corridorToBonsaiDoorOpen = true;
        OuterBonsaiDoorOpeningSound.Stop();
        OuterBonsaiDoorOpenSound.Play();
    }

    IEnumerator DelayedAutomaticCloseControlBonsai()
    {
        bonsaiControlDoorClosingSoon = true;
        for (int i = 0; i < 10; i++)
        {
            BonsaiControlDoorCountdown[i].Play();
            BonsaiControlCounterOuter.text = (10 - i).ToString();
            BonsaiControlCounterInner.text = (10 - i).ToString();
            if (i < 7)
            {
                BonsaiControlCounterOuter.color = Color.white;
                BonsaiControlCounterInner.color = Color.white;
            }
            else if (i == 7 || i == 8)
            {
                BonsaiControlCounterOuter.color = Color.yellow;
                BonsaiControlCounterInner.color = Color.yellow;
            }
            else
            {
                BonsaiControlCounterOuter.color = Color.red;
                BonsaiControlCounterInner.color = Color.red;
            }
            yield return new WaitForSecondsRealtime(1f);
        }
        if (bonsaiControlDoorOpen && BonsaiControlAnim.GetInteger("INTERRUPTED") == 0)
        {
            BonsaiControlAnim.SetBool("OPEN", false);
            BonsaiControlAnim.SetFloat("Speed", 1f);
        }
        else if (bonsaiControlDoorOpen)
        {
            BonsaiControlAnim.SetBool("OPEN", false);
            BonsaiControlAnim.SetFloat("Speed", 1f);
        }
        BonsaiControlCounterOuter.text = 0.ToString();
        BonsaiControlCounterInner.text = 0.ToString();
        bonsaiControlDoorClosing = true;
        bonsaiControlDoorOpen = false;
        bonsaiControlDoorClosingSoon = false;
        BonsaiControlDoorClosingSound.Play();
        bonsaiControlTimer = 0f;
        StartCoroutine(CounterOuters("ControlBonsai"));
        yield return new WaitForSecondsRealtime(doorAnimationTime); //door closing time is 3s atm
        bonsaiControlDoorClosed = true;
        bonsaiControlDoorClosing = false;
        BonsaiControlDoorClosingSound.Stop();
        BonsaiControlDoorClosedSound.Play();
    }

    IEnumerator ControlBonsaiDoorOpening()
    {
        BonsaiControlCounterOuter.text = 10.ToString();
        BonsaiControlCounterOuter.color = Color.white;
        BonsaiControlCounterInner.text = 10.ToString();
        BonsaiControlCounterInner.color = Color.white;
        if (bonsaiControlDoorClosed)
        {
            BonsaiControlAnim.SetInteger("INTERRUPTED", 0);
            BonsaiControlAnim.SetBool("OPEN", true);
            BonsaiControlAnim.SetFloat("Speed", 1f);
        }
        else if (bonsaiControlDoorClosing)
        {
            StopCoroutine("DelayedAutomaticCloseBonsaiControl");
            bonsaiControlDoorClosing = false;
            BonsaiControlAnim.SetFloat("Speed", -1f);
            BonsaiControlAnim.SetBool("OPEN", true);
            if (BonsaiControlAnim.GetInteger("INTERRUPTED") == 0)
            {
                BonsaiControlAnim.SetInteger("INTERRUPTED", 1);
            }
            else if (BonsaiControlAnim.GetInteger("INTERRUPTED") == 1)
            {
                BonsaiControlAnim.SetInteger("INTERRUPTED", 2);
            }
            else if (BonsaiControlAnim.GetInteger("INTERRUPTED") == 2) //this happens when two interruptions in a row, animator cycle moves to previous
            {
                BonsaiControlAnim.SetInteger("INTERRUPTED", 1);
            }
            BonsaiControlDoorClosingSound.Stop();
            //here we also play either the alarm sound in case the door was stopped by an object or player, or some other sound in case it was key card or button press
        }
        bonsaiControlDoorOpening = true;
        bonsaiControlDoorClosed = false;
        BonsaiControlDoorOpeningSound.Play();
        yield return new WaitForSecondsRealtime(BonsaiControlAnim.GetCurrentAnimatorStateInfo(0).length - (doorAnimationTime - bonsaiControlTimer));
        bonsaiControlDoorOpening = false;
        bonsaiControlDoorOpen = true;
        BonsaiControlDoorOpeningSound.Stop();
        BonsaiControlDoorOpenSound.Play();
    }

    IEnumerator DelayedAutomaticCloseCorridorToMF()
    {
        corridorToMFDoorClosingSoon = true;
        for (int i = 0; i < 10; i++)    
        {
            Corridor_ToMFDoorCountdown[i].Play();
            CorridorToMFCounter.text = (10 - i).ToString();
            if (i < 7)
            {
                CorridorToMFCounter.color = Color.white;
            }
            else if (i == 7 || i == 8)
            {
                CorridorToMFCounter.color = Color.yellow;
            }
            else
            {
                CorridorToMFCounter.color = Color.red;
            }
            yield return new WaitForSecondsRealtime(1f);
        }
        if (corridorToMFDoorOpen && CorridorToMFDoorAnim.GetInteger("INTERRUPTED") == 0)
        {
            CorridorToMFDoorAnim.SetBool("OPEN", false);
            CorridorToMFDoorAnim.SetFloat("Speed", 1f);
        }
        else if (corridorToMFDoorOpen)
        {
            CorridorToMFDoorAnim.SetBool("OPEN", false);
            CorridorToMFDoorAnim.SetFloat("Speed", 1f);
        }
        CorridorToMFCounter.text = 0.ToString();
        corridorToMFDoorClosing = true;
        corridorToMFDoorOpen = false;
        corridorToMFDoorClosingSoon = false;
        Corridor_ToMFDoorClosingSound.Play();
        corridor_ToMFTimer = 0f;
        StartCoroutine(CounterInners("CorridorToMF"));
        yield return new WaitForSecondsRealtime(doorAnimationTime);
        corridorToMFDoorClosed = true;
        corridorToMFDoorClosing = false;
        Corridor_ToMFDoorClosingSound.Stop();
        Corridor_ToMFDoorClosedSound.Play();
    }

    IEnumerator CorridorToMFDoorOpening()
    {
        CorridorToMFCounter.color = Color.white;
        CorridorToMFCounter.text = 10.ToString();
        if (corridorToMFDoorClosed)
        {
            CorridorToMFDoorAnim.SetInteger("INTERRUPTED", 0);
            CorridorToMFDoorAnim.SetBool("OPEN", true);
            CorridorToMFDoorAnim.SetFloat("Speed", 1f);
        }
        else if (corridorToMFDoorClosing)
        {
            StopCoroutine("DelayedAutomaticCloseCorridorToMF");
            corridorToMFDoorClosing = false;
            CorridorToMFDoorAnim.SetFloat("Speed", -1f);
            CorridorToMFDoorAnim.SetBool("OPEN", true);
            if (CorridorToMFDoorAnim.GetInteger("INTERRUPTED") == 0)
            {
                CorridorToMFDoorAnim.SetInteger("INTERRUPTED", 1);
            }
            else if (CorridorToMFDoorAnim.GetInteger("INTERRUPTED") == 1)
            {
                CorridorToMFDoorAnim.SetInteger("INTERRUPTED", 2);
            }
            else if (CorridorToMFDoorAnim.GetInteger("INTERRUPTED") == 2) //this happens when two interruptions in a row, animator cycle moves to previous
            {
                CorridorToMFDoorAnim.SetInteger("INTERRUPTED", 1);
            }
            Corridor_ToMFDoorClosingSound.Stop();
            //here we also play either the alarm sound in case the door was stopped by an object or player, or some other sound in case it was key card or button press
        }
        corridorToMFDoorOpening = true;
        corridorToMFDoorClosed = false;
        Corridor_ToMFDoorOpeningSound.Play();
        yield return new WaitForSecondsRealtime(CorridorToMFDoorAnim.GetCurrentAnimatorStateInfo(0).length - (doorAnimationTime - corridor_ToMFTimer)); //door closing time is 3s atm
        corridorToMFDoorOpening = false;
        corridorToMFDoorOpen = true;
        Corridor_ToMFDoorOpeningSound.Stop();
        Corridor_ToMFDoorOpenSound.Play();
        //after button press door opens, start counting down for closing
        //StartCoroutine("DelayedAutomaticCloseCorridorToMF");
    }

    IEnumerator DelayedAutomaticCloseMFToCorridor()
    {
        mfToCorridorDoorClosingSoon = true;
        for (int i = 0; i < 10; i++)
        {
            MF_ToCorridorDoorCountdown[i].Play();
            MFToCorridorCounter.text = (10 - i).ToString();
            if (i < 7)
            {
                MFToCorridorCounter.color = Color.white;
            }
            else if (i == 7 || i == 8)
            {
                MFToCorridorCounter.color = Color.yellow;
            }
            else
            {
                MFToCorridorCounter.color = Color.red;
            }
            yield return new WaitForSecondsRealtime(1f);
        }
        if (mfToCorridorDoorOpen && MFToCorridorDoorAnim.GetInteger("INTERRUPTED") == 0)
        {
            MFToCorridorDoorAnim.SetBool("OPEN", false);
            MFToCorridorDoorAnim.SetFloat("Speed", 1f);
        }
        else if (mfToCorridorDoorOpen)
        {
            MFToCorridorDoorAnim.SetBool("OPEN", false);
            MFToCorridorDoorAnim.SetFloat("Speed", 1f);
        }
        MFToCorridorCounter.text = 0.ToString();
        mfToCorridorDoorClosing = true;
        mfToCorridorDoorOpen = false;
        mfToCorridorDoorClosingSoon = false;
        MF_ToCorridorDoorClosingSound.Play();
        mf_ToCorridorTimer = 0f;
        StartCoroutine(CounterOuters("MFToCorridor"));
        yield return new WaitForSecondsRealtime(doorAnimationTime);
        mfToCorridorDoorClosed = true;
        mfToCorridorDoorClosing = false;
        MF_ToCorridorDoorClosingSound.Stop();
        MF_ToCorridorDoorClosedSound.Play();
    }

    IEnumerator MFToCorridorDoorOpening()
    {
        MFToCorridorCounter.text = 10.ToString();
        MFToCorridorCounter.color = Color.white;
        if (mfToCorridorDoorClosed)
        {
            MFToCorridorDoorAnim.SetInteger("INTERRUPTED", 0);
            MFToCorridorDoorAnim.SetBool("OPEN", true);
            MFToCorridorDoorAnim.SetFloat("Speed", 1f);
        }
        else if (mfToCorridorDoorClosing)
        {
            StopCoroutine("DelayedAutomaticCloseMFToCorridor");
            mfToCorridorDoorClosing = false;
            MFToCorridorDoorAnim.SetFloat("Speed", -1f);
            MFToCorridorDoorAnim.SetBool("OPEN", true);
            if (MFToCorridorDoorAnim.GetInteger("INTERRUPTED") == 0)
            {
                MFToCorridorDoorAnim.SetInteger("INTERRUPTED", 1);
            }
            else if (MFToCorridorDoorAnim.GetInteger("INTERRUPTED") == 1)
            {
                MFToCorridorDoorAnim.SetInteger("INTERRUPTED", 2);
            }
            else if (MFToCorridorDoorAnim.GetInteger("INTERRUPTED") == 2) //this happens when two interruptions in a row, animator cycle moves to previous
            {
                MFToCorridorDoorAnim.SetInteger("INTERRUPTED", 1);
            }
            MF_ToCorridorDoorClosingSound.Stop();
            //here we also play either the alarm sound in case the door was stopped by an object or player, or some other sound in case it was key card or button press
        }
        mfToCorridorDoorOpening = true;
        mfToCorridorDoorClosed = false;
        MF_ToCorridorDoorOpeningSound.Play();
        yield return new WaitForSecondsRealtime(MFToCorridorDoorAnim.GetCurrentAnimatorStateInfo(0).length - (doorAnimationTime - mf_ToCorridorTimer)); //door closing time is 3s atm
        mfToCorridorDoorOpening = false;
        mfToCorridorDoorOpen = true;
        MF_ToCorridorDoorOpeningSound.Stop();
        MF_ToCorridorDoorOpenSound.Play();
        //after button press door opens, start counting down for closing
        //StartCoroutine("DelayedAutomaticCloseMFToCorridor");
    }

    IEnumerator DelayedAutomaticCloseMFToBridge()
    {
        mfToBridgeDoorClosingSoon = true;
        for (int i = 0; i < 10; i++)
        {
            MF_ToBridgeDoorCountdown[i].Play();
            MFToBridgeCounter.text = (10 - i).ToString();
            if (i < 7)
            {
                MFToBridgeCounter.color = Color.white;
            }
            else if (i == 7 || i == 8)
            {
                MFToBridgeCounter.color = Color.yellow;
            }
            else
            {
                MFToBridgeCounter.color = Color.red;
            }
            yield return new WaitForSecondsRealtime(1f);
        }
        if (mfToBridgeDoorOpen && MFToBridgeDoorAnim.GetInteger("INTERRUPTED") == 0)
        {
            MFToBridgeDoorAnim.SetBool("OPEN", false);
            MFToBridgeDoorAnim.SetFloat("Speed", 1f);
        }
        else if (mfToBridgeDoorOpen)
        {
            MFToBridgeDoorAnim.SetBool("OPEN", false);
            MFToBridgeDoorAnim.SetFloat("Speed", 1f);
        }
        MFToBridgeCounter.text = 0.ToString();
        mfToBridgeDoorClosing = true;
        mfToBridgeDoorOpen = false;
        mfToBridgeDoorClosingSoon = false;
        MF_ToBridgeDoorClosingSound.Play();
        mf_ToBridgeTimer = 0f;
        StartCoroutine(CounterOuters("MFToBridge"));      
        yield return new WaitForSecondsRealtime(doorAnimationTime);
        mfToBridgeDoorClosed = true;
        mfToBridgeDoorClosing = false;
        MF_ToBridgeDoorClosingSound.Stop();
        MF_ToBridgeDoorClosedSound.Play();
    }

    IEnumerator MFToBridgeDoorOpening()
    {
        MFToBridgeCounter.text = 10.ToString();
        MFToBridgeCounter.color = Color.white;
        if (mfToBridgeDoorClosed)
        {
            MFToBridgeDoorAnim.SetInteger("INTERRUPTED", 0);
            MFToBridgeDoorAnim.SetBool("OPEN", true);
            MFToBridgeDoorAnim.SetFloat("Speed", 1f);
        }
        else if (mfToBridgeDoorClosing)
        {
            StopCoroutine("DelayedAutomaticCloseMFToBridge");
            mfToBridgeDoorClosing = false;
            MFToBridgeDoorAnim.SetFloat("Speed", -1f);
            MFToBridgeDoorAnim.SetBool("OPEN", true);
            if (MFToBridgeDoorAnim.GetInteger("INTERRUPTED") == 0)
            {
                MFToBridgeDoorAnim.SetInteger("INTERRUPTED", 1);
            }
            else if (MFToBridgeDoorAnim.GetInteger("INTERRUPTED") == 1)
            {
                MFToBridgeDoorAnim.SetInteger("INTERRUPTED", 2);
            }
            else if (MFToBridgeDoorAnim.GetInteger("INTERRUPTED") == 2) //this happens when two interruptions in a row, animator cycle moves to previous
            {
                MFToBridgeDoorAnim.SetInteger("INTERRUPTED", 1);
            }
            MF_ToBridgeDoorClosingSound.Stop();
            //here we also play either the alarm sound in case the door was stopped by an object or player, or some other sound in case it was key card or button press
        }
        mfToBridgeDoorOpening = true;
        mfToBridgeDoorClosed = false;
        MF_ToBridgeDoorOpeningSound.Play();
        yield return new WaitForSecondsRealtime(MFToBridgeDoorAnim.GetCurrentAnimatorStateInfo(0).length - (doorAnimationTime - mf_ToBridgeTimer)); //door closing time is 3s atm
        mfToBridgeDoorOpening = false;
        mfToBridgeDoorOpen = true;
        MF_ToBridgeDoorOpeningSound.Stop();
        MF_ToBridgeDoorOpenSound.Play();
    }

    IEnumerator DelayedAutomaticCloseBridgeToMF()
    {
        bridgeToMFDoorClosingSoon = true;
        for (int i = 0; i < 10; i++)
        {
            Bridge_ToMFDoorCountdown[i].Play();
            BridgeToMFCounter.text = (10 - i).ToString();
            if (i < 7)
            {
                BridgeToMFCounter.color = Color.white;
            }
            else if (i == 7 || i == 8)
            {
                BridgeToMFCounter.color = Color.yellow;
            }
            else
            {
                BridgeToMFCounter.color = Color.red;
            }
            yield return new WaitForSecondsRealtime(1f);
        }
        if (bridgeToMFDoorOpen && BridgeToMFDoorAnim.GetInteger("INTERRUPTED") == 0)
        {
            BridgeToMFDoorAnim.SetBool("OPEN", false);
            BridgeToMFDoorAnim.SetFloat("Speed", 1f);
        }
        else if (bridgeToMFDoorOpen)
        {
            BridgeToMFDoorAnim.SetBool("OPEN", false);
            BridgeToMFDoorAnim.SetFloat("Speed", 1f);
        }
        BridgeToMFCounter.text = 0.ToString();
        bridgeToMFDoorClosing = true;
        bridgeToMFDoorOpen = false;
        bridgeToMFDoorClosingSoon = false;
        Bridge_ToMFDoorClosingSound.Play();
        bridge_ToMFTimer = 0f;
        StartCoroutine(CounterInners("BridgeToMF"));
        yield return new WaitForSecondsRealtime(doorAnimationTime);
        bridgeToMFDoorClosed = true;
        bridgeToMFDoorClosing = false;
        Bridge_ToMFDoorClosingSound.Stop();
        Bridge_ToMFDoorClosedSound.Play();
    }

    IEnumerator BridgeToMFDoorOpening()
    {
        BridgeToMFCounter.text = 10.ToString();
        BridgeToMFCounter.color = Color.white;
        if (bridgeToMFDoorClosed)
        {
            BridgeToMFDoorAnim.SetInteger("INTERRUPTED", 0);
            BridgeToMFDoorAnim.SetBool("OPEN", true);
            BridgeToMFDoorAnim.SetFloat("Speed", 1f);
        }
        else if (bridgeToMFDoorClosing)
        {
            StopCoroutine("DelayedAutomaticCloseBridgeToMF");
            bridgeToMFDoorClosing = false;
            BridgeToMFDoorAnim.SetFloat("Speed", -1f);
            BridgeToMFDoorAnim.SetBool("OPEN", true);
            if (BridgeToMFDoorAnim.GetInteger("INTERRUPTED") == 0)
            {
                BridgeToMFDoorAnim.SetInteger("INTERRUPTED", 1);
            }
            else if (BridgeToMFDoorAnim.GetInteger("INTERRUPTED") == 1)
            {
                BridgeToMFDoorAnim.SetInteger("INTERRUPTED", 2);
            }
            else if (BridgeToMFDoorAnim.GetInteger("INTERRUPTED") == 2) //this happens when two interruptions in a row, animator cycle moves to previous
            {
                BridgeToMFDoorAnim.SetInteger("INTERRUPTED", 1);
            }
            Bridge_ToMFDoorClosingSound.Stop();
            //here we also play either the alarm sound in case the door was stopped by an object or player, or some other sound in case it was key card or button press
        }
        bridgeToMFDoorOpening = true;
        bridgeToMFDoorClosed = false;
        Bridge_ToMFDoorOpeningSound.Play();
        yield return new WaitForSecondsRealtime(BridgeToMFDoorAnim.GetCurrentAnimatorStateInfo(0).length - (doorAnimationTime - bridge_ToMFTimer)); //door closing time is 3s atm
        bridgeToMFDoorOpening = false;
        bridgeToMFDoorOpen = true;
        Bridge_ToMFDoorOpeningSound.Stop();
        Bridge_ToMFDoorOpenSound.Play();
    }

    IEnumerator DelayedAutomaticCloseMFToMelter()
    {
        mfToMelterDoorClosingSoon = true;
        for (int i = 0; i < 10; i++)
        {
            MF_ToMelterDoorCountdown[i].Play();
            MFToMelterCounter.text = (10 - i).ToString();
            if (i < 7)
            {
                MFToMelterCounter.color = Color.white;
            }
            else if (i == 7 || i == 8)
            {
                MFToMelterCounter.color = Color.yellow;
            }
            else
            {
                MFToMelterCounter.color = Color.red;
            }
            yield return new WaitForSecondsRealtime(1f);
        }
        if (mfToMelterDoorOpen && MFToMelterDoorAnim.GetInteger("INTERRUPTED") == 0)
        {
            MFToMelterDoorAnim.SetBool("OPEN", false);
            MFToMelterDoorAnim.SetFloat("Speed", 1f);
        }
        else if (mfToMelterDoorOpen)
        {
            MFToMelterDoorAnim.SetBool("OPEN", false);
            MFToMelterDoorAnim.SetFloat("Speed", 1f);
        }
        MFToMelterCounter.text = 0.ToString();
        mfToMelterDoorClosing = true;
        mfToMelterDoorOpen = false;
        mfToMelterDoorClosingSoon = false;
        MF_ToMelterDoorClosingSound.Play();
        mf_ToMelterTimer = 0f;
        StartCoroutine(CounterOuters("MFToMelter"));
        yield return new WaitForSecondsRealtime(doorAnimationTime);
        mfToMelterDoorClosed = true;
        mfToMelterDoorClosing = false;
        MF_ToMelterDoorClosingSound.Stop();
        MF_ToMelterDoorClosedSound.Play();
    }

    IEnumerator MFToMelterDoorOpening()
    {
        MFToMelterCounter.text = 10.ToString();
        MFToMelterCounter.color = Color.white;
        if (mfToMelterDoorClosed)
        {
            MFToMelterDoorAnim.SetInteger("INTERRUPTED", 0);
            MFToMelterDoorAnim.SetBool("OPEN", true);
            MFToMelterDoorAnim.SetFloat("Speed", 1f);
        }
        else if (mfToMelterDoorClosing)
        {
            StopCoroutine("DelayedAutomaticCloseMFToMelter");
            mfToMelterDoorClosing = false;
            MFToMelterDoorAnim.SetFloat("Speed", -1f);
            MFToMelterDoorAnim.SetBool("OPEN", true);
            if (MFToMelterDoorAnim.GetInteger("INTERRUPTED") == 0)
            {
                MFToMelterDoorAnim.SetInteger("INTERRUPTED", 1);
            }
            else if (MFToMelterDoorAnim.GetInteger("INTERRUPTED") == 1)
            {
                MFToMelterDoorAnim.SetInteger("INTERRUPTED", 2);
            }
            else if (MFToMelterDoorAnim.GetInteger("INTERRUPTED") == 2) //this happens when two interruptions in a row, animator cycle moves to previous
            {
                MFToMelterDoorAnim.SetInteger("INTERRUPTED", 1);
            }
            MF_ToMelterDoorClosingSound.Stop();
            //here we also play either the alarm sound in case the door was stopped by an object or player, or some other sound in case it was key card or button press
        }
        mfToMelterDoorOpening = true;
        mfToMelterDoorClosed = false;
        MF_ToMelterDoorOpeningSound.Play();
        yield return new WaitForSecondsRealtime(MFToMelterDoorAnim.GetCurrentAnimatorStateInfo(0).length - (doorAnimationTime - mf_ToMelterTimer)); //door closing time is 3s atm
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
            MelterToMFCounter.text = (10 - i).ToString();
            if (i < 7)
            {
                MelterToMFCounter.color = Color.white;
            }
            else if (i == 7 || i == 8)
            {
                MelterToMFCounter.color = Color.yellow;
            }
            else
            {
                MelterToMFCounter.color = Color.red;
            }
            yield return new WaitForSecondsRealtime(1f);
        }
        if (melterToMFDoorOpen && MelterToMFDoorAnim.GetInteger("INTERRUPTED") == 0)
        {
            MelterToMFDoorAnim.SetBool("OPEN", false);
            MelterToMFDoorAnim.SetFloat("Speed", 1f);
        }
        else if (melterToMFDoorOpen)
        {
            MelterToMFDoorAnim.SetBool("OPEN", false);
            MelterToMFDoorAnim.SetFloat("Speed", 1f);
        }
        MelterToMFCounter.text = 0.ToString();
        melterToMFDoorClosing = true;
        melterToMFDoorOpen = false;
        melterToMFDoorClosingSoon = false;
        Melter_ToMFDoorClosingSound.Play();
        melter_ToMFTimer = 0f;
        StartCoroutine(CounterInners("MelterToMF"));
        yield return new WaitForSecondsRealtime(doorAnimationTime);
        melterToMFDoorClosed = true;
        melterToMFDoorClosing = false;
        Melter_ToMFDoorClosingSound.Stop();
        Melter_ToMFDoorClosedSound.Play();
    }

    IEnumerator MelterToMFDoorOpening()
    {
        MelterToMFCounter.text = 10.ToString();
        MelterToMFCounter.color = Color.white;
        if (melterToMFDoorClosed)
        {
            MelterToMFDoorAnim.SetInteger("INTERRUPTED", 0);
            MelterToMFDoorAnim.SetBool("OPEN", true);
            MelterToMFDoorAnim.SetFloat("Speed", 1f);
        }
        else if (melterToMFDoorClosing)
        {
            StopCoroutine("DelayedAutomaticCloseMelterToMF");
            melterToMFDoorClosing = false;
            MelterToMFDoorAnim.SetFloat("Speed", -1f);
            MelterToMFDoorAnim.SetBool("OPEN", true);
            if (MelterToMFDoorAnim.GetInteger("INTERRUPTED") == 0)
            {
                MelterToMFDoorAnim.SetInteger("INTERRUPTED", 1);
            }
            else if (MelterToMFDoorAnim.GetInteger("INTERRUPTED") == 1)
            {
                MelterToMFDoorAnim.SetInteger("INTERRUPTED", 2);
            }
            else if (MelterToMFDoorAnim.GetInteger("INTERRUPTED") == 2) //this happens when two interruptions in a row, animator cycle moves to previous
            {
                MelterToMFDoorAnim.SetInteger("INTERRUPTED", 1);
            }
            Melter_ToMFDoorClosingSound.Stop();
            //here we also play either the alarm sound in case the door was stopped by an object or player, or some other sound in case it was key card or button press
        }
        melterToMFDoorOpening = true;
        melterToMFDoorClosed = false;
        Melter_ToMFDoorOpeningSound.Play();
        yield return new WaitForSecondsRealtime(MelterToMFDoorAnim.GetCurrentAnimatorStateInfo(0).length - (doorAnimationTime - melter_ToMFTimer)); //door closing time is 3s atm
        melterToMFDoorOpening = false;
        melterToMFDoorOpen = true;
        Melter_ToMFDoorOpeningSound.Stop();
        Melter_ToMFDoorOpenSound.Play();
    }
    //not used rn
    //IEnumerator PlayAndWaitForAnim(Animator targetAnim, string stateName)
    //{
    //    //Get hash of animation
    //    int animHash = 0;
    //    if (stateName == "Jump")
    //        animHash = openAnimHash;
    //    else if (stateName == "Move")
    //        animHash = closeAnimHash;
    //    //else if (stateName == "Look")
    //    //    animHash = openWhenInterruptedAnimHash;

    //    //targetAnim.Play(stateName);
    //    targetAnim.CrossFadeInFixedTime(stateName, 0.6f);

    //    //Wait until we enter the current state
    //    while (targetAnim.GetCurrentAnimatorStateInfo(0).fullPathHash != animHash)
    //    {
    //        yield return null;
    //    }

    //    float counter = 0;
    //    float waitTime = targetAnim.GetCurrentAnimatorStateInfo(0).length;

    //    //Now, Wait until the current state is done playing
    //    while (counter < (waitTime))
    //    {
    //        counter += Time.deltaTime;
    //        yield return null;
    //    }

    //    //Done playing. Do something below!
    //    Debug.Log("Done Playing");

    //}
}
