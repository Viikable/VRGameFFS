using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.PostProcessing;

public class OxygenControl : MonoBehaviour {

    //Post processing starts
    PostProcessVolume GlobalPP;

    //BoolParameter @true = new BoolParameter();

    //FloatParameter @float = new FloatParameter();

    WaterMovement Water;

    //to not light hands when fading the players view
    public static bool noHandsLighting;

    private Vignette _Vignette;

    bool fadingIn;

    bool changingFadeDirection;

    public GameObject VignetteDonut;

    public Material _DonutMaterial;

    Vector3 donutScaleSpeed;

    Color donutMatCol;

    float alpha;

    //for interpolating
    float t;

    //Post processing ends
    [Tooltip("Tells how much oxygen there is in the current room as a percentage right now")]
    float currentRoomOxygenPercentage;

    [Tooltip("Tells how much oxygen there is in the current room as a percentage a second ago")]
    float previousRoomOxygenPercentage;

    [Tooltip("Tells the name of the current oxygen level (Safe, Okay, Alarming or Deadly)")]
    OxygenLevelName currentOxygenLevel;

    [Tooltip("Tells the name of the previous oxygen level (Safe, Okay, Alarming or Deadly) in order to be able to play breathing sounds when the level changes only")]
    OxygenLevelName previousOxygenLevel;
 
    [Tooltip("The factorial for the current oxygen level name which tells how much more the player's oxygen decreases per second when the oxygen level is constantly lowering. This value is different for each oxygen level name.")]
    private float oxygenLevelLowersFactorial;

    [Tooltip("The factorial for the current oxygen level name which tells how much more the player's oxygen increases per second when the oxygen level is constantly lowering. This value is different for each oxygen level name.")]
    private float oxygenLevelIncreasesFactorial;

    [Tooltip("The factorial for the current oxygen level name which tells how much more the player's oxygen decreases per second when the oxygen level stays the same. This value is different for each oxygen level name.")]
    private float oxygenLevelStaysFactorial;

    [Tooltip("Tells the default oxygen spread speed which will be timed based on room size differences")]
    private float defaultOxygenSpreadSpeedFactor;

    [Tooltip("Tells how quickly the oxygen amount is changing in Bonsai Room (and whether it is positive or negative change")]
    private float oxygenSpreadSpeedBonsai;
  
    [Tooltip("Tells how quickly the oxygen amount is changing in MF Lobby (and whether it is positive or negative change")]
    private float oxygenSpreadSpeedMFLobby;
  
    [Tooltip("Tells how quickly the oxygen amount is changing in Janitor Room (and whether it is positive or negative change")]
    private float oxygenSpreadSpeedJanitor;

    [Tooltip("Tells how quickly the oxygen amount is changing in Maintenance Corridor (and whether it is positive or negative change")]
    private float oxygenSpreadSpeedCorridor;

    [Tooltip("Tells how quickly the oxygen amount is changing in Melter Room (and whether it is positive or negative change")]
    private float oxygenSpreadSpeedMelter;

    [Tooltip("Tells the amount of oxygen the player currently has remaining")]
    private float playerOxygen;

    [Tooltip("Shows whether it is time to call the checkFunctions or not (second passed or not)")]
    private bool secondPassed;

    [Tooltip("Tells the amount of oxygen in MF lobby.")]
    private float mainFacilityLobbyOxygen;

    [Tooltip("Tells the position in the oxygen amount hierarchy of the MFLobby area.")]
    private int mfLobbyPositionInOxygenHierarchy;

    [Tooltip("Text field for displaying MFLobby oxygen level")]
    private TextMeshPro MFLobbyOxygenDisplayMelter;

    [Tooltip("Text field for displaying MFLobby oxygen level")]
    private TextMeshPro MFLobbyOxygenDisplayBridge;

    [Tooltip("Text field for displaying MFLobby oxygen level")]
    private TextMeshPro MFLobbyOxygenDisplayCorridor;

    [Tooltip("Tells the amount of oxygen in MF Bridge.")]
    private float mainFacilityBridgeOxygen;

    [Tooltip("Text field for displaying MFBridge oxygen level")]
    private TextMeshPro MFBridgeOxygenDisplay;

    [Tooltip("Tells the amount of oxygen in Bonsai Room.")]
    private float bonsaiRoomOxygen;

    [Tooltip("Tells the position in the oxygen amount hierarchy of the bonsai room.")]
    private int bonsaiRoomPositionInOxygenHierarchy;

    [Tooltip("Text field for displaying Bonsai oxygen level")]
    private TextMeshPro BonsaiOxygenDisplay;

    [Tooltip("Tells the amount of oxygen in Janitor Room.")]
    private float janitorRoomOxygen;

    [Tooltip("Tells the position in the oxygen amount hierarchy of the janitor room.")]
    private int janitorRoomPositionInOxygenHierarchy;

    [Tooltip("Text field for displaying Janitor oxygen level")]
    private TextMeshPro JanitorOxygenDisplay;

    [Tooltip("Tells the amount of oxygen in Maintenance Corridor.")]
    private float corridorOxygen;

    [Tooltip("Tells the position in the oxygen amount hierarchy of the corridor.")]
    private int corridorPositionInOxygenHierarchy;

    [Tooltip("Text field for displaying Corridor oxygen level")]
    private TextMeshPro CorridorOxygenDisplayMFLobby;

    [Tooltip("Text field for displaying Corridor oxygen level")]
    private TextMeshPro CorridorOxygenDisplayJanitor;

    [Tooltip("Text field for displaying Corridor oxygen level")]
    private TextMeshPro CorridorOxygenDisplayBonsai;

    [Tooltip("Tells the amount of oxygen in Melter Room.")]
    private float melterRoomOxygen;

    [Tooltip("Tells the position in the oxygen amount hierarchy of the melter room.")]
    private int melterRoomPositionInOxygenHierarchy;

    [Tooltip("Text field for displaying Melter oxygen level")]
    private TextMeshPro MelterOxygenDisplay;

    [Tooltip("The combined oxygen between rooms which are connected, used to calculate spreading")]
    private float combinedOxygen;

    [Tooltip("The level of oxygen which all connected rooms are spreading towards to")]
    private float targetOxygenSpreadLevel;

    [Tooltip("Tells the relative size of the airspace in the main hall lobby")]
    private float mainHallLobbyRoomSizeFactorial;

    [Tooltip("Tells the relative size of the airspace in the main hall bridge")]
    private float mainHallBridgeRoomSizeFactorial;

    [Tooltip("Tells the relative size of the airspace in the bonsai Room")]
    private float bonsaiRoomSizeFactorial;

    [Tooltip("Tells the relative size of the airspace in the janitor Room")]
    private float janitorRoomSizeFactorial;

    [Tooltip("Tells the relative size of the airspace in the melter Room")]
    private float melterRoomSizeFactorial;

    [Tooltip("Tells the relative size of the airspace in the maintenance corridor")]
    private float maintenanceCorridorRoomSizeFactorial;

    [Tooltip("The hierarchy of the oxygenLevels, sorted in OxygenSpreads method from least to most relative amount of oxygen.")]
    private int[] oxygenHierarchy;

    public FuseboxFunctionality fuseBox;
    //COLOURS
    public float green;

    public float red;

    public float blue;

    public float yellow;

    public float magenta;

    public float cyan;

    //these are the four possible oxygen levels in an area
    public enum OxygenLevelName
    {
        SeriousOverpressure,
        MediumOverpressure,
        SlightOverpressure,
        Safe,
        Okay,
        Alarming,
        Deadly,
    }

    private void Awake()
    {
        //if (GameObject.Find("GlobalPostProcessing") != null)
        //{
        //    GlobalPP = GameObject.Find("GlobalPostProcessing").GetComponent<PostProcessVolume>();
        //    GlobalPP.profile.TryGetSettings(out _Vignette);
        //}
        
        if (GameObject.Find("Water") != null)
        {
            Water = GameObject.Find("Water").GetComponent<WaterMovement>();
        }

        fadingIn = true;

        noHandsLighting = false;

        changingFadeDirection = false;

        donutScaleSpeed = new Vector3(0.01f, 0.01f, 0.01f);

        donutMatCol = _DonutMaterial.GetColor("_Color");

        alpha = 1f;

        t = 0f;

        defaultOxygenSpreadSpeedFactor = 2;
        currentOxygenLevel = OxygenLevelName.Safe;

        oxygenSpreadSpeedBonsai = 0f;
        oxygenSpreadSpeedCorridor = 0f;
        oxygenSpreadSpeedJanitor = 0f;
        oxygenSpreadSpeedMelter = 0f;       
        oxygenSpreadSpeedMFLobby = 0f;

        playerOxygen = 65f;
        currentRoomOxygenPercentage = 100f;
        previousRoomOxygenPercentage = 100f;
        secondPassed = true;

        mainFacilityBridgeOxygen = 0f;
        MFBridgeOxygenDisplay = GameObject.Find("MFBridgeOxygenDisplay").GetComponent<TextMeshPro>();
        mainFacilityLobbyOxygen = 0f;
        mfLobbyPositionInOxygenHierarchy = 0;
        MFLobbyOxygenDisplayMelter = GameObject.Find("MFLobbyOxygenDisplayMelter").GetComponent<TextMeshPro>();
        MFLobbyOxygenDisplayBridge = GameObject.Find("MFLobbyOxygenDisplayBridge").GetComponent<TextMeshPro>();
        MFLobbyOxygenDisplayCorridor = GameObject.Find("MFLobbyOxygenDisplayCorridor").GetComponent<TextMeshPro>();
        bonsaiRoomOxygen = 0f;
        bonsaiRoomPositionInOxygenHierarchy = 0;
        BonsaiOxygenDisplay = GameObject.Find("BonsaiOxygenDisplay").GetComponent<TextMeshPro>();
        janitorRoomOxygen = 0f;
        janitorRoomPositionInOxygenHierarchy = 0;
        JanitorOxygenDisplay = GameObject.Find("JanitorOxygenDisplay").GetComponent<TextMeshPro>();
        corridorOxygen = 0f;
        corridorPositionInOxygenHierarchy = 0;
        CorridorOxygenDisplayMFLobby = GameObject.Find("CorridorOxygenDisplayMFLobby").GetComponent<TextMeshPro>();
        CorridorOxygenDisplayJanitor = GameObject.Find("CorridorOxygenDisplayJanitor").GetComponent<TextMeshPro>();
        CorridorOxygenDisplayBonsai = GameObject.Find("CorridorOxygenDisplayBonsai").GetComponent<TextMeshPro>();
        melterRoomOxygen = 0f;
        melterRoomPositionInOxygenHierarchy = 0;
        MelterOxygenDisplay = GameObject.Find("MelterOxygenDisplay").GetComponent<TextMeshPro>();
        combinedOxygen = 0f;
        targetOxygenSpreadLevel = 0f;

        mainHallLobbyRoomSizeFactorial = 2f;
        mainHallBridgeRoomSizeFactorial = 10f; //not used
        bonsaiRoomSizeFactorial = 8f;
        janitorRoomSizeFactorial = 10f;
        melterRoomSizeFactorial = 6f;
        maintenanceCorridorRoomSizeFactorial = 7f;

        if (GameObject.Find("FuseBoxFunctionality") != null)
        {
            fuseBox = GameObject.Find("FuseBoxFunctionality").GetComponent<FuseboxFunctionality>();
        }

        green = 0f;
        red = 0f;
        blue = 0f;
        yellow = 0f;
        magenta = 0f;
        cyan = 0f;

        oxygenHierarchy = new int[5];
    }


    private void Update()
    {
         //PlayerOxygenLevelSideEffects();
        //only updates each second       
        if (secondPassed && fuseBox != null)
        {          
            secondPassed = false;
            RefreshUnconnectedRooms();
            IsOxygenSpreading();
            DisplayRoomOxygenLevels();
            CheckCurrentRoomOxygenPercentage();
            CheckCurrentOxygenLevelName();
            PlayerOxygenLevelChanges();
            StartCoroutine("WaitASecond");
        }
    }
    //This method will be called from the Bonsai oxygen panel when setting the new oxygen level
    public void SetOxygenLevels(Color[] colours)
    {
        //reset colours when new combination gets set
        green = 0f;
        red = 0f;
        blue = 0f;
        yellow = 0f;
        magenta = 0f;
        cyan = 0f;
        //4 colours in the array as 4 lamps
        for (int i = 0; i < 4; i++)
        {
            if (colours[i] == Color.green)
            {
                green++;
            }
            else if (colours[i] == Color.red)
            {
                red++;
            }
            else if (colours[i] == Color.blue)
            {
                blue++;
            }
            else if (colours[i] == Color.yellow)
            {
                yellow++;
            }
            else if (colours[i] == Color.magenta)
            {
                magenta++;
            }
            else if (colours[i] == Color.cyan)
            {
                cyan++;
            }
        }
        //set oxygen levels based on wavelengths of the light
        mainFacilityLobbyOxygen = 20f * green;
        mainFacilityBridgeOxygen = 100f * blue;
        bonsaiRoomOxygen = 80f * yellow;
        janitorRoomOxygen = 100f * magenta;
        corridorOxygen = 70f * cyan;
        melterRoomOxygen = 60f * red;
        Debug.Log("hai" + mainFacilityLobbyOxygen);
    }

    //checks whether doors between rooms are currently open,
    private void IsOxygenSpreading()
    {
        //starting with the case of all possible doors being open to be able to check for other combinations after and not mix up
        if ((fuseBox.corridorToBonsaiDoorOpen || fuseBox.corridorToBonsaiDoorClosing || fuseBox.corridorToBonsaiDoorOpening)
            && (fuseBox.bonsaiToCorridorDoorOpen || fuseBox.bonsaiToCorridorDoorClosing || fuseBox.bonsaiToCorridorDoorOpening)
            && (fuseBox.janitorToCorridorDoorOpen || fuseBox.janitorToCorridorDoorClosing || fuseBox.janitorToCorridorDoorOpening)
            && (fuseBox.corridorToJanitorDoorOpen || fuseBox.corridorToJanitorDoorClosing || fuseBox.corridorToJanitorDoorOpening)
            && (fuseBox.corridorToMFDoorOpen || fuseBox.corridorToMFDoorClosing || fuseBox.corridorToMFDoorOpening)
            && (fuseBox.mfToCorridorDoorOpen || fuseBox.mfToCorridorDoorClosing || fuseBox.mfToCorridorDoorOpening)
            && (fuseBox.mfToMelterDoorOpen || fuseBox.mfToMelterDoorClosing || fuseBox.mfToMelterDoorOpening)
            && (fuseBox.melterToMFDoorOpen || fuseBox.melterToMFDoorClosing || fuseBox.melterToMFDoorOpening))
        {
            //first parameter refers to bonsaiRoom, second Janitor, third corridor, 4th MF and 5th Melter
            OxygenSpreads(true, true, true, true, true, 5f);
        }
        //ONE DOOR CLOSED
        // all but Melter Door open
        else if ((fuseBox.corridorToBonsaiDoorOpen || fuseBox.corridorToBonsaiDoorClosing || fuseBox.corridorToBonsaiDoorOpening)
            && (fuseBox.bonsaiToCorridorDoorOpen || fuseBox.bonsaiToCorridorDoorClosing || fuseBox.bonsaiToCorridorDoorOpening)
            && (fuseBox.janitorToCorridorDoorOpen || fuseBox.janitorToCorridorDoorClosing || fuseBox.janitorToCorridorDoorOpening)
            && (fuseBox.corridorToJanitorDoorOpen || fuseBox.corridorToJanitorDoorClosing || fuseBox.corridorToJanitorDoorOpening)
            && (fuseBox.corridorToMFDoorOpen || fuseBox.corridorToMFDoorClosing || fuseBox.corridorToMFDoorOpening)
            && (fuseBox.mfToCorridorDoorOpen || fuseBox.mfToCorridorDoorClosing || fuseBox.mfToCorridorDoorOpening))
        {
            OxygenSpreads(true, true, true, true, false, 4f);
        }
        //all but Bonsai Door open
        else if ((fuseBox.janitorToCorridorDoorOpen || fuseBox.janitorToCorridorDoorClosing || fuseBox.janitorToCorridorDoorOpening)
            && (fuseBox.corridorToJanitorDoorOpen || fuseBox.corridorToJanitorDoorClosing || fuseBox.corridorToJanitorDoorOpening)
            && (fuseBox.corridorToMFDoorOpen || fuseBox.corridorToMFDoorClosing || fuseBox.corridorToMFDoorOpening)
            && (fuseBox.mfToCorridorDoorOpen || fuseBox.mfToCorridorDoorClosing || fuseBox.mfToCorridorDoorOpening)
            && (fuseBox.mfToMelterDoorOpen || fuseBox.mfToMelterDoorClosing || fuseBox.mfToMelterDoorOpening)
            && (fuseBox.melterToMFDoorOpen || fuseBox.melterToMFDoorClosing || fuseBox.melterToMFDoorOpening))
        {
            //first parameter refers to bonsaiRoom, second Janitor, third corridor, 4th MF and 5th Melter
            OxygenSpreads(false, true, true, true, true, 4f);
        }
        //all but Janitor Door open
        else if ((fuseBox.corridorToBonsaiDoorOpen || fuseBox.corridorToBonsaiDoorClosing || fuseBox.corridorToBonsaiDoorOpening)
            && (fuseBox.bonsaiToCorridorDoorOpen || fuseBox.bonsaiToCorridorDoorClosing || fuseBox.bonsaiToCorridorDoorOpening)
            && (fuseBox.corridorToMFDoorOpen || fuseBox.corridorToMFDoorClosing || fuseBox.corridorToMFDoorOpening)
            && (fuseBox.mfToCorridorDoorOpen || fuseBox.mfToCorridorDoorClosing || fuseBox.mfToCorridorDoorOpening)
            && (fuseBox.mfToMelterDoorOpen || fuseBox.mfToMelterDoorClosing || fuseBox.mfToMelterDoorOpening)
            && (fuseBox.melterToMFDoorOpen || fuseBox.melterToMFDoorClosing || fuseBox.melterToMFDoorOpening))
        {
            //first parameter refers to bonsaiRoom, second Janitor, third corridor, 4th MF and 5th Melter
            OxygenSpreads(true, false, true, true, true, 4f);
        }            
        //all but MF and corridor Door open, this creates 2 different oxygen spread zones SPECIAL CASE
        else if ((fuseBox.corridorToBonsaiDoorOpen || fuseBox.corridorToBonsaiDoorClosing || fuseBox.corridorToBonsaiDoorOpening)
            && (fuseBox.bonsaiToCorridorDoorOpen || fuseBox.bonsaiToCorridorDoorClosing || fuseBox.bonsaiToCorridorDoorOpening)
            && (fuseBox.janitorToCorridorDoorOpen || fuseBox.janitorToCorridorDoorClosing || fuseBox.janitorToCorridorDoorOpening)
            && (fuseBox.corridorToJanitorDoorOpen || fuseBox.corridorToJanitorDoorClosing || fuseBox.corridorToJanitorDoorOpening)
            && (fuseBox.mfToMelterDoorOpen || fuseBox.mfToMelterDoorClosing || fuseBox.mfToMelterDoorOpening)
            && (fuseBox.melterToMFDoorOpen || fuseBox.melterToMFDoorClosing || fuseBox.melterToMFDoorOpening))
        {
            //2 different zones requires the method to be called two times with the separate zones, maintenance area and melter+MF
            OxygenSpreads(true, true, true, false, false, 3f);
            OxygenSpreads(false, false, false, true, true, 2f);
        }
        //TWO DOORS CLOSED
        //all but Melter and MF+corridor Doors open
        else if ((fuseBox.corridorToBonsaiDoorOpen || fuseBox.corridorToBonsaiDoorClosing || fuseBox.corridorToBonsaiDoorOpening)
           && (fuseBox.bonsaiToCorridorDoorOpen || fuseBox.bonsaiToCorridorDoorClosing || fuseBox.bonsaiToCorridorDoorOpening)
           && (fuseBox.janitorToCorridorDoorOpen || fuseBox.janitorToCorridorDoorClosing || fuseBox.janitorToCorridorDoorOpening)
           && (fuseBox.corridorToJanitorDoorOpen || fuseBox.corridorToJanitorDoorClosing || fuseBox.corridorToJanitorDoorOpening))
        {
            //first parameter refers to bonsaiRoom, second Janitor, third corridor, 4th MF and 5th Melter
            OxygenSpreads(true, true, true, false, false, 3f);
        }
        //all but Melter and Bonsai Doors open
        else if ((fuseBox.janitorToCorridorDoorOpen || fuseBox.janitorToCorridorDoorClosing || fuseBox.janitorToCorridorDoorOpening)
            && (fuseBox.corridorToJanitorDoorOpen || fuseBox.corridorToJanitorDoorClosing || fuseBox.corridorToJanitorDoorOpening)
            && (fuseBox.corridorToMFDoorOpen || fuseBox.corridorToMFDoorClosing || fuseBox.corridorToMFDoorOpening)
            && (fuseBox.mfToCorridorDoorOpen || fuseBox.mfToCorridorDoorClosing || fuseBox.mfToCorridorDoorOpening))
        {
            //first parameter refers to bonsaiRoom, second Janitor, third corridor, 4th MF and 5th Melter
            OxygenSpreads(false, true, true, true, false, 3f);
        }
        //all but Melter and Janitor doors open
        else if ((fuseBox.corridorToBonsaiDoorOpen || fuseBox.corridorToBonsaiDoorClosing || fuseBox.corridorToBonsaiDoorOpening)
            && (fuseBox.bonsaiToCorridorDoorOpen || fuseBox.bonsaiToCorridorDoorClosing || fuseBox.bonsaiToCorridorDoorOpening)
            && (fuseBox.corridorToMFDoorOpen || fuseBox.corridorToMFDoorClosing || fuseBox.corridorToMFDoorOpening)
            && (fuseBox.mfToCorridorDoorOpen || fuseBox.mfToCorridorDoorClosing || fuseBox.mfToCorridorDoorOpening))
        {
            //first parameter refers to bonsaiRoom, second Janitor, third corridor, 4th MF and 5th Melter
            OxygenSpreads(true, false, true, true, false, 3f);
        }
        //all but Bonsai and Janitor Doors open
        else if ((fuseBox.corridorToMFDoorOpen || fuseBox.corridorToMFDoorClosing || fuseBox.corridorToMFDoorOpening)
            && (fuseBox.mfToCorridorDoorOpen || fuseBox.mfToCorridorDoorClosing || fuseBox.mfToCorridorDoorOpening)
            && (fuseBox.mfToMelterDoorOpen || fuseBox.mfToMelterDoorClosing || fuseBox.mfToMelterDoorOpening)
            && (fuseBox.melterToMFDoorOpen || fuseBox.melterToMFDoorClosing || fuseBox.melterToMFDoorOpening))
        {
            //first parameter refers to bonsaiRoom, second Janitor, third corridor, 4th MF and 5th Melter
            OxygenSpreads(false, false, true, true, true, 3f);
        }
        //all but MF + corridor door and Janitor door open, this creates 2 different oxygen spread zones SPECIAL CASE
        else if ((fuseBox.corridorToBonsaiDoorOpen || fuseBox.corridorToBonsaiDoorClosing || fuseBox.corridorToBonsaiDoorOpening)
            && (fuseBox.bonsaiToCorridorDoorOpen || fuseBox.bonsaiToCorridorDoorClosing || fuseBox.bonsaiToCorridorDoorOpening)                  
            && (fuseBox.mfToMelterDoorOpen || fuseBox.mfToMelterDoorClosing || fuseBox.mfToMelterDoorOpening)
            && (fuseBox.melterToMFDoorOpen || fuseBox.melterToMFDoorClosing || fuseBox.melterToMFDoorOpening))
        {
            //2 different zones requires the method to be called two times with the separate zones, melter+MF and corridor+Bonsai
            OxygenSpreads(false, false, false, true, true, 2f);
            OxygenSpreads(true, false, true, false, false, 2f);
        }
        //all but MF + corridor door and Bonsai door open, this creates 2 different oxygen spread zones SPECIAL CASE
        else if ((fuseBox.janitorToCorridorDoorOpen || fuseBox.janitorToCorridorDoorClosing || fuseBox.janitorToCorridorDoorOpening)
            && (fuseBox.corridorToJanitorDoorOpen || fuseBox.corridorToJanitorDoorClosing || fuseBox.corridorToJanitorDoorOpening)
            && (fuseBox.mfToMelterDoorOpen || fuseBox.mfToMelterDoorClosing || fuseBox.mfToMelterDoorOpening)
            && (fuseBox.melterToMFDoorOpen || fuseBox.melterToMFDoorClosing || fuseBox.melterToMFDoorOpening))
        {
            //2 different zones requires the method to be called two times with the separate zones, melter+MF and corridor+Janitor
            OxygenSpreads(false, false, false, true, true, 2f);
            OxygenSpreads(false, true, true, false, false, 2f);
        }
        // THREE DOORS CLOSED
        // only mf+corridor door open
        else if ((fuseBox.corridorToMFDoorOpen || fuseBox.corridorToMFDoorClosing || fuseBox.corridorToMFDoorOpening)
           && (fuseBox.mfToCorridorDoorOpen || fuseBox.mfToCorridorDoorClosing || fuseBox.mfToCorridorDoorOpening))
          
        {
            //first parameter refers to bonsaiRoom, second Janitor, third corridor, 4th MF and 5th Melter
            OxygenSpreads(false, false, true, true, false, 2f);
        }
        // only melter door open
        else if ((fuseBox.mfToMelterDoorOpen || fuseBox.mfToMelterDoorClosing || fuseBox.mfToMelterDoorOpening)
           && (fuseBox.melterToMFDoorOpen || fuseBox.melterToMFDoorClosing || fuseBox.melterToMFDoorOpening))
        {
            //first parameter refers to bonsaiRoom, second Janitor, third corridor, 4th MF and 5th Melter
            OxygenSpreads(false, false, false, true, true, 2f);
        }
        // only janitor door open
        else if ((fuseBox.janitorToCorridorDoorOpen || fuseBox.janitorToCorridorDoorClosing || fuseBox.janitorToCorridorDoorOpening)
            && (fuseBox.corridorToJanitorDoorOpen || fuseBox.corridorToJanitorDoorClosing || fuseBox.corridorToJanitorDoorOpening))
        {
            //first parameter refers to bonsaiRoom, second Janitor, third corridor, 4th MF and 5th Melter
            OxygenSpreads(false, true, true, false, false, 2f);
        }
        // only bonsai door open
        else if ((fuseBox.corridorToBonsaiDoorOpen || fuseBox.corridorToBonsaiDoorClosing || fuseBox.corridorToBonsaiDoorOpening)
            && (fuseBox.bonsaiToCorridorDoorOpen || fuseBox.bonsaiToCorridorDoorClosing || fuseBox.bonsaiToCorridorDoorOpening))
        {
            //first parameter refers to bonsaiRoom, second Janitor, third corridor, 4th MF and 5th Melter
            OxygenSpreads(true, false, true, false, false, 2f);
        }   
    }
    //NOTE: corridor is spreading as long as one of the doors, janitor, bonsai or mfTOcorridor is open
    //bonsai and some other rooms are connected, remember that rooms can be connected at the same time with others. etc Bonsai+Corridor and Melter+MF
    private void OxygenSpreads(bool bonsaiSpreading, bool janitorSpreading, bool corridorSpreading, bool mfSpreading, bool melterSpreading, float amountOfRooms)
    {
        //first calculating the order of the currentOxygenPercentages to get the correct targetValues 
        //setting all positions to zero initially always
        mfLobbyPositionInOxygenHierarchy = 0;
        bonsaiRoomPositionInOxygenHierarchy = 0;
        melterRoomPositionInOxygenHierarchy = 0;
        corridorPositionInOxygenHierarchy = 0;
        janitorRoomPositionInOxygenHierarchy = 0;

        //checking which place has more air than others the most times       
        //mfposition
        if (20f * green > 80f * yellow)
        {
            mfLobbyPositionInOxygenHierarchy++;
        }
        if (20f * green > 70f * cyan)
        {
            mfLobbyPositionInOxygenHierarchy++;
        }
        if (20f * green > 100f * magenta)
        {
            mfLobbyPositionInOxygenHierarchy++;
        }
        if (20f * green > 60f * red)       //this is the only combination which can be equal while nonzero, with 3 green lights and one red
        {
            mfLobbyPositionInOxygenHierarchy++;
        }
        //melterposition
        if (60f * red > 80f * yellow)
        {
            melterRoomPositionInOxygenHierarchy++;
        }
        if (60f * red > 70f * cyan)
        {
            melterRoomPositionInOxygenHierarchy++;
        }
        if (60f * red > 100f * magenta)
        {
            melterRoomPositionInOxygenHierarchy++;
        }
        if (60f * red > 20f * green)
        {
            melterRoomPositionInOxygenHierarchy++;
        }
        //janitorposition
        if (100f * magenta > 80f * yellow)
        {
            janitorRoomPositionInOxygenHierarchy++;
        }
        if (100f * magenta > 70f * cyan)
        {
            janitorRoomPositionInOxygenHierarchy++;
        }
        if (100f * magenta > 60f * red)
        {
            janitorRoomPositionInOxygenHierarchy++;
        }
        if (100f * magenta > 20f * green)
        {
            janitorRoomPositionInOxygenHierarchy++;
        }
        //bonsaiposition
        if (80f * yellow > 100f * magenta)
        {
            bonsaiRoomPositionInOxygenHierarchy++;
        }
        if (80f * yellow > 70f * cyan)
        {
            bonsaiRoomPositionInOxygenHierarchy++;
        }
        if (80f * yellow > 60f * red)
        {
            bonsaiRoomPositionInOxygenHierarchy++;
        }
        if (80f * yellow > 20f * green)
        {
            bonsaiRoomPositionInOxygenHierarchy++;
        }
        //corridorposition
        if (70f * cyan > 100f * magenta)
        {
            corridorPositionInOxygenHierarchy++;
        }
        if (70f * cyan > 80f * yellow)
        {
            corridorPositionInOxygenHierarchy++;
        }
        if (70f * cyan > 60f * red)
        {
            corridorPositionInOxygenHierarchy++;
        }
        if (70f * cyan > 20f * green)
        {
            corridorPositionInOxygenHierarchy++;
        }

        //the nonzero rooms order properly, zeroes will  have position 0 in hierarchy and can be multiple
        

        //all doors open (highly unlikely case)
        if (bonsaiSpreading && janitorSpreading && corridorSpreading && mfSpreading && melterSpreading)
        {
            if (bonsaiRoomOxygen > 0 || corridorOxygen > 0 || janitorRoomOxygen > 0 || mainFacilityLobbyOxygen > 0 || melterRoomOxygen > 0)
            {
                //checks the current colours in the bonsai light combination, which don't change due to spreading while the oxygenlevels in the rooms do
                combinedOxygen = 80f * yellow + 70f * cyan + 100f * magenta + 20f * green + 60f * red;
                //the spreadspeed is the room's factorial divided by the mean of the other connected rooms
                oxygenSpreadSpeedMFLobby = mainHallLobbyRoomSizeFactorial /
                    ((mainHallLobbyRoomSizeFactorial + bonsaiRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + janitorRoomSizeFactorial + melterRoomSizeFactorial) / amountOfRooms);
                oxygenSpreadSpeedBonsai = bonsaiRoomSizeFactorial /
                    ((bonsaiRoomSizeFactorial + mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + janitorRoomSizeFactorial + melterRoomSizeFactorial) / amountOfRooms);
                oxygenSpreadSpeedMelter = melterRoomSizeFactorial /
                    ((melterRoomSizeFactorial + mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + janitorRoomSizeFactorial + bonsaiRoomSizeFactorial) / amountOfRooms);
                oxygenSpreadSpeedJanitor = janitorRoomSizeFactorial /
                    ((janitorRoomSizeFactorial + mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + bonsaiRoomSizeFactorial + melterRoomSizeFactorial) / amountOfRooms);
                oxygenSpreadSpeedCorridor = maintenanceCorridorRoomSizeFactorial /
                    ((maintenanceCorridorRoomSizeFactorial + mainHallLobbyRoomSizeFactorial + bonsaiRoomSizeFactorial + janitorRoomSizeFactorial + melterRoomSizeFactorial) / amountOfRooms);

                //CALCULATES THE ESTIMATED COMBINED AMOUNT OF OXYGEN BASED ON THE ROOM SIZES AND THEN DIVIDES IT WITH THE ESTIMATE OF (amountOfRooms)
                targetOxygenSpreadLevel = ((mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + bonsaiRoomSizeFactorial + melterRoomSizeFactorial) / amountOfRooms / mainHallLobbyRoomSizeFactorial * 20f * green
                    + (mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + bonsaiRoomSizeFactorial + melterRoomSizeFactorial) / amountOfRooms / maintenanceCorridorRoomSizeFactorial * 70f * cyan
                    + (mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + bonsaiRoomSizeFactorial + melterRoomSizeFactorial) / amountOfRooms / bonsaiRoomSizeFactorial * 80f * yellow
                    + (mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + bonsaiRoomSizeFactorial + melterRoomSizeFactorial) / amountOfRooms / melterRoomSizeFactorial * 60f * red
                    + (mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + bonsaiRoomSizeFactorial + melterRoomSizeFactorial) / amountOfRooms / janitorRoomSizeFactorial * 100f * magenta)
                    / (amountOfRooms);  //LAST DIVIDER IS AN ESTIMATE WHICH SEEMS TO BE AROUND THE CORRECT LINES
                Debug.Log(targetOxygenSpreadLevel + "allopenspread");
                //checks whether increasing or decreasing the oxygen level
                if (bonsaiRoomOxygen < targetOxygenSpreadLevel)
                {
                    bonsaiRoomOxygen += oxygenSpreadSpeedBonsai;
                }
                else if (bonsaiRoomOxygen > targetOxygenSpreadLevel)
                {
                    bonsaiRoomOxygen -= oxygenSpreadSpeedBonsai;
                }
                if (janitorRoomOxygen < targetOxygenSpreadLevel)
                {
                    janitorRoomOxygen += oxygenSpreadSpeedJanitor;
                }
                else if (janitorRoomOxygen > targetOxygenSpreadLevel)
                {
                    janitorRoomOxygen -= oxygenSpreadSpeedJanitor;
                }
                if (corridorOxygen < targetOxygenSpreadLevel)
                {
                    corridorOxygen += oxygenSpreadSpeedCorridor;
                }
                else if (corridorOxygen > targetOxygenSpreadLevel)
                {
                    corridorOxygen -= oxygenSpreadSpeedCorridor;
                }
                if (mainFacilityLobbyOxygen < targetOxygenSpreadLevel)
                {
                    mainFacilityLobbyOxygen += oxygenSpreadSpeedMFLobby;
                }
                else if (mainFacilityLobbyOxygen > targetOxygenSpreadLevel)
                {
                    mainFacilityLobbyOxygen -= oxygenSpreadSpeedMFLobby;
                }
                if (melterRoomOxygen < targetOxygenSpreadLevel)
                {
                    melterRoomOxygen += oxygenSpreadSpeedMelter;
                }
                else if (melterRoomOxygen > targetOxygenSpreadLevel)
                {
                    melterRoomOxygen -= oxygenSpreadSpeedMelter;
                }
            }
        }
        //ONE DOOR CLOSED
        // melter closed
        else if (bonsaiSpreading && janitorSpreading && corridorSpreading && mfSpreading && !melterSpreading)
        {
            if (bonsaiRoomOxygen > 0 || corridorOxygen > 0 || janitorRoomOxygen > 0 || mainFacilityLobbyOxygen > 0)
            {
                combinedOxygen = 80f * yellow + 70f * cyan + 100f * magenta + 20f * green; 
                targetOxygenSpreadLevel = combinedOxygen / amountOfRooms;
                //the spreadspeed is the room's factorial divided by the mean of the other connected rooms
                oxygenSpreadSpeedMFLobby = mainHallLobbyRoomSizeFactorial /
                    ((mainHallLobbyRoomSizeFactorial + bonsaiRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + janitorRoomSizeFactorial) / amountOfRooms);
                oxygenSpreadSpeedBonsai = bonsaiRoomSizeFactorial /
                    ((bonsaiRoomSizeFactorial + mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + janitorRoomSizeFactorial) / amountOfRooms);
                oxygenSpreadSpeedJanitor = janitorRoomSizeFactorial /
                    ((janitorRoomSizeFactorial + mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + bonsaiRoomSizeFactorial) / amountOfRooms);
                oxygenSpreadSpeedCorridor = maintenanceCorridorRoomSizeFactorial /
                    ((maintenanceCorridorRoomSizeFactorial + mainHallLobbyRoomSizeFactorial + bonsaiRoomSizeFactorial + janitorRoomSizeFactorial) / amountOfRooms);

                //CALCULATES THE ESTIMATED COMBINED AMOUNT OF OXYGEN BASED ON THE ROOM SIZES AND THEN DIVIDES IT WITH THE ESTIMATE OF (amountOfRooms +1)
                targetOxygenSpreadLevel = ((mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + bonsaiRoomSizeFactorial + janitorRoomSizeFactorial) / amountOfRooms / mainHallLobbyRoomSizeFactorial * 20f * green
                    + (mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + bonsaiRoomSizeFactorial + janitorRoomSizeFactorial) / amountOfRooms / maintenanceCorridorRoomSizeFactorial * 70f * cyan
                    + (mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + bonsaiRoomSizeFactorial + janitorRoomSizeFactorial) / amountOfRooms / bonsaiRoomSizeFactorial * 80f * yellow
                    + (mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + bonsaiRoomSizeFactorial + janitorRoomSizeFactorial) / amountOfRooms / janitorRoomSizeFactorial * 100f * magenta)
                    / (amountOfRooms + 1);  //LAST DIVIDER IS AN ESTIMATE WHICH SEEMS TO BE AROUND THE CORRECT LINES

                //checks whether increasing or decreasing the oxygen level
                if (bonsaiRoomOxygen < targetOxygenSpreadLevel)
                {
                    bonsaiRoomOxygen += oxygenSpreadSpeedBonsai;
                }
                else if (bonsaiRoomOxygen > targetOxygenSpreadLevel)
                {
                    bonsaiRoomOxygen -= oxygenSpreadSpeedBonsai;
                }
                if (janitorRoomOxygen < targetOxygenSpreadLevel)
                {
                    janitorRoomOxygen += oxygenSpreadSpeedJanitor;
                }
                else if (janitorRoomOxygen > targetOxygenSpreadLevel)
                {
                    janitorRoomOxygen -= oxygenSpreadSpeedJanitor;
                }
                if (corridorOxygen < targetOxygenSpreadLevel)
                {
                    corridorOxygen += oxygenSpreadSpeedCorridor;
                }
                else if (corridorOxygen > targetOxygenSpreadLevel)
                {
                    corridorOxygen -= oxygenSpreadSpeedCorridor;
                }
                if (mainFacilityLobbyOxygen < targetOxygenSpreadLevel)
                {
                    mainFacilityLobbyOxygen += oxygenSpreadSpeedMFLobby;
                }
                else if (mainFacilityLobbyOxygen > targetOxygenSpreadLevel)
                {
                    mainFacilityLobbyOxygen -= oxygenSpreadSpeedMFLobby;
                }
            }
        }
        // bonsai closed
        else if (!bonsaiSpreading && janitorSpreading && corridorSpreading && mfSpreading && melterSpreading)
        {
            if (corridorOxygen > 0 || janitorRoomOxygen > 0 || mainFacilityLobbyOxygen > 0 || melterRoomOxygen > 0)
            {
                combinedOxygen = 70f * cyan + 100f * magenta + 20f * green + 60f * red;
                targetOxygenSpreadLevel = combinedOxygen / amountOfRooms;
                //the spreadspeed is the room's factorial divided by the mean of the other connected rooms
                oxygenSpreadSpeedMFLobby = mainHallLobbyRoomSizeFactorial /
                    ((mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + janitorRoomSizeFactorial + melterRoomSizeFactorial) / amountOfRooms);
                oxygenSpreadSpeedMelter = melterRoomSizeFactorial /
                    ((melterRoomSizeFactorial + mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + janitorRoomSizeFactorial) / amountOfRooms);
                oxygenSpreadSpeedJanitor = janitorRoomSizeFactorial /
                    ((janitorRoomSizeFactorial + mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + melterRoomSizeFactorial) / amountOfRooms);
                oxygenSpreadSpeedCorridor = maintenanceCorridorRoomSizeFactorial /
                    ((maintenanceCorridorRoomSizeFactorial + mainHallLobbyRoomSizeFactorial + janitorRoomSizeFactorial + melterRoomSizeFactorial) / amountOfRooms);

                //CALCULATES THE ESTIMATED COMBINED AMOUNT OF OXYGEN BASED ON THE ROOM SIZES AND THEN DIVIDES IT WITH THE ESTIMATE OF (amountOfRooms +1)
                targetOxygenSpreadLevel = ((mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + janitorRoomSizeFactorial + melterRoomSizeFactorial) / amountOfRooms / mainHallLobbyRoomSizeFactorial * 20f * green
                    + (mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + janitorRoomSizeFactorial + melterRoomSizeFactorial) / amountOfRooms / maintenanceCorridorRoomSizeFactorial * 70f * cyan
                    + (mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + janitorRoomSizeFactorial + melterRoomSizeFactorial) / amountOfRooms / janitorRoomSizeFactorial * 100f * magenta
                    + (mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + janitorRoomSizeFactorial + melterRoomSizeFactorial) / amountOfRooms / melterRoomSizeFactorial * 60f * red)
                    / (amountOfRooms + 1);  //LAST DIVIDER IS AN ESTIMATE WHICH SEEMS TO BE AROUND THE CORRECT LINES

                //checks whether increasing or decreasing the oxygen level           
                if (janitorRoomOxygen < targetOxygenSpreadLevel)
                {
                    janitorRoomOxygen += oxygenSpreadSpeedJanitor;
                }
                else if (janitorRoomOxygen > targetOxygenSpreadLevel)
                {
                    janitorRoomOxygen -= oxygenSpreadSpeedJanitor;
                }
                if (corridorOxygen < targetOxygenSpreadLevel)
                {
                    corridorOxygen += oxygenSpreadSpeedCorridor;
                }
                else if (corridorOxygen > targetOxygenSpreadLevel)
                {
                    corridorOxygen -= oxygenSpreadSpeedCorridor;
                }
                if (mainFacilityLobbyOxygen < targetOxygenSpreadLevel)
                {
                    mainFacilityLobbyOxygen += oxygenSpreadSpeedMFLobby;
                }
                else if (mainFacilityLobbyOxygen > targetOxygenSpreadLevel)
                {
                    mainFacilityLobbyOxygen -= oxygenSpreadSpeedMFLobby;
                }
                if (melterRoomOxygen < targetOxygenSpreadLevel)
                {
                    melterRoomOxygen += oxygenSpreadSpeedMelter;
                }
                else if (melterRoomOxygen > targetOxygenSpreadLevel)
                {
                    melterRoomOxygen -= oxygenSpreadSpeedMelter;
                }
            }
        }
        // janitor closed
        else if (bonsaiSpreading && !janitorSpreading && corridorSpreading && mfSpreading && melterSpreading)
        {
            if (bonsaiRoomOxygen > 0 || corridorOxygen > 0 || mainFacilityLobbyOxygen > 0 || melterRoomOxygen > 0)
            {
                combinedOxygen = 80f * yellow + 70f * cyan + 20f * green + 60f * red;
                targetOxygenSpreadLevel = combinedOxygen / amountOfRooms;
                //the spreadspeed is the room's factorial divided by the mean of the other connected rooms
                oxygenSpreadSpeedMFLobby = mainHallLobbyRoomSizeFactorial /
                    ((mainHallLobbyRoomSizeFactorial + bonsaiRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + melterRoomSizeFactorial) / amountOfRooms);
                oxygenSpreadSpeedBonsai = bonsaiRoomSizeFactorial /
                    ((bonsaiRoomSizeFactorial + mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + melterRoomSizeFactorial) / amountOfRooms);
                oxygenSpreadSpeedMelter = melterRoomSizeFactorial /
                    ((melterRoomSizeFactorial + mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + bonsaiRoomSizeFactorial) / amountOfRooms);              
                oxygenSpreadSpeedCorridor = maintenanceCorridorRoomSizeFactorial /
                    ((maintenanceCorridorRoomSizeFactorial + mainHallLobbyRoomSizeFactorial + bonsaiRoomSizeFactorial + janitorRoomSizeFactorial + melterRoomSizeFactorial) / amountOfRooms);

                //CALCULATES THE ESTIMATED COMBINED AMOUNT OF OXYGEN BASED ON THE ROOM SIZES AND THEN DIVIDES IT WITH THE ESTIMATE OF (amountOfRooms +1)
                targetOxygenSpreadLevel = ((mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + bonsaiRoomSizeFactorial + melterRoomSizeFactorial) / amountOfRooms / mainHallLobbyRoomSizeFactorial * 20f * green
                    + (mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + bonsaiRoomSizeFactorial + melterRoomSizeFactorial) / amountOfRooms / maintenanceCorridorRoomSizeFactorial * 70f * cyan
                    + (mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + bonsaiRoomSizeFactorial + melterRoomSizeFactorial) / amountOfRooms / bonsaiRoomSizeFactorial * 80f * yellow
                    + (mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + bonsaiRoomSizeFactorial + melterRoomSizeFactorial) / amountOfRooms / melterRoomSizeFactorial * 60f * red)
                    / (amountOfRooms + 1);  //LAST DIVIDER IS AN ESTIMATE WHICH SEEMS TO BE AROUND THE CORRECT LINES

                //checks whether increasing or decreasing the oxygen level
                if (bonsaiRoomOxygen < targetOxygenSpreadLevel)
                {
                    bonsaiRoomOxygen += oxygenSpreadSpeedBonsai;
                }
                else if (bonsaiRoomOxygen > targetOxygenSpreadLevel)
                {
                    bonsaiRoomOxygen -= oxygenSpreadSpeedBonsai;
                }             
                if (corridorOxygen < targetOxygenSpreadLevel)
                {
                    corridorOxygen += oxygenSpreadSpeedCorridor;
                }
                else if (corridorOxygen > targetOxygenSpreadLevel)
                {
                    corridorOxygen -= oxygenSpreadSpeedCorridor;
                }
                if (mainFacilityLobbyOxygen < targetOxygenSpreadLevel)
                {
                    mainFacilityLobbyOxygen += oxygenSpreadSpeedMFLobby;
                }
                else if (mainFacilityLobbyOxygen > targetOxygenSpreadLevel)
                {
                    mainFacilityLobbyOxygen -= oxygenSpreadSpeedMFLobby;
                }
                if (melterRoomOxygen < targetOxygenSpreadLevel)
                {
                    melterRoomOxygen += oxygenSpreadSpeedMelter;
                }
                else if (melterRoomOxygen > targetOxygenSpreadLevel)
                {
                    melterRoomOxygen -= oxygenSpreadSpeedMelter;
                }
            }
        }
        //no mf+corridor door as it is separated into two ifs later
        // TWO DOORS CLOSED
        //mf+corridor door and melter closed
        else if (bonsaiSpreading && janitorSpreading && corridorSpreading && !mfSpreading && !melterSpreading)
        {
            if (bonsaiRoomOxygen > 0 || corridorOxygen > 0 || janitorRoomOxygen > 0)
            {
                combinedOxygen = 80f * yellow + 70f * cyan + 100f * magenta; 
                targetOxygenSpreadLevel = combinedOxygen / amountOfRooms;
                //the spreadspeed is the room's factorial divided by the mean of the other connected rooms               
                oxygenSpreadSpeedBonsai = bonsaiRoomSizeFactorial /
                    ((bonsaiRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + janitorRoomSizeFactorial) / amountOfRooms);              
                oxygenSpreadSpeedJanitor = janitorRoomSizeFactorial /
                    ((janitorRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + bonsaiRoomSizeFactorial) / amountOfRooms);
                oxygenSpreadSpeedCorridor = maintenanceCorridorRoomSizeFactorial /
                    ((maintenanceCorridorRoomSizeFactorial + bonsaiRoomSizeFactorial + janitorRoomSizeFactorial) / amountOfRooms);

                //CALCULATES THE ESTIMATED COMBINED AMOUNT OF OXYGEN BASED ON THE ROOM SIZES AND THEN DIVIDES IT WITH THE ESTIMATE OF (amountOfRooms +1)
                targetOxygenSpreadLevel = ((bonsaiRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + janitorRoomSizeFactorial) / amountOfRooms / bonsaiRoomSizeFactorial * 80f * yellow
                    + (bonsaiRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + janitorRoomSizeFactorial) / amountOfRooms / maintenanceCorridorRoomSizeFactorial * 70f * cyan
                    + (bonsaiRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + janitorRoomSizeFactorial) / amountOfRooms / janitorRoomSizeFactorial * 100f * magenta)
                    / (amountOfRooms + 1);  //LAST DIVIDER IS AN ESTIMATE WHICH SEEMS TO BE AROUND THE CORRECT LINES

                //checks whether increasing or decreasing the oxygen level
                if (bonsaiRoomOxygen < targetOxygenSpreadLevel)
                {
                    bonsaiRoomOxygen += oxygenSpreadSpeedBonsai;
                }
                else if (bonsaiRoomOxygen > targetOxygenSpreadLevel)
                {
                    bonsaiRoomOxygen -= oxygenSpreadSpeedBonsai;
                }
                if (janitorRoomOxygen < targetOxygenSpreadLevel)
                {
                    janitorRoomOxygen += oxygenSpreadSpeedJanitor;
                }
                else if (janitorRoomOxygen > targetOxygenSpreadLevel)
                {
                    janitorRoomOxygen -= oxygenSpreadSpeedJanitor;
                }
                if (corridorOxygen < targetOxygenSpreadLevel)
                {
                    corridorOxygen += oxygenSpreadSpeedCorridor;
                }
                else if (corridorOxygen > targetOxygenSpreadLevel)
                {
                    corridorOxygen -= oxygenSpreadSpeedCorridor;
                }              
            }
        }
        //melter and bonsai doors closed
        else if (!bonsaiSpreading && janitorSpreading && corridorSpreading && mfSpreading && !melterSpreading)
        {
            if (corridorOxygen > 0 || janitorRoomOxygen > 0 || mainFacilityLobbyOxygen > 0)
            {
                combinedOxygen = 70f * cyan + 100f * magenta + 20f * green; 
                targetOxygenSpreadLevel = combinedOxygen / amountOfRooms;
                //the spreadspeed is the room's factorial divided by the mean of the other connected rooms
                oxygenSpreadSpeedMFLobby = mainHallLobbyRoomSizeFactorial /
                    ((mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + janitorRoomSizeFactorial) / amountOfRooms);                              
                oxygenSpreadSpeedJanitor = janitorRoomSizeFactorial /
                    ((janitorRoomSizeFactorial + mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial) / amountOfRooms);
                oxygenSpreadSpeedCorridor = maintenanceCorridorRoomSizeFactorial /
                    ((maintenanceCorridorRoomSizeFactorial + mainHallLobbyRoomSizeFactorial + janitorRoomSizeFactorial) / amountOfRooms);

                //CALCULATES THE ESTIMATED COMBINED AMOUNT OF OXYGEN BASED ON THE ROOM SIZES AND THEN DIVIDES IT WITH THE ESTIMATE OF (amountOfRooms +1)
                targetOxygenSpreadLevel = ((mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + janitorRoomSizeFactorial) / amountOfRooms / mainHallLobbyRoomSizeFactorial * 20f * green
                    + (mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + janitorRoomSizeFactorial) / amountOfRooms / maintenanceCorridorRoomSizeFactorial * 70f * cyan
                    + (mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + janitorRoomSizeFactorial) / amountOfRooms / janitorRoomSizeFactorial * 100f * magenta)
                    / (amountOfRooms + 1);  //LAST DIVIDER IS AN ESTIMATE WHICH SEEMS TO BE AROUND THE CORRECT LINES

                //checks whether increasing or decreasing the oxygen level             
                if (janitorRoomOxygen < targetOxygenSpreadLevel)
                {
                    janitorRoomOxygen += oxygenSpreadSpeedJanitor;
                }
                else if (janitorRoomOxygen > targetOxygenSpreadLevel)
                {
                    janitorRoomOxygen -= oxygenSpreadSpeedJanitor;
                }
                if (corridorOxygen < targetOxygenSpreadLevel)
                {
                    corridorOxygen += oxygenSpreadSpeedCorridor;
                }
                else if (corridorOxygen > targetOxygenSpreadLevel)
                {
                    corridorOxygen -= oxygenSpreadSpeedCorridor;
                }
                if (mainFacilityLobbyOxygen < targetOxygenSpreadLevel)
                {
                    mainFacilityLobbyOxygen += oxygenSpreadSpeedMFLobby;
                }
                else if (mainFacilityLobbyOxygen > targetOxygenSpreadLevel)
                {
                    mainFacilityLobbyOxygen -= oxygenSpreadSpeedMFLobby;
                }              
            }
        }
        //melter and janitor doors closed
        else if (bonsaiSpreading && !janitorSpreading && corridorSpreading && mfSpreading && !melterSpreading)
        {
            if (bonsaiRoomOxygen > 0 || corridorOxygen > 0 || mainFacilityLobbyOxygen > 0)
            {
                combinedOxygen = 80f * yellow + 70f * cyan + 20f * green; 
                targetOxygenSpreadLevel = combinedOxygen / amountOfRooms;
                //the spreadspeed is the room's factorial divided by the mean of the other connected rooms
                oxygenSpreadSpeedMFLobby = mainHallLobbyRoomSizeFactorial /
                    ((mainHallLobbyRoomSizeFactorial + bonsaiRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial) / amountOfRooms);
                oxygenSpreadSpeedBonsai = bonsaiRoomSizeFactorial /
                    ((bonsaiRoomSizeFactorial + mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial) / amountOfRooms);              
                oxygenSpreadSpeedCorridor = maintenanceCorridorRoomSizeFactorial /
                    ((maintenanceCorridorRoomSizeFactorial + mainHallLobbyRoomSizeFactorial + bonsaiRoomSizeFactorial) / amountOfRooms);

                //CALCULATES THE ESTIMATED COMBINED AMOUNT OF OXYGEN BASED ON THE ROOM SIZES AND THEN DIVIDES IT WITH THE ESTIMATE OF (amountOfRooms +1)
                targetOxygenSpreadLevel = ((mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + bonsaiRoomSizeFactorial) / amountOfRooms / mainHallLobbyRoomSizeFactorial * 20f * green
                    + (mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + bonsaiRoomSizeFactorial) / amountOfRooms / maintenanceCorridorRoomSizeFactorial * 70f * cyan
                    + (mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + bonsaiRoomSizeFactorial) / amountOfRooms / bonsaiRoomSizeFactorial * 80f * yellow)
                    / (amountOfRooms + 1);  //LAST DIVIDER IS AN ESTIMATE WHICH SEEMS TO BE AROUND THE CORRECT LINES

                //checks whether increasing or decreasing the oxygen level
                if (bonsaiRoomOxygen < targetOxygenSpreadLevel)
                {
                    bonsaiRoomOxygen += oxygenSpreadSpeedBonsai;
                }
                else if (bonsaiRoomOxygen > targetOxygenSpreadLevel)
                {
                    bonsaiRoomOxygen -= oxygenSpreadSpeedBonsai;
                }               
                if (corridorOxygen < targetOxygenSpreadLevel)
                {
                    corridorOxygen += oxygenSpreadSpeedCorridor;
                }
                else if (corridorOxygen > targetOxygenSpreadLevel)
                {
                    corridorOxygen -= oxygenSpreadSpeedCorridor;
                }
                if (mainFacilityLobbyOxygen < targetOxygenSpreadLevel)
                {
                    mainFacilityLobbyOxygen += oxygenSpreadSpeedMFLobby;
                }
                else if (mainFacilityLobbyOxygen > targetOxygenSpreadLevel)
                {
                    mainFacilityLobbyOxygen -= oxygenSpreadSpeedMFLobby;
                }              
            }
        }
        //bonsai and janitor doors closed     
        else if (!bonsaiSpreading && !janitorSpreading && corridorSpreading && mfSpreading && melterSpreading)
        {
            if (corridorOxygen > 0 || mainFacilityLobbyOxygen > 0 || melterRoomOxygen > 0)
            {
                combinedOxygen = 70f * cyan + 20f * green + 60f * red;               
                //the spreadspeed is the room's factorial divided by the mean of the other connected rooms
                oxygenSpreadSpeedMFLobby = mainHallLobbyRoomSizeFactorial /
                    ((mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + melterRoomSizeFactorial) / amountOfRooms);              
                oxygenSpreadSpeedMelter = melterRoomSizeFactorial /
                    ((melterRoomSizeFactorial + mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial) / amountOfRooms);              
                oxygenSpreadSpeedCorridor = maintenanceCorridorRoomSizeFactorial /
                    ((maintenanceCorridorRoomSizeFactorial + mainHallLobbyRoomSizeFactorial + melterRoomSizeFactorial) / amountOfRooms);

                                            //CALCULATES THE ESTIMATED COMBINED AMOUNT OF OXYGEN BASED ON THE ROOM SIZES AND THEN DIVIDES IT WITH THE ESTIMATE OF (amountOfRooms +1)
                targetOxygenSpreadLevel = ((mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + melterRoomSizeFactorial) / amountOfRooms / mainHallLobbyRoomSizeFactorial * 20f * green 
                    + (mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + melterRoomSizeFactorial) / amountOfRooms / maintenanceCorridorRoomSizeFactorial * 70f * cyan
                    + (mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + melterRoomSizeFactorial) / amountOfRooms / melterRoomSizeFactorial * 60f * cyan)
                    / (amountOfRooms + 1);  //LAST DIVIDER IS AN ESTIMATE WHICH SEEMS TO BE AROUND THE CORRECT LINES
                Debug.Log(targetOxygenSpreadLevel);
                //checks whether increasing or decreasing the oxygen level               
                if (corridorOxygen < targetOxygenSpreadLevel)
                {
                    corridorOxygen += oxygenSpreadSpeedCorridor;
                }
                else if (corridorOxygen > targetOxygenSpreadLevel)
                {
                    corridorOxygen -= oxygenSpreadSpeedCorridor;
                }
                if (mainFacilityLobbyOxygen < targetOxygenSpreadLevel)
                {
                    mainFacilityLobbyOxygen += oxygenSpreadSpeedMFLobby;
                }
                else if (mainFacilityLobbyOxygen > targetOxygenSpreadLevel)
                {
                    mainFacilityLobbyOxygen -= oxygenSpreadSpeedMFLobby;
                }
                if (melterRoomOxygen < targetOxygenSpreadLevel)
                {
                    melterRoomOxygen += oxygenSpreadSpeedMelter;
                }
                else if (melterRoomOxygen > targetOxygenSpreadLevel)
                {
                    melterRoomOxygen -= oxygenSpreadSpeedMelter;
                }
            }
        }
        //THREE DOORS CLOSED
        //only mf+corridor door open
        else if (!bonsaiSpreading && !janitorSpreading && corridorSpreading && mfSpreading && !melterSpreading)
        {
            if (corridorOxygen > 0 || mainFacilityLobbyOxygen > 0)
            {
                combinedOxygen = 70f * cyan + 20f * green;              
                //the spreadspeed is the room's factorial divided by the mean of all the connected rooms
                oxygenSpreadSpeedMFLobby = mainHallLobbyRoomSizeFactorial /
                    ((mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial) / amountOfRooms);               
                oxygenSpreadSpeedCorridor = maintenanceCorridorRoomSizeFactorial /
                    ((maintenanceCorridorRoomSizeFactorial + mainHallLobbyRoomSizeFactorial) / amountOfRooms);
                //setting target level
                if (mfLobbyPositionInOxygenHierarchy > corridorPositionInOxygenHierarchy)
                {                   //MORE % OXYGEN IN mf SO DECREASES // THIS PART DENOTES THE SECONDS TO EVEN OUT BETWEEN THESE TWO ROOOMS ............................  //AND THEN ITS TIMED WITH SPREADSPEED OF THE ROOM IN QUESTION                                              
                    targetOxygenSpreadLevel = 20f * green - ((20f * green - 70f * cyan) / (oxygenSpreadSpeedCorridor + oxygenSpreadSpeedMFLobby) * oxygenSpreadSpeedMFLobby);
                }
                else
                {                  //MORE % OXYGEN IN CORRIDOR SO DECREASES
                    targetOxygenSpreadLevel = 70f * cyan - ((70f * cyan - 20f * green) / (oxygenSpreadSpeedCorridor + oxygenSpreadSpeedMFLobby) * oxygenSpreadSpeedCorridor);
                }

                //checks whether increasing or decreasing the oxygen level              
                if (corridorOxygen < targetOxygenSpreadLevel)
                {
                    corridorOxygen += oxygenSpreadSpeedCorridor;
                    Debug.Log("moreoxygen corridor");
                }
                else if (corridorOxygen > targetOxygenSpreadLevel)
                {
                    corridorOxygen -= oxygenSpreadSpeedCorridor;
                    Debug.Log("lessoxygen corridor");
                }
                if (mainFacilityLobbyOxygen < targetOxygenSpreadLevel)
                {
                    Debug.Log("moreoxygen MFlobby");
                    mainFacilityLobbyOxygen += oxygenSpreadSpeedMFLobby;
                    Debug.Log(oxygenSpreadSpeedMFLobby);
                }
                else if (mainFacilityLobbyOxygen > targetOxygenSpreadLevel)
                {
                    mainFacilityLobbyOxygen -= oxygenSpreadSpeedMFLobby;
                    Debug.Log("lessoxygen MFLobby");
                }               
            }
        }
        // only melter door open
        else if (!bonsaiSpreading && !janitorSpreading && !corridorSpreading && mfSpreading && melterSpreading)
        {
            if (mainFacilityLobbyOxygen > 0 || melterRoomOxygen > 0)
            {
                combinedOxygen = 20f * green + 60f * red;       
                //the spreadspeed is the room's factorial divided by the mean of the other connected rooms
                oxygenSpreadSpeedMFLobby = mainHallLobbyRoomSizeFactorial /
                    ((mainHallLobbyRoomSizeFactorial + melterRoomSizeFactorial) / amountOfRooms);                
                oxygenSpreadSpeedMelter = melterRoomSizeFactorial /
                    ((melterRoomSizeFactorial + mainHallLobbyRoomSizeFactorial) / amountOfRooms);
                Debug.Log(mfLobbyPositionInOxygenHierarchy);
                Debug.Log(melterRoomPositionInOxygenHierarchy);
                if (mfLobbyPositionInOxygenHierarchy > melterRoomPositionInOxygenHierarchy)
                {                                                             
                    targetOxygenSpreadLevel = 20f * green - ((20f * green - 60f * red) / (oxygenSpreadSpeedMelter + oxygenSpreadSpeedMFLobby) * oxygenSpreadSpeedMFLobby);
                }
                //even if both have 60% air in them it's fine as then the target is the current level
                else
                {                 
                    targetOxygenSpreadLevel = 60f * red - ((60f * red - 20f * green) / (oxygenSpreadSpeedMelter + oxygenSpreadSpeedMFLobby) * oxygenSpreadSpeedMelter);
                }

                Debug.Log(oxygenSpreadSpeedMFLobby);
                Debug.Log(oxygenSpreadSpeedMelter);
                //checks whether increasing or decreasing the oxygen level               
                if (mainFacilityLobbyOxygen < targetOxygenSpreadLevel)
                {
                    mainFacilityLobbyOxygen += oxygenSpreadSpeedMFLobby;
                }
                else if (mainFacilityLobbyOxygen > targetOxygenSpreadLevel)
                {
                    mainFacilityLobbyOxygen -= oxygenSpreadSpeedMFLobby;
                }
                if (melterRoomOxygen < targetOxygenSpreadLevel)
                {
                    melterRoomOxygen += oxygenSpreadSpeedMelter;
                }
                else if (melterRoomOxygen > targetOxygenSpreadLevel)
                {
                    melterRoomOxygen -= oxygenSpreadSpeedMelter;
                }
            }
        }
        // only janitor door open
        else if (!bonsaiSpreading && janitorSpreading && corridorSpreading && !mfSpreading && !melterSpreading)
        {
            if (corridorOxygen > 0 || janitorRoomOxygen > 0)
            {
                combinedOxygen = 70f * cyan + 100f * magenta;               
                //the spreadspeed is the room's factorial divided by the mean of the other connected rooms               
                oxygenSpreadSpeedJanitor = janitorRoomSizeFactorial /
                    ((janitorRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial) / amountOfRooms);
                oxygenSpreadSpeedCorridor = maintenanceCorridorRoomSizeFactorial /
                    ((maintenanceCorridorRoomSizeFactorial + janitorRoomSizeFactorial) / amountOfRooms);

                if (corridorPositionInOxygenHierarchy > janitorRoomPositionInOxygenHierarchy)
                {
                    targetOxygenSpreadLevel = 70f * cyan - ((70f * cyan - 100f * magenta) / (oxygenSpreadSpeedCorridor + oxygenSpreadSpeedJanitor) * oxygenSpreadSpeedCorridor);
                }
                //even if both have 60% air in them it's fine as then the target is the current level
                else
                {
                    targetOxygenSpreadLevel = 100f * magenta - ((100f * magenta - 70f * cyan) / (oxygenSpreadSpeedCorridor + oxygenSpreadSpeedJanitor) * oxygenSpreadSpeedJanitor);
                }

                //checks whether increasing or decreasing the oxygen level             
                if (janitorRoomOxygen < targetOxygenSpreadLevel)
                {
                    janitorRoomOxygen += oxygenSpreadSpeedJanitor;
                }
                else if (janitorRoomOxygen > targetOxygenSpreadLevel)
                {
                    janitorRoomOxygen -= oxygenSpreadSpeedJanitor;
                }
                if (corridorOxygen < targetOxygenSpreadLevel)
                {
                    corridorOxygen += oxygenSpreadSpeedCorridor;
                }
                else if (corridorOxygen > targetOxygenSpreadLevel)
                {
                    corridorOxygen -= oxygenSpreadSpeedCorridor;
                }               
            }
        }
        // only bonsai door open
        else if (bonsaiSpreading && !janitorSpreading && corridorSpreading && !mfSpreading && !melterSpreading)
        {
            if (bonsaiRoomOxygen > 0 || corridorOxygen > 0)
            {
                combinedOxygen = 80f * yellow + 70f * cyan;                
                //the spreadspeed is the room's factorial divided by the mean of the other connected rooms               
                oxygenSpreadSpeedBonsai = bonsaiRoomSizeFactorial /
                    ((bonsaiRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial) / amountOfRooms);               
                oxygenSpreadSpeedCorridor = maintenanceCorridorRoomSizeFactorial /
                    ((maintenanceCorridorRoomSizeFactorial + bonsaiRoomSizeFactorial) / amountOfRooms);

                if (corridorPositionInOxygenHierarchy > bonsaiRoomPositionInOxygenHierarchy)
                {
                    targetOxygenSpreadLevel = 70f * cyan - ((70f * cyan - 80f * yellow) / (oxygenSpreadSpeedCorridor + oxygenSpreadSpeedBonsai) * oxygenSpreadSpeedCorridor);
                }
                //even if both have 60% air in them it's fine as then the target is the current level
                else
                {
                    targetOxygenSpreadLevel = 80f * yellow - ((80f * yellow - 70f * cyan) / (oxygenSpreadSpeedCorridor + oxygenSpreadSpeedBonsai) * oxygenSpreadSpeedBonsai);
                }

                //checks whether increasing or decreasing the oxygen level
                if (bonsaiRoomOxygen < targetOxygenSpreadLevel)
                {
                    bonsaiRoomOxygen += oxygenSpreadSpeedBonsai;
                }
                else
                {
                    bonsaiRoomOxygen -= oxygenSpreadSpeedBonsai;
                }                
                if (corridorOxygen < targetOxygenSpreadLevel)
                {
                    corridorOxygen += oxygenSpreadSpeedCorridor;
                }
                else
                {
                    corridorOxygen -= oxygenSpreadSpeedCorridor;
                }               
            }
        }
    }

    private void DisplayRoomOxygenLevels()
    {
        MFLobbyOxygenDisplayMelter.text = mainFacilityLobbyOxygen.ToString("#.00");
        MFLobbyOxygenDisplayBridge.text = mainFacilityLobbyOxygen.ToString("#.00");
        MFLobbyOxygenDisplayCorridor.text = mainFacilityLobbyOxygen.ToString("#.00");
        MFBridgeOxygenDisplay.text = mainFacilityBridgeOxygen.ToString("#.00");
        BonsaiOxygenDisplay.text = bonsaiRoomOxygen.ToString("#.00");
        MelterOxygenDisplay.text = melterRoomOxygen.ToString("#.00");
        JanitorOxygenDisplay.text = janitorRoomOxygen.ToString("#.00");
        CorridorOxygenDisplayMFLobby.text = corridorOxygen.ToString("#.00");
        CorridorOxygenDisplayJanitor.text = corridorOxygen.ToString("#.00");
        CorridorOxygenDisplayBonsai.text = corridorOxygen.ToString("#.00");

        if (mainFacilityLobbyOxygen <= 25)
        {
            MFLobbyOxygenDisplayMelter.color = Color.red;
            MFLobbyOxygenDisplayBridge.color = Color.red;
            MFLobbyOxygenDisplayCorridor.color = Color.red;
        }
        else if (mainFacilityLobbyOxygen > 25 && mainFacilityLobbyOxygen < 50)
        {
            MFLobbyOxygenDisplayMelter.color = Color.yellow;
            MFLobbyOxygenDisplayBridge.color = Color.yellow;
            MFLobbyOxygenDisplayCorridor.color = Color.yellow;
        }
        else if (mainFacilityLobbyOxygen >= 50 && mainFacilityLobbyOxygen <= 75)
        {
            MFLobbyOxygenDisplayMelter.color = Color.green;
            MFLobbyOxygenDisplayBridge.color = Color.green;
            MFLobbyOxygenDisplayCorridor.color = Color.green;
        }
        else if (mainFacilityLobbyOxygen > 75 && mainFacilityLobbyOxygen <= 125)
        {
            MFLobbyOxygenDisplayMelter.color = Color.blue;
            MFLobbyOxygenDisplayBridge.color = Color.blue;
            MFLobbyOxygenDisplayCorridor.color = Color.blue;
        }
        //MF lobby max oxygen is 80f

        if (mainFacilityBridgeOxygen <= 25)
        {
            MFBridgeOxygenDisplay.color = Color.red;
        }
        else if (mainFacilityBridgeOxygen > 25 && mainFacilityBridgeOxygen < 50)
        {
            MFBridgeOxygenDisplay.color = Color.yellow;
        }
        else if (mainFacilityBridgeOxygen >= 50 && mainFacilityBridgeOxygen <= 75)
        {
            MFBridgeOxygenDisplay.color = Color.green;
        }
        else if (mainFacilityBridgeOxygen > 75 && mainFacilityBridgeOxygen <= 125)
        {
            MFBridgeOxygenDisplay.color = Color.blue;
        }
        else if (mainFacilityBridgeOxygen > 125 && mainFacilityBridgeOxygen <= 175)
        {
            MFBridgeOxygenDisplay.color = Color.cyan;
        }
        else if (mainFacilityBridgeOxygen > 175 && mainFacilityBridgeOxygen <= 250)
        {
            MFBridgeOxygenDisplay.color = Color.white;
        }
        else if (mainFacilityBridgeOxygen > 250)
        {
            MFBridgeOxygenDisplay.color = Color.black;
        }

        if (bonsaiRoomOxygen <= 25)
        {
            BonsaiOxygenDisplay.color = Color.red;
        }
        else if (bonsaiRoomOxygen > 25 && bonsaiRoomOxygen < 50)
        {
            BonsaiOxygenDisplay.color = Color.yellow;
        }
        else if (bonsaiRoomOxygen >= 50 && bonsaiRoomOxygen <= 75)
        {
            BonsaiOxygenDisplay.color = Color.green;
        }
        else if (bonsaiRoomOxygen > 75 && bonsaiRoomOxygen <= 125)
        {
            BonsaiOxygenDisplay.color = Color.blue;
        }
        else if (bonsaiRoomOxygen > 125 && bonsaiRoomOxygen <= 175)
        {
            BonsaiOxygenDisplay.color = Color.cyan;
        }
        else if (bonsaiRoomOxygen > 175 && bonsaiRoomOxygen <= 250)
        {
            BonsaiOxygenDisplay.color = Color.white;
        }
        else if (bonsaiRoomOxygen > 250)
        {
            BonsaiOxygenDisplay.color = Color.black;
        }


        if (melterRoomOxygen <= 25)
        {
            MelterOxygenDisplay.color = Color.red;
        }
        else if (melterRoomOxygen > 25 && melterRoomOxygen < 50)
        {
            MelterOxygenDisplay.color = Color.yellow;
        }
        else if (melterRoomOxygen >= 50 && melterRoomOxygen <= 75)
        {
            MelterOxygenDisplay.color = Color.green;
        }
        else if (melterRoomOxygen > 75 && melterRoomOxygen <= 125)
        {
            MelterOxygenDisplay.color = Color.blue;
        }
        else if (melterRoomOxygen > 125 && melterRoomOxygen <= 175)
        {
            MelterOxygenDisplay.color = Color.cyan;
        }
        else if (melterRoomOxygen > 175 && melterRoomOxygen <= 250)
        {
            MelterOxygenDisplay.color = Color.white;
        }
       // max 240f

        if (janitorRoomOxygen <= 25)
        {
            JanitorOxygenDisplay.color = Color.red;
        }
        else if (janitorRoomOxygen > 25 && janitorRoomOxygen < 50)
        {
            JanitorOxygenDisplay.color = Color.yellow;
        }
        else if (janitorRoomOxygen >= 50 && janitorRoomOxygen <= 75)
        {
            JanitorOxygenDisplay.color = Color.green;
        }
        else if (janitorRoomOxygen > 75 && janitorRoomOxygen <= 125)
        {
            JanitorOxygenDisplay.color = Color.blue;
        }
        else if (janitorRoomOxygen > 125 && janitorRoomOxygen <= 175)
        {
            JanitorOxygenDisplay.color = Color.cyan;
        }
        else if (janitorRoomOxygen > 175 && janitorRoomOxygen <= 250)
        {
            JanitorOxygenDisplay.color = Color.white;
        }
        else if (janitorRoomOxygen > 250)
        {
            JanitorOxygenDisplay.color = Color.black;
        }

        if (corridorOxygen <= 25)
        {
            CorridorOxygenDisplayMFLobby.color = Color.red;
            CorridorOxygenDisplayJanitor.color = Color.red;
            CorridorOxygenDisplayBonsai.color = Color.red;
        }
        else if (corridorOxygen > 25 && corridorOxygen < 50)
        {
            CorridorOxygenDisplayMFLobby.color = Color.yellow;
            CorridorOxygenDisplayJanitor.color = Color.yellow;
            CorridorOxygenDisplayBonsai.color = Color.yellow;
        }
        else if (corridorOxygen >= 50 && corridorOxygen <= 75)
        {
            CorridorOxygenDisplayMFLobby.color = Color.green;
            CorridorOxygenDisplayJanitor.color = Color.green;
            CorridorOxygenDisplayBonsai.color = Color.green;
        }
        else if (corridorOxygen > 75 && corridorOxygen <= 125)
        {
            CorridorOxygenDisplayMFLobby.color = Color.blue;
            CorridorOxygenDisplayJanitor.color = Color.blue;
            CorridorOxygenDisplayBonsai.color = Color.blue;
        }
        else if (corridorOxygen > 125 && corridorOxygen <= 175)
        {
            CorridorOxygenDisplayMFLobby.color = Color.cyan;
            CorridorOxygenDisplayJanitor.color = Color.cyan;
            CorridorOxygenDisplayBonsai.color = Color.cyan;
        }
        else if (corridorOxygen > 175 && corridorOxygen <= 250)
        {
            CorridorOxygenDisplayMFLobby.color = Color.white;
            CorridorOxygenDisplayJanitor.color = Color.white;
            CorridorOxygenDisplayBonsai.color = Color.white;
        }
        else if (corridorOxygen > 250)
        {
            CorridorOxygenDisplayMFLobby.color = Color.black;
            CorridorOxygenDisplayJanitor.color = Color.black;
            CorridorOxygenDisplayBonsai.color = Color.black;
        }

    }

    private void CheckCurrentRoomOxygenPercentage()
    {
        //to be able to compare the changes in the oxygen level
        previousRoomOxygenPercentage = currentRoomOxygenPercentage;
        //check player's current location and then the oxygen in that location, doors will help in this. Register player moving through doors. Collider after door, middle space own detection
        if (ResetOutOfFacilityObjectLocation.playerLocation == ResetOutOfFacilityObjectLocation.PlayerCurrentLocation.MainHallLobby)
        {
            currentRoomOxygenPercentage = mainFacilityLobbyOxygen;
        }
        else if (ResetOutOfFacilityObjectLocation.playerLocation == ResetOutOfFacilityObjectLocation.PlayerCurrentLocation.MainHallBridge)
        {
            currentRoomOxygenPercentage = mainFacilityBridgeOxygen;
        }
        else if (ResetOutOfFacilityObjectLocation.playerLocation == ResetOutOfFacilityObjectLocation.PlayerCurrentLocation.JanitorRoom)
        {
            currentRoomOxygenPercentage = janitorRoomOxygen;
        }
        else if (ResetOutOfFacilityObjectLocation.playerLocation == ResetOutOfFacilityObjectLocation.PlayerCurrentLocation.BonsaiRoom)
        {
            currentRoomOxygenPercentage = bonsaiRoomOxygen;
        }
        else if (ResetOutOfFacilityObjectLocation.playerLocation == ResetOutOfFacilityObjectLocation.PlayerCurrentLocation.MaintenanceCorridor)
        {
            currentRoomOxygenPercentage = corridorOxygen;
        }
        else if (ResetOutOfFacilityObjectLocation.playerLocation == ResetOutOfFacilityObjectLocation.PlayerCurrentLocation.MelterRoom)
        {
            currentRoomOxygenPercentage = melterRoomOxygen;
        }
    }

	private void CheckCurrentOxygenLevelName()
    {
        //to be able to start the indicators when oxygen level changes
        previousOxygenLevel = currentOxygenLevel;

        if (currentRoomOxygenPercentage > 250f)
        {
            currentOxygenLevel = OxygenLevelName.SeriousOverpressure;
            playerOxygen = 120f;
        }
        if (currentRoomOxygenPercentage > 175f && currentRoomOxygenPercentage <= 250f)
        {
            currentOxygenLevel = OxygenLevelName.MediumOverpressure;
            playerOxygen = 120f;
        }
        else if (currentRoomOxygenPercentage > 125f && currentRoomOxygenPercentage <= 175f)
        {
            currentOxygenLevel = OxygenLevelName.SlightOverpressure;
            playerOxygen = 120f;

        }
        else if (currentRoomOxygenPercentage > 75f && currentRoomOxygenPercentage <= 125f)
        {
            //resets oxygen level to max if this level is reached
            currentOxygenLevel = OxygenLevelName.Safe;
            playerOxygen = 120f;         
        }
        else if (currentRoomOxygenPercentage <= 75f && currentRoomOxygenPercentage >= 50f)
        {
            currentOxygenLevel = OxygenLevelName.Okay;         
            oxygenLevelLowersFactorial = 0.25f;
            oxygenLevelIncreasesFactorial = 0.75f;
            oxygenLevelStaysFactorial = 0f;
        }
        else if (currentRoomOxygenPercentage < 50f && currentRoomOxygenPercentage > 25f)
        {
            currentOxygenLevel = OxygenLevelName.Alarming;           
            oxygenLevelLowersFactorial = 0.5f;
            oxygenLevelIncreasesFactorial = 0.5f;
            oxygenLevelStaysFactorial = 0.25f;
        }
        else if (currentRoomOxygenPercentage <= 25f)
        {
            currentOxygenLevel = OxygenLevelName.Deadly;            
            oxygenLevelLowersFactorial = 0.75f;
            oxygenLevelIncreasesFactorial = 0.25f;
            oxygenLevelStaysFactorial = 0.5f;
        }
    }
    // the changing speed of oxygen levels only affects how quickly the OxygenLevelName changes, the individual changing speed does not affect otherwise to the player's remaining oxygen
    private void PlayerOxygenLevelChanges()
    {
        //player's oxygen changing speed if oxygen percentage in the room is currently changing and not Safe or overpressured
        if (previousRoomOxygenPercentage != currentRoomOxygenPercentage && currentOxygenLevel != OxygenLevelName.Safe 
            && currentOxygenLevel != OxygenLevelName.SlightOverpressure && currentOxygenLevel != OxygenLevelName.MediumOverpressure && currentOxygenLevel != OxygenLevelName.SeriousOverpressure)
        {
            if (currentRoomOxygenPercentage < previousRoomOxygenPercentage)
            {              
                playerOxygen -= 1 + oxygenLevelLowersFactorial + oxygenLevelStaysFactorial;
            }
            else if (currentRoomOxygenPercentage > previousRoomOxygenPercentage)
            {               
                playerOxygen -= 1 - oxygenLevelIncreasesFactorial + oxygenLevelStaysFactorial;             
            }
        }
        //here we check the player's oxygen changing speed if the oxygen percentage in the room is not changing currently and not Safe or overpressured
        else if (previousRoomOxygenPercentage == currentRoomOxygenPercentage && currentOxygenLevel != OxygenLevelName.Safe 
            && currentOxygenLevel != OxygenLevelName.SlightOverpressure && currentOxygenLevel != OxygenLevelName.MediumOverpressure && currentOxygenLevel != OxygenLevelName.SeriousOverpressure)
        {
            //this causes for example that the oxygen in a Deadly area drains 50% faster than in an Okay area
            playerOxygen -= 1 + oxygenLevelStaysFactorial;
        }
    }

    private void OxygenLevelIndicator()
    {        
        if (currentOxygenLevel == OxygenLevelName.Safe)
        {
            //do nothing
        }
        else if (currentOxygenLevel == OxygenLevelName.Okay)
        {
            //cough lightly when first time entering this
        }
        else if (currentOxygenLevel == OxygenLevelName.Alarming)
        {
            //cough harder and start fading the vision but not completely
                   
        }
        else if (currentOxygenLevel == OxygenLevelName.Deadly)
        {
            //cough like the dying and start completely losing vision for longer and longer times, also add motion blur and pixelation effects
        }
        else if (currentOxygenLevel == OxygenLevelName.SlightOverpressure)
        {
            //Some slight effect dizzying?
        }
        else if (currentOxygenLevel == OxygenLevelName.MediumOverpressure)
        {
            //getting really dizzy
        }
        else if (currentOxygenLevel == OxygenLevelName.SeriousOverpressure)
        {
            //MAXIMUM HIGH
        }
    }

    //creates the side effects for player based on the player's current remaining oxygen
    private void PlayerOxygenLevelSideEffects()
    {

        if (playerOxygen >= 30f && playerOxygen <= 60f)
        {
            VignetteDonut.GetComponent<MeshRenderer>().enabled = true;
            StartSideEffect("Alarming");         
        }
        else if (playerOxygen < 30f && playerOxygen > 0f)
        {
            StartSideEffect("Deadly");          
        }
        else if (playerOxygen <= 0f)
        {
            StartSideEffect("Death");
        }
        else if (playerOxygen > 60f)
        {
            VignetteDonut.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void StartSideEffect(string intensity)
    {
        
        if (intensity == "Alarming")
        {
            //Blink(1.5f);
            if (fadingIn)
            {
                if (VignetteDonut.transform.localScale.x > 6f)
                {
                    donutScaleSpeed = new Vector3(0.05f, 0.0f, 0.05f);
                    VignetteDonut.transform.localScale -= donutScaleSpeed;
                    //if (alpha < 1)
                    //{
                    //alpha += 0.003f;
                    //}
                    //_DonutMaterial.color = new Color(_DonutMaterial.color.r, _DonutMaterial.color.g, _DonutMaterial.color.b, alpha);
                    Water.headSet.GetComponentInChildren<UnderWaterEffect>().enabled = true;
                    Water.headSet.GetComponentInChildren<UnderWaterEffect>()._pixelOffset = 0.003f;
                }
                else if (!changingFadeDirection)
                {
                    changingFadeDirection = true;
                    Water.headSet.GetComponentInChildren<UnderWaterEffect>()._pixelOffset = 0.01f;
                    noHandsLighting = true;
                    WaterMovement.fader.Fade(Color.black, 2f);
                    StartCoroutine(Vignettepause(3f, false));
                }
            }
            else if (!fadingIn)
            {
                if (VignetteDonut.transform.localScale.x < 35f)
                {
                    donutScaleSpeed = new Vector3(0.05f, 0.0f, 0.05f);
                    VignetteDonut.transform.localScale += donutScaleSpeed;
                    //if (alpha > 0)
                    //{
                    //    alpha -= 0.003f;
                    //}
                    //_DonutMaterial.color = new Color(_DonutMaterial.color.r, _DonutMaterial.color.g, _DonutMaterial.color.b, alpha);
                    //Water.headSet.GetComponentInChildren<UnderWaterEffect>().enabled = false;
                    Water.headSet.GetComponentInChildren<UnderWaterEffect>()._pixelOffset = 0.001f;
                }
                else if (!changingFadeDirection)
                {
                    changingFadeDirection = true;
                    StartCoroutine(Vignettepause(4f, true));
                }
            }
        }
        else if (intensity == "Deadly")
        {
            if (fadingIn)
            {
                if (VignetteDonut.transform.localScale.x > 4f)
                {
                    donutScaleSpeed = new Vector3(0.1f, 0f, 0.1f);
                    VignetteDonut.transform.localScale -= donutScaleSpeed;
                    //if (alpha < 1)
                    //{
                    //    alpha += 0.003f;
                    //}
                    //_DonutMaterial.color = new Color(_DonutMaterial.color.r, _DonutMaterial.color.g, _DonutMaterial.color.b, alpha);
                    Water.headSet.GetComponentInChildren<UnderWaterEffect>().enabled = true;
                    Water.headSet.GetComponentInChildren<UnderWaterEffect>()._pixelOffset = 0.01f;
                }
                else if (!changingFadeDirection)
                {
                    Water.headSet.GetComponentInChildren<UnderWaterEffect>()._pixelOffset = 0.05f;
                    noHandsLighting = true;
                    WaterMovement.fader.Fade(Color.black, 1f);
                    changingFadeDirection = true;
                    StartCoroutine(Vignettepause(4.5f, false));
                }
            }
            else if (!fadingIn)
            {
                if (VignetteDonut.transform.localScale.x < 25f)
                {
                    donutScaleSpeed = new Vector3(0.1f, 0f, 0.1f);
                    VignetteDonut.transform.localScale += donutScaleSpeed;
                    //if (alpha > 0)
                    //{
                    //    alpha -= 0.003f;
                    //}
                    //_DonutMaterial.color = new Color(_DonutMaterial.color.r, _DonutMaterial.color.g, _DonutMaterial.color.b, alpha);
                    Water.headSet.GetComponentInChildren<UnderWaterEffect>().enabled = true;
                    Water.headSet.GetComponentInChildren<UnderWaterEffect>()._pixelOffset = 0.005f;
                }
                else if (!changingFadeDirection)
                {
                    changingFadeDirection = true;
                    Water.headSet.GetComponentInChildren<UnderWaterEffect>()._pixelOffset = 0.002f;
                    StartCoroutine(Vignettepause(2f, true));
                }
            }
        }
        else if (intensity == "Death")
        {
            WaterMovement.fader.Fade(Color.black, 2f);
        }
    }

    private void Blink(float blinkspeed)
    {
        donutScaleSpeed = new Vector3(blinkspeed, 0.0f, blinkspeed);
        if (VignetteDonut.transform.localScale.x > 3f && fadingIn)
        {
            VignetteDonut.transform.localScale -= donutScaleSpeed;
            if (VignetteDonut.transform.localScale.x <= 3f)
            {
                fadingIn = false;
            }
        }
        else if (VignetteDonut.transform.localScale.x < 35f && !fadingIn)
        {
            VignetteDonut.transform.localScale += donutScaleSpeed;
            if (VignetteDonut.transform.localScale.x >= 35f)
            {
                fadingIn = true;
            }
        }
                      
    }

    //this method check whether any of the rooms are not currently connected and gradually sets their oxygen levels towards their own values defined in the Bonsai Room
    private void RefreshUnconnectedRooms()
    {
        //if janitor room is isolated
        if (fuseBox.janitorToCorridorDoorClosed || fuseBox.corridorToJanitorDoorClosed)
        {
            //in order to get the number nicely to the exact interval
            //this checks that the current oxygen isn't less than the base value
            if (janitorRoomOxygen < 100f * magenta)
            {
                if (janitorRoomOxygen <= (100f * magenta - janitorRoomSizeFactorial))
                {
                    janitorRoomOxygen += janitorRoomSizeFactorial;
                }
                else
                {
                    janitorRoomOxygen = 100f * magenta;
                }
            }
            else if (janitorRoomOxygen > 100f * magenta)
            {
                if (janitorRoomOxygen >= janitorRoomSizeFactorial)
                {
                    janitorRoomOxygen -= janitorRoomSizeFactorial;
                }
                else
                {
                    janitorRoomOxygen = 0f;
                }
            }
        }
        //if bonsai room is isolated
        if (fuseBox.bonsaiToCorridorDoorClosed || fuseBox.corridorToBonsaiDoorClosed)
        {
            if (bonsaiRoomOxygen < 80f * yellow)
            {
                if (bonsaiRoomOxygen <= (80f * yellow - bonsaiRoomSizeFactorial))
                {
                    bonsaiRoomOxygen += bonsaiRoomSizeFactorial;
                }
                else
                {
                    bonsaiRoomOxygen = 80f * yellow;
                }
            }
            else if (bonsaiRoomOxygen > 80f * yellow)
            {
                if (bonsaiRoomOxygen >= (bonsaiRoomSizeFactorial + 80f * yellow))
                {
                    bonsaiRoomOxygen -= bonsaiRoomSizeFactorial;
                }
                else
                {
                    bonsaiRoomOxygen = 80f * yellow;  //0 or 80
                }
            }
        }
        //if melter room is isolated
        if (fuseBox.melterToMFDoorClosed || fuseBox.mfToMelterDoorClosed)
        {
            if (melterRoomOxygen < 60f * red)
            {
                if (melterRoomOxygen <= (60f * red - melterRoomSizeFactorial))
                {
                    melterRoomOxygen += melterRoomSizeFactorial;
                }
                else
                {
                    melterRoomOxygen = 60f * red;
                }
            }
            else if (melterRoomOxygen > 60f * red)
            {
                if (melterRoomOxygen >= (melterRoomSizeFactorial + 60f * red))
                {
                    melterRoomOxygen -= melterRoomSizeFactorial;
                }
                else
                {
                    melterRoomOxygen = 60f * red;  //0 or 60
                }
            }
        }
        //if MFLobby is isolated
        if ((fuseBox.mfToMelterDoorClosed || fuseBox.melterToMFDoorClosed) && (fuseBox.mfToCorridorDoorClosed || fuseBox.corridorToMFDoorClosed))
        {
            if (mainFacilityLobbyOxygen < 20f * green)
            {
                if (mainFacilityLobbyOxygen <= (20f * green - mainHallLobbyRoomSizeFactorial))
                {
                    mainFacilityLobbyOxygen += mainHallLobbyRoomSizeFactorial;
                }
                else
                {
                    mainFacilityLobbyOxygen = 20f * green;
                }
            }
            else if (mainFacilityLobbyOxygen > 20f * green)
            {
                if (mainFacilityLobbyOxygen >= (mainHallLobbyRoomSizeFactorial + 20f * green))
                {
                    mainFacilityLobbyOxygen -= mainHallLobbyRoomSizeFactorial;
                }
                else
                {
                    mainFacilityLobbyOxygen = 20f * green;  //0,20,40,60 or 80
                }
            }
        }
        //if Corridor is isolated
        if ((fuseBox.corridorToMFDoorClosed || fuseBox.mfToCorridorDoorClosed) 
            && (fuseBox.bonsaiToCorridorDoorClosed || fuseBox.corridorToBonsaiDoorClosed) 
            && (fuseBox.janitorToCorridorDoorClosed || fuseBox.corridorToJanitorDoorClosed))
        {
            if (corridorOxygen < 70f * cyan)
            {
                if (corridorOxygen <= (70f * cyan - maintenanceCorridorRoomSizeFactorial))
                {
                    corridorOxygen += maintenanceCorridorRoomSizeFactorial;
                }
                else
                {
                    corridorOxygen = 70f * cyan;
                }
            }
            else if (corridorOxygen > 70f * cyan)
            {
                if (corridorOxygen >= (maintenanceCorridorRoomSizeFactorial + 70f * cyan))
                {
                    corridorOxygen -= maintenanceCorridorRoomSizeFactorial;
                }
                else
                {
                    corridorOxygen = 70f * cyan;  //0,20,40,60 or 80
                }
            }
        }
    }

        IEnumerator WaitASecond()
    {
        yield return new WaitForSecondsRealtime(1f);
        secondPassed = true;     
    }

    IEnumerator Vignettepause(float waitTime, bool change)
    {
        yield return new WaitForSecondsRealtime(waitTime);      
        fadingIn = change;
        changingFadeDirection = false;
        WaterMovement.fader.Unfade(0.25f);
        noHandsLighting = false;
    }
}
