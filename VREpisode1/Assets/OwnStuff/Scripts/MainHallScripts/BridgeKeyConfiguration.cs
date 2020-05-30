using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables.PhysicsBased;
using TMPro;
using System;
using System.Text;
using UnityEngine.UI;
using VRTK;

public class BridgeKeyConfiguration : KeyboardMappings {

    public VRTK_SnapDropZone BridgeKeyActivator;
	
	protected override void Start ()
    {
        BridgeKeyActivator = GameObject.Find("BridgeKeyActivator").transform.Find("BridgeKeyActivatorSnapZone").GetComponent<VRTK_SnapDropZone>();

        //MONITOR SCREEN
        MonitorScreen = GameObject.Find("BridgeMonitorCanvas/Scrollparent/Viewport/MonitorScreen").GetComponent<TextMeshProUGUI>();

        bar = GameObject.Find("BridgeMonitorCanvas/Scrollparent/Scrollbar").GetComponent<Scrollbar>();

        //CONTROL VARIABLES
        buttonBeingPressed = false;

        characterCount = 0;

        addedCharacters = new StringBuilder();

        idle = false;

        //ALPHABET
        A = transform.Find("A_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        B = transform.Find("B_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        C = transform.Find("C_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        D = transform.Find("D_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        E = transform.Find("E_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        F = transform.Find("F_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        G = transform.Find("G_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        H = transform.Find("H_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        I = transform.Find("I_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        J = transform.Find("J_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        K = transform.Find("K_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        L = transform.Find("L_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        M = transform.Find("M_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        N = transform.Find("N_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        O = transform.Find("O_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        P = transform.Find("P_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        Q = transform.Find("Q_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        R = transform.Find("R_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        S = transform.Find("S_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        T = transform.Find("T_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        U = transform.Find("U_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        V = transform.Find("V_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        W = transform.Find("W_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        X = transform.Find("X_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        Y = transform.Find("Y_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        Z = transform.Find("Z_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        Å = transform.Find("Å_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        Ä = transform.Find("Ä_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        Ö = transform.Find("Ö_Container").GetComponentInChildren<VRTK_PhysicsPusher>();


        //CONTROL BUTTONS
        BackSpace = transform.Find("BACKSPACE_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        CapsLock = transform.Find("CAPSLOCK_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        Enter = transform.Find("ENTER_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        Space = transform.Find("SPACE_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        Delete = transform.Find("DELETE_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        Escape = transform.Find("ESC_Container").GetComponentInChildren<VRTK_PhysicsPusher>();

        Down = transform.Find("DOWN_Container").GetComponentInChildren<VRTK_PhysicsPusher>();
        Up = transform.Find("UP_Container").GetComponentInChildren<VRTK_PhysicsPusher>();

        //STARTLINE fixes text lining up correctly
        MonitorScreen.text = "BridgePC_Main@DESKTOP-BRIDGE EYE128 /e" + Environment.NewLine + "$" + " ";

    }

    protected override void CodeCheck()
    {
        if (BridgeKeyActivator.GetCurrentSnappedObject() != null)
        {
            if (addedCharacters.ToString() == "CLEARONE" && BridgeKeyActivator.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 0)
            {
                //starts the conveyorbelt
                MonitorScreen.text += " " + "KEY ACTIVATED WITH CLEARANCE LEVEL 1";
                BridgeKeyActivator.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel = 1;
                MonitorScreen.text += Environment.NewLine + "BridgePC_Main@DESKTOP-BRIDGE EYE128 /e" + Environment.NewLine + "$" + " ";
            }
            else if (addedCharacters.ToString() == "CLEARONE" && BridgeKeyActivator.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 0)
            {
                //starts the conveyorbelt
                MonitorScreen.text += " " + "INACTIVATE KEY BEFORE ASSIGNING A NEW CLEARANCE LEVEL";
                MonitorScreen.text += Environment.NewLine + "BridgePC_Main@DESKTOP-BRIDGE EYE128 /e" + Environment.NewLine + "$" + " ";
            }
            else if (addedCharacters.ToString() == "CLEARTWO" && BridgeKeyActivator.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 0)
            {
                //starts the conveyorbelt
                MonitorScreen.text += " " + "KEY ACTIVATED WITH CLEARANCE LEVEL 2";
                BridgeKeyActivator.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel = 2;
                MonitorScreen.text += Environment.NewLine + "BridgePC_Main@DESKTOP-BRIDGE EYE128 /e" + Environment.NewLine + "$" + " ";
            }
            else if (addedCharacters.ToString() == "CLEARTWO" && BridgeKeyActivator.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 0)
            {
                //starts the conveyorbelt
                MonitorScreen.text += " " + "INACTIVATE KEY BEFORE ASSIGNING A NEW CLEARANCE LEVEL";
                MonitorScreen.text += Environment.NewLine + "BridgePC_Main@DESKTOP-BRIDGE EYE128 /e" + Environment.NewLine + "$" + " ";
            }
            else if (addedCharacters.ToString() == "CLEARTHREE" && BridgeKeyActivator.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 0)
            {
                //starts the conveyorbelt
                MonitorScreen.text += " " + "KEY ACTIVATED WITH CLEARANCE LEVEL 3";
                BridgeKeyActivator.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel = 3;
                MonitorScreen.text += Environment.NewLine + "BridgePC_Main@DESKTOP-BRIDGE EYE128 /e" + Environment.NewLine + "$" + " ";
            }
            else if (addedCharacters.ToString() == "CLEARTHREE" && BridgeKeyActivator.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 0)
            {
                //starts the conveyorbelt
                MonitorScreen.text += " " + "INACTIVATE KEY BEFORE ASSIGNING A NEW CLEARANCE LEVEL";
                MonitorScreen.text += Environment.NewLine + "BridgePC_Main@DESKTOP-BRIDGE EYE128 /e" + Environment.NewLine + "$" + " ";
            }
            else if (addedCharacters.ToString() == "CLEAR" && BridgeKeyActivator.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel != 0)
            {
                //starts the conveyorbelt
                MonitorScreen.text += " " + "KEY DEACTIVATED";
                BridgeKeyActivator.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel = 0;
                MonitorScreen.text += Environment.NewLine + "BridgePC_Main@DESKTOP-BRIDGE EYE128 /e" + Environment.NewLine + "$" + " ";
            }
            else if (addedCharacters.ToString() == "CLEAR" && BridgeKeyActivator.GetCurrentSnappedObject().GetComponent<KeyType>().clearanceLevel == 0)
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
}
