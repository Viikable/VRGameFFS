using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class OxygenPanel : MonoBehaviour {

    //This script is attached to the oxygen panel which contains the buttons for switching the lamp colours for the bonsai

    private OxygenControl OxygenController;

    [Header("Oxygen lamp buttons")]

    public Button GreenButton;      //MF
    public Button MagentaButton;  //Janitor
    public Button CyanButton;  // Corridor
    public Button YellowButton;  // Bonsai
    public Button RedButton;   // Melter
    public Button BlueButton;  // Bridge

    public Button ClockWiseButton;       //these rotate the selection of lamps
    public Button CounterClockWiseButton;

    private Color[] LampColours;

    [SerializeField]
    [Tooltip("Ranges from 1-4, denotes which lamp's colour can be changed at the moment.")]
    private int currentlySelectedLamp;

    [Header("Oxygen lamps and colours")]

    public Light FirstLamp;
    public Light SecondLamp;
    public Light ThirdLamp;
    public Light FourthLamp;

    public Animator SelectedLampIndicator;

    public Material FirstLampBeam;
    public Material SecondLampBeam;
    public Material ThirdLampBeam;
    public Material FourthLampBeam;

    public Color LampGreen;
    public Color LampMagenta;
    public Color LampCyan;
    public Color LampYellow;
    public Color LampRed;
    public Color LampBlue;

    [Header("Booleans")]

    public bool lampJustChanged;

    void Start ()
    {
        OxygenController = GameObject.Find("OxygenDisplays").GetComponent<OxygenControl>();

        //buttons

        GreenButton = GameObject.Find("BONSAI_ROOM/OxygenPanel/OxygenGreenButton").GetComponentInChildren<Button>();
        MagentaButton = GameObject.Find("BONSAI_ROOM/OxygenPanel/OxygenMagentaButton").GetComponentInChildren<Button>();
        CyanButton = GameObject.Find("BONSAI_ROOM/OxygenPanel/OxygenCyanButton").GetComponentInChildren<Button>();
        YellowButton = GameObject.Find("BONSAI_ROOM/OxygenPanel/OxygenYellowButton").GetComponentInChildren<Button>();
        RedButton = GameObject.Find("BONSAI_ROOM/OxygenPanel/OxygenRedButton").GetComponentInChildren<Button>();
        BlueButton = GameObject.Find("BONSAI_ROOM/OxygenPanel/OxygenBlueButton").GetComponentInChildren<Button>();

        ClockWiseButton = GameObject.Find("BONSAI_ROOM/OxygenPanel/OxygenClockWiseButton").GetComponentInChildren<Button>();
        CounterClockWiseButton = GameObject.Find("BONSAI_ROOM/OxygenPanel/OxygenCounterClockWiseButton").GetComponentInChildren<Button>();

        LampColours = new Color[4];

        //initial oxygen state here
        LampColours[0] = Color.yellow;
        LampColours[1] = Color.red;
        LampColours[2] = Color.green;
        LampColours[3] = Color.blue;

        currentlySelectedLamp = 1;

        //oxygen lamps and colours

        FirstLamp = GameObject.Find("BONSAI_ROOM/BonsaiLamps/FirstLamp").GetComponent<Light>();
        SecondLamp = GameObject.Find("BONSAI_ROOM/BonsaiLamps/SecondLamp").GetComponent<Light>();
        ThirdLamp = GameObject.Find("BONSAI_ROOM/BonsaiLamps/ThirdLamp").GetComponent<Light>();
        FourthLamp = GameObject.Find("BONSAI_ROOM/BonsaiLamps/FourthLamp").GetComponent<Light>();


        // shows on the panel on the side which lamp is selected currently

        SelectedLampIndicator = GameObject.Find("BONSAI_ROOM/OxygenPanel/SelectedLampIndicators").GetComponent<Animator>();

        FirstLampBeam = GameObject.Find("BONSAI_ROOM/OxygenPanel/SelectedLampIndicators/FirstLampBeam").GetComponent<MeshRenderer>().material;
        SecondLampBeam = GameObject.Find("BONSAI_ROOM/OxygenPanel/SelectedLampIndicators/SecondLampBeam").GetComponent<MeshRenderer>().material;
        ThirdLampBeam = GameObject.Find("BONSAI_ROOM/OxygenPanel/SelectedLampIndicators/ThirdLampBeam").GetComponent<MeshRenderer>().material;
        FourthLampBeam = GameObject.Find("BONSAI_ROOM/OxygenPanel/SelectedLampIndicators/FourthLampBeam").GetComponent<MeshRenderer>().material;

        LampGreen = GameObject.Find("BONSAI_ROOM/LampColours/LampGreen").GetComponent<MeshRenderer>().material.color;
        LampMagenta = GameObject.Find("BONSAI_ROOM/LampColours/LampMagenta").GetComponent<MeshRenderer>().material.color;
        LampCyan = GameObject.Find("BONSAI_ROOM/LampColours/LampCyan").GetComponent<MeshRenderer>().material.color;
        LampYellow = GameObject.Find("BONSAI_ROOM/LampColours/LampYellow").GetComponent<MeshRenderer>().material.color;
        LampRed = GameObject.Find("BONSAI_ROOM/LampColours/LampRed").GetComponent<MeshRenderer>().material.color;
        LampBlue = GameObject.Find("BONSAI_ROOM/LampColours/LampBlue").GetComponent<MeshRenderer>().material.color;

        //initialize lamp beams here
        FirstLampBeam.color = LampYellow;
        SecondLampBeam.color = LampRed;
        ThirdLampBeam.color = LampGreen;
        FourthLampBeam.color = LampMagenta;

        //booleans

        lampJustChanged = false;
    }
	
	void Update ()
    {
        CheckForSelectedLamp();      
        CheckForLampColours();
	}

    private void CheckForSelectedLamp()
    {
        if (ClockWiseButton.isPressedDown && !lampJustChanged)
        {
            if (currentlySelectedLamp == 4)
            {
                currentlySelectedLamp = 1;
            }
            else
            {
                currentlySelectedLamp++;
            }
            lampJustChanged = true;
            IndicateLampSelection();
            StartCoroutine(LampChangeWaitTime());
        }
        else if (CounterClockWiseButton.isPressedDown && !lampJustChanged)
        {
            if (currentlySelectedLamp == 1)
            {
                currentlySelectedLamp = 4;
            }
            else
            {
                currentlySelectedLamp--;
            }
            lampJustChanged = true;
            IndicateLampSelection();
            StartCoroutine(LampChangeWaitTime());
        }
    }

    //indicates which lamp's colour will be changed by the next colour input
    private void IndicateLampSelection()
    {
        if (currentlySelectedLamp == 1)
        {
            SelectedLampIndicator.SetInteger("LampNumber", 1);           
        }
        else if (currentlySelectedLamp == 2)
        {
            SelectedLampIndicator.SetInteger("LampNumber", 2);
        }
        else if (currentlySelectedLamp == 3)
        {
            SelectedLampIndicator.SetInteger("LampNumber", 3);
        }
        else if (currentlySelectedLamp == 4)
        {
            SelectedLampIndicator.SetInteger("LampNumber", 4);
        }
    }

    private void CheckForLampColours()
    {
        //green
        if (GreenButton.isPressedDown && !lampJustChanged)
        {
            if(currentlySelectedLamp == 1)
            {
                FirstLamp.color = LampGreen;
                FirstLampBeam.color = LampGreen;
                LampColours[0] = Color.green;
            }
            else if (currentlySelectedLamp == 2)
            {
                SecondLamp.color = LampGreen;
                SecondLampBeam.color = LampGreen;
                LampColours[1] = Color.green;
            }
            else if (currentlySelectedLamp == 3)
            {
                ThirdLamp.color = LampGreen;
                ThirdLampBeam.color = LampGreen;
                LampColours[2] = Color.green;
            }
            else if (currentlySelectedLamp == 4)
            {
                FourthLamp.color = LampGreen;
                FourthLampBeam.color = LampGreen;
                LampColours[3] = Color.green;
            }
            lampJustChanged = true;
            StartCoroutine(LampChangeWaitTime());
        }
        //magenta
        else if (MagentaButton.isPressedDown && !lampJustChanged)
        {
            if (currentlySelectedLamp == 1)
            {
                FirstLamp.color = LampMagenta;
                FirstLampBeam.color = LampMagenta;
                LampColours[0] = Color.magenta;
            }
            else if (currentlySelectedLamp == 2)
            {
                SecondLamp.color = LampMagenta;
                SecondLampBeam.color = LampMagenta;
                LampColours[1] = Color.magenta;
            }
            else if (currentlySelectedLamp == 3)
            {
                ThirdLamp.color = LampMagenta;
                ThirdLampBeam.color = LampMagenta;
                LampColours[2] = Color.magenta;
            }
            else if (currentlySelectedLamp == 4)
            {
                FourthLamp.color = LampMagenta;
                FourthLampBeam.color = LampMagenta;
                LampColours[3] = Color.magenta;
            }
            lampJustChanged = true;
            StartCoroutine(LampChangeWaitTime());
        }
        else if (CyanButton.isPressedDown && !lampJustChanged)
        {
            if (currentlySelectedLamp == 1)
            {
                FirstLamp.color = LampCyan;
                FirstLampBeam.color = LampCyan;
                LampColours[0] = Color.cyan;
            }
            else if (currentlySelectedLamp == 2)
            {
                SecondLamp.color = LampCyan;
                SecondLampBeam.color = LampCyan;
                LampColours[1] = Color.cyan;
            }
            else if (currentlySelectedLamp == 3)
            {
                ThirdLamp.color = LampCyan;
                ThirdLampBeam.color = LampCyan;
                LampColours[2] = Color.cyan;
            }
            else if (currentlySelectedLamp == 4)
            {
                FourthLamp.color = LampCyan;
                FourthLampBeam.color = LampCyan;
                LampColours[3] = Color.cyan;
            }
            lampJustChanged = true;
            StartCoroutine(LampChangeWaitTime());
        }
        else if (YellowButton.isPressedDown && !lampJustChanged)
        {
            if (currentlySelectedLamp == 1)
            {
                FirstLamp.color = LampYellow;
                FirstLampBeam.color = LampYellow;
                LampColours[0] = Color.yellow;
            }
            else if (currentlySelectedLamp == 2)
            {
                SecondLamp.color = LampYellow;
                SecondLampBeam.color = LampYellow;
                LampColours[1] = Color.yellow;
            }
            else if (currentlySelectedLamp == 3)
            {
                ThirdLamp.color = LampYellow;
                ThirdLampBeam.color = LampYellow;
                LampColours[2] = Color.yellow;
            }
            else if (currentlySelectedLamp == 4)
            {
                FourthLamp.color = LampYellow;
                FourthLampBeam.color = LampYellow;
                LampColours[3] = Color.yellow;
            }
            lampJustChanged = true;
            StartCoroutine(LampChangeWaitTime());
        }
        else if (RedButton.isPressedDown && !lampJustChanged)
        {
            if (currentlySelectedLamp == 1)
            {
                FirstLamp.color = LampRed;
                FirstLampBeam.color = LampRed;
                LampColours[0] = Color.red;
            }
            else if (currentlySelectedLamp == 2)
            {
                SecondLamp.color = LampRed;
                SecondLampBeam.color = LampRed;
                LampColours[1] = Color.red;
            }
            else if (currentlySelectedLamp == 3)
            {
                ThirdLamp.color = LampRed;
                ThirdLampBeam.color = LampRed;
                LampColours[2] = Color.red;
            }
            else if (currentlySelectedLamp == 4)
            {
                FourthLamp.color = LampRed;
                FourthLampBeam.color = LampRed;
                LampColours[3] = Color.red;
            }
            lampJustChanged = true;
            StartCoroutine(LampChangeWaitTime());
        }
        else if (BlueButton.isPressedDown && !lampJustChanged)
        {
            if (currentlySelectedLamp == 1)
            {
                FirstLamp.color = LampBlue;
                FirstLampBeam.color = LampBlue;
                LampColours[0] = Color.blue;
            }
            else if (currentlySelectedLamp == 2)
            {
                SecondLamp.color = LampBlue;
                SecondLampBeam.color = LampBlue;
                LampColours[1] = Color.blue;
            }
            else if (currentlySelectedLamp == 3)
            {
                ThirdLamp.color = LampBlue;
                ThirdLampBeam.color = LampBlue;
                LampColours[2] = Color.blue;
            }
            else if (currentlySelectedLamp == 4)
            {
                FourthLamp.color = LampBlue;
                FourthLampBeam.color = LampBlue;
                LampColours[3] = Color.blue;
            }
            lampJustChanged = true;
            StartCoroutine(LampChangeWaitTime());
        }

        //checking in case something changed sending the new colour code

        if (lampJustChanged)
        {
            OxygenController.SetOxygenLevels(LampColours);
        }
    }

    IEnumerator LampChangeWaitTime()
    {
        yield return new WaitForSecondsRealtime(0.75f);
        lampJustChanged = false;
    }
}
