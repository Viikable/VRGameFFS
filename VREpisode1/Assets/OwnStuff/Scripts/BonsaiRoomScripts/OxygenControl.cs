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

    [Tooltip("Tells how quickly the oxygen divides itself between rooms when a door is opened to another space")]
    private float oxygenSpreadSpeed;

    [Tooltip("Tells the amount of oxygen the player currently has remaining")]
    private float playerOxygen;

    [Tooltip("Shows whether it is time to call the checkFunctions or not (second passed or not)")]
    private bool secondPassed;

    [Tooltip("Tells the amount of oxygen in MF lobby.")]
    private float mainFacilityLobbyOxygen;

    [Tooltip("Tells the amount of oxygen in MF Bridge.")]
    private float mainFacilityBridgeOxygen;

    [Tooltip("Tells the amount of oxygen in Bonsai Room.")]
    private float bonsaiRoomOxygen;

    [Tooltip("Tells the amount of oxygen in Janitor Room.")]
    private float janitorRoomOxygen;

    [Tooltip("Tells the amount of oxygen in Maintenance Corridor.")]
    private float maintenanceCorridorOxygen;

    [Tooltip("Tells the amount of oxygen in Melter Room.")]
    private float melterRoomOxygen;

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
        oxygenSpreadSpeed = 0.02f;
        currentOxygenLevel = OxygenLevelName.Safe;
        playerOxygen = 120f;
        currentRoomOxygenPercentage = 100;
        previousRoomOxygenPercentage = 100;
        secondPassed = true;

        mainFacilityBridgeOxygen = 0f;
        mainFacilityLobbyOxygen = 0f;
        bonsaiRoomOxygen = 0f;
        janitorRoomOxygen = 0f;
        maintenanceCorridorOxygen = 0f;
        melterRoomOxygen = 0f;
    }


    private void Update()
    {
        //only updates each second 
        if (secondPassed)
        {
            secondPassed = false;
            CheckCurrentRoomOxygenPercentage();
            CheckCurrentOxygenLevelName();
            OxygenLevelChanges();
            StartCoroutine("WaitASecond");
        }
    }
    //This method will be called from the Bonsai oxygen Machine when setting the new oxygen level
    public void SetOxygenLevels(Color firstLight, Color secondLight, Color thirdLight, Color fourthLight)
    {
        // if all lights are green for example, which means MF lobby gets 80% oxygen
        if (firstLight == Color.green && secondLight == Color.green && thirdLight == Color.green && fourthLight == Color.green)
        {
            mainFacilityLobbyOxygen = 80f;

            mainFacilityBridgeOxygen = 0f;          
            bonsaiRoomOxygen = 0f;
            janitorRoomOxygen = 0f;
            maintenanceCorridorOxygen = 0f;
            melterRoomOxygen = 0f;
        }
    }


    private void CheckCurrentRoomOxygenPercentage()
    {
        //to be able to compare the changes in the oxygen level
        previousRoomOxygenPercentage = currentRoomOxygenPercentage;
        //check player's current location and then the oxygen in that location, doors will help in this. Register player moving through doors. Collider after door, middle space own detection

    }

	private void CheckCurrentOxygenLevelName()
    {
        //to be able to start the indicators when oxygen level changes
        previousOxygenLevel = currentOxygenLevel;

        if (currentRoomOxygenPercentage > 75f)
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
    private void OxygenLevelChanges()
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
