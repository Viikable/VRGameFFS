using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables.PhysicsBased;
using TMPro;
using System;
using System.Text;

public class KeyboardMappings : MonoBehaviour {

    //MONITOR SCREEN
    TextMeshPro MonitorScreen;

    //CONTROL VARIABLES
    [Tooltip("Indicates if any buttons are currently being pressed," +
    " this so that the monitor can go to sleep mode or do an idle animation when a certain time occurs without presses")]
    public bool buttonBeingPressed;

    [SerializeField]
    [Tooltip("Stores all the characters which are added to the current command, resetted and checked by pressing Enter")]
    public StringBuilder addedCharacters;

    [Tooltip("Indexes the characters in the added Characters array so that the commands can be easily interperated no matter how much text on screen")]
    public int characterCount;

    [Tooltip("This tells whether the terminal is on idle mode or not, in idle mode the _ starts showing on and off")]
    public bool idle;

    [Tooltip("CAPS on or off")]  //commands are not case-sensitive currently, like in a real terminal
    public bool caps; 
 
    //ALPHABET
    VRTK_PhysicsPusher A;
    VRTK_PhysicsPusher B;
    VRTK_PhysicsPusher C;
    VRTK_PhysicsPusher D;
    VRTK_PhysicsPusher E;
    VRTK_PhysicsPusher F;
    VRTK_PhysicsPusher G;
    VRTK_PhysicsPusher H;
    VRTK_PhysicsPusher I;
    VRTK_PhysicsPusher J;
    VRTK_PhysicsPusher K;
    VRTK_PhysicsPusher L;
    VRTK_PhysicsPusher M;
    VRTK_PhysicsPusher N;
    VRTK_PhysicsPusher O;
    VRTK_PhysicsPusher P;
    VRTK_PhysicsPusher Q;
    VRTK_PhysicsPusher R;
    VRTK_PhysicsPusher S;
    VRTK_PhysicsPusher T;
    VRTK_PhysicsPusher U;
    VRTK_PhysicsPusher V;
    VRTK_PhysicsPusher W;
    VRTK_PhysicsPusher X;
    VRTK_PhysicsPusher Y;
    VRTK_PhysicsPusher Z;
    VRTK_PhysicsPusher Å;
    VRTK_PhysicsPusher Ä;
    VRTK_PhysicsPusher Ö;


    //Special control buttons
    VRTK_PhysicsPusher BackSpace;
    VRTK_PhysicsPusher Enter;
    VRTK_PhysicsPusher CapsLock;
    VRTK_PhysicsPusher Tab;
    VRTK_PhysicsPusher Space;
    VRTK_PhysicsPusher Shift_Left;
    VRTK_PhysicsPusher Shift_Right;
    VRTK_PhysicsPusher Delete;


    void Start ()
    {
        //MONITOR SCREEN
        MonitorScreen = transform.Find("MonitorScreen").GetComponent<TextMeshPro>();


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

        //STARTLINE fixes text lining up correctly
        MonitorScreen.text += Environment.NewLine + "MelterPC_1@DESKTOP-MELT EYE128 /e" + Environment.NewLine + "$" + " ";
    }
	
	
	void Update ()
    {      
        MonitorButtonPressCheck();        
        if (!buttonBeingPressed && !idle)
        {
            idle = true;
            StartCoroutine("IdleAnimation");
        }
        Debug.Log(addedCharacters.ToString());
	}

    private void MonitorButtonPressCheck()
    {
        if (A.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            //This takes the last char and compares if it is _ by changing text and _ to CharArray first
            if (MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "A";
            }
            else
            {
                MonitorScreen.text += "a";
            }
            addedCharacters.Append("A");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        if (B.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "B";
            }
            else
            {
                MonitorScreen.text += "b";
            }
            addedCharacters.Append("B");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        if (C.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "C";
            }
            else
            {
                MonitorScreen.text += "c";
            }
            addedCharacters.Append("C");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        if (D.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "D";
            }
            else
            {
                MonitorScreen.text += "d";
            }
            addedCharacters.Append("D");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        if (E.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "E";
            }
            else
            {
                MonitorScreen.text += "e";
            }
            addedCharacters.Append("E");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        if (F.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "F";
            }
            else
            {
                MonitorScreen.text += "f";
            }
            addedCharacters.Append("F");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        if (G.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "G";
            }
            else
            {
                MonitorScreen.text += "g";
            }
            addedCharacters.Append("G");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        if (H.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "H";
            }
            else
            {
                MonitorScreen.text += "h";
            }
            addedCharacters.Append("H");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        if (I.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "I";
            }
            else
            {
                MonitorScreen.text += "i";
            }
            addedCharacters.Append("I");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        if (J.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "J";
            }
            else
            {
                MonitorScreen.text += "j";
            }
            addedCharacters.Append("J");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        if (K.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "K";
            }
            else
            {
                MonitorScreen.text += "k";
            }
            addedCharacters.Append("K");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        if (L.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "L";
            }
            else
            {
                MonitorScreen.text += "l";
            }
            addedCharacters.Append("L");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        if (M.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "M";
            }
            else
            {
                MonitorScreen.text += "m";
            }
            addedCharacters.Append("M");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        if (N.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "N";
            }
            else
            {
                MonitorScreen.text += "n";
            }
            addedCharacters.Append("N");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        if (O.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "O";
            }
            else
            {
                MonitorScreen.text += "o";
            }
            addedCharacters.Append("O");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        if (P.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "P";
            }
            else
            {
                MonitorScreen.text += "p";
            }
            addedCharacters.Append("P");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        if (Q.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "Q";
            }
            else
            {
                MonitorScreen.text += "q";
            }
            addedCharacters.Append("Q");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        if (R.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "R";
            }
            else
            {
                MonitorScreen.text += "r";
            }
            addedCharacters.Append("R");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        if (S.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "S";
            }
            else
            {
                MonitorScreen.text += "s";
            }
            addedCharacters.Append("S");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        if (T.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "T";
            }
            else
            {
                MonitorScreen.text += "t";
            }
            addedCharacters.Append("T");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        if (U.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "U";
            }
            else
            {
                MonitorScreen.text += "u";
            }
            addedCharacters.Append("U");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        if (V.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "V";
            }
            else
            {
                MonitorScreen.text += "v";
            }
            addedCharacters.Append("V");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        if (W.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "W";
            }
            else
            {
                MonitorScreen.text += "w";
            }
            addedCharacters.Append("W");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        if (X.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "X";
            }
            else
            {
                MonitorScreen.text += "x";
            }
            addedCharacters.Append("X");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        if (Y.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "Y";
            }
            else
            {
                MonitorScreen.text += "y";
            }
            addedCharacters.Append("Y");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        if (Z.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "Z";
            }
            else
            {
                MonitorScreen.text += "z";
            }
            addedCharacters.Append("Z");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        if (Å.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "Å";
            }
            else
            {
                MonitorScreen.text += "å";
            }
            addedCharacters.Append("Å");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        if (Ä.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "Ä";
            }
            else
            {
                MonitorScreen.text += "ä";
            }
            addedCharacters.Append("Ä");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        if (Ö.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            if (caps)
            {
                MonitorScreen.text += "Ö";
            }
            else
            {
                MonitorScreen.text += "ö";
            }
            addedCharacters.Append("Ö");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        //Special control buttons
        if ((BackSpace.AtMaxLimit() || Delete.AtMaxLimit()) && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            //removes the last character, but keeps a space between the start and § 
            if (MonitorScreen.text.Length != 0 && addedCharacters.Length > 0)
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }
            //removes the last character and shortens characterCount to match
            if (addedCharacters.Length > 0)
            {
            addedCharacters.Remove(addedCharacters.Length - 1, 1);
            characterCount--;
            }
            StartCoroutine("IdleCheck");
        }
        if (Space.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }

            MonitorScreen.text += " ";
            addedCharacters.Append(" ");
            characterCount++;
            StartCoroutine("IdleCheck");
        }
        if (CapsLock.AtMaxLimit() && !buttonBeingPressed)
        {
            //changes keys to capital or not
            if (caps)
            {
                caps = false;
            }
            else
            {
                caps = true;
            }
            buttonBeingPressed = true;
            StopAllCoroutines();            
            StartCoroutine("IdleCheck");
        }
        if (Enter.AtMaxLimit() && !buttonBeingPressed)
        {
            StopAllCoroutines();
            buttonBeingPressed = true;
            if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
            }                     
            MonitorScreen.text += Environment.NewLine;
            CodeCheck();
            StartCoroutine("IdleCheck");
        }
    }

    private void CodeCheck()
    {
        //no need to worry about CAPS as the characters are stored only as upper keys
        if (addedCharacters.ToString() == "CONSTART")
        {
            //starts the conveyorbelt
            MonitorScreen.text += " " + "CONVEYOR BELT STARTING..";
            MonitorScreen.text += Environment.NewLine + "MelterPC_1@DESKTOP-MELT EYE128 /e" + Environment.NewLine + "$" + " ";
        }
        else
        {
            MonitorScreen.text += " " + "COMMAND NOT FOUND";
            MonitorScreen.text += Environment.NewLine + "MelterPC_1@DESKTOP-MELT EYE128 /e" + Environment.NewLine + "$" + " ";
        }
        characterCount = 0;
        //clears the stringbuilder
        addedCharacters.Clear();       
    }

    //creates a line which appears and disappears like waiting for more text
    IEnumerator IdleAnimation()
    {
        while (!buttonBeingPressed && idle)
        {
            MonitorScreen.text += "_";
            Debug.Log("addedline");
            yield return new WaitForSecondsRealtime(0.35f);
            if (!buttonBeingPressed && MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {
                Debug.Log("removedline");
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);              
            }
            yield return new WaitForSecondsRealtime(0.35f);           
        }   
    }
    //waits for 0.25 seconds to see if another button is pressed which stops the coroutine from turning buttonBeingPressed to false, thus enabling "IdleAnimation"
    IEnumerator IdleCheck()
    {
        yield return new WaitForSecondsRealtime(0.25f);
        buttonBeingPressed = false;
        idle = false;
    }   
}
