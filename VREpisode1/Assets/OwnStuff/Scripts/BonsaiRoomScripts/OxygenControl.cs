using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OxygenControl : MonoBehaviour {

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
    private TextMeshPro MFLobbyOxygenDisplay;

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
    private TextMeshPro CorridorOxygenDisplay;

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

    public float black;

    //these are the four possible oxygen levels in an area
    public enum OxygenLevelName
    {
        Safe,
        Okay,
        Alarming,
        Deadly,
    }

    private void Awake()
    {
        defaultOxygenSpreadSpeedFactor = 2;
        currentOxygenLevel = OxygenLevelName.Safe;

        oxygenSpreadSpeedBonsai = 0f;
        oxygenSpreadSpeedCorridor = 0f;
        oxygenSpreadSpeedJanitor = 0f;
        oxygenSpreadSpeedMelter = 0f;       
        oxygenSpreadSpeedMFLobby = 0f;

        playerOxygen = 120f;
        currentRoomOxygenPercentage = 100f;
        previousRoomOxygenPercentage = 100f;
        secondPassed = true;

        mainFacilityBridgeOxygen = 0f;
        MFBridgeOxygenDisplay = GameObject.Find("MFBridgeOxygenDisplay").GetComponent<TextMeshPro>();
        mainFacilityLobbyOxygen = 40f;
        mfLobbyPositionInOxygenHierarchy = 0;
        MFLobbyOxygenDisplay = GameObject.Find("MFLobbyOxygenDisplay").GetComponent<TextMeshPro>();
        bonsaiRoomOxygen = 0f;
        bonsaiRoomPositionInOxygenHierarchy = 0;
        BonsaiOxygenDisplay = GameObject.Find("BonsaiOxygenDisplay").GetComponent<TextMeshPro>();
        janitorRoomOxygen = 0f;
        janitorRoomPositionInOxygenHierarchy = 0;
        JanitorOxygenDisplay = GameObject.Find("JanitorOxygenDisplay").GetComponent<TextMeshPro>();
        corridorOxygen = 0f;
        corridorPositionInOxygenHierarchy = 0;
        CorridorOxygenDisplay = GameObject.Find("CorridorOxygenDisplay").GetComponent<TextMeshPro>();
        melterRoomOxygen = 60f;
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

        fuseBox = GameObject.Find("FuseBoxFunctionality").GetComponent<FuseboxFunctionality>();

        green = 2f;
        red = 1f;
        blue = 0f;
        yellow = 0f;
        magenta = 0f;
        black = 0f;

        oxygenHierarchy = new int[5];
    }


    private void Update()
    {
        //only updates each second 
        if (secondPassed)
        {          
            secondPassed = false;
            //RefreshUnconnectedRooms();
            IsOxygenSpreading();
            DisplayRoomOxygenLevels();
            CheckCurrentRoomOxygenPercentage();
            CheckCurrentOxygenLevelName();
            PlayerOxygenLevelChanges();            
            StartCoroutine("WaitASecond");
        }
    }
    //This method will be called from the Bonsai oxygen Machine when setting the new oxygen level
    public void SetOxygenLevels(Color[] colours)
    {
        //reset colours when new combination gets set
        green = 0f;
        red = 0f;
        blue = 0f;
        yellow = 0f;
        magenta = 0f;
        black = 0f;

        for (int i = 0; i < colours.Length; i++)
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
            else if (colours[i] == Color.black)
            {
                black++;
            }
        }
        //set oxygen levels based on wavelengths, do we want overpressure?
        mainFacilityLobbyOxygen = 20f * green;
        mainFacilityBridgeOxygen = 100f * blue;
        bonsaiRoomOxygen = 80f * yellow;
        janitorRoomOxygen = 100f * magenta;
        corridorOxygen = 70f * black;
        melterRoomOxygen = 60f * red;
        //this part disallows overpressuring rooms, wasting the extra used capacity, it also will not spread
        if (mainFacilityBridgeOxygen > 100f)
        {
            mainFacilityBridgeOxygen = 100f;
        }
        if (bonsaiRoomOxygen > 100f)
        {
            bonsaiRoomOxygen = 100f;
        }
        if (janitorRoomOxygen > 100f)
        {
            janitorRoomOxygen = 100f;
        }
        if (corridorOxygen > 100f)
        {
            corridorOxygen = 100f;
        }
        if (melterRoomOxygen > 100f)
        {
            melterRoomOxygen = 100f;
        }
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

        //oxygenHierarchy[0] = mfLobbyPositionInOxygenHierarchy;
        //oxygenHierarchy[1] = bonsaiRoomPositionInOxygenHierarchy;
        //oxygenHierarchy[2] = melterRoomPositionInOxygenHierarchy;
        //oxygenHierarchy[3] = corridorPositionInOxygenHierarchy;
        //oxygenHierarchy[4] = janitorRoomPositionInOxygenHierarchy;

        //checking which place has more air than others the most times       
        //mfposition
        if (20f * green > 80f * yellow)
        {
            mfLobbyPositionInOxygenHierarchy++;
        }
        if (20f * green > 70f * black)
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
        if (60f * red > 70f * black)
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
        if (100f * magenta > 70f * black)
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
        if (80f * yellow > 70f * black)
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
        if (70f * black > 100f * magenta)
        {
            corridorPositionInOxygenHierarchy++;
        }
        if (70f * black > 80f * yellow)
        {
            corridorPositionInOxygenHierarchy++;
        }
        if (70f * black > 60f * red)
        {
            corridorPositionInOxygenHierarchy++;
        }
        if (70f * black > 20f * green)
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
                combinedOxygen = 80f * yellow + 70f * black + 100f * magenta + 20f * green + 60f * red;
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

                //20f * green + oxygenSpreadSpeedMFLobby * secondsToSpread == 80f * yellow + oxygenSpreadSpeedBonsai * secondsToSpread;
                targetOxygenSpreadLevel = combinedOxygen / amountOfRooms;

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
                combinedOxygen = 80f * yellow + 70f * black + 100f * magenta + 20f * green; 
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
                combinedOxygen = 70f * black + 100f * magenta + 20f * green + 60f * red;
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
                combinedOxygen = 80f * yellow + 70f * black + 20f * green + 60f * red;
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
                combinedOxygen = 80f * yellow + 70f * black + 100f * magenta; 
                targetOxygenSpreadLevel = combinedOxygen / amountOfRooms;
                //the spreadspeed is the room's factorial divided by the mean of the other connected rooms               
                oxygenSpreadSpeedBonsai = bonsaiRoomSizeFactorial /
                    ((bonsaiRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + janitorRoomSizeFactorial) / amountOfRooms);              
                oxygenSpreadSpeedJanitor = janitorRoomSizeFactorial /
                    ((janitorRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + bonsaiRoomSizeFactorial) / amountOfRooms);
                oxygenSpreadSpeedCorridor = maintenanceCorridorRoomSizeFactorial /
                    ((maintenanceCorridorRoomSizeFactorial + bonsaiRoomSizeFactorial + janitorRoomSizeFactorial) / amountOfRooms);

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
                combinedOxygen = 70f * black + 100f * magenta + 20f * green; 
                targetOxygenSpreadLevel = combinedOxygen / amountOfRooms;
                //the spreadspeed is the room's factorial divided by the mean of the other connected rooms
                oxygenSpreadSpeedMFLobby = mainHallLobbyRoomSizeFactorial /
                    ((mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + janitorRoomSizeFactorial) / amountOfRooms);                              
                oxygenSpreadSpeedJanitor = janitorRoomSizeFactorial /
                    ((janitorRoomSizeFactorial + mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial) / amountOfRooms);
                oxygenSpreadSpeedCorridor = maintenanceCorridorRoomSizeFactorial /
                    ((maintenanceCorridorRoomSizeFactorial + mainHallLobbyRoomSizeFactorial + janitorRoomSizeFactorial) / amountOfRooms);

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
                combinedOxygen = 80f * yellow + 70f * black + 20f * green; 
                targetOxygenSpreadLevel = combinedOxygen / amountOfRooms;
                //the spreadspeed is the room's factorial divided by the mean of the other connected rooms
                oxygenSpreadSpeedMFLobby = mainHallLobbyRoomSizeFactorial /
                    ((mainHallLobbyRoomSizeFactorial + bonsaiRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial) / amountOfRooms);
                oxygenSpreadSpeedBonsai = bonsaiRoomSizeFactorial /
                    ((bonsaiRoomSizeFactorial + mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial) / amountOfRooms);              
                oxygenSpreadSpeedCorridor = maintenanceCorridorRoomSizeFactorial /
                    ((maintenanceCorridorRoomSizeFactorial + mainHallLobbyRoomSizeFactorial + bonsaiRoomSizeFactorial) / amountOfRooms);

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
                combinedOxygen = 70f * black + 20f * green + 60f * red;               
                //the spreadspeed is the room's factorial divided by the mean of the other connected rooms
                oxygenSpreadSpeedMFLobby = mainHallLobbyRoomSizeFactorial /
                    ((mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + melterRoomSizeFactorial) / amountOfRooms);              
                oxygenSpreadSpeedMelter = melterRoomSizeFactorial /
                    ((melterRoomSizeFactorial + mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial) / amountOfRooms);              
                oxygenSpreadSpeedCorridor = maintenanceCorridorRoomSizeFactorial /
                    ((maintenanceCorridorRoomSizeFactorial + mainHallLobbyRoomSizeFactorial + melterRoomSizeFactorial) / amountOfRooms);


                targetOxygenSpreadLevel = ;
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
                combinedOxygen = 70f * black + 20f * green;              
                //the spreadspeed is the room's factorial divided by the mean of all the connected rooms
                oxygenSpreadSpeedMFLobby = mainHallLobbyRoomSizeFactorial /
                    ((mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial) / amountOfRooms);               
                oxygenSpreadSpeedCorridor = maintenanceCorridorRoomSizeFactorial /
                    ((maintenanceCorridorRoomSizeFactorial + mainHallLobbyRoomSizeFactorial) / amountOfRooms);
                //setting target level
                if (mfLobbyPositionInOxygenHierarchy > corridorPositionInOxygenHierarchy)
                {                   //MORE % OXYGEN IN mf SO DECREASES // THIS PART DENOTES THE SECONDS TO EVEN OUT BETWEEN THESE TWO ROOOMS ............................  //AND THEN ITS TIMED WITH SPREADSPEED OF THE ROOM IN QUESTION                                              
                    targetOxygenSpreadLevel = 20f * green - ((20f * green - 70f * black) / (oxygenSpreadSpeedCorridor + oxygenSpreadSpeedMFLobby) * oxygenSpreadSpeedMFLobby);
                }
                else
                {                  //MORE % OXYGEN IN CORRIDOR SO DECREASES
                    targetOxygenSpreadLevel = 70f * black - ((70f * black - 20f * green) / (oxygenSpreadSpeedCorridor + oxygenSpreadSpeedMFLobby) * oxygenSpreadSpeedCorridor);
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
                combinedOxygen = 70f * black + 100f * magenta;               
                //the spreadspeed is the room's factorial divided by the mean of the other connected rooms               
                oxygenSpreadSpeedJanitor = janitorRoomSizeFactorial /
                    ((janitorRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial) / amountOfRooms);
                oxygenSpreadSpeedCorridor = maintenanceCorridorRoomSizeFactorial /
                    ((maintenanceCorridorRoomSizeFactorial + janitorRoomSizeFactorial) / amountOfRooms);

                if (corridorPositionInOxygenHierarchy > janitorRoomPositionInOxygenHierarchy)
                {
                    targetOxygenSpreadLevel = 70f * black - ((70f * black - 100f * magenta) / (oxygenSpreadSpeedCorridor + oxygenSpreadSpeedJanitor) * oxygenSpreadSpeedCorridor);
                }
                //even if both have 60% air in them it's fine as then the target is the current level
                else
                {
                    targetOxygenSpreadLevel = 100f * magenta - ((100f * magenta - 70f * black) / (oxygenSpreadSpeedCorridor + oxygenSpreadSpeedJanitor) * oxygenSpreadSpeedJanitor);
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
                combinedOxygen = 80f * yellow + 70f * black;                
                //the spreadspeed is the room's factorial divided by the mean of the other connected rooms               
                oxygenSpreadSpeedBonsai = bonsaiRoomSizeFactorial /
                    ((bonsaiRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial) / amountOfRooms);               
                oxygenSpreadSpeedCorridor = maintenanceCorridorRoomSizeFactorial /
                    ((maintenanceCorridorRoomSizeFactorial + bonsaiRoomSizeFactorial) / amountOfRooms);

                if (corridorPositionInOxygenHierarchy > bonsaiRoomPositionInOxygenHierarchy)
                {
                    targetOxygenSpreadLevel = 70f * black - ((70f * black - 80f * yellow) / (oxygenSpreadSpeedCorridor + oxygenSpreadSpeedBonsai) * oxygenSpreadSpeedCorridor);
                }
                //even if both have 60% air in them it's fine as then the target is the current level
                else
                {
                    targetOxygenSpreadLevel = 80f * yellow - ((80f * yellow - 70f * black) / (oxygenSpreadSpeedCorridor + oxygenSpreadSpeedBonsai) * oxygenSpreadSpeedBonsai);
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
        MFLobbyOxygenDisplay.text = mainFacilityLobbyOxygen.ToString("#.00");
        MFBridgeOxygenDisplay.text = mainFacilityBridgeOxygen.ToString("#.00");
        BonsaiOxygenDisplay.text = bonsaiRoomOxygen.ToString("#.00");
        MelterOxygenDisplay.text = melterRoomOxygen.ToString("#.00");
        JanitorOxygenDisplay.text = janitorRoomOxygen.ToString("#.00");
        CorridorOxygenDisplay.text = corridorOxygen.ToString("#.00");

        if (mainFacilityLobbyOxygen <= 25)
        {
            MFLobbyOxygenDisplay.color = Color.red;
        }
        else if (mainFacilityLobbyOxygen > 25 && mainFacilityLobbyOxygen < 50)
        {
            MFLobbyOxygenDisplay.color = Color.yellow;
        }
        else if (mainFacilityLobbyOxygen >= 50 && mainFacilityLobbyOxygen <= 75)
        {
            MFLobbyOxygenDisplay.color = Color.green;
        }
        else if (mainFacilityLobbyOxygen > 75)
        {
            MFLobbyOxygenDisplay.color = Color.blue;
        }

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
        else if (mainFacilityBridgeOxygen > 75)
        {
            MFBridgeOxygenDisplay.color = Color.blue;
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
        else if (bonsaiRoomOxygen > 75)
        {
            BonsaiOxygenDisplay.color = Color.blue;
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
        else if (melterRoomOxygen > 75)
        {
            MelterOxygenDisplay.color = Color.blue;
        }

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
        else if (janitorRoomOxygen > 75)
        {
            JanitorOxygenDisplay.color = Color.blue;
        }

        if (corridorOxygen <= 25)
        {
            CorridorOxygenDisplay.color = Color.red;
        }
        else if (corridorOxygen > 25 && corridorOxygen < 50)
        {
            CorridorOxygenDisplay.color = Color.yellow;
        }
        else if (corridorOxygen >= 50 && corridorOxygen <= 75)
        {
            CorridorOxygenDisplay.color = Color.green;
        }
        else if (corridorOxygen > 75)
        {
            CorridorOxygenDisplay.color = Color.blue;
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

        if (currentRoomOxygenPercentage > 75)
        {
            //resets oxygen level to max if this level is reached
            currentOxygenLevel = OxygenLevelName.Safe;
            playerOxygen = 120f;         
        }
        else if (currentRoomOxygenPercentage <= 75 && currentRoomOxygenPercentage >= 50)
        {
            currentOxygenLevel = OxygenLevelName.Okay;         
            oxygenLevelLowersFactorial = 0.25f;
            oxygenLevelIncreasesFactorial = 0.75f;
            oxygenLevelStaysFactorial = 0f;
        }
        else if (currentRoomOxygenPercentage < 50 && currentRoomOxygenPercentage > 25)
        {
            currentOxygenLevel = OxygenLevelName.Alarming;           
            oxygenLevelLowersFactorial = 0.5f;
            oxygenLevelIncreasesFactorial = 0.5f;
            oxygenLevelStaysFactorial = 0.25f;
        }
        else if (currentRoomOxygenPercentage <= 25)
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
        //player's oxygen changing speed if oxygen percentage in the room is currently changing and not Safe
        if (previousRoomOxygenPercentage != currentRoomOxygenPercentage && currentOxygenLevel != OxygenLevelName.Safe)
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
        //here we check the player's oxygen changing speed if the oxygen percentage in the room is not changing currently and not Safe
        else if (previousRoomOxygenPercentage == currentRoomOxygenPercentage && currentOxygenLevel != OxygenLevelName.Safe)
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
                if (janitorRoomOxygen <= (100f - janitorRoomSizeFactorial))
                {
                    janitorRoomOxygen += janitorRoomSizeFactorial;
                }
                else
                {
                    janitorRoomOxygen = 100f;
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
                if (bonsaiRoomOxygen <= (100f - bonsaiRoomSizeFactorial))
                {
                    bonsaiRoomOxygen += bonsaiRoomSizeFactorial;
                }
                else
                {
                    bonsaiRoomOxygen = 100f;
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
                if (melterRoomOxygen <= (100f - melterRoomSizeFactorial))
                {
                    melterRoomOxygen += melterRoomSizeFactorial;
                }
                else
                {
                    melterRoomOxygen = 100f;
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
                if (mainFacilityLobbyOxygen <= (80f - mainHallLobbyRoomSizeFactorial))
                {
                    mainFacilityLobbyOxygen += mainHallLobbyRoomSizeFactorial;
                }
                else
                {
                    mainFacilityLobbyOxygen = 80f;
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
            if (corridorOxygen < 70f * black)
            {
                if (corridorOxygen <= (100f - maintenanceCorridorRoomSizeFactorial))
                {
                    corridorOxygen += maintenanceCorridorRoomSizeFactorial;
                }
                else
                {
                    corridorOxygen = 100f;
                }
            }
            else if (corridorOxygen > 70f * black)
            {
                if (corridorOxygen >= (maintenanceCorridorRoomSizeFactorial + 70f * black))
                {
                    corridorOxygen -= maintenanceCorridorRoomSizeFactorial;
                }
                else
                {
                    corridorOxygen = 70f * black;  //0,20,40,60 or 80
                }
            }
        }
    }

        IEnumerator WaitASecond()
    {
        yield return new WaitForSecondsRealtime(1f);
        secondPassed = true;     
    }
	
}
