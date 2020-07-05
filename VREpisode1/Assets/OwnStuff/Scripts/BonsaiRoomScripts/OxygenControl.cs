using System.Collections;
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

    [Tooltip("Text field for displaying MFLobby oxygen level")]
    private TextMeshPro MFLobbyOxygenDisplay;

    [Tooltip("Tells the amount of oxygen in MF Bridge.")]
    private float mainFacilityBridgeOxygen;

    [Tooltip("Text field for displaying MFBridge oxygen level")]
    private TextMeshPro MFBridgeOxygenDisplay;

    [Tooltip("Tells the amount of oxygen in Bonsai Room.")]
    private float bonsaiRoomOxygen;

    [Tooltip("Text field for displaying Bonsai oxygen level")]
    private TextMeshPro BonsaiOxygenDisplay;

    [Tooltip("Tells the amount of oxygen in Janitor Room.")]
    private float janitorRoomOxygen;

    [Tooltip("Text field for displaying Janitor oxygen level")]
    private TextMeshPro JanitorOxygenDisplay;

    [Tooltip("Tells the amount of oxygen in Maintenance Corridor.")]
    private float CorridorOxygen;

    [Tooltip("Text field for displaying Corridor oxygen level")]
    private TextMeshPro CorridorOxygenDisplay;

    [Tooltip("Tells the amount of oxygen in Melter Room.")]
    private float melterRoomOxygen;

    [Tooltip("Text field for displaying Melter oxygen level")]
    private TextMeshPro MelterOxygenDisplay;

    [Tooltip("The combined oxygen between rooms which are connected, used to calculate spreading")]
    private float combinedOxygen;

    [Tooltip("The level of oxygen which all connected rooms are spreading towards to")]
    private float targetOxygenSpreadLevel;

    [Tooltip("Tells the relative size of the airspace in the main hall lobby")]
    private int mainHallLobbyRoomSizeFactorial;

    [Tooltip("Tells the relative size of the airspace in the main hall bridge")]
    private int mainHallBridgeRoomSizeFactorial;

    [Tooltip("Tells the relative size of the airspace in the bonsai Room")]
    private int bonsaiRoomSizeFactorial;

    [Tooltip("Tells the relative size of the airspace in the janitor Room")]
    private int janitorRoomSizeFactorial;

    [Tooltip("Tells the relative size of the airspace in the melter Room")]
    private int melterRoomSizeFactorial;

    [Tooltip("Tells the relative size of the airspace in the maintenance corridor")]
    private int maintenanceCorridorRoomSizeFactorial;

    public FuseboxFunctionality fuseBox;

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
        currentRoomOxygenPercentage = 100;
        previousRoomOxygenPercentage = 100;
        secondPassed = true;

        mainFacilityBridgeOxygen = 0;
        MFBridgeOxygenDisplay = GameObject.Find("MFBridgeOxygenDisplay").GetComponent<TextMeshPro>();
        mainFacilityLobbyOxygen = 30;
        MFLobbyOxygenDisplay = GameObject.Find("MFLobbyOxygenDisplay").GetComponent<TextMeshPro>();
        bonsaiRoomOxygen = 0;
        BonsaiOxygenDisplay = GameObject.Find("BonsaiOxygenDisplay").GetComponent<TextMeshPro>();
        janitorRoomOxygen = 0;
        JanitorOxygenDisplay = GameObject.Find("JanitorOxygenDisplay").GetComponent<TextMeshPro>();
        CorridorOxygen = 60;
        CorridorOxygenDisplay = GameObject.Find("CorridorOxygenDisplay").GetComponent<TextMeshPro>();
        melterRoomOxygen = 0;
        MelterOxygenDisplay = GameObject.Find("MelterOxygenDisplay").GetComponent<TextMeshPro>();
        combinedOxygen = 0;
        targetOxygenSpreadLevel = 0;

        mainHallLobbyRoomSizeFactorial = 2;
        mainHallBridgeRoomSizeFactorial = 10; //not used
        bonsaiRoomSizeFactorial = 8;
        janitorRoomSizeFactorial = 10;
        melterRoomSizeFactorial = 6;
        maintenanceCorridorRoomSizeFactorial = 7;

        fuseBox = GameObject.Find("FuseBoxFunctionality").GetComponent<FuseboxFunctionality>();
    }


    private void Update()
    {
        //only updates each second 
        if (secondPassed)
        {
            secondPassed = false;
            IsOxygenSpreading();
            DisplayRoomOxygenLevels();
            CheckCurrentRoomOxygenPercentage();
            CheckCurrentOxygenLevelName();
            PlayerOxygenLevelChanges();
            StartCoroutine("WaitASecond");
        }
    }
    //This method will be called from the Bonsai oxygen Machine when setting the new oxygen level
    public void SetOxygenLevels(Color firstLight, Color secondLight, Color thirdLight, Color fourthLight)
    {
        // if all lights are green for example, which means MF lobby gets 80% oxygen
        if (firstLight == Color.green && secondLight == Color.green && thirdLight == Color.green && fourthLight == Color.green)
        {
            mainFacilityLobbyOxygen = 80;
            mainFacilityBridgeOxygen = 0;          
            bonsaiRoomOxygen = 0;
            janitorRoomOxygen = 0;
            CorridorOxygen = 0;
            melterRoomOxygen = 0;
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
            OxygenSpreads(true, true, true, true, true, 5);
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
            OxygenSpreads(true, true, true, true, false, 4);
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
            OxygenSpreads(false, true, true, true, true, 4);
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
            OxygenSpreads(true, false, true, true, true, 4);
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
            OxygenSpreads(true, true, true, false, false, 3);
            OxygenSpreads(false, false, false, true, true, 2);
        }
        //TWO DOORS CLOSED
        //all but Melter and MF+corridor Doors open
        else if ((fuseBox.corridorToBonsaiDoorOpen || fuseBox.corridorToBonsaiDoorClosing || fuseBox.corridorToBonsaiDoorOpening)
           && (fuseBox.bonsaiToCorridorDoorOpen || fuseBox.bonsaiToCorridorDoorClosing || fuseBox.bonsaiToCorridorDoorOpening)
           && (fuseBox.janitorToCorridorDoorOpen || fuseBox.janitorToCorridorDoorClosing || fuseBox.janitorToCorridorDoorOpening)
           && (fuseBox.corridorToJanitorDoorOpen || fuseBox.corridorToJanitorDoorClosing || fuseBox.corridorToJanitorDoorOpening))
        {
            //first parameter refers to bonsaiRoom, second Janitor, third corridor, 4th MF and 5th Melter
            OxygenSpreads(true, true, true, false, false, 3);
        }
        //all but Melter and Bonsai Doors open
        else if ((fuseBox.janitorToCorridorDoorOpen || fuseBox.janitorToCorridorDoorClosing || fuseBox.janitorToCorridorDoorOpening)
            && (fuseBox.corridorToJanitorDoorOpen || fuseBox.corridorToJanitorDoorClosing || fuseBox.corridorToJanitorDoorOpening)
            && (fuseBox.corridorToMFDoorOpen || fuseBox.corridorToMFDoorClosing || fuseBox.corridorToMFDoorOpening)
            && (fuseBox.mfToCorridorDoorOpen || fuseBox.mfToCorridorDoorClosing || fuseBox.mfToCorridorDoorOpening))
        {
            //first parameter refers to bonsaiRoom, second Janitor, third corridor, 4th MF and 5th Melter
            OxygenSpreads(false, true, true, true, false, 3);
        }
        //all but Melter and Janitor doors open
        else if ((fuseBox.corridorToBonsaiDoorOpen || fuseBox.corridorToBonsaiDoorClosing || fuseBox.corridorToBonsaiDoorOpening)
            && (fuseBox.bonsaiToCorridorDoorOpen || fuseBox.bonsaiToCorridorDoorClosing || fuseBox.bonsaiToCorridorDoorOpening)
            && (fuseBox.corridorToMFDoorOpen || fuseBox.corridorToMFDoorClosing || fuseBox.corridorToMFDoorOpening)
            && (fuseBox.mfToCorridorDoorOpen || fuseBox.mfToCorridorDoorClosing || fuseBox.mfToCorridorDoorOpening))
        {
            //first parameter refers to bonsaiRoom, second Janitor, third corridor, 4th MF and 5th Melter
            OxygenSpreads(true, false, true, true, false, 3);
        }
        //all but Bonsai and Janitor Doors open
        else if ((fuseBox.corridorToMFDoorOpen || fuseBox.corridorToMFDoorClosing || fuseBox.corridorToMFDoorOpening)
            && (fuseBox.mfToCorridorDoorOpen || fuseBox.mfToCorridorDoorClosing || fuseBox.mfToCorridorDoorOpening)
            && (fuseBox.mfToMelterDoorOpen || fuseBox.mfToMelterDoorClosing || fuseBox.mfToMelterDoorOpening)
            && (fuseBox.melterToMFDoorOpen || fuseBox.melterToMFDoorClosing || fuseBox.melterToMFDoorOpening))
        {
            //first parameter refers to bonsaiRoom, second Janitor, third corridor, 4th MF and 5th Melter
            OxygenSpreads(false, false, true, true, true, 3);
        }
        //all but MF + corridor door and Janitor door open, this creates 2 different oxygen spread zones SPECIAL CASE
        else if ((fuseBox.corridorToBonsaiDoorOpen || fuseBox.corridorToBonsaiDoorClosing || fuseBox.corridorToBonsaiDoorOpening)
            && (fuseBox.bonsaiToCorridorDoorOpen || fuseBox.bonsaiToCorridorDoorClosing || fuseBox.bonsaiToCorridorDoorOpening)                  
            && (fuseBox.mfToMelterDoorOpen || fuseBox.mfToMelterDoorClosing || fuseBox.mfToMelterDoorOpening)
            && (fuseBox.melterToMFDoorOpen || fuseBox.melterToMFDoorClosing || fuseBox.melterToMFDoorOpening))
        {
            //2 different zones requires the method to be called two times with the separate zones, melter+MF and corridor+Bonsai
            OxygenSpreads(false, false, false, true, true, 2);
            OxygenSpreads(true, false, true, false, false, 2);
        }
        //all but MF + corridor door and Bonsai door open, this creates 2 different oxygen spread zones SPECIAL CASE
        else if ((fuseBox.janitorToCorridorDoorOpen || fuseBox.janitorToCorridorDoorClosing || fuseBox.janitorToCorridorDoorOpening)
            && (fuseBox.corridorToJanitorDoorOpen || fuseBox.corridorToJanitorDoorClosing || fuseBox.corridorToJanitorDoorOpening)
            && (fuseBox.mfToMelterDoorOpen || fuseBox.mfToMelterDoorClosing || fuseBox.mfToMelterDoorOpening)
            && (fuseBox.melterToMFDoorOpen || fuseBox.melterToMFDoorClosing || fuseBox.melterToMFDoorOpening))
        {
            //2 different zones requires the method to be called two times with the separate zones, melter+MF and corridor+Janitor
            OxygenSpreads(false, false, false, true, true, 2);
            OxygenSpreads(false, true, true, false, false, 2);
        }
        // THREE DOORS CLOSED
        // only mf+corridor door open
        else if ((fuseBox.corridorToMFDoorOpen || fuseBox.corridorToMFDoorClosing || fuseBox.corridorToMFDoorOpening)
           && (fuseBox.mfToCorridorDoorOpen || fuseBox.mfToCorridorDoorClosing || fuseBox.mfToCorridorDoorOpening))
          
        {
            //first parameter refers to bonsaiRoom, second Janitor, third corridor, 4th MF and 5th Melter
            OxygenSpreads(false, false, true, true, false, 2);
        }
        // only melter door open
        else if ((fuseBox.mfToMelterDoorOpen || fuseBox.mfToMelterDoorClosing || fuseBox.mfToMelterDoorOpening)
           && (fuseBox.melterToMFDoorOpen || fuseBox.melterToMFDoorClosing || fuseBox.melterToMFDoorOpening))
        {
            //first parameter refers to bonsaiRoom, second Janitor, third corridor, 4th MF and 5th Melter
            OxygenSpreads(false, false, false, true, true, 2);
        }
        // only janitor door open
        else if ((fuseBox.janitorToCorridorDoorOpen || fuseBox.janitorToCorridorDoorClosing || fuseBox.janitorToCorridorDoorOpening)
            && (fuseBox.corridorToJanitorDoorOpen || fuseBox.corridorToJanitorDoorClosing || fuseBox.corridorToJanitorDoorOpening))
        {
            //first parameter refers to bonsaiRoom, second Janitor, third corridor, 4th MF and 5th Melter
            OxygenSpreads(false, true, true, false, false, 2);
        }
        // only bonsai door open
        else if ((fuseBox.corridorToBonsaiDoorOpen || fuseBox.corridorToBonsaiDoorClosing || fuseBox.corridorToBonsaiDoorOpening)
            && (fuseBox.bonsaiToCorridorDoorOpen || fuseBox.bonsaiToCorridorDoorClosing || fuseBox.bonsaiToCorridorDoorOpening))
        {
            //first parameter refers to bonsaiRoom, second Janitor, third corridor, 4th MF and 5th Melter
            OxygenSpreads(true, false, true, false, false, 2);
        }   
    }
    //NOTE: corridor is spreading as long as one of the doors, janitor, bonsai or mfTOcorridor is open
    //bonsai and some other rooms are connected, remember that rooms can be connected at the same time with others. etc Bonsai+Corridor and Melter+MF
    private void OxygenSpreads(bool bonsaiSpreading, bool janitorSpreading, bool corridorSpreading, bool mfSpreading, bool melterSpreading, int amountOfRooms)
    {
        //all doors open (highly unlikely case)
        if (bonsaiSpreading && janitorSpreading && corridorSpreading && mfSpreading && melterSpreading)
        {
            if (bonsaiRoomOxygen > 0 || CorridorOxygen > 0 || janitorRoomOxygen > 0 || mainFacilityLobbyOxygen > 0 || melterRoomOxygen > 0)
            {
                combinedOxygen = bonsaiRoomOxygen + CorridorOxygen + janitorRoomOxygen + mainFacilityLobbyOxygen + melterRoomOxygen;
                targetOxygenSpreadLevel = combinedOxygen / amountOfRooms;
                //the spreadspeed is the room's factorial divided by the mean of the other connected rooms
                oxygenSpreadSpeedMFLobby = mainHallLobbyRoomSizeFactorial /
                    ((bonsaiRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + janitorRoomSizeFactorial + melterRoomSizeFactorial) / (amountOfRooms - 1));
                oxygenSpreadSpeedBonsai = bonsaiRoomSizeFactorial /
                    ((mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + janitorRoomSizeFactorial + melterRoomSizeFactorial) / (amountOfRooms - 1));
                oxygenSpreadSpeedMelter = melterRoomSizeFactorial /
                    ((mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + janitorRoomSizeFactorial + bonsaiRoomSizeFactorial) / (amountOfRooms - 1));
                oxygenSpreadSpeedJanitor = janitorRoomSizeFactorial /
                    ((mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + bonsaiRoomSizeFactorial + melterRoomSizeFactorial) / (amountOfRooms - 1));
                oxygenSpreadSpeedCorridor = maintenanceCorridorRoomSizeFactorial /
                    ((mainHallLobbyRoomSizeFactorial + bonsaiRoomSizeFactorial + janitorRoomSizeFactorial + melterRoomSizeFactorial) / (amountOfRooms - 1));

                //checks whether increasing or decreasing the oxygen level
                if (bonsaiRoomOxygen < targetOxygenSpreadLevel)
                {
                    bonsaiRoomOxygen += oxygenSpreadSpeedBonsai;
                }
                else
                {
                    bonsaiRoomOxygen -= oxygenSpreadSpeedBonsai;
                }
                if (janitorRoomOxygen < targetOxygenSpreadLevel)
                {
                    janitorRoomOxygen += oxygenSpreadSpeedJanitor;
                }
                else
                {
                    janitorRoomOxygen -= oxygenSpreadSpeedJanitor;
                }
                if (CorridorOxygen < targetOxygenSpreadLevel)
                {
                    CorridorOxygen += oxygenSpreadSpeedCorridor;
                }
                else
                {
                    CorridorOxygen -= oxygenSpreadSpeedCorridor;
                }
                if (mainFacilityLobbyOxygen < targetOxygenSpreadLevel)
                {
                    mainFacilityLobbyOxygen += oxygenSpreadSpeedMFLobby;
                }
                else
                {
                    mainFacilityLobbyOxygen -= oxygenSpreadSpeedMFLobby;
                }
                if (melterRoomOxygen < targetOxygenSpreadLevel)
                {
                    melterRoomOxygen += oxygenSpreadSpeedMelter;
                }
                else
                {
                    melterRoomOxygen -= oxygenSpreadSpeedMelter;
                }
            }
        }
        //ONE DOOR CLOSED
        // melter closed
        else if (bonsaiSpreading && janitorSpreading && corridorSpreading && mfSpreading && !melterSpreading)
        {
            if (bonsaiRoomOxygen > 0 || CorridorOxygen > 0 || janitorRoomOxygen > 0 || mainFacilityLobbyOxygen > 0)
            {
                combinedOxygen = bonsaiRoomOxygen + CorridorOxygen + janitorRoomOxygen + mainFacilityLobbyOxygen;
                targetOxygenSpreadLevel = combinedOxygen / amountOfRooms;
                //the spreadspeed is the room's factorial divided by the mean of the other connected rooms
                oxygenSpreadSpeedMFLobby = mainHallLobbyRoomSizeFactorial /
                    ((bonsaiRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + janitorRoomSizeFactorial) / (amountOfRooms - 1));
                oxygenSpreadSpeedBonsai = bonsaiRoomSizeFactorial /
                    ((mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + janitorRoomSizeFactorial) / (amountOfRooms - 1));
                oxygenSpreadSpeedJanitor = janitorRoomSizeFactorial /
                    ((mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + bonsaiRoomSizeFactorial) / (amountOfRooms - 1));
                oxygenSpreadSpeedCorridor = maintenanceCorridorRoomSizeFactorial /
                    ((mainHallLobbyRoomSizeFactorial + bonsaiRoomSizeFactorial + janitorRoomSizeFactorial) / (amountOfRooms - 1));

                //checks whether increasing or decreasing the oxygen level
                if (bonsaiRoomOxygen < targetOxygenSpreadLevel)
                {
                    bonsaiRoomOxygen += oxygenSpreadSpeedBonsai;
                }
                else
                {
                    bonsaiRoomOxygen -= oxygenSpreadSpeedBonsai;
                }
                if (janitorRoomOxygen < targetOxygenSpreadLevel)
                {
                    janitorRoomOxygen += oxygenSpreadSpeedJanitor;
                }
                else
                {
                    janitorRoomOxygen -= oxygenSpreadSpeedJanitor;
                }
                if (CorridorOxygen < targetOxygenSpreadLevel)
                {
                    CorridorOxygen += oxygenSpreadSpeedCorridor;
                }
                else
                {
                    CorridorOxygen -= oxygenSpreadSpeedCorridor;
                }
                if (mainFacilityLobbyOxygen < targetOxygenSpreadLevel)
                {
                    mainFacilityLobbyOxygen += oxygenSpreadSpeedMFLobby;
                }
                else
                {
                    mainFacilityLobbyOxygen -= oxygenSpreadSpeedMFLobby;
                }
            }
        }
        // bonsai closed
        else if (!bonsaiSpreading && janitorSpreading && corridorSpreading && mfSpreading && melterSpreading)
        {
            if (CorridorOxygen > 0 || janitorRoomOxygen > 0 || mainFacilityLobbyOxygen > 0 || melterRoomOxygen > 0)
            {
                combinedOxygen = CorridorOxygen + janitorRoomOxygen + mainFacilityLobbyOxygen + melterRoomOxygen;
                targetOxygenSpreadLevel = combinedOxygen / amountOfRooms;
                //the spreadspeed is the room's factorial divided by the mean of the other connected rooms
                oxygenSpreadSpeedMFLobby = mainHallLobbyRoomSizeFactorial /
                    ((maintenanceCorridorRoomSizeFactorial + janitorRoomSizeFactorial + melterRoomSizeFactorial) / (amountOfRooms - 1));
                oxygenSpreadSpeedMelter = melterRoomSizeFactorial /
                    ((mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + janitorRoomSizeFactorial) / (amountOfRooms - 1));
                oxygenSpreadSpeedJanitor = janitorRoomSizeFactorial /
                    ((mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + melterRoomSizeFactorial) / (amountOfRooms - 1));
                oxygenSpreadSpeedCorridor = maintenanceCorridorRoomSizeFactorial /
                    ((mainHallLobbyRoomSizeFactorial + janitorRoomSizeFactorial + melterRoomSizeFactorial) / (amountOfRooms - 1));

                //checks whether increasing or decreasing the oxygen level           
                if (janitorRoomOxygen < targetOxygenSpreadLevel)
                {
                    janitorRoomOxygen += oxygenSpreadSpeedJanitor;
                }
                else
                {
                    janitorRoomOxygen -= oxygenSpreadSpeedJanitor;
                }
                if (CorridorOxygen < targetOxygenSpreadLevel)
                {
                    CorridorOxygen += oxygenSpreadSpeedCorridor;
                }
                else
                {
                    CorridorOxygen -= oxygenSpreadSpeedCorridor;
                }
                if (mainFacilityLobbyOxygen < targetOxygenSpreadLevel)
                {
                    mainFacilityLobbyOxygen += oxygenSpreadSpeedMFLobby;
                }
                else
                {
                    mainFacilityLobbyOxygen -= oxygenSpreadSpeedMFLobby;
                }
                if (melterRoomOxygen < targetOxygenSpreadLevel)
                {
                    melterRoomOxygen += oxygenSpreadSpeedMelter;
                }
                else
                {
                    melterRoomOxygen -= oxygenSpreadSpeedMelter;
                }
            }
        }
        // janitor closed
        else if (bonsaiSpreading && !janitorSpreading && corridorSpreading && mfSpreading && melterSpreading)
        {
            if (bonsaiRoomOxygen > 0 || CorridorOxygen > 0 || mainFacilityLobbyOxygen > 0 || melterRoomOxygen > 0)
            {
                combinedOxygen = bonsaiRoomOxygen + CorridorOxygen + mainFacilityLobbyOxygen + melterRoomOxygen;
                targetOxygenSpreadLevel = combinedOxygen / amountOfRooms;
                //the spreadspeed is the room's factorial divided by the mean of the other connected rooms
                oxygenSpreadSpeedMFLobby = mainHallLobbyRoomSizeFactorial /
                    ((bonsaiRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + melterRoomSizeFactorial) / (amountOfRooms - 1));
                oxygenSpreadSpeedBonsai = bonsaiRoomSizeFactorial /
                    ((mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + melterRoomSizeFactorial) / (amountOfRooms - 1));
                oxygenSpreadSpeedMelter = melterRoomSizeFactorial /
                    ((mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial + bonsaiRoomSizeFactorial) / (amountOfRooms - 1));              
                oxygenSpreadSpeedCorridor = maintenanceCorridorRoomSizeFactorial /
                    ((mainHallLobbyRoomSizeFactorial + bonsaiRoomSizeFactorial + janitorRoomSizeFactorial + melterRoomSizeFactorial) / (amountOfRooms - 1));

                //checks whether increasing or decreasing the oxygen level
                if (bonsaiRoomOxygen < targetOxygenSpreadLevel)
                {
                    bonsaiRoomOxygen += oxygenSpreadSpeedBonsai;
                }
                else
                {
                    bonsaiRoomOxygen -= oxygenSpreadSpeedBonsai;
                }             
                if (CorridorOxygen < targetOxygenSpreadLevel)
                {
                    CorridorOxygen += oxygenSpreadSpeedCorridor;
                }
                else
                {
                    CorridorOxygen -= oxygenSpreadSpeedCorridor;
                }
                if (mainFacilityLobbyOxygen < targetOxygenSpreadLevel)
                {
                    mainFacilityLobbyOxygen += oxygenSpreadSpeedMFLobby;
                }
                else
                {
                    mainFacilityLobbyOxygen -= oxygenSpreadSpeedMFLobby;
                }
                if (melterRoomOxygen < targetOxygenSpreadLevel)
                {
                    melterRoomOxygen += oxygenSpreadSpeedMelter;
                }
                else
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
            if (bonsaiRoomOxygen > 0 || CorridorOxygen > 0 || janitorRoomOxygen > 0)
            {
                combinedOxygen = bonsaiRoomOxygen + CorridorOxygen + janitorRoomOxygen;
                targetOxygenSpreadLevel = combinedOxygen / amountOfRooms;
                //the spreadspeed is the room's factorial divided by the mean of the other connected rooms               
                oxygenSpreadSpeedBonsai = bonsaiRoomSizeFactorial /
                    ((maintenanceCorridorRoomSizeFactorial + janitorRoomSizeFactorial) / (amountOfRooms - 1));              
                oxygenSpreadSpeedJanitor = janitorRoomSizeFactorial /
                    ((maintenanceCorridorRoomSizeFactorial + bonsaiRoomSizeFactorial) / (amountOfRooms - 1));
                oxygenSpreadSpeedCorridor = maintenanceCorridorRoomSizeFactorial /
                    ((bonsaiRoomSizeFactorial + janitorRoomSizeFactorial) / (amountOfRooms - 1));

                //checks whether increasing or decreasing the oxygen level
                if (bonsaiRoomOxygen < targetOxygenSpreadLevel)
                {
                    bonsaiRoomOxygen += oxygenSpreadSpeedBonsai;
                }
                else
                {
                    bonsaiRoomOxygen -= oxygenSpreadSpeedBonsai;
                }
                if (janitorRoomOxygen < targetOxygenSpreadLevel)
                {
                    janitorRoomOxygen += oxygenSpreadSpeedJanitor;
                }
                else
                {
                    janitorRoomOxygen -= oxygenSpreadSpeedJanitor;
                }
                if (CorridorOxygen < targetOxygenSpreadLevel)
                {
                    CorridorOxygen += oxygenSpreadSpeedCorridor;
                }
                else
                {
                    CorridorOxygen -= oxygenSpreadSpeedCorridor;
                }              
            }
        }
        //melter and bonsai doors closed
        else if (!bonsaiSpreading && janitorSpreading && corridorSpreading && mfSpreading && !melterSpreading)
        {
            if (CorridorOxygen > 0 || janitorRoomOxygen > 0 || mainFacilityLobbyOxygen > 0)
            {
                combinedOxygen = CorridorOxygen + janitorRoomOxygen + mainFacilityLobbyOxygen;
                targetOxygenSpreadLevel = combinedOxygen / amountOfRooms;
                //the spreadspeed is the room's factorial divided by the mean of the other connected rooms
                oxygenSpreadSpeedMFLobby = mainHallLobbyRoomSizeFactorial /
                    ((maintenanceCorridorRoomSizeFactorial + janitorRoomSizeFactorial) / (amountOfRooms - 1));                              
                oxygenSpreadSpeedJanitor = janitorRoomSizeFactorial /
                    ((mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial) / (amountOfRooms - 1));
                oxygenSpreadSpeedCorridor = maintenanceCorridorRoomSizeFactorial /
                    ((mainHallLobbyRoomSizeFactorial+ janitorRoomSizeFactorial) / (amountOfRooms - 1));

                //checks whether increasing or decreasing the oxygen level             
                if (janitorRoomOxygen < targetOxygenSpreadLevel)
                {
                    janitorRoomOxygen += oxygenSpreadSpeedJanitor;
                }
                else
                {
                    janitorRoomOxygen -= oxygenSpreadSpeedJanitor;
                }
                if (CorridorOxygen < targetOxygenSpreadLevel)
                {
                    CorridorOxygen += oxygenSpreadSpeedCorridor;
                }
                else
                {
                    CorridorOxygen -= oxygenSpreadSpeedCorridor;
                }
                if (mainFacilityLobbyOxygen < targetOxygenSpreadLevel)
                {
                    mainFacilityLobbyOxygen += oxygenSpreadSpeedMFLobby;
                }
                else
                {
                    mainFacilityLobbyOxygen -= oxygenSpreadSpeedMFLobby;
                }              
            }
        }
        //melter and janitor doors closed
        else if (bonsaiSpreading && !janitorSpreading && corridorSpreading && mfSpreading && !melterSpreading)
        {
            if (bonsaiRoomOxygen > 0 || CorridorOxygen > 0 || mainFacilityLobbyOxygen > 0)
            {
                combinedOxygen = bonsaiRoomOxygen + CorridorOxygen + mainFacilityLobbyOxygen;
                targetOxygenSpreadLevel = combinedOxygen / amountOfRooms;
                //the spreadspeed is the room's factorial divided by the mean of the other connected rooms
                oxygenSpreadSpeedMFLobby = mainHallLobbyRoomSizeFactorial /
                    ((bonsaiRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial) / (amountOfRooms - 1));
                oxygenSpreadSpeedBonsai = bonsaiRoomSizeFactorial /
                    ((mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial) / (amountOfRooms - 1));              
                oxygenSpreadSpeedCorridor = maintenanceCorridorRoomSizeFactorial /
                    ((mainHallLobbyRoomSizeFactorial + bonsaiRoomSizeFactorial) / (amountOfRooms - 1));

                //checks whether increasing or decreasing the oxygen level
                if (bonsaiRoomOxygen < targetOxygenSpreadLevel)
                {
                    bonsaiRoomOxygen += oxygenSpreadSpeedBonsai;
                }
                else
                {
                    bonsaiRoomOxygen -= oxygenSpreadSpeedBonsai;
                }               
                if (CorridorOxygen < targetOxygenSpreadLevel)
                {
                    CorridorOxygen += oxygenSpreadSpeedCorridor;
                }
                else
                {
                    CorridorOxygen -= oxygenSpreadSpeedCorridor;
                }
                if (mainFacilityLobbyOxygen < targetOxygenSpreadLevel)
                {
                    mainFacilityLobbyOxygen += oxygenSpreadSpeedMFLobby;
                }
                else
                {
                    mainFacilityLobbyOxygen -= oxygenSpreadSpeedMFLobby;
                }              
            }
        }
        //bonsai and janitor doors closed
        //THREE DOORS CLOSED
        else if (!bonsaiSpreading && !janitorSpreading && corridorSpreading && mfSpreading && melterSpreading)
        {
            if (CorridorOxygen > 0 || mainFacilityLobbyOxygen > 0 || melterRoomOxygen > 0)
            {
                combinedOxygen = CorridorOxygen + mainFacilityLobbyOxygen + melterRoomOxygen;
                targetOxygenSpreadLevel = combinedOxygen / amountOfRooms;
                //the spreadspeed is the room's factorial divided by the mean of the other connected rooms
                oxygenSpreadSpeedMFLobby = mainHallLobbyRoomSizeFactorial /
                    ((maintenanceCorridorRoomSizeFactorial + melterRoomSizeFactorial) / (amountOfRooms - 1));              
                oxygenSpreadSpeedMelter = melterRoomSizeFactorial /
                    ((mainHallLobbyRoomSizeFactorial + maintenanceCorridorRoomSizeFactorial) / (amountOfRooms - 1));              
                oxygenSpreadSpeedCorridor = maintenanceCorridorRoomSizeFactorial /
                    ((mainHallLobbyRoomSizeFactorial + melterRoomSizeFactorial) / (amountOfRooms - 1));

                //checks whether increasing or decreasing the oxygen level               
                if (CorridorOxygen < targetOxygenSpreadLevel)
                {
                    CorridorOxygen += oxygenSpreadSpeedCorridor;
                }
                else
                {
                    CorridorOxygen -= oxygenSpreadSpeedCorridor;
                }
                if (mainFacilityLobbyOxygen < targetOxygenSpreadLevel)
                {
                    mainFacilityLobbyOxygen += oxygenSpreadSpeedMFLobby;
                }
                else
                {
                    mainFacilityLobbyOxygen -= oxygenSpreadSpeedMFLobby;
                }
                if (melterRoomOxygen < targetOxygenSpreadLevel)
                {
                    melterRoomOxygen += oxygenSpreadSpeedMelter;
                }
                else
                {
                    melterRoomOxygen -= oxygenSpreadSpeedMelter;
                }
            }
        }
        //only mf+corridor door open
        else if (!bonsaiSpreading && !janitorSpreading && corridorSpreading && mfSpreading && !melterSpreading)
        {
            if (CorridorOxygen > 0 || mainFacilityLobbyOxygen > 0)
            {
                combinedOxygen = CorridorOxygen + mainFacilityLobbyOxygen;
                targetOxygenSpreadLevel = combinedOxygen / amountOfRooms;
                //the spreadspeed is the room's factorial divided by the mean of the other connected rooms
                oxygenSpreadSpeedMFLobby = mainHallLobbyRoomSizeFactorial /
                    (maintenanceCorridorRoomSizeFactorial / (amountOfRooms - 1));               
                oxygenSpreadSpeedCorridor = maintenanceCorridorRoomSizeFactorial /
                    (mainHallLobbyRoomSizeFactorial / (amountOfRooms - 1));

                //checks whether increasing or decreasing the oxygen level              
                if (CorridorOxygen < targetOxygenSpreadLevel)
                {
                    CorridorOxygen += oxygenSpreadSpeedCorridor;
                }
                else
                {
                    CorridorOxygen -= oxygenSpreadSpeedCorridor;
                }
                if (mainFacilityLobbyOxygen < targetOxygenSpreadLevel)
                {
                    mainFacilityLobbyOxygen += oxygenSpreadSpeedMFLobby;
                }
                else
                {
                    mainFacilityLobbyOxygen -= oxygenSpreadSpeedMFLobby;
                }               
            }
        }
        // only melter door open
        else if (!bonsaiSpreading && !janitorSpreading && !corridorSpreading && mfSpreading && melterSpreading)
        {
            if (mainFacilityLobbyOxygen > 0 || melterRoomOxygen > 0)
            {
                combinedOxygen = mainFacilityLobbyOxygen + melterRoomOxygen;
                targetOxygenSpreadLevel = combinedOxygen / amountOfRooms;
                //the spreadspeed is the room's factorial divided by the mean of the other connected rooms
                oxygenSpreadSpeedMFLobby = mainHallLobbyRoomSizeFactorial /
                    (melterRoomSizeFactorial / (amountOfRooms - 1));                
                oxygenSpreadSpeedMelter = melterRoomSizeFactorial /
                    (mainHallLobbyRoomSizeFactorial / (amountOfRooms - 1));                
                //checks whether increasing or decreasing the oxygen level               
                if (mainFacilityLobbyOxygen < targetOxygenSpreadLevel)
                {
                    mainFacilityLobbyOxygen += oxygenSpreadSpeedMFLobby;
                }
                else
                {
                    mainFacilityLobbyOxygen -= oxygenSpreadSpeedMFLobby;
                }
                if (melterRoomOxygen < targetOxygenSpreadLevel)
                {
                    melterRoomOxygen += oxygenSpreadSpeedMelter;
                }
                else
                {
                    melterRoomOxygen -= oxygenSpreadSpeedMelter;
                }
            }
        }
        // only janitor door open
        else if (!bonsaiSpreading && janitorSpreading && corridorSpreading && !mfSpreading && !melterSpreading)
        {
            if (CorridorOxygen > 0 || janitorRoomOxygen > 0)
            {
                combinedOxygen = CorridorOxygen + janitorRoomOxygen;
                targetOxygenSpreadLevel = combinedOxygen / amountOfRooms;
                //the spreadspeed is the room's factorial divided by the mean of the other connected rooms               
                oxygenSpreadSpeedJanitor = janitorRoomSizeFactorial /
                    (maintenanceCorridorRoomSizeFactorial / (amountOfRooms - 1));
                oxygenSpreadSpeedCorridor = maintenanceCorridorRoomSizeFactorial /
                    (janitorRoomSizeFactorial / (amountOfRooms - 1));

                //checks whether increasing or decreasing the oxygen level             
                if (janitorRoomOxygen < targetOxygenSpreadLevel)
                {
                    janitorRoomOxygen += oxygenSpreadSpeedJanitor;
                }
                else
                {
                    janitorRoomOxygen -= oxygenSpreadSpeedJanitor;
                }
                if (CorridorOxygen < targetOxygenSpreadLevel)
                {
                    CorridorOxygen += oxygenSpreadSpeedCorridor;
                }
                else
                {
                    CorridorOxygen -= oxygenSpreadSpeedCorridor;
                }               
            }
        }
        // only bonsai door open
        else if (bonsaiSpreading && !janitorSpreading && corridorSpreading && !mfSpreading && !melterSpreading)
        {
            if (bonsaiRoomOxygen > 0 || CorridorOxygen > 0)
            {
                combinedOxygen = bonsaiRoomOxygen + CorridorOxygen;
                targetOxygenSpreadLevel = combinedOxygen / amountOfRooms;
                //the spreadspeed is the room's factorial divided by the mean of the other connected rooms               
                oxygenSpreadSpeedBonsai = bonsaiRoomSizeFactorial /
                    (maintenanceCorridorRoomSizeFactorial / (amountOfRooms - 1));               
                oxygenSpreadSpeedCorridor = maintenanceCorridorRoomSizeFactorial /
                    (bonsaiRoomSizeFactorial / (amountOfRooms - 1));
                //checks whether increasing or decreasing the oxygen level
                if (bonsaiRoomOxygen < targetOxygenSpreadLevel)
                {
                    bonsaiRoomOxygen += oxygenSpreadSpeedBonsai;
                }
                else
                {
                    bonsaiRoomOxygen -= oxygenSpreadSpeedBonsai;
                }                
                if (CorridorOxygen < targetOxygenSpreadLevel)
                {
                    CorridorOxygen += oxygenSpreadSpeedCorridor;
                }
                else
                {
                    CorridorOxygen -= oxygenSpreadSpeedCorridor;
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
        CorridorOxygenDisplay.text = CorridorOxygen.ToString("#.00");

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

        if (CorridorOxygen <= 25)
        {
            CorridorOxygenDisplay.color = Color.red;
        }
        else if (CorridorOxygen > 25 && CorridorOxygen < 50)
        {
            CorridorOxygenDisplay.color = Color.yellow;
        }
        else if (CorridorOxygen >= 50 && CorridorOxygen <= 75)
        {
            CorridorOxygenDisplay.color = Color.green;
        }
        else if (CorridorOxygen > 75)
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
            currentRoomOxygenPercentage = CorridorOxygen;
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
                playerOxygen -= (1 - oxygenLevelIncreasesFactorial) + oxygenLevelStaysFactorial;             
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

    IEnumerator WaitASecond()
    {
        yield return new WaitForSecondsRealtime(1f);
        secondPassed = true;
    }
	
}
