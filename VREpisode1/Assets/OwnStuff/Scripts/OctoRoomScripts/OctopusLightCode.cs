using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables.PhysicsBased;

public class OctopusLightCode : MonoBehaviour
{
    VRTK_PhysicsPusher RedLight;
    VRTK_PhysicsPusher GreenLight;
    VRTK_PhysicsPusher CyanLight;
    VRTK_PhysicsPusher YellowLight;
    VRTK_PhysicsPusher OctopusAttention;

    [Tooltip("This lights the attention button once a code has been entered")]
    Light AttentionLight;

    [Tooltip("This lights the red button once a red button has been pressed")]
    Light RedLightSource;

    [Tooltip("This lights the red button once a green button has been pressed")]
    Light GreenLightSource;

    [Tooltip("This lights the red button once a cyan button has been pressed")]
    Light CyanLightSource;

    [Tooltip("This lights the red button once a yellow button has been pressed")]
    Light YellowLightSource;

    [Tooltip("This shows how many colours have been entered into the combination, ranges from 0-4")]
    int combinationNumber;

    [Tooltip("This is a list containing all the currently stored colour names in a combination")]
    string[] colourCode;

    [Tooltip("This describes the object where the marker is attatched to atm")]
    string currentMarkedLocation;

    bool codeEntered;

    bool buttonRegistering;

    [Tooltip("Shows the player the colour which has been entered first into the code")]
    GameObject CodeCube1;

    [Tooltip("Shows the player the colour which has been entered second into the code")]
    GameObject CodeCube2;

    [Tooltip("Shows the player the colour which has been entered third into the code")]
    GameObject CodeCube3;

    [Tooltip("Shows the player the colour which has been entered fourth into the code")]
    GameObject CodeCube4;

    [Tooltip("Snaps to objects so that the Octopus recognizes we want to apply the code with them or get a code from them")]
    GameObject Marker;

    void Start()
    {
        RedLight = transform.Find("RedLight").GetChild(0).GetComponent<VRTK_PhysicsPusher>();
        GreenLight = transform.Find("GreenLight").GetChild(0).GetComponent<VRTK_PhysicsPusher>();
        CyanLight = transform.Find("CyanLight").GetChild(0).GetComponent<VRTK_PhysicsPusher>();
        YellowLight = transform.Find("YellowLight").GetChild(0).GetComponent<VRTK_PhysicsPusher>();
        OctopusAttention = transform.Find("OctopusAttention").GetChild(0).GetComponent<VRTK_PhysicsPusher>();
        combinationNumber = 0;
        colourCode = new string[4];
        currentMarkedLocation = null;
        codeEntered = false;
        AttentionLight = transform.Find("AttentionLight").GetComponent<Light>();
        RedLightSource = transform.Find("RedLightSource").GetComponent<Light>();
        YellowLightSource = transform.Find("YellowLightSource").GetComponent<Light>();
        GreenLightSource = transform.Find("GreenLightSource").GetComponent<Light>();
        CyanLightSource = transform.Find("CyanLightSource").GetComponent<Light>();
        buttonRegistering = false;
        CodeCube1 = transform.Find("CodeCube1").gameObject;
        CodeCube2 = transform.Find("CodeCube2").gameObject;
        CodeCube3 = transform.Find("CodeCube3").gameObject;
        CodeCube4 = transform.Find("CodeCube4").gameObject;
        Marker = GameObject.Find("Marker");
    }
    void Update()
    {

        if (RedLight.AtMaxLimit() && combinationNumber <= 3 && !codeEntered && !buttonRegistering)            //checking what colour combination has been entered
        {
            colourCode[combinationNumber] = "Red";
            combinationNumber++;
            buttonRegistering = true;
            RedLightSource.enabled = true;
            if (combinationNumber == 1)
            {
                CodeCube1.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            else if (combinationNumber == 2)
            {
                CodeCube2.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            else if (combinationNumber == 3)
            {
                CodeCube3.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            else
            {
                CodeCube4.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            StartCoroutine("WaitForPress");
        }
        if (GreenLight.AtMaxLimit() && combinationNumber <= 3 && !codeEntered && !buttonRegistering)
        {
            colourCode[combinationNumber] = "Green";
            combinationNumber++;
            buttonRegistering = true;
            GreenLightSource.enabled = true;
            if (combinationNumber == 1)
            {
                CodeCube1.GetComponent<MeshRenderer>().material.color = Color.green;
            }
            else if (combinationNumber == 2)
            {
                CodeCube2.GetComponent<MeshRenderer>().material.color = Color.green;
            }
            else if (combinationNumber == 3)
            {
                CodeCube3.GetComponent<MeshRenderer>().material.color = Color.green;
            }
            else
            {
                CodeCube4.GetComponent<MeshRenderer>().material.color = Color.green;
            }
            StartCoroutine("WaitForPress");
        }
        if (YellowLight.AtMaxLimit() && combinationNumber <= 3 && !codeEntered && !buttonRegistering)
        {
            colourCode[combinationNumber] = "Yellow";
            combinationNumber++;
            buttonRegistering = true;
            YellowLightSource.enabled = true;
            if (combinationNumber == 1)
            {
                CodeCube1.GetComponent<MeshRenderer>().material.color = Color.yellow;
            }
            else if (combinationNumber == 2)
            {
                CodeCube2.GetComponent<MeshRenderer>().material.color = Color.yellow;
            }
            else if (combinationNumber == 3)
            {
                CodeCube3.GetComponent<MeshRenderer>().material.color = Color.yellow;
            }
            else
            {
                CodeCube4.GetComponent<MeshRenderer>().material.color = Color.yellow;
            }
            StartCoroutine("WaitForPress");
        }
        if (CyanLight.AtMaxLimit() && combinationNumber <= 3 && !codeEntered && !buttonRegistering)
        {
            colourCode[combinationNumber] = "Cyan";
            combinationNumber++;
            buttonRegistering = true;
            CyanLightSource.enabled = true;
            if (combinationNumber == 1)
            {
                CodeCube1.GetComponent<MeshRenderer>().material.color = Color.cyan;
            }
            else if (combinationNumber == 2)
            {
                CodeCube2.GetComponent<MeshRenderer>().material.color = Color.cyan;
            }
            else if (combinationNumber == 3)
            {
                CodeCube3.GetComponent<MeshRenderer>().material.color = Color.cyan;
            }
            else
            {
                CodeCube4.GetComponent<MeshRenderer>().material.color = Color.cyan;
            }
            StartCoroutine("WaitForPress");
        }
        if (combinationNumber == 4 && !codeEntered)
        {
            AttentionLight.enabled = true;
            OctopusAttention.stayPressed = true;
            CheckCodeValidity();
        }
    }
    IEnumerator WaitForPress()
    {
        //Waits for the button to register being pressed and lifted up so it's only registered once
        yield return new WaitForSecondsRealtime(1);
        buttonRegistering = false;
        RedLightSource.enabled = false;
        GreenLightSource.enabled = false;
        YellowLightSource.enabled = false;
        CyanLightSource.enabled = false;
    }
    public void ColourReset()
    {
        CodeCube1.GetComponent<MeshRenderer>().material.color = Color.grey;
        CodeCube2.GetComponent<MeshRenderer>().material.color = Color.grey;
        CodeCube3.GetComponent<MeshRenderer>().material.color = Color.grey;
        CodeCube4.GetComponent<MeshRenderer>().material.color = Color.grey;
        codeEntered = false;
    }

    public void CheckCodeValidity()
    {
        if (OctopusAttention.AtMaxLimit() && OctopusAttention.stayPressed)
        {
            if (colourCode[0] == "Red")
            {
                if (colourCode[1] == "Green" && colourCode[2] == "Green" && colourCode[3] == "Green")
                {
                    Debug.Log("CLOSE");
                    //This word is CLOSE
                    //here we can write what we can close and what happens if we type close and then ask the octopus about it
                    if (currentMarkedLocation == "OpenBox" /* && the OpenBox is on the research table snapped */)
                    {
                        //we play the animation which closes the box like a hologram on the table separate from the actual box
                    }
                    combinationNumber = 0;
                    AttentionLight.enabled = false;
                    codeEntered = true;
                    OctopusAttention.stayPressed = false;
                    //signals the player somehow that marker isn't in the right place or that the object needs to be on the table
                }
                else if (colourCode[1] == "Cyan" && colourCode[2] == "Green" && colourCode[3] == "Green")
                {
                    //This word is OPEN, this is the KEY word to open the elevator
                    if (currentMarkedLocation == "Elevator")
                    {
                        //Gives the code to unlock the elevator panel to the player
                    }
                    combinationNumber = 0;
                    AttentionLight.enabled = false;
                    codeEntered = true;
                    OctopusAttention.stayPressed = false;
                    //signals the player somehow that marker isn't in the right place
                }
                else
                {
                    //Nothing happens/Octopus doesn't understand
                    combinationNumber = 0;
                    AttentionLight.enabled = false;
                    codeEntered = true;
                    OctopusAttention.stayPressed = false;
                }
            }
            else if (colourCode[0] == "Cyan")
            {
                if (colourCode[1] == "Red" && colourCode[2] == "Yellow" && colourCode[3] == "Green")
                {
                    //This one is MUTE, which the player can see at the start paper, it is used to shut down the music player at least
                    if (currentMarkedLocation == "MusicPlayer")
                    {
                        //Mutes the music player
                    }
                    combinationNumber = 0;
                    AttentionLight.enabled = false;
                    codeEntered = true;
                    OctopusAttention.stayPressed = false;
                    //signals the player somehow that marker isn't in the right place
                }
                else if (colourCode[1] == "Yellow" && colourCode[2] == "Red" && colourCode[3] == "Green")
                {
                    //This one is PLAY and it can be used to enable the music player, as long as it has the marker on it first
                    if (currentMarkedLocation == "MusicPlayer")
                    {
                        //Starts the music player
                    }
                    combinationNumber = 0;
                    AttentionLight.enabled = false;
                    codeEntered = true;
                    OctopusAttention.stayPressed = false;
                    //signals the player somehow that marker isn't in the right place
                }
                else
                {
                    //Nothing happens/Octopus doesn't understand
                    combinationNumber = 0;
                    AttentionLight.enabled = false;
                    codeEntered = true;
                    OctopusAttention.stayPressed = false;
                }
            }
            else if (colourCode[0] == "Yellow")
            {
                if (colourCode[1] == "Red" && colourCode[2] == "Green" && colourCode[3] == "Yellow")
                {
                    //This one is LIFT, used only with the research objects most likely
                    combinationNumber = 0;
                    AttentionLight.enabled = false;
                    codeEntered = true;
                    OctopusAttention.stayPressed = false;
                }
                else if (colourCode[1] == "Yellow" && colourCode[2] == "Green" && colourCode[3] == "Red")
                {
                    //This one is LOWER, also used only with research objects
                    combinationNumber = 0;
                    AttentionLight.enabled = false;
                    codeEntered = true;
                    OctopusAttention.stayPressed = false;
                }
                else
                {
                    combinationNumber = 0;
                    AttentionLight.enabled = false;
                    codeEntered = true;
                    OctopusAttention.stayPressed = false;
                }
            }
            else if (colourCode[0] == "Green")
            {
                if (colourCode[1] == "Red" && colourCode[2] == "Red" && colourCode[3] == "Red")
                {
                    // This one is ON and that is also known at the start paper, 
                    // it can be used to turn on some research items and the monitor
                    combinationNumber = 0;
                    AttentionLight.enabled = false;
                    codeEntered = true;
                    OctopusAttention.stayPressed = false;
                }
                else if (colourCode[1] == "Yellow" && colourCode[2] == "Yellow" && colourCode[3] == "Yellow")
                {
                    //This one is OFF, and it is used to turn the magnetic gate off and some research items like the LAMP can give this verb
                    if (currentMarkedLocation == "MagneticGate")
                    {
                        //turn the magnetic gate off
                    }
                    combinationNumber = 0;
                    AttentionLight.enabled = false;
                    codeEntered = true;
                    OctopusAttention.stayPressed = false;
                }
                else
                {
                    combinationNumber = 0;
                    AttentionLight.enabled = false;
                    codeEntered = true;
                    OctopusAttention.stayPressed = false;
                }
            }
            ColourReset();
        }
        else
        {
            //attention button hasn't been pressed
            return;
        }
    }
}

