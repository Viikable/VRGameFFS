using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables.PhysicsBased;
using TMPro;

public class OxygenPanel : MonoBehaviour {

    //This script is attached to the oxygen panel which contains the buttons for switching the lamp colours for the bonsai

    private OxygenControl OxygenController;

    [Header("Oxygen lamp buttons")]

    public VRTK_PhysicsPusher GreenButton;      //MF
    public VRTK_PhysicsPusher MagentaButton;  //Janitor
    public VRTK_PhysicsPusher CyanButton;  // Corridor
    public VRTK_PhysicsPusher YellowButton;  // Bonsai
    public VRTK_PhysicsPusher RedButton;   // Melter
    public VRTK_PhysicsPusher BlueButton;  // Bridge

    public VRTK_PhysicsPusher ClockWiseButton;       //these rotate the selection of lamps
    public VRTK_PhysicsPusher CounterClockWiseButton;

    private Color[] LampColours;

    [SerializeField]
    [Tooltip("Ranges from 1-4, denotes which lamp's colour can be changed at the moment.")]
    private int currentlySelectedLamp;

    [Header("Oxygen lamps and colours")]

    public Light FirstLamp;
    public Light SecondLamp;
    public Light ThirdLamp;
    public Light FourthLamp;

    public TextMeshPro SelectedLampIndicator1;
    public TextMeshPro SelectedLampIndicator2;
    public TextMeshPro SelectedLampIndicator3;
    public TextMeshPro SelectedLampIndicator4;

    public Color LampGreen;
    public Color LampMagenta;
    public Color LampBlack;
    public Color LampYellow;
    public Color LampRed;
    public Color LampBlue;

    [Header("Booleans")]

    public bool lampJustChanged;

    void Start ()
    {
        OxygenController = GameObject.Find("OxygenDisplays").GetComponent<OxygenControl>();

        //buttons

        GreenButton = GameObject.Find("BONSAI_ROOM/OxygenPanel/OxygenGreenButton").GetComponentInChildren<VRTK_PhysicsPusher>();
        MagentaButton = GameObject.Find("BONSAI_ROOM/OxygenPanel/OxygenMagentaButton").GetComponentInChildren<VRTK_PhysicsPusher>();
        CyanButton = GameObject.Find("BONSAI_ROOM/OxygenPanel/OxygenCyanButton").GetComponentInChildren<VRTK_PhysicsPusher>();
        YellowButton = GameObject.Find("BONSAI_ROOM/OxygenPanel/OxygenYellowButton").GetComponentInChildren<VRTK_PhysicsPusher>();
        RedButton = GameObject.Find("BONSAI_ROOM/OxygenPanel/OxygenRedButton").GetComponentInChildren<VRTK_PhysicsPusher>();
        BlueButton = GameObject.Find("BONSAI_ROOM/OxygenPanel/OxygenBlueButton").GetComponentInChildren<VRTK_PhysicsPusher>();

        ClockWiseButton = GameObject.Find("BONSAI_ROOM/OxygenPanel/OxygenClockWiseButton").GetComponentInChildren<VRTK_PhysicsPusher>();
        CounterClockWiseButton = GameObject.Find("BONSAI_ROOM/OxygenPanel/OxygenCounterClockWiseButton").GetComponentInChildren<VRTK_PhysicsPusher>();

        LampColours = new Color[4];

        currentlySelectedLamp = 1;

        //oxygen lamps and colours

        FirstLamp = GameObject.Find("BONSAI_ROOM/BonsaiLamps/FirstLamp").GetComponent<Light>();
        SecondLamp = GameObject.Find("BONSAI_ROOM/BonsaiLamps/SecondLamp").GetComponent<Light>();
        ThirdLamp = GameObject.Find("BONSAI_ROOM/BonsaiLamps/ThirdLamp").GetComponent<Light>();
        FourthLamp = GameObject.Find("BONSAI_ROOM/BonsaiLamps/FourthLamp").GetComponent<Light>();


        // shows on the panel on the side which lamp is selected currently

        SelectedLampIndicator1 = GameObject.Find("BONSAI_ROOM/SelectedLampIndicators/SelectedLampIndicator1").GetComponent<TextMeshPro>();
        SelectedLampIndicator2 = GameObject.Find("BONSAI_ROOM/SelectedLampIndicators/SelectedLampIndicator2").GetComponent<TextMeshPro>();
        SelectedLampIndicator3 = GameObject.Find("BONSAI_ROOM/SelectedLampIndicators/SelectedLampIndicator3").GetComponent<TextMeshPro>();
        SelectedLampIndicator4 = GameObject.Find("BONSAI_ROOM/SelectedLampIndicators/SelectedLampIndicator4").GetComponent<TextMeshPro>();

        LampGreen = GameObject.Find("BONSAI_ROOM/LampColours/LampGreen").GetComponent<MeshRenderer>().material.color;
        LampMagenta = GameObject.Find("BONSAI_ROOM/LampColours/LampMagenta").GetComponent<MeshRenderer>().material.color;
        LampBlack = GameObject.Find("BONSAI_ROOM/LampColours/LampCyan").GetComponent<MeshRenderer>().material.color;
        LampYellow = GameObject.Find("BONSAI_ROOM/LampColours/LampYellow").GetComponent<MeshRenderer>().material.color;
        LampRed = GameObject.Find("BONSAI_ROOM/LampColours/LampRed").GetComponent<MeshRenderer>().material.color;
        LampBlue = GameObject.Find("BONSAI_ROOM/LampColours/LampBlue").GetComponent<MeshRenderer>().material.color;

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
        if (ClockWiseButton.AtMaxLimit() && !lampJustChanged)
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
        else if (CounterClockWiseButton.AtMaxLimit() && !lampJustChanged)
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
            SelectedLampIndicator1.color = Color.red;
            SelectedLampIndicator2.color = Color.white;
            SelectedLampIndicator3.color = Color.white;
            SelectedLampIndicator4.color = Color.white;
        }
        else if (currentlySelectedLamp == 2)
        {
            SelectedLampIndicator2.color = Color.red;
            SelectedLampIndicator1.color = Color.white;
            SelectedLampIndicator3.color = Color.white;
            SelectedLampIndicator4.color = Color.white;
        }
        else if (currentlySelectedLamp == 3)
        {
            SelectedLampIndicator3.color = Color.red;
            SelectedLampIndicator1.color = Color.white;
            SelectedLampIndicator2.color = Color.white;
            SelectedLampIndicator4.color = Color.white;
        }
        else if (currentlySelectedLamp == 4)
        {
            SelectedLampIndicator4.color = Color.red;
            SelectedLampIndicator1.color = Color.white;
            SelectedLampIndicator2.color = Color.white;
            SelectedLampIndicator3.color = Color.white;
        }
    }

    private void CheckForLampColours()
    {
        //green
        if (GreenButton.AtMaxLimit() && !lampJustChanged)
        {
            if(currentlySelectedLamp == 1)
            {
                FirstLamp.color = LampGreen;
                LampColours[0] = Color.green;
            }
            else if (currentlySelectedLamp == 2)
            {
                SecondLamp.color = LampGreen;
                LampColours[1] = Color.green;
            }
            else if (currentlySelectedLamp == 3)
            {
                ThirdLamp.color = LampGreen;
                LampColours[2] = Color.green;
            }
            else if (currentlySelectedLamp == 4)
            {
                FourthLamp.color = LampGreen;
                LampColours[3] = Color.green;
            }
            lampJustChanged = true;
            StartCoroutine(LampChangeWaitTime());
        }
        //magenta
        else if (MagentaButton.AtMaxLimit() && !lampJustChanged)
        {
            if (currentlySelectedLamp == 1)
            {
                FirstLamp.color = LampMagenta;
                LampColours[0] = Color.magenta;
            }
            else if (currentlySelectedLamp == 2)
            {
                SecondLamp.color = LampMagenta;
                LampColours[1] = Color.magenta;
            }
            else if (currentlySelectedLamp == 3)
            {
                ThirdLamp.color = LampMagenta;
                LampColours[2] = Color.magenta;
            }
            else if (currentlySelectedLamp == 4)
            {
                FourthLamp.color = LampMagenta;
                LampColours[3] = Color.magenta;
            }
            lampJustChanged = true;
            StartCoroutine(LampChangeWaitTime());
        }
        else if (CyanButton.AtMaxLimit() && !lampJustChanged)
        {
            if (currentlySelectedLamp == 1)
            {
                FirstLamp.color = LampBlack;
                LampColours[0] = Color.cyan;
            }
            else if (currentlySelectedLamp == 2)
            {
                SecondLamp.color = LampBlack;
                LampColours[1] = Color.cyan;
            }
            else if (currentlySelectedLamp == 3)
            {
                ThirdLamp.color = LampBlack;
                LampColours[2] = Color.cyan;
            }
            else if (currentlySelectedLamp == 4)
            {
                FourthLamp.color = LampBlack;
                LampColours[3] = Color.cyan;
            }
            lampJustChanged = true;
            StartCoroutine(LampChangeWaitTime());
        }
        else if (YellowButton.AtMaxLimit() && !lampJustChanged)
        {
            if (currentlySelectedLamp == 1)
            {
                FirstLamp.color = LampYellow;
                LampColours[0] = Color.yellow;
            }
            else if (currentlySelectedLamp == 2)
            {
                SecondLamp.color = LampYellow;
                LampColours[1] = Color.yellow;
            }
            else if (currentlySelectedLamp == 3)
            {
                ThirdLamp.color = LampYellow;
                LampColours[2] = Color.yellow;
            }
            else if (currentlySelectedLamp == 4)
            {
                FourthLamp.color = LampYellow;
                LampColours[3] = Color.yellow;
            }
            lampJustChanged = true;
            StartCoroutine(LampChangeWaitTime());
        }
        else if (RedButton.AtMaxLimit() && !lampJustChanged)
        {
            if (currentlySelectedLamp == 1)
            {
                FirstLamp.color = LampRed;
                LampColours[0] = Color.red;
            }
            else if (currentlySelectedLamp == 2)
            {
                SecondLamp.color = LampRed;
                LampColours[1] = Color.red;
            }
            else if (currentlySelectedLamp == 3)
            {
                ThirdLamp.color = LampRed;
                LampColours[2] = Color.red;
            }
            else if (currentlySelectedLamp == 4)
            {
                FourthLamp.color = LampRed;
                LampColours[3] = Color.red;
            }
            lampJustChanged = true;
            StartCoroutine(LampChangeWaitTime());
        }
        else if (BlueButton.AtMaxLimit() && !lampJustChanged)
        {
            if (currentlySelectedLamp == 1)
            {
                FirstLamp.color = LampBlue;
                LampColours[0] = Color.blue;
            }
            else if (currentlySelectedLamp == 2)
            {
                SecondLamp.color = LampBlue;
                LampColours[1] = Color.blue;
            }
            else if (currentlySelectedLamp == 3)
            {
                ThirdLamp.color = LampBlue;
                LampColours[2] = Color.blue;
            }
            else if (currentlySelectedLamp == 4)
            {
                FourthLamp.color = LampBlue;
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
