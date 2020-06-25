using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenControl : MonoBehaviour {

    [Tooltip("Tells how much oxygen there is in the current room as a percentage right now")]
    int currentRoomOxygenPercentage;

    [Tooltip("Tells how much oxygen there is in the current room as a percentage a second ago")]
    int previousRoomOxygenPercentage;

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
    private int oxygenSpreadSpeedBonsai;

    [Tooltip("Tells how quickly the oxygen amount is changing in MF Lobby (and whether it is positive or negative change")]
    private int oxygenSpreadSpeedMFLobby;

    [Tooltip("Tells how quickly the oxygen amount is changing in MF Bridge (and whether it is positive or negative change")]
    private int oxygenSpreadSpeedMFBridge;

    [Tooltip("Tells how quickly the oxygen amount is changing in Janitor Room (and whether it is positive or negative change")]
    private int oxygenSpreadSpeedJanitor;

    [Tooltip("Tells how quickly the oxygen amount is changing in Maintenance Corridor (and whether it is positive or negative change")]
    private int oxygenSpreadSpeedCorridor;

    [Tooltip("Tells how quickly the oxygen amount is changing in Melter Room (and whether it is positive or negative change")]
    private int oxygenSpreadSpeedMelter;

    [Tooltip("Tells the amount of oxygen the player currently has remaining")]
    private float playerOxygen;

    [Tooltip("Shows whether it is time to call the checkFunctions or not (second passed or not)")]
    private bool secondPassed;

    [Tooltip("Tells the amount of oxygen in MF lobby.")]
    private int mainFacilityLobbyOxygen;

    [Tooltip("Tells the amount of oxygen in MF Bridge.")]
    private int mainFacilityBridgeOxygen;

    [Tooltip("Tells the amount of oxygen in Bonsai Room.")]
    private int bonsaiRoomOxygen;

    [Tooltip("Tells the amount of oxygen in Janitor Room.")]
    private int janitorRoomOxygen;

    [Tooltip("Tells the amount of oxygen in Maintenance Corridor.")]
    private int maintenanceCorridorOxygen;

    [Tooltip("Tells the amount of oxygen in Melter Room.")]
    private int melterRoomOxygen;

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

        oxygenSpreadSpeedBonsai = 0;
        oxygenSpreadSpeedCorridor = 0;
        oxygenSpreadSpeedJanitor = 0;
        oxygenSpreadSpeedMelter = 0;
        oxygenSpreadSpeedMFBridge = 0;
        oxygenSpreadSpeedMFLobby = 0;

        playerOxygen = 120f;
        currentRoomOxygenPercentage = 100;
        previousRoomOxygenPercentage = 100;
        secondPassed = true;

        mainFacilityBridgeOxygen = 0;
        mainFacilityLobbyOxygen = 0;
        bonsaiRoomOxygen = 0;
        janitorRoomOxygen = 0;
        maintenanceCorridorOxygen = 0;
        melterRoomOxygen = 0;

        mainHallLobbyRoomSizeFactorial = 2;
        mainHallBridgeRoomSizeFactorial = 10;
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
            maintenanceCorridorOxygen = 0;
            melterRoomOxygen = 0;
        }
    }
    //checks whether doors between rooms are currently open
    private void IsOxygenSpreading()
    {
        //Bonsai and corridor
        if ((fuseBox.corridorToBonsaiDoorOpen || fuseBox.corridorToBonsaiDoorClosing || fuseBox.corridorToBonsaiDoorOpening)
            && (fuseBox.bonsaiToCorridorDoorOpen || fuseBox.bonsaiToCorridorDoorClosing || fuseBox.bonsaiToCorridorDoorOpening))
        {
            OxygenSpreads("Corridor", "Bonsai");
        }       
    }

    private void OxygenSpreads(string spreadingLocation0, string spreadingLocation1, string spreadingLocation2 = null, string spreadingLocation3 = null, string spreadingLocation4 = null)
    {
        if (spreadingLocation0 == "Corridor")
        {
            if (spreadingLocation1 == "Bonsai" && spreadingLocation2 == null)
            {
                // >1 because 1 won't divide between the rooms, try to code min value to be 2 or 0
                if (bonsaiRoomOxygen > 1 || maintenanceCorridorOxygen > 1)
                {
                    oxygenSpreadSpeedBonsai = Mathf.RoundToInt(bonsaiRoomSizeFactorial / maintenanceCorridorRoomSizeFactorial * defaultOxygenSpreadSpeedFactor);
                    oxygenSpreadSpeedCorridor = Mathf.RoundToInt(maintenanceCorridorRoomSizeFactorial / bonsaiRoomSizeFactorial * defaultOxygenSpreadSpeedFactor);
                    if (bonsaiRoomOxygen > maintenanceCorridorOxygen)
                    {                                                                   
                        oxygenSpreadSpeedBonsai = -oxygenSpreadSpeedBonsai;
                    }
                    else if (maintenanceCorridorOxygen > bonsaiRoomOxygen)
                    {
                        oxygenSpreadSpeedCorridor = -oxygenSpreadSpeedCorridor;
                    }
                    else  //if the oxygen levels are the same
                    {
                        oxygenSpreadSpeedBonsai = 0;
                        oxygenSpreadSpeedCorridor = 0;
                    }
                    bonsaiRoomOxygen += oxygenSpreadSpeedBonsai;
                    maintenanceCorridorOxygen += oxygenSpreadSpeedCorridor;
                }
            }
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
    }

    IEnumerator WaitASecond()
    {
        yield return new WaitForSecondsRealtime(1f);
        secondPassed = true;
    }
	
}
