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
            survivalTime = Mathf.Infinity;  
        }
        else if (currentRoomOxygenPercentage <= 75f && currentRoomOxygenPercentage >= 50f)
        {
            currentOxygenLevel = OxygenLevelName.Okay;
            survivalTime = 120f;
        }
        else if (currentRoomOxygenPercentage < 50f && currentRoomOxygenPercentage > 25f)
        {
            currentOxygenLevel = OxygenLevelName.Alarming;
            survivalTime = 60f;
        }
        else if (currentRoomOxygenPercentage < 25f)
        {
            currentOxygenLevel = OxygenLevelName.Deadly;
            survivalTime = 30f;
        }
    }

    private void OxygenLevelChanges()
    {
        if (previousRoomOxygenPercentage != currentRoomOxygenPercentage)
        {
            if (currentRoomOxygenPercentage < previousRoomOxygenPercentage)
            {
                playerOxygen -= 0.02f * survivalTime; 
            }
            else if (currentRoomOxygenPercentage > previousRoomOxygenPercentage)
            {
                playerOxygen += 0.02f * survivalTime;
            }
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
