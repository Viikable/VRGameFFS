using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using System;
using System.Text;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class BridgeKeyConfiguration : KeyboardMappings {

    public XRSocketInteractor BridgeKeyActivator;
	
	protected override void Start ()
    {
        BridgeKeyActivator = GameObject.Find("BridgeKeyActivator").transform.Find("BridgeKeyActivatorSnapZone").GetComponent<XRSocketInteractor>();

        machineryActive = false;

        //MONITOR SCREEN
        MonitorScreen = GameObject.Find("BridgeMonitorCanvas/Scrollparent/Viewport/MonitorScreen").GetComponent<TextMeshProUGUI>();

        bar = GameObject.Find("BridgeMonitorCanvas/Scrollparent/Scrollbar").GetComponent<Scrollbar>();

        //CONTROL VARIABLES
        buttonBeingPressed = false;

        characterCount = 0;

        addedCharacters = new StringBuilder();

        idle = false;

        //ALPHABET
        A = transform.Find("A_Container").GetComponentInChildren<Button>();
        B = transform.Find("B_Container").GetComponentInChildren<Button>();
        C = transform.Find("C_Container").GetComponentInChildren<Button>();
        D = transform.Find("D_Container").GetComponentInChildren<Button>();
        E = transform.Find("E_Container").GetComponentInChildren<Button>();
        F = transform.Find("F_Container").GetComponentInChildren<Button>();
        G = transform.Find("G_Container").GetComponentInChildren<Button>();
        H = transform.Find("H_Container").GetComponentInChildren<Button>();
        I = transform.Find("I_Container").GetComponentInChildren<Button>();
        J = transform.Find("J_Container").GetComponentInChildren<Button>();
        K = transform.Find("K_Container").GetComponentInChildren<Button>();
        L = transform.Find("L_Container").GetComponentInChildren<Button>();
        M = transform.Find("M_Container").GetComponentInChildren<Button>();
        N = transform.Find("N_Container").GetComponentInChildren<Button>();
        O = transform.Find("O_Container").GetComponentInChildren<Button>();
        P = transform.Find("P_Container").GetComponentInChildren<Button>();
        Q = transform.Find("Q_Container").GetComponentInChildren<Button>();
        R = transform.Find("R_Container").GetComponentInChildren<Button>();
        S = transform.Find("S_Container").GetComponentInChildren<Button>();
        T = transform.Find("T_Container").GetComponentInChildren<Button>();
        U = transform.Find("U_Container").GetComponentInChildren<Button>();
        V = transform.Find("V_Container").GetComponentInChildren<Button>();
        W = transform.Find("W_Container").GetComponentInChildren<Button>();
        X = transform.Find("X_Container").GetComponentInChildren<Button>();
        Y = transform.Find("Y_Container").GetComponentInChildren<Button>();
        Z = transform.Find("Z_Container").GetComponentInChildren<Button>();
        Å = transform.Find("Å_Container").GetComponentInChildren<Button>();
        Ä = transform.Find("Ä_Container").GetComponentInChildren<Button>();
        Ö = transform.Find("Ö_Container").GetComponentInChildren<Button>();


        //CONTROL BUTTONS
        BackSpace = transform.Find("BACKSPACE_Container").GetComponentInChildren<Button>();
        CapsLock = transform.Find("CAPSLOCK_Container").GetComponentInChildren<Button>();
        Enter = transform.Find("ENTER_Container").GetComponentInChildren<Button>();
        Space = transform.Find("SPACE_Container").GetComponentInChildren<Button>();
        Delete = transform.Find("DELETE_Container").GetComponentInChildren<Button>();
        Escape = transform.Find("ESC_Container").GetComponentInChildren<Button>();

        Down = transform.Find("DOWN_Container").GetComponentInChildren<Button>();
        Up = transform.Find("UP_Container").GetComponentInChildren<Button>();

        //STARTLINE fixes text lining up correctly
        MonitorScreen.text = "BridgePC_Main@DESKTOP-BRIDGE EYE128 /e" + Environment.NewLine + "$" + " ";
    }

    protected override void CodeCheck()
    {
        if (BridgeKeyActivator.firstInteractableSelected != null)
        {
            if (addedCharacters.ToString() == "CLEARONE" && BridgeKeyActivator.firstInteractableSelected.transform.gameObject.GetComponent<KeyType>().clearanceLevel == 0)
            {
                //starts the conveyorbelt
                MonitorScreen.text += " " + "KEY ACTIVATED WITH CLEARANCE LEVEL 1";
                BridgeKeyActivator.firstInteractableSelected.transform.gameObject.GetComponent<KeyType>().clearanceLevel = 1;
                MonitorScreen.text += Environment.NewLine + "BridgePC_Main@DESKTOP-BRIDGE EYE128 /e" + Environment.NewLine + "$" + " ";
            }
            else if (addedCharacters.ToString() == "CLEARONE" && BridgeKeyActivator.firstInteractableSelected.transform.gameObject.GetComponent<KeyType>().clearanceLevel != 0)
            {
                //starts the conveyorbelt
                MonitorScreen.text += " " + "INACTIVATE KEY BEFORE ASSIGNING A NEW CLEARANCE LEVEL";
                MonitorScreen.text += Environment.NewLine + "BridgePC_Main@DESKTOP-BRIDGE EYE128 /e" + Environment.NewLine + "$" + " ";
            }
            else if (addedCharacters.ToString() == "CLEARTWO" && BridgeKeyActivator.firstInteractableSelected.transform.gameObject.GetComponent<KeyType>().clearanceLevel == 0)
            {
                //starts the conveyorbelt
                MonitorScreen.text += " " + "KEY ACTIVATED WITH CLEARANCE LEVEL 2";
                BridgeKeyActivator.firstInteractableSelected.transform.gameObject.GetComponent<KeyType>().clearanceLevel = 2;
                MonitorScreen.text += Environment.NewLine + "BridgePC_Main@DESKTOP-BRIDGE EYE128 /e" + Environment.NewLine + "$" + " ";
            }
            else if (addedCharacters.ToString() == "CLEARTWO" && BridgeKeyActivator.firstInteractableSelected.transform.gameObject.GetComponent<KeyType>().clearanceLevel != 0)
            {
                //starts the conveyorbelt
                MonitorScreen.text += " " + "INACTIVATE KEY BEFORE ASSIGNING A NEW CLEARANCE LEVEL";
                MonitorScreen.text += Environment.NewLine + "BridgePC_Main@DESKTOP-BRIDGE EYE128 /e" + Environment.NewLine + "$" + " ";
            }
            else if (addedCharacters.ToString() == "CLEARTHREE" && BridgeKeyActivator.firstInteractableSelected.transform.gameObject.GetComponent<KeyType>().clearanceLevel == 0)
            {
                //starts the conveyorbelt
                MonitorScreen.text += " " + "KEY ACTIVATED WITH CLEARANCE LEVEL 3";
                BridgeKeyActivator.firstInteractableSelected.transform.gameObject.GetComponent<KeyType>().clearanceLevel = 3;
                MonitorScreen.text += Environment.NewLine + "BridgePC_Main@DESKTOP-BRIDGE EYE128 /e" + Environment.NewLine + "$" + " ";
            }
            else if (addedCharacters.ToString() == "CLEARTHREE" && BridgeKeyActivator.firstInteractableSelected.transform.gameObject.GetComponent<KeyType>().clearanceLevel != 0)
            {
                //starts the conveyorbelt
                MonitorScreen.text += " " + "INACTIVATE KEY BEFORE ASSIGNING A NEW CLEARANCE LEVEL";
                MonitorScreen.text += Environment.NewLine + "BridgePC_Main@DESKTOP-BRIDGE EYE128 /e" + Environment.NewLine + "$" + " ";
            }
            else if (addedCharacters.ToString() == "CLEAR" && BridgeKeyActivator.firstInteractableSelected.transform.gameObject.GetComponent<KeyType>().clearanceLevel != 0)
            {
                //starts the conveyorbelt
                MonitorScreen.text += " " + "KEY DEACTIVATED";
                BridgeKeyActivator.firstInteractableSelected.transform.gameObject.GetComponent<KeyType>().clearanceLevel = 0;
                MonitorScreen.text += Environment.NewLine + "BridgePC_Main@DESKTOP-BRIDGE EYE128 /e" + Environment.NewLine + "$" + " ";
            }
            else if (addedCharacters.ToString() == "CLEAR" && BridgeKeyActivator.firstInteractableSelected.transform.gameObject.GetComponent<KeyType>().clearanceLevel == 0)
            {
                //starts the conveyorbelt
                MonitorScreen.text += " " + "KEY ALREADY INACTIVE";
                MonitorScreen.text += Environment.NewLine + "BridgePC_Main@DESKTOP-BRIDGE EYE128 /e" + Environment.NewLine + "$" + " ";
            }
            else
            {
                MonitorScreen.text += " " + "COMMAND NOT FOUND";
                MonitorScreen.text += Environment.NewLine + "BridgePC_Main@DESKTOP-BRIDGE EYE128 /e" + Environment.NewLine + "$" + " ";
            }
            characterCount = 0;
            //clears the stringbuilder
            addedCharacters.Clear();
        }
        else
        {
            MonitorScreen.text += " " + "PLEASE INSERT KEY";
            MonitorScreen.text += Environment.NewLine + "BridgePC_Main@DESKTOP-BRIDGE EYE128 /e" + Environment.NewLine + "$" + " ";
        }
    }

    protected override void Update()
    {
        if (machineryActive)
        {
            if (MonitorScreen.text == "")
            {
                MonitorScreen.text = "BridgePC_Main@DESKTOP-BRIDGE EYE128 /e" + Environment.NewLine + "$" + " ";
            }
            MonitorButtonPressCheck();
            if (!buttonBeingPressed && !idle)
            {
                idle = true;
                StartCoroutine("IdleAnimation");             
            }
        }
        else
        {
            StopAllCoroutines();
            MonitorScreen.text = "";
        }
    }

    //public new static void ActivateMonitor()
    //{
    //    machineryActive = true;
    //}

    //public new static void DeactivateMonitor()
    //{
    //    machineryActive = false;
    //}
}
