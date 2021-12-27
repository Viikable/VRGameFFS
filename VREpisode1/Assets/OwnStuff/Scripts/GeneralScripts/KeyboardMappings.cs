using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

using TMPro;
using System;
using System.Text;
using UnityEngine.UI;

public class KeyboardMappings : MonoBehaviour {

    //Is the current monitor going to be active based on fusebox setting or not
    protected bool machineryActive;

    //MONITOR SCREEN
    protected TextMeshProUGUI MonitorScreen;

    protected Scrollbar bar;

    [Header("Control Variables")]
    [Tooltip("Indicates if any buttons are currently being pressed," +
    "this so that the monitor can go to sleep mode or do an idle animation when a certain time occurs without presses")]
    public bool buttonBeingPressed;

    [SerializeField]
    [Tooltip("Stores all the characters which are added to the current command, resetted and checked by pressing Enter")]
    public StringBuilder addedCharacters;

    [Tooltip("Indexes the characters in the addedCharacters StringBuilder so that the commands can be easily interperated no matter how much text on screen")]
    public int characterCount;

    [Tooltip("This tells whether the terminal is on idle mode or not, in idle mode the _ starts showing on and off")]
    public bool idle;

    [Tooltip("CAPS on or off")]  //commands are not case-sensitive currently, like in a real terminal
    public bool caps; 
 
    //ALPHABET
    protected Button A;
    protected Button B;
    protected Button C;
    protected Button D;
    protected Button E;
    protected Button F;
    protected Button G;
    protected Button H;
    protected Button I;
    protected Button J;
    protected Button K;
    protected Button L;
    protected Button M;
    protected Button N;
    protected Button O;
    protected Button P;
    protected Button Q;
    protected Button R;
    protected Button S;
    protected Button T;
    protected Button U;
    protected Button V;
    protected Button W;
    protected Button X;
    protected Button Y;
    protected Button Z;
    protected Button Å;
    protected Button Ä;
    protected Button Ö;


    //Special control buttons
    protected Button BackSpace;
    protected Button Enter;
    protected Button CapsLock;
    protected Button Tab;
    protected Button Space;
    protected Button Shift_Left;
    protected Button Shift_Right;
    protected Button Delete;
    protected Button Escape;

    // for scrolling the expanded command list
    protected Button Down;
    protected Button Up;


    protected virtual void Start ()
    {
        machineryActive = false;

        //MONITOR SCREEN
        MonitorScreen = GameObject.Find("MonitorCanvas/Scrollparent/Viewport/MonitorScreen").GetComponent<TextMeshProUGUI>();

        bar = GameObject.Find("MonitorCanvas/Scrollparent/Scrollbar").GetComponent<Scrollbar>();

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
        MonitorScreen.text = "MelterPC_1@DESKTOP-MELT EYE128 /e" + Environment.NewLine + "$" + " ";
    }
	
	
	protected virtual void Update ()
    {
        //if machinery is off then shows no text and doesn't react to buttonpresses
        if (machineryActive)
        {
            if (MonitorScreen.text == "")
            {
                MonitorScreen.text = "MelterPC_1@DESKTOP-MELT EYE128 /e" + Environment.NewLine + "$" + " ";
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

    protected void MonitorButtonPressCheck()
    {
        if (!buttonBeingPressed)
        {
            if (A.isPressedDown )
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
            else if (B.isPressedDown )
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
            else if (C.isPressedDown )
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
            else if (D.isPressedDown )
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
            else if (E.isPressedDown )
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
            else if (F.isPressedDown )
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
            else if (G.isPressedDown )
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
            else if (H.isPressedDown )
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
            else if (I.isPressedDown )
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
            else if (J.isPressedDown )
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
            else if (K.isPressedDown )
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
            else if (L.isPressedDown )
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
            else if (M.isPressedDown )
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
            else if (N.isPressedDown )
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
            else if (O.isPressedDown )
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
            else if (P.isPressedDown )
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
            else if (Q.isPressedDown )
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
            else if (R.isPressedDown )
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
            else if (S.isPressedDown )
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
            else if (T.isPressedDown )
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
            else if (U.isPressedDown )
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
            else if (V.isPressedDown )
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
            else if (W.isPressedDown )
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
            else if (X.isPressedDown )
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
            else if (Y.isPressedDown )
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
            else if (Z.isPressedDown )
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
            else if (Å.isPressedDown )
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
            else if (Ä.isPressedDown )
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
            else if (Ö.isPressedDown )
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
            else if ((BackSpace.isPressedDown || Delete.isPressedDown) )
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
            else if (Space.isPressedDown )
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
            else if (CapsLock.isPressedDown )
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
                if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
                {
                    MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
                }
                StartCoroutine("IdleCheck");
            }
            else if (Enter.isPressedDown )
            {
                StopCoroutine("IdleCheck");
                StopCoroutine("IdleAnimation");
                buttonBeingPressed = true;
                if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
                {
                    MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
                }
                MonitorScreen.text += Environment.NewLine;
                CodeCheck();
                StartCoroutine("BarDown");
                StartCoroutine("IdleCheck");
            }
            else if (Escape.isPressedDown )
            {
                StopAllCoroutines();
                buttonBeingPressed = true;
                if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
                {
                    MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
                }
                MonitorScreen.text = "MelterPC_1@DESKTOP-MELT EYE128 /e" + Environment.NewLine + "$" + " ".ToString();
                StartCoroutine("IdleCheck");
            }
            else if (Down.isPressedDown )
            {
                StopAllCoroutines();
                buttonBeingPressed = true;
                if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
                {
                    MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
                }
                bar.value -= 0.1f;
                StartCoroutine("IdleCheck");
            }
            else if (Up.isPressedDown )
            {
                StopAllCoroutines();
                buttonBeingPressed = true;
                if (MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
                {
                    MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);
                }
                bar.value += 0.1f;
                StartCoroutine("IdleCheck");
            }
        }
    }

    protected virtual void CodeCheck()
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
    protected IEnumerator IdleAnimation()
    {
        while (!buttonBeingPressed && idle)
        {
            MonitorScreen.text += "_";
            
            yield return new WaitForSecondsRealtime(0.35f);

            if (!buttonBeingPressed && MonitorScreen.text.Length != 0 && MonitorScreen.text.ToCharArray()[MonitorScreen.text.Length - 1] == "_".ToCharArray()[0])
            {               
                MonitorScreen.text = MonitorScreen.text.Remove(MonitorScreen.text.Length - 1);              
            }
            yield return new WaitForSecondsRealtime(0.35f);           
        }   
    }
    //waits for 0.25 seconds to see if another button is pressed which stops the coroutine from turning buttonBeingPressed to false, thus enabling "IdleAnimation"
    protected IEnumerator IdleCheck()
    {
        yield return new WaitForSecondsRealtime(0.35f);
        buttonBeingPressed = false;
        idle = false;         //actually makes idle true as there is a clause in update for that, looks slightly confusing have to admit
    }  
    protected IEnumerator BarDown()
    {
        yield return new WaitForEndOfFrame();
        bar.value = 0f;
    }

    public void ActivateMonitor()
    {
        machineryActive = true;
    }

    public void DeactivateMonitor()
    {
        machineryActive = false;
    }
}
