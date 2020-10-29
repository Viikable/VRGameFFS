using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables.PhysicsBased;

public class OxygenPanel : MonoBehaviour {

    //This script is attached to the oxygen panel which contains the buttons for switching the lamp colours for the bonsai

    private OxygenControl OxygenController;

    [Header("Oxygen lamp buttons")]

    public VRTK_PhysicsPusher GreenButton;      //MF
    public VRTK_PhysicsPusher MagentaButton;  //Janitor
    public VRTK_PhysicsPusher BlackButton;  // Corridor
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

        GreenButton = GameObject.Find("OxygenGreenButton").GetComponentInChildren<VRTK_PhysicsPusher>();
        MagentaButton = GameObject.Find("OxygenMagentaButton").GetComponentInChildren<VRTK_PhysicsPusher>();
        BlackButton = GameObject.Find("OxygenBlackButton").GetComponentInChildren<VRTK_PhysicsPusher>();
        YellowButton = GameObject.Find("OxygenYellowButton").GetComponentInChildren<VRTK_PhysicsPusher>();
        RedButton = GameObject.Find("OxygenRedButton").GetComponentInChildren<VRTK_PhysicsPusher>();
        BlueButton = GameObject.Find("OxygenBlueButton").GetComponentInChildren<VRTK_PhysicsPusher>();

        ClockWiseButton = GameObject.Find("OxygenClockWiseButton").GetComponentInChildren<VRTK_PhysicsPusher>();
        CounterClockWiseButton = GameObject.Find("OxygenCounterClockWiseButton").GetComponentInChildren<VRTK_PhysicsPusher>();

        LampColours = new Color[4];

        currentlySelectedLamp = 1;

        //oxygen lamps and colours

        FirstLamp = GameObject.Find("FirstLamp").GetComponent<Light>();
        SecondLamp = GameObject.Find("SecondLamp").GetComponent<Light>();
        ThirdLamp = GameObject.Find("ThirdLamp").GetComponent<Light>();
        FourthLamp = GameObject.Find("FourthLamp").GetComponent<Light>();

        LampGreen = GameObject.Find("LampGreen").GetComponent<Material>().color;
        LampMagenta = GameObject.Find("LampMagenta").GetComponent<Material>().color;
        LampBlack = GameObject.Find("LampBlack").GetComponent<Material>().color;
        LampYellow = GameObject.Find("LampYellow").GetComponent<Material>().color;
        LampRed = GameObject.Find("LampRed").GetComponent<Material>().color;
        LampBlue = GameObject.Find("LampBlue").GetComponent<Material>().color;

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
            StartCoroutine(LampChangeWaitTime());
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
        else if (BlackButton.AtMaxLimit() && !lampJustChanged)
        {
            if (currentlySelectedLamp == 1)
            {
                FirstLamp.color = LampBlack;
                LampColours[0] = Color.black;
            }
            else if (currentlySelectedLamp == 2)
            {
                SecondLamp.color = LampBlack;
                LampColours[1] = Color.black;
            }
            else if (currentlySelectedLamp == 3)
            {
                ThirdLamp.color = LampBlack;
                LampColours[2] = Color.black;
            }
            else if (currentlySelectedLamp == 4)
            {
                FourthLamp.color = LampBlack;
                LampColours[3] = Color.black;
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
