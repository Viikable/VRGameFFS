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

    [Tooltip("Tells the base amount of time respective to the oxygen level as a default")]
    float survivalTime;

    [Tooltip("The factorial for a room which tells how much more the player's oxygen decreases per second when the oxygen level is constantly lowering. This value is different for each oxygen level name.")]
    float oxygenLevelLowersFactorial;

    [Tooltip("The factorial for a room which tells how much more the player's oxygen increases per second when the oxygen level is constantly lowering. This value is different for each oxygen level name.")]
    float oxygenLevelIncreasesFactorial;

    [Tooltip("The speed of oxygen percentage increasing in the room based on the room size")]
    float accelerationSpeed;

    [Tooltip("Tells how quickly the oxygen divides itself between rooms when a door is opened to another space")]
    float oxygenSpreadSpeed;

    [Tooltip("Tells the amount of oxygen the player currently has remaining")]
    float playerOxygen;

    [Tooltip("Shows whether it is time to call the checkFunctions or not (second passed or not)")]
    bool secondPassed;

   //these are the four possible oxygen levels in the room
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
        playerOxygen = Mathf.Infinity;
        currentRoomOxygenPercentage = 100;
        previousRoomOxygenPercentage = 100;
        secondPassed = true;
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
            currentOxygenLevel = OxygenLevelName.Safe;
            survivalTime = 120f;
            oxygenLevelLowersFactorial = 0f;
            oxygenLevelIncreasesFactorial = 0f;
        }
        else if (currentRoomOxygenPercentage <= 75f && currentRoomOxygenPercentage >= 50f)
        {
            currentOxygenLevel = OxygenLevelName.Okay;         
            oxygenLevelLowersFactorial = 0.25f;
            oxygenLevelIncreasesFactorial = 0.75f;
        }
        else if (currentRoomOxygenPercentage < 50f && currentRoomOxygenPercentage > 25f)
        {
            currentOxygenLevel = OxygenLevelName.Alarming;           
            oxygenLevelLowersFactorial = 0.5f;
            oxygenLevelIncreasesFactorial = 0.5f;
        }
        else if (currentRoomOxygenPercentage <= 25f)
        {
            currentOxygenLevel = OxygenLevelName.Deadly;            
            oxygenLevelLowersFactorial = 0.75f;
            oxygenLevelIncreasesFactorial = 0.25f;
        }
    }
    // the changing speed of oxygen levels only affects how quickly the OxygenLevelName changes, the individual changing speed does not affect otherwise to the player's remaining oxygen
    private void OxygenLevelChanges()
    {
        //player's oxygen changing speed if oxygen percentage in the room is currently changing
        if (previousRoomOxygenPercentage != currentRoomOxygenPercentage && currentOxygenLevel != OxygenLevelName.Safe)
        {
            if (currentRoomOxygenPercentage < previousRoomOxygenPercentage)
            {
                // take into account the room size
                playerOxygen -= 1 + oxygenLevelLowersFactorial;
            }
            else if (currentRoomOxygenPercentage > previousRoomOxygenPercentage)
            {               
                playerOxygen -= 1 - oxygenLevelIncreasesFactorial;             
            }
        }
        //here we check the player's oxygen changing speed if the oxygen percentage in the room is not changing currently
        else if (previousRoomOxygenPercentage == currentRoomOxygenPercentage && currentOxygenLevel != OxygenLevelName.Safe)
        {

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
